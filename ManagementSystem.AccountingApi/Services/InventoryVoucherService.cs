using ManagementSystem.AccountingApi.Data;

using ManagementSystem.Common.Entities;
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


        public async Task<bool> CreateInventoryDeliveryVoucher(NewInventoryVoucherDto request)
        {
            try
            {
                var inventory = new InventoryVoucher();
                inventory.UserId = request.UserId;
                inventory.PurchasingRepresentive = request.PurchasingRepresentive;
                inventory.RepresentivePhone = request.RepresentivePhone;
                inventory.TransactionDate = DateTime.Now;
                inventory.ReasonFor = request.ReasonFor;
                inventory.Note = request.Note;
                inventory.PaymentMethodId = request.PaymentMethodId;
                inventory.CustomerId = request.CustomerId;

                _context.InventoryVouchers.Add(inventory);
                _context.SaveChanges();

                foreach (var detail in request.Details)
                {
                    var item = new InventoryVoucherDetail();
                    item.DocummentNumber = inventory.DocummentNumber;
                    item.ProductId = detail.ProductId;
                    item.CreditAccount = detail.CreditAccount;
                    item.DebitAccount = detail.DebitAccount;
                    item.PaymentDiscountAccount = detail.PaymentDiscountAccount;
                    item.TaxAccount = detail.TaxAccount;
                    item.Quantity = detail.Quantity;
                    item.Price = detail.Price;
                    item.TotalMoneyBeforeTax = detail.TotalMoneyBeforeTax;
                    item.DebitAccountMoney = detail.DebitAccountMoney;
                    item.CreditAccountMoney = detail.CreditAccountMoney;
                    item.PaymentDiscountMoney = detail.PaymentDiscountMoney;
                    item.TaxMoney = detail.TaxMoney;
                    item.TotalMoneyAfterTax = detail.TotalMoneyAfterTax;
                    item.Note = detail.Note;

                    _context.InventoryVoucherDetails.Add(item);
                }
                await _context.SaveChangesAsync();


                // Add activity logs
                _context.ActivityLog.Add(new ActivityLog()
                {
                    UserId = request.UserId,
                    Action = "Create Inventory Voucher: " + inventory.DocummentNumber.ToString(),
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
                JOIN StoragesDb..Products p ON p.ProductId = details.ProductId
                JOIN StoragesDb..ProductUnit pu ON p.ProductId = pu.ProductId
                JOIN StoragesDb..Unit u ON pu.UnitId = u.UnitId
                WHERE details.DocummentNumber = {0}
            ", documentNumber);

            var result = _context.InventoryVoucherDetailResponses.FromSqlRaw(query).ToList();

            return result;
        }

        public async Task<List<InventoryVoucherResponseDto>> GetInventoryVouchers(int page = 1, int pageSize = 10)
        {
            string query = string.Format(@"
                SELECT iv.DocummentNumber
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
                FROM InventoryVouchers iv
                JOIN StoragesDb..customers c ON iv.CustomerId = c.CustomerId
                JOIN AccountsDb..Users u ON iv.UserId = u.UserId
                JOIN StoragesDb..PaymentMethods p ON p.PaymentMethodId = iv.PaymentMethodId
                ORDER BY iv.TransactionDate DESC
                OFFSET ({0}-1)*{1} ROWS
                FETCH NEXT {1} ROWS ONLY
            ", page, pageSize);
            var result = _context.InventoryVoucherResponseDto.FromSqlRaw(query)
            .ToList();

            return result;
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
                inventory.PaymentMethodId = request.PaymentMethodId;
                inventory.CustomerId = request.CustomerId;

                _context.SaveChanges();

                _context.InventoryVoucherDetails.RemoveRange(inventory.Details);

                foreach (var detail in request.Details)
                {
                    var item = new InventoryVoucherDetail();
                    item.DocummentNumber = detail.DocummentNumber;
                    item.ProductId = detail.ProductId;
                    item.CreditAccount = detail.CreditAccount;
                    item.DebitAccount = detail.DebitAccount;
                    item.PaymentDiscountAccount = detail.PaymentDiscountAccount;
                    item.TaxAccount = detail.TaxAccount;
                    item.Quantity = detail.Quantity;
                    item.Price = detail.Price;
                    item.TotalMoneyBeforeTax = detail.TotalMoneyBeforeTax;
                    item.DebitAccountMoney = detail.DebitAccountMoney;
                    item.CreditAccountMoney = detail.CreditAccountMoney;
                    item.PaymentDiscountMoney = detail.PaymentDiscountMoney;
                    item.TaxMoney = detail.TaxMoney;
                    item.TotalMoneyAfterTax = detail.TotalMoneyAfterTax;
                    item.Note = detail.Note;

                    _context.InventoryVoucherDetails.Add(item);
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
    }
}
