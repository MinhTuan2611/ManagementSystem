using ManagementSystem.AccountingApi.Data;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.AccountingApi.Services
{
    public class OtherAccountEntryService : IOtherAccountEntryService
    {
        private readonly AccountingDbContext _context;
        private readonly ILegerService _legerService;
        public OtherAccountEntryService(AccountingDbContext context, ILegerService legerService)
        {
            _context = context;
            _legerService = legerService;
        }

        public async Task<OtherAccountEntry> CreateAccountEntry(NewOtherAccountEntrydto newOtherAccountEntry)
        {
            try
            {
                var otherAccountEntry = new OtherAccountEntry();
                otherAccountEntry.BrandId = newOtherAccountEntry.BrandId;
                otherAccountEntry.AccountId = newOtherAccountEntry.AccountId;
                otherAccountEntry.UserId = newOtherAccountEntry.UserId;
                otherAccountEntry.Amount = newOtherAccountEntry.Amount;
                otherAccountEntry.CustomerId = newOtherAccountEntry.CustomerId;
                otherAccountEntry.Note = newOtherAccountEntry.Note;
                otherAccountEntry.PaymentDescription = newOtherAccountEntry.PaymentDescription;
                otherAccountEntry.Reason = newOtherAccountEntry.Reason;

                _context.OtherAccountEntries.Add(otherAccountEntry);
                _context.SaveChanges();

                var accounts = GetAccountInfor(newOtherAccountEntry.Reason);
                await _legerService.CreateLegers(new Leger()
                {
                    CustomerId = newOtherAccountEntry.CustomerId,
                    TransactionDate = otherAccountEntry.TransactionDate,
                    DoccumentNumber = otherAccountEntry.DocumentNumber,
                    CreditAccount = accounts?.CreditAccount,
                    DepositAccount = accounts?.DebitAccount,
                    DoccumentType = AccountingConstant.OtherAccountEntryType,
                    BillId = 0,
                    Amount = otherAccountEntry.Amount.Value,
                    UserId = otherAccountEntry.UserId,
                    StorageId = otherAccountEntry.BrandId,
                });

                _context.SaveChanges();

                // Add activity logs
                _context.ActivityLog.Add(new ActivityLog()
                {
                    UserId = otherAccountEntry.UserId.Value,
                    Action = "Update Other Account Entry: " + otherAccountEntry.DocumentNumber.ToString(),
                    Source = "OtherAccountEntry",
                    DateModified = DateTime.Now,
                });
                await _context.SaveChangesAsync();

                return otherAccountEntry;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<List<OtherAccountEntryResponseDto>> GetOtherAccountEntries(int? page = 1, int? pageSize = 10)
        {
            try
            {
                string query = string.Format(@"
                    SELECT b.BranchCode
		                    ,b.BranchName
		                    ,b.[Address]
		                    ,c.CustomerName AS PayerName
		                    ,c.CustomerName
		                    ,oe.PaymentDescription
		                    ,oe.Reason
		                    ,CONCAT(u.FirstName, ' ', u.LastName) AS EmployeeName
		                    ,u.UserId AS EmployeeId
		                    ,oe.Amount
                            ,oe.AccountId
                            ,oe.DocumentNumber
                            ,oe.Note
                    FROM OtherAccountEntries oe
                    LEFT JOIN StoragesDb.dbo.Branches b ON oe.BrandId = b.BranchId
                    LEFT JOIN StoragesDb.dbo.Customers c ON c.CustomerId = oe.CustomerId
                    LEFT JOIN AccountsDB.dbo.Users u ON oe.UserId = u.UserId
                    ORDER BY oe.TransactionDate DESC
                    OFFSET ({0}-1)*{1} ROWS
                    FETCH NEXT {1} ROWS ONLY
                ", page, pageSize);

                var result = await _context.OtherAccountEntryResponseDtos.FromSqlRaw(query).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<OtherAccountEntryResponseDto> GetOtherAccountEntry(int documentId)
        {
            try
            {
                string query = string.Format(@"
                    SELECT b.BranchCode
		                    ,b.BranchName
		                    ,b.[Address]
		                    ,c.CustomerName AS PayerName
		                    ,c.CustomerName
		                    ,oe.Reason
		                    ,CONCAT(u.FirstName, ' ', u.LastName) AS EmployeeName
		                    ,u.UserId AS EmployeeId
		                    ,oe.Amount
		                    ,oe.PaymentDescription
                            ,oe.AccountId
                            ,oe.DocumentNumber
                            ,oe.Note
                    FROM OtherAccountEntries oe
                    LEFT JOIN StoragesDb.dbo.Branches b ON oe.BrandId = b.BranchId
                    LEFT JOIN StoragesDb.dbo.Customers c ON c.CustomerId = oe.CustomerId
                    LEFT JOIN AccountsDB.dbo.Users u ON oe.UserId = u.UserId
                    WHERE oe.DocumentNumber = {0}
                ", documentId);

                var result = await _context.OtherAccountEntryResponseDtos.FromSqlRaw(query).SingleOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<OtherAccountEntry> UpdateAccountEntry(UpdateOtherAccountEntryDto updateOtherAccountEntry)
        {
            try
            {
                var otherAccountEntry = _context.OtherAccountEntries.SingleOrDefault(x => x.DocumentNumber == updateOtherAccountEntry.DocumentNumber);
                otherAccountEntry.BrandId = updateOtherAccountEntry.BrandId;
                otherAccountEntry.AccountId = updateOtherAccountEntry.AccountId;
                otherAccountEntry.UserId = updateOtherAccountEntry.UserId;
                otherAccountEntry.Amount = updateOtherAccountEntry.Amount;
                otherAccountEntry.CustomerId = updateOtherAccountEntry.CustomerId;
                otherAccountEntry.Note = updateOtherAccountEntry.Note;
                otherAccountEntry.PaymentDescription = updateOtherAccountEntry.PaymentDescription;
                otherAccountEntry.Reason = updateOtherAccountEntry.Reason;

                _context.SaveChanges();

                // Add activity logs
                _context.ActivityLog.Add(new ActivityLog()
                {
                    UserId = otherAccountEntry.UserId.Value,
                    Action = "Update Other Account Entry: " + otherAccountEntry.DocumentNumber.ToString(),
                    Source = "OtherAccountEntry",
                    DateModified = DateTime.Now,
                });
                await _context.SaveChangesAsync();

                return otherAccountEntry;
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
