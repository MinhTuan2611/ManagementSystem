using Dapper;
using ManagementSystem.AccountingApi.Data;
using ManagementSystem.AccountingApi.Utility;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models.Enum;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.AccountingApi.Services;

public class RefundService : IRefundService
{
    private IConfiguration _configuration;
    private AccountingDbContext _context;
    private IInventoryVoucherService _inventoryVoucherService;
    private IReceiptService _receiptService;
    private IPaymentVoucherService _paymentVoucherService;

    public RefundService(IConfiguration configuration, AccountingDbContext context
        , IInventoryVoucherService inventoryVoucherService, IReceiptService receiptService
        , IPaymentVoucherService paymentVoucherService)
    {
        _configuration = configuration;
        _context = context;
        _inventoryVoucherService = inventoryVoucherService;
        _receiptService = receiptService;
        _paymentVoucherService = paymentVoucherService;
    }

    public async Task<bool> CreateRefundVoucher(BillRefundRequestDto model)
    {
        try
        {
            // Create Phieu tra hang
            var exchangeItem = new ExchangeItemVoucher()
            {
                UserId = model.UserId,
                CustomerId = model.CustomerId,
                RefundAmount = model.TotalDeductibleAmount,
                TotalExchangeProduct = model.ExchangedProduct.Count(),
                TotalReturnProduct = model.ReturnedProduct.Count(),
                BranchId = model.BranchId
            };

            var exchangeResult = _context.ExchangeItemVouchers.Add(exchangeItem);
            _context.SaveChanges();

            // If exchange product > 0
            if (model.ExchangedProduct != null && model.ExchangedProduct.Count >0 )
            {
                HandleExchangeProduct(exchangeItem.Id, model);
            }
            // If Return Product > 0
            if (model.ReturnedProduct != null && model.ReturnedProduct.Count > 0)
            {
                HandleReturnProduct(exchangeItem.Id, model);
            }
            // Tạo phiếu chi
            await HandlePhieuThuChi(exchangeItem.Id, model);

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    #region Methods Handle
    private async Task UpdateProductStorage(int productId, float quantity, int userId, int branchId)
    {
        string storateConnection = string.Format(_configuration.GetSection("ConnectionStrings:StoragesDbConnStr").Value.ToString(), SD.StorageDbName);

        var storage = GetMainStorageByBranch(branchId);
        string query = string.Empty;

        var productStorages = GetProductStorare(storage.StorageId, productId);

        using (var connection = new SqlConnection(storateConnection))
        {
            if (productStorages == null)
            {
                query = string.Format(@"
                    INSERT INTO [dbo].[ProductStorages]
                           ([ProductId]
                           ,[StorageId]
                           ,[Quantity]
                           ,[CreateDate]
                           ,[CreateBy]
                           ,[ModifyDate]
                           ,[ModifyBy])
                     VALUES
                           ({0}
                           ,{1}
                           ,{2}
                           ,GETDATE()
                           ,{3}
                           ,GETDATE()
                           ,{3})
                    ", productId, storage.StorageId, quantity, userId);
            }
            else
            {
                query = string.Format(@"
                UPDATE ps
	                SET ps.Quantity = {0}
		                ,ModifyDate = GETDATE()
		                ,ModifyBy = {1}
                FROM dbo.ProductStorages ps
                JOIN dbo.Storages s on ps.StorageId = s.StorageId
                WHERE s.BranchId = {2}
		                AND ps.ProductId = {3}
            ", quantity, userId, branchId, productId);
            }

            try
            {
                var affectedRows = connection.Execute(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    private Branch GetBranch(int branchId)
    {
        string storateConnection = string.Format(_configuration.GetSection("ConnectionStrings:StoragesDbConnStr").Value.ToString(), SD.StorageDbName);
        var result = new Branch();
        using (var connection = new SqlConnection(storateConnection))
        {
            result = connection.Query<Branch>(@"
                SELECT *
                FROM Branches
                WHERE BranchId = 
            " + branchId).FirstOrDefault();
        }

        return result;
    }
    private async Task HandleExchangeProduct(int exchangeItemId, BillRefundRequestDto model)
    {
        try
        {
            var listItem = new List<InventoryVoucherDetailDto>();
            foreach (var item in model.ExchangedProduct)
            {
                UpdateProductStorage(item.ProductId, -item.Quantity, model.UserId, model.BranchId.Value);

                // Insert to model
                _context.ExchangeProducts.Add(new ExchangeProduct()
                {
                    ExchangeItemVoucherId = exchangeItemId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    UnitId = item.UnitId

                });

                var product = new InventoryVoucherDetailDto()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitId = item.UnitId,
                    TotalMoneyAfterTax = item.Quantity * item.Price
                };
                listItem.Add(product);
            }

            var InventoryModel = new NewInventoryVoucherDto()
            {
                BrandId = model.BranchId,
                CustomerId = model.CustomerId,
                CustomerName = model.CustomerName,
                UserId = model.UserId,
                Details = listItem
            };
            await _inventoryVoucherService.CreateInventoryVoucher(InventoryModel, true);

            _context.SaveChanges();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void HandleReturnProduct(int exchangeItemId, BillRefundRequestDto model)
    {
        try
        {
            foreach (var item in model.ReturnedProduct)
            {
                UpdateProductStorage(item.ProductId, item.Quantity, model.UserId, model.BranchId.Value);

                _context.ReturnProducts.Add(new ReturnProduct()
                {
                    ExchangeItemVoucherId = exchangeItemId,
                    ProductId = item.ProductId,
                    Action = item.Action == "DOIMOI" ? RefundAction.DOIMOI : RefundAction.HOANTIEN,
                    Quantity = item.Quantity,
                    Price = item.Price.Value,
                    ReasonRef = item.Reason == "HU" ? RefundReason.HU : RefundReason.DOI,
                });
            }

            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private async Task HandlePhieuThuChi(int exchangeItemId, BillRefundRequestDto model)
    {
        try
        {
            if (model.TotalDeductibleAmount < 0)
            {
                var branch = GetBranch(model.BranchId.Value);

                var paymentVoucher = new NewPaymentVoucherDto();
                paymentVoucher.BranchId = model.BranchId;
                paymentVoucher.BranchCode = branch.BranchCode;
                paymentVoucher.BranchName = branch.BranchName;
                paymentVoucher.ShiftId = model.ShiftId;
                paymentVoucher.UserId = model.UserId;
                paymentVoucher.CreditAccount = "0";
                paymentVoucher.DebitAccount = "0";
                paymentVoucher.Description = string.Format("Đổi trả hàng cho phiếu {0}", exchangeItemId);
                paymentVoucher.ExchangeRate = 0;
                paymentVoucher.Reason = "";
                paymentVoucher.ReceiverName = model.CustomerName;
                paymentVoucher.TotalMoneyVND = model.TotalDeductibleAmount * -1;
                paymentVoucher.NTMoney = 0;

                await _paymentVoucherService.CreatePaymentVoucher(paymentVoucher);

            }
            else if (model.TotalDeductibleAmount > 0)
            {
                var receiptModel = new NewReceiptRequestDto()
                {
                    CustomerId = model.CustomerId,
                    CustomerName = model.CustomerName,
                    ForReason = string.Format("Đổi trả hàng cho phiếu {0}", exchangeItemId),
                    TotalMoney = model.TotalDeductibleAmount,
                    UserId = model.UserId
                };
                await _receiptService.CreateReceipt(receiptModel);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private Storage GetMainStorageByBranch(int branchId)
    {
        string storateConnection = string.Format(_configuration.GetSection("ConnectionStrings:StoragesDbConnStr").Value.ToString(), SD.StorageDbName);
        Storage storage = new Storage();

        using (var connection = new SqlConnection(storateConnection))
        {
            string query = string.Format(@"
                SELECT TOP 1 *
                FROM Storages
                WHERE StorageCode NOT LIKE '%-%'
                AND BranchId = {0}
            ", branchId);

            storage = connection.Query<Storage>(query).FirstOrDefault();
        }

        return storage;
    }

    private ProductStorage GetProductStorare(int storageId, int productId)
    {
        string storateConnection = string.Format(_configuration.GetSection("ConnectionStrings:StoragesDbConnStr").Value.ToString(), SD.StorageDbName);
        ProductStorage productStorage = new ProductStorage();

        using (var connection = new SqlConnection( storateConnection))
        {
            string query = string.Format(@"
                SELECT TOP 1 *
                FROM ProductStorages
                WHERE StorageId = {0}
                AND  ProductId = {1}    
            ", storageId, productId);

            productStorage = connection.Query<ProductStorage>(query).FirstOrDefault();
        }

        return productStorage;
    }
    #endregion
}
