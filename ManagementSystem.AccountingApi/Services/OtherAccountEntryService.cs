using ManagementSystem.AccountingApi.Data;
using ManagementSystem.AccountingApi.Utility;
using ManagementSystem.Common;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ManagementSystem.AccountingApi.Services
{
    public class OtherAccountEntryService : IOtherAccountEntryService
    {
        private readonly AccountingDbContext _context;
        private readonly ILegerService _legerService;
        private IConfiguration _configuration;

        public OtherAccountEntryService(AccountingDbContext context, ILegerService legerService, IConfiguration configuration)
        {
            _context = context;
            _legerService = legerService;
            _configuration = configuration;
        }

        public async Task<OtherAccountEntry> CreateAccountEntry(NewOtherAccountEntrydto newOtherAccountEntry)
        {
            try
            {
                var accounts = GetAccountInfor(newOtherAccountEntry.Reason);
                var otherAccountEntry = new OtherAccountEntry();
                otherAccountEntry.BrandId = newOtherAccountEntry.BrandId;
                otherAccountEntry.AccountId = newOtherAccountEntry.AccountId;
                otherAccountEntry.UserId = newOtherAccountEntry.UserId;
                otherAccountEntry.Amount = newOtherAccountEntry.Amount;
                otherAccountEntry.CustomerId = newOtherAccountEntry.CustomerId;
                otherAccountEntry.CustomerName = newOtherAccountEntry.CustomerId == null && newOtherAccountEntry.CustomerName != null ? newOtherAccountEntry.CustomerName : string.Empty;
                otherAccountEntry.Note = newOtherAccountEntry.Note;
                otherAccountEntry.PaymentDescription = newOtherAccountEntry.PaymentDescription;
                otherAccountEntry.Reason = newOtherAccountEntry.Reason;
                otherAccountEntry.CreditAccount = accounts?.CreditAccount;
                otherAccountEntry.DebitAccount = accounts?.DebitAccount;

                _context.OtherAccountEntries.Add(otherAccountEntry);
                _context.SaveChanges();

                
                await _legerService.CreateLegers(new Leger()
                {
                    CustomerId = newOtherAccountEntry.CustomerId,
                    CustomerName = newOtherAccountEntry.CustomerId == null && newOtherAccountEntry.CustomerName != null ? newOtherAccountEntry.CustomerName : string.Empty,
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

        public async Task<TPagination<OtherAccountEntryResponseDto>> GetOtherAccountEntries(int? page = 1, int? pageSize = 10)
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
						    ,oe.CreditAccount
						    ,oe.DebitAccount
                    FROM OtherAccountEntries oe
                    LEFT JOIN {0}.dbo.Branches b ON oe.BrandId = b.BranchId
                    LEFT JOIN {0}.dbo.Customers c ON c.CustomerId = oe.CustomerId
                    LEFT JOIN {1}.dbo.Users u ON oe.UserId = u.UserId
                    ORDER BY oe.TransactionDate DESC
                    OFFSET ({2}-1)*{3} ROWS
                    FETCH NEXT {3} ROWS ONLY
                ", SD.StorageDbName, SD.AccountDbName, page, pageSize);

                var data = await _context.OtherAccountEntryResponseDtos.FromSqlRaw(query).ToListAsync();
                int totalRecords = _context.OtherAccountEntries.Count();


                var result = new TPagination<OtherAccountEntryResponseDto>();
                result.Items = data;
                result.TotalItems = totalRecords;
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
                            ,oe.CreditAccount
		                    ,oe.DebitAccount
                    FROM OtherAccountEntries oe
                    LEFT JOIN {0}.dbo.Branches b ON oe.BrandId = b.BranchId
                    LEFT JOIN {0}.dbo.Customers c ON c.CustomerId = oe.CustomerId
                    LEFT JOIN {1}.dbo.Users u ON oe.UserId = u.UserId
                    WHERE oe.DocumentNumber = {2}
                ",SD.StorageDbName, SD.AccountDbName, documentId);

                var result = await _context.OtherAccountEntryResponseDtos.FromSqlRaw(query).SingleOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<TPagination<OtherAccountEntryResponseDto>> SearchOtherAccountEntries(SearchCriteria criteria)
        {
            try
            {
                string xmlString = XMLCommonFunction.SerializeToXml(criteria);

                // Your DbContextFactory and DbContext creation code
                var dbContextFactory = new DbContextFactory(_configuration);
                using var dbContext = dbContextFactory.CreateDbContext<AccountingDbContext>("AcountingsDbConnStr");
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@xmlString", xmlString )
                };

                int pageNumber = criteria.PageNumber <= 0 ? 1 : criteria.PageNumber;
                int pageSize = criteria.PageSize <= 0 ? 10 : criteria.PageSize;

                var executeResult = await GenericSearchRepository<OtherAccountEntryResponseDto>.ExecutePagedStoredProcedureCommonAsync<OtherAccountEntryResponseDto>
                                                                                    (dbContext, "sp_SearchOtherEntries", pageNumber, pageSize, parameters);

                // Process the results
                List<OtherAccountEntryResponseDto> pagedData = executeResult.Item1;
                int totalRecords = executeResult.Item2;

                var result = new TPagination<OtherAccountEntryResponseDto>();
                result.Items = pagedData;
                result.TotalItems = totalRecords;
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
                otherAccountEntry.CustomerName = updateOtherAccountEntry.CustomerId == null && updateOtherAccountEntry.CustomerName != null ? updateOtherAccountEntry.CustomerName : string.Empty;
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
