using ManagementSystem.AccountingApi.Data;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Entities.Accountings;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models.Dtos.Accounting;
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
                //inventory.PaymentMethodId = request.PaymentMethodId;
                inventory.CustomerId = request.CustomerId;

                _context.InventoryVouchers.Add(inventory);
                _context.SaveChanges();

                foreach (var detail in request.Details)
                {
                    var product = GetProductInformation(detail.ProductId);
                    var unit = GetUnitInformation(detail.UnitId);
                    var productStorage = GetProductStorageDto(request.BrandId.Value, detail.Quantity);

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
                    item.StorageId = productStorage.StorageId;

                    _context.InventoryVoucherDetails.Add(item);

                    if (productStorage != null)
                    {
                        bool result = UpdateProductStorage(productStorage, detail.Quantity);

                        if (!result)
                            return null;
                    }
                }

                foreach (var code in request.PaymentMethodCodes)
                {
                    var method = GetPaymentInformation(code);

                    var inventoryPaymentMethod = new InventoryVoucherPaymentMethod();
                    inventoryPaymentMethod.DocumentNumber = inventory.DocummentNumber;
                    inventoryPaymentMethod.PaymentMethodId = inventoryPaymentMethod.PaymentMethodId;

                    _context.InventoryVoucherPaymentMethods.Add(inventoryPaymentMethod);
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

        public async Task<bool> UpdateInventoryDeliveryVoucher(UpdateInventoryVoucherDto request)
        {
            try
            {
                var inventory = _context.InventoryVouchers.Include(x => x.Details)
                                                            .FirstOrDefault(x => x.DocummentNumber == request.DocummentNumber);
                if (inventory == null)
                    return false;

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
                    var productStorage = GetProductStorageDto(request.BrandId.Value, detail.Quantity);

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
                    item.StorageId = productStorage.StorageId;

                    _context.InventoryVoucherDetails.Add(item);

                    if (productStorage != null)
                    {
                        bool result = UpdateProductStorage(productStorage, detail.Quantity);

                        if (!result)
                            return false;
                    }
                }
                await _context.SaveChangesAsync();

                var paymentMethods = _context.InventoryVoucherPaymentMethods.Where(x => x.DocumentNumber == request.DocummentNumber).ToList();
                _context.InventoryVoucherPaymentMethods.RemoveRange(paymentMethods);
                foreach (var id in request.PaymentMethodIds)
                {
                    var inventoryPaymentMethod = new InventoryVoucherPaymentMethod();
                    inventoryPaymentMethod.DocumentNumber = request.DocummentNumber;
                    inventoryPaymentMethod.PaymentMethodId = id;

                    _context.InventoryVoucherPaymentMethods.Add(inventoryPaymentMethod);
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

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<InventoryVoucherDetailResponseDto>> GetInventoryVoucherDetail(int documentNumber)
        {
            string query = string.Format(@"
                SELECT p.ProductId
		                ,p.ProductName
		                ,p.ProductCode
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
		                ,details.TaxMoney
		                ,details.TotalMoneyAfterTax
		                ,details.Note
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
            catch (Exception ex) {
                return null;
            }
        }

        public async Task<List<InventoryVoucherResponseDto>> GetInventoryVouchers(int page = 1, int pageSize = 10)
        {
            string query = string.Format(@"
        SELECT DISTINCT iv.DocummentNumber
		                ,iv.CustomerId
		                ,c.CustomerName
		                ,iv.PurchasingRepresentive
		                ,iv.RepresentivePhone
		                ,iv.Note
		                ,iv.UserId
		                ,u.FirstName
		                ,u.LastName
		                ,u.Email
		                ,u.PhoneNumber
		                ,iv.ReasonFor
		                ,p.PaymentMethodName
		                ,iv.TransactionDate
						,s.StorageName
                FROM InventoryVouchers iv
				JOIN InventoryVoucherDetails id ON iv.DocummentNumber = id.DocummentNumber
				LEFT JOIN InventoryVoucherPaymentMethods ipm ON iv.DocummentNumber = ipm.DocumentNumber
                LEFT JOIN StoragesDb.dbo.customers c ON iv.CustomerId = c.CustomerId
                JOIN AccountsDb.dbo.Users u ON iv.UserId = u.UserId
                LEFT JOIN StoragesDb.dbo.PaymentMethods p ON p.PaymentMethodId = ipm.PaymentMethodId
				LEFT JOIN StoragesDb.dbo.Storages s ON s.StorageId = id.StorageId
                ORDER BY iv.TransactionDate DESC
                OFFSET ({0} - 1)*{1} ROWS
                FETCH NEXT {1} ROWS ONLY
            ", page, pageSize);

            try
            {
                var result = _context.InventoryVoucherResponseDto.FromSqlRaw(query)
                 .ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null; ;
            }
        }

        // Private Funtion Handling Get Data

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
    }
}
