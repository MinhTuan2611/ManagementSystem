using ManagementSystem.AccountingApi.Data;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.AccountingApi.Services
{
    public class PaymentVoucherService : IPaymentVoucherService
    {
        private readonly AccountingDbContext _context;
        private readonly ILegerService _legerService;

        public PaymentVoucherService(AccountingDbContext context, ILegerService legerService)
        {
            _context = context;
            _legerService = legerService;
        }

        public async Task<PaymentVoucher> CreatePaymentVoucher(NewPaymentVoucherDto newPaymentVoucher)
        {
            try
            {
                var paymentVoucher = new PaymentVoucher();
                paymentVoucher.BranchId = newPaymentVoucher.BranchId;
                paymentVoucher.ShiftId = newPaymentVoucher.ShiftId;
                paymentVoucher.UserId = newPaymentVoucher.UserId;
                paymentVoucher.CreditAccount = newPaymentVoucher.CreditAccount;
                paymentVoucher.DebitAccount = newPaymentVoucher.DebitAccount;
                paymentVoucher.Description = newPaymentVoucher.Description;
                paymentVoucher.ExchangeRate = newPaymentVoucher.ExchangeRate;
                paymentVoucher.Reason = string.IsNullOrEmpty(newPaymentVoucher.Reason) ? AccountingConstant.CCHReason : newPaymentVoucher.Reason;
                paymentVoucher.ReceiverName = newPaymentVoucher.ReceiverName;
                paymentVoucher.TotalMoneyVND = newPaymentVoucher.TotalMoneyVND;
                paymentVoucher.NTMoney = newPaymentVoucher.NTMoney;

                _context.PaymentVouchers.Add(paymentVoucher);
                _context.SaveChanges();

                var accounts = GetAccountInfor(paymentVoucher.Reason);

                await _legerService.CreateLegers(new Leger()
                {
                    CustomerId = null,
                    TransactionDate = paymentVoucher.TransactionDate,
                    DoccumentNumber = paymentVoucher.DocumentNumber,
                    CreditAccount = accounts?.CreditAccount,
                    DepositAccount = accounts?.DebitAccount,
                    DoccumentType = AccountingConstant.PaymentVoucherType,
                    BillId = 0,
                    Amount = newPaymentVoucher.TotalMoneyVND.Value,
                    UserId = newPaymentVoucher.UserId,
                    StorageId = newPaymentVoucher.BranchId,
                });

                _context.SaveChanges();

                // Add activity logs
                _context.ActivityLog.Add(new ActivityLog()
                {
                    UserId = newPaymentVoucher.UserId.Value,
                    Action = "Create Payment Voucher: " + paymentVoucher.DocumentNumber.ToString(),
                    Source = "PaymentVoucher",
                    DateModified = DateTime.Now,
                });
                await _context.SaveChangesAsync();

                return paymentVoucher;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<PaymentVoucherResponseDto> GetPaymentVoucher(int DocumentId)
        {
            try
            {
                string query = string.Format(@"
                    SELECT b.BranchCode
		                    ,b.BranchName
		                    ,b.[Address]
		                    ,CONCAT(u.FirstName, ' ', u.LastName) AS EmployeeName
		                    ,u.UserId AS EmployeeId
		                    ,pv.ReceiverName
		                    ,pv.Description
		                    ,pv.Reason
		                    ,pv.TotalMoneyVND
		                    ,pv.ExchangeRate
		                    ,pv.NTMoney
                            ,pv.DocumentNumber
                            ,pv.TransactionDate
                    FROM PaymentVouchers pv
                    LEFT JOIN StoragesDb.dbo.Branches b ON pv.BranchId = b.BranchId 
                    LEFT JOIN AccountsDb.dbo.Users u ON pv.UserId = u.UserId
                    WHERE DocumentNumber = {0}
                ", DocumentId);

                var result = await _context.PaymentVoucherResponseDtos.FromSqlRaw(query).SingleOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<PaymentVoucherResponseDto>> GetPaymentVouchers(int? page = 1, int? pageSize = 10)
        {
            try
            {
                string query = string.Format(@"
                    SELECT b.BranchCode
		                    ,b.BranchName
		                    ,b.[Address]
		                    ,CONCAT(u.FirstName, ' ', u.LastName) AS EmployeeName
		                    ,u.UserId AS EmployeeId
		                    ,pv.ReceiverName
		                    ,pv.Description
		                    ,pv.Reason
		                    ,pv.TotalMoneyVND
		                    ,pv.ExchangeRate
		                    ,pv.NTMoney
                            ,pv.DocumentNumber
                            ,pv.TransactionDate
                    FROM PaymentVouchers pv
                    LEFT JOIN StoragesDb.dbo.Branches b ON pv.BranchId = b.BranchId 
                    LEFT JOIN AccountsDb.dbo.Users u ON pv.UserId = u.UserId
                    ORDER BY pv.TransactionDate DESC
                    OFFSET ({0}-1)*{1} ROWS
                    FETCH NEXT {1} ROWS ONLY
                ", page, pageSize);

                var result = await _context.PaymentVoucherResponseDtos.FromSqlRaw(query).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<PaymentVoucher> UpdatePaymentVoucher(UpdatePaymentVoucherDto updatePaymentVoucher)
        {
            try
            {
                var paymentVoucher = _context.PaymentVouchers.SingleOrDefault(x => x.DocumentNumber == updatePaymentVoucher.DocumentNumber);
                paymentVoucher.BranchId = updatePaymentVoucher.BranchId;
                paymentVoucher.ShiftId = updatePaymentVoucher.ShiftId;
                paymentVoucher.UserId = updatePaymentVoucher.UserId;
                paymentVoucher.CreditAccount = updatePaymentVoucher.CreditAccount;
                paymentVoucher.DebitAccount = updatePaymentVoucher.DebitAccount;
                paymentVoucher.Description = updatePaymentVoucher.Description;
                paymentVoucher.ExchangeRate = updatePaymentVoucher.ExchangeRate;
                paymentVoucher.Reason = string.IsNullOrEmpty(updatePaymentVoucher.Reason) ? AccountingConstant.CCHReason : updatePaymentVoucher.Reason;
                paymentVoucher.ReceiverName = updatePaymentVoucher.ReceiverName;
                paymentVoucher.TotalMoneyVND = updatePaymentVoucher.TotalMoneyVND;
                paymentVoucher.NTMoney = updatePaymentVoucher.NTMoney;

                _context.SaveChanges();

                // Add activity logs
                _context.ActivityLog.Add(new ActivityLog()
                {
                    UserId = updatePaymentVoucher.UserId.Value,
                    Action = "Update Payment Voucher: " + paymentVoucher.DocumentNumber.ToString(),
                    Source = "PaymentVoucher",
                    DateModified = DateTime.Now,
                });
                await _context.SaveChangesAsync();

                return paymentVoucher;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #region Private Handle function
        private AccountsDto GetAccountInfor(string reason)
        {
            var query = string.Format(@"
                SELECT tc.AccountCode AS CreditAccount
		                ,td.AccountCode AS DebitAccount
                FROM  dbo.Recordingtransactions rt
                JOIN dbo.TypesOfAccounts tc ON tc.AccountId = rt.CreditAccountId
                JOIN dbo.TypesOfAccounts td ON td.AccountId = rt.DebitAccountId
                WHERE rt.ReasonCode = '{0}'
            ", reason);

            try
            {
                var result = _context.AccountDtos.FromSqlRaw(query).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
