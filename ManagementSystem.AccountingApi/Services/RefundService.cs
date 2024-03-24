using Dapper;
using ManagementSystem.AccountingApi.Data;
using ManagementSystem.AccountingApi.Utility;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models.Enum;
using Microsoft.Data.SqlClient;

namespace ManagementSystem.AccountingApi.Services;

public class RefundService : IRefundService
{
    private IConfiguration _configuration;
    private AccountingDbContext _context;
    private IInventoryVoucherService _inventoryVoucherService;

    public RefundService(IConfiguration configuration, AccountingDbContext context, IInventoryVoucherService inventoryVoucherService)
    {
        _configuration = configuration;
        _context = context;
        _inventoryVoucherService = inventoryVoucherService;
    }

    public async Task CreateRefundVoucher(BillRefundRequestDto model)
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
        // If exchange product > 0
        foreach(var item in model.ExchangedProduct)
        {
            UpdateProductStorage(item.ProductId, -item.Quantity, model.UserId, model.BranchId.Value);

            // Insert to model
            _context.ExchangeProducts.Add(new ExchangeProduct()
            {
                ExchangeItemVoucherId = exchangeItem.Id,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = item.Price,
                UnitId = item.UnitId

            });

        }
        // If Return Product > 0
        foreach(var item in model.ReturnedProduct)
        {
            UpdateProductStorage(item.ProductId, item.Quantity, model.UserId, model.BranchId.Value);

            _context.ReturnProducts.Add(new ReturnProduct()
            {
                ExchangeItemVoucherId = exchangeItem.Id,
                ProductId = item.ProductId,
                Action = item.Action == "DOIMOI" ? RefundAction.DOIMOI : RefundAction.HOANTIEN,
                Quantity = item.Quantity,
                Price = item.Price,
                ReasonRef = item.Reason == "HU" ? RefundReason.HU : RefundReason.DOI,
            });
        }

        // Tạo phiếu chi
        if (model.TotalDeductibleAmount < 0)
        {
            var branch = await GetBranch(model.BranchId.Value);

            var paymentVoucher = new PaymentVoucher();
            paymentVoucher.BranchId = model.BranchId;
            paymentVoucher.BranchCode = branch.BranchCode;
            paymentVoucher.BranchName = branch.BranchName;
            paymentVoucher.ShiftId = model.ShiftId;
            paymentVoucher.UserId = model.UserId;
            paymentVoucher.CreditAccount = "0";
            paymentVoucher.DebitAccount = "0";
            paymentVoucher.Description = string.Format("Đổi trả hàng cho phiếu {0}", exchangeItem.Id);
            paymentVoucher.ExchangeRate = 0;
            paymentVoucher.Reason = "";
            paymentVoucher.ReceiverName = model.CustomerName;
            paymentVoucher.TotalMoneyVND = model.TotalDeductibleAmount * -1;
            paymentVoucher.NTMoney = 0;

            _context.PaymentVouchers.Add(new PaymentVoucher());

            _context.Legers.Add(new Leger()
            {
                CustomerId = null,
                TransactionDate = paymentVoucher.TransactionDate,
                DoccumentNumber = paymentVoucher.DocumentNumber,
                CreditAccount = "0",
                DepositAccount = "0",
                DoccumentType = AccountingConstant.PaymentVoucherType,
                BillId = 0,
                Amount = model.TotalDeductibleAmount * -1,
                UserId = model.UserId,
                StorageId = model.BranchId,
            });

            _context.SaveChanges();
        }
    }

    #region Methods Handle
    private async Task UpdateProductStorage(int productId, float quantity, int userId, int branchId)
    {
        string  storateConnection = string.Format(_configuration.GetSection("ConnectionStrings:StoragesDbConnStr").Value.ToString(), SD.StorageDbName);
        using(var connection = new SqlConnection(storateConnection))
        {
            string query = string.Format(@"
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
    }

    private async Task<Branch> GetBranch(int branchId)
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
    private void HandleExchangeProduct(int exchangeItemId, BillRefundRequestDto model)
    {
        if (model.ExchangedProduct.Count > 0)
        {
            var listItem = new List<InventoryVoucherDetailDto>();
            foreach (var item in model.ExchangedProduct)
            {
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
        }
    }
    #endregion
}
