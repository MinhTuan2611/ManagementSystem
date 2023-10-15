﻿using ManagementSystem.AccountingApi.Data;
using ManagementSystem.Common;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.EntityFrameworkCore;


namespace ManagementSystem.AccountingApi.Services
{
    public class InventoryVoucherService : IInventoryVoucherService
    {
        private readonly AccountingDbContext _context;

        public InventoryVoucherService(AccountingDbContext context)
        {
            _context = context;
        }


        public async Task<InventoryVoucher> CreateInventoryVoucher(NewInventoryVoucherDto request)
        {
            try
            {
                var inventory = new InventoryVoucher();
                inventory.UserId = request.UserId;
                inventory.PurchasingRepresentive = request.PurchasingRepresentive;
                inventory.TransactionDate = DateTime.Now;
                inventory.ReasonFor = AccountingConstant.XBAReason;
                inventory.Note = request.Note;
                inventory.RepresentivePhone = "";
                inventory.CustomerId = request.CustomerId;
                inventory.StorageId = GetProductStorageDto(request.BrandId.Value, request.Details[0].ProductId).StorageId;

                _context.InventoryVouchers.Add(inventory);
                _context.SaveChanges();

                foreach (var detail in request.Details)
                {
                    var product = GetProductInformation(detail.ProductId);
                    var unit = GetUnitInformation(detail.UnitId);
                    var productStorage = GetProductStorageDto(request.BrandId.Value, detail.ProductId);

                    var item = new InventoryVoucherDetail();
                    item.DocummentNumber = inventory.DocummentNumber;
                    item.ProductId = detail.ProductId;
                    item.CreditAccount = product.CreditAccountId;
                    item.DebitAccount = product.DebitAccountId;
                    //item.PaymentDiscountAccount = detail.PaymentDiscountAccount;
                    //item.TaxAccount = detail.TaxAccount;
                    item.Quantity = detail.Quantity;
                    item.Price = product.PriceBeforeTax;
                    item.TotalMoneyBeforeTax = product.PriceBeforeTax * detail.Quantity;
                    item.DebitAccountMoney = detail.TotalMoneyAfterTax;
                    item.CreditAccountMoney = detail.TotalMoneyAfterTax;
                    //item.PaymentDiscountMoney = detail.PaymentDiscountMoney;
                    //item.TaxMoney = detail.TaxMoney;
                    item.TotalMoneyAfterTax = detail.TotalMoneyAfterTax;
                    item.Note = detail.Note;

                    _context.InventoryVoucherDetails.Add(item);

                    if (productStorage != null)
                    {
                        bool result = UpdateProductStorage(productStorage, detail.Quantity);

                        if (!result)
                            return null;
                    }
                }

                // Add activity logs
                _context.ActivityLog.Add(new ActivityLog()
                {
                    UserId = request.UserId,
                    Action = "Create Inventory Voucher: " + inventory.DocummentNumber.ToString(),
                    Source = "InventoryDeliveryVoucher",
                    DateModified = DateTime.Now,
                });
                await _context.SaveChangesAsync();

                return inventory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<InventoryVoucher> UpdateInventoryDeliveryVoucher(UpdateInventoryVoucherDto request)
        {
            try
            {
                var inventory = _context.InventoryVouchers.Include(x => x.Details)
                                                            .FirstOrDefault(x => x.DocummentNumber == request.DocummentNumber);
                if (inventory == null)
                    return null;

                inventory.UserId = request.UserId;
                inventory.PurchasingRepresentive = request.PurchasingRepresentive;
                inventory.RepresentivePhone = request.RepresentivePhone;
                inventory.ReasonFor = request.ReasonFor;
                inventory.Note = request.Note;
                inventory.CustomerId = request.CustomerId;

                _context.SaveChanges();

                _context.InventoryVoucherDetails.RemoveRange(inventory.Details);

                foreach (var detail in request.Details)
                {
                    var product = GetProductInformation(detail.ProductId);
                    var unit = GetUnitInformation(detail.UnitId);
                    var productStorage = GetProductStorageDto(request.BrandId.Value, detail.ProductId);

                    var item = new InventoryVoucherDetail();
                    item.DocummentNumber = inventory.DocummentNumber;
                    item.ProductId = detail.ProductId;
                    item.CreditAccount = product.CreditAccountId;
                    item.DebitAccount = product.DebitAccountId;
                    //item.PaymentDiscountAccount = detail.PaymentDiscountAccount;
                    //item.TaxAccount = detail.TaxAccount;
                    item.Quantity = detail.Quantity;
                    item.Price = product.PriceBeforeTax;
                    item.TotalMoneyBeforeTax = product.PriceBeforeTax * detail.Quantity;
                    item.DebitAccountMoney = detail.TotalMoneyAfterTax;
                    item.CreditAccountMoney = detail.TotalMoneyAfterTax;
                    //item.PaymentDiscountMoney = detail.PaymentDiscountMoney;
                    //item.TaxMoney = detail.TaxMoney;
                    item.TotalMoneyAfterTax = detail.TotalMoneyAfterTax;
                    item.Note = detail.Note;

                    _context.InventoryVoucherDetails.Add(item);

                    if (productStorage != null)
                    {
                        bool result = UpdateProductStorage(productStorage, detail.Quantity);

                        if (!result)
                            return null;
                    }
                }

                await _context.SaveChangesAsync();

                // Add activity logs
                _context.ActivityLog.Add(new ActivityLog()
                {
                    UserId = request.UserId,
                    Action = "Update Inventory Voucher: " + inventory.DocummentNumber.ToString(),
                    Source = "InventoryDeliveryVoucher",
                    DateModified = DateTime.Now,
                });
                await _context.SaveChangesAsync();

                return inventory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<InventoryVoucherDetailResponseDto>> GetInventoryVoucherDetail(int documentNumber)
        {
            string query = string.Format(@"
                SELECT p.ProductId
		                ,p.ProductName
		                ,p.ProductCode
						,p.DefaultPurchasePrice
						,p.BarCode
						,p.Tax
		                ,u.UnitName
		                ,p.Price
		                ,details.Quantity
		                ,details.DebitAccount
		                ,details.CreditAccount
		                ,details.PaymentDiscountAccount
		                ,details.TaxAccount
		                ,details.TotalMoneyBeforeTax
		                ,details.DebitAccountMoney
		                ,details.CreditAccountMoney
		                ,details.PaymentDiscountMoney
		                ,details.TotalMoneyAfterTax
		                ,details.Note
                        ,details.TaxMoney
                FROM InventoryVoucherDetails details
                JOIN StoragesDb.dbo.Products p ON p.ProductId = details.ProductId
                JOIN StoragesDb.dbo.ProductUnit pu ON p.ProductId = pu.ProductId
                JOIN StoragesDb.dbo.Unit u ON pu.UnitId = u.UnitId
                WHERE details.DocummentNumber = {0}
            ", documentNumber);

            try
            {
                var results = _context.InventoryVoucherDetailResponses.FromSqlRaw(query).ToList();

                return results;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<InventoryVoucherResponseDto>> GetInventoryVouchers(SearchCriteria searchModel)
        {
            try
            {
                string xmlString = XMLCommonFunction.SerializeToXml(searchModel);
                var result = _context.InventoryVoucherResponseDto.FromSqlRaw(string.Format("EXEC sp_SearchInventoryVoucher '{0}', {1}, {2}", xmlString, searchModel.PageNumber, searchModel.PageSize)).AsNoTracking().ToList();

                List <InventoryVoucherResponseDto> response = new List <InventoryVoucherResponseDto>();
                foreach (var item in result)
                {
                    var billPaymentMethods = await GetBillPaymentMethods(item.BillId.Value);

                    item.PaymentMethods = billPaymentMethods;

                    response.Add(item);
                }

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PaymentMethodResponseDto GetPaymentInformation(string paymentMethodCode)
        {
            string query = string.Format(@"
                    SELECT PaymentMethodId
                    FROM StoragesDb.dbo.PaymentMethods p
                    WHERE p.PaymentMethodCode = '{0}'
            ", paymentMethodCode);

            var paymentMethod = _context.PaymentMethodResponseDtos.FromSqlRaw(query).FirstOrDefault();

            return paymentMethod;
        }

        public UnitResponseDto GetUnitInformation(int unitId)
        {
            string query = string.Format(@"
                    SELECT UnitName
                    FROM StoragesDb.dbo.Unit u
                    WHERE u.UnitId = {0}
            ", unitId);

            var unit = _context.UnitResponseDtos.FromSqlRaw(query).FirstOrDefault();

            return unit;
        }

        public ProductStorageInformationDto GetProductStorageDto(int brandId, int productId)
        {
            string query = string.Format(@"
                SELECT s.StorageId
		                ,ps.ProductId
		                ,COALESCE(ps.Quantity, 0) AS Quantity
                FROM StoragesDb.dbo.Storages s
                LEFT JOIN StoragesDb.dbo.ProductStorages ps ON s.StorageId = ps.StorageId
                WHERE s.BranchId = {0}
                AND ps.ProductId = {1}
            ", brandId, productId);

            var productStorage = _context.ProductStorageInformationDtos.FromSqlRaw(query).FirstOrDefault();

            return productStorage;
        }

        public bool UpdateProductStorage(ProductStorageInformationDto dto, int productQuantity)
        {
            //if (dto.Quantity - productQuantity <= 0)
            //    return false;

            string query = string.Format(@"
                UPDATE StoragesDb.dbo.ProductStorages
                SET Quantity = {0}
                    ,ModifyDate = GETDATE()
                WHERE ProductId = {1}
                AND StorageId = {2}
            ", dto.Quantity - productQuantity, dto.ProductId, dto.StorageId);

            var result = _context.Database.ExecuteSqlRaw(query);

            return result == 0 ? false : true;
        }

        #region Private Function Handle
        private async Task<List<BillPaymentDetailResponseDto>> GetBillPaymentMethods(int billId)
        {
            string query = string.Format(@"
 	                SELECT b.Id
			                ,b.Amount
			                ,b.PaymentTransactionRef
			                ,p.PaymentMethodCode
			                ,P.PaymentMethodName
	                FROM StoragesDb.dbo.BillPayments b
	                JOIN StoragesDb.dbo.PaymentMethods p ON b.PaymentMethodId = p.PaymentMethodId
	                WHERE b.BillId = {0}
            ", billId);

            try
            {
                var result = _context.BillPaymentDetailResponseDtos.FromSqlRaw(query).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private ProductResponseDto GetProductInformation(int productId)
        {
            string query = string.Format(@"
                    SELECT	p.ProductName
		                    ,p.Price
		                    ,p.Price * (1 + Tax/100) AS PriceBeforeTax
		                    ,p.CreditAccountId
		                    ,p.DebitAccountId
                    FROM StoragesDb.dbo.Products p
                    WHERE p.ProductId = {0}
            ", productId);

            var product = _context.ProductResponseDtos.FromSqlRaw(query).FirstOrDefault();

            return product;
        }
        #endregion
    }
}
