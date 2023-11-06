using ManagementSystem.AccountingApi.Data;
using ManagementSystem.Common;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Loggers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models.Dtos.Accounting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ManagementSystem.AccountingApi.Services
{

    public class DebitVoucherService : IDebitVoucherService
    {
        private readonly AccountingDbContext _context;
        private readonly string _path = string.Empty;
        private readonly ILegerService _legerService;
        private IConfiguration _configuration;

        public DebitVoucherService(AccountingDbContext context, ILegerService legerService, IConfiguration configuration)
        {
            _context = context;
            _path = @"C:\\Logs\\Accounting\\DebitVoucher";
            _legerService = legerService;
            _configuration = configuration;

        }

        public async Task<DebitVoucher> CreateDebitVoucher(NewDebitVoucherRequestDto requestDto)
        {
            try
            {
                var paymentMethod = GetPaymentMethodInformation(requestDto.PaymentMethodCode);
                string reason = GetReasonByMethodCode(requestDto.PaymentMethodCode);
                var accounts = GetAccountInfor(requestDto.PaymentMethodCode);

                var debitVoucher = new DebitVoucher();
                debitVoucher.ShiftId = requestDto.ShiftId;
                debitVoucher.UserId = requestDto.UserId;
                debitVoucher.CreditAccount = accounts?.CreditAccount;
                debitVoucher.DebitAccount = accounts?.DebitAccount;
                debitVoucher.Description = requestDto.Description;
                debitVoucher.ExchangeRate = requestDto.ExchangeRate;
                debitVoucher.Reason = reason;
                requestDto.ReceiverName = requestDto.ReceiverName;
                debitVoucher.TotalMoneyVND = requestDto.TotalMoneyVND;
                debitVoucher.NTMoney = requestDto.NTMoney;
                debitVoucher.GroupId = requestDto.GroupId;
                debitVoucher.PaymentMethodId = paymentMethod.PaymentMethodId;
                _context.DebitVouchers.Add(debitVoucher);
                _context.SaveChanges();

                // Add activity logs
                _context.ActivityLog.Add(new ActivityLog()
                {
                    UserId = requestDto.UserId.Value,
                    Action = "Create Debit Voucher: " + debitVoucher.DocumentNumber.ToString(),
                    Source = "DebitVoucher",
                    DateModified = DateTime.Now,
                });
                _context.SaveChanges();

                await _legerService.CreateLegers(new Leger()
                {
                    CustomerId = requestDto.CustomerId,
                    TransactionDate = debitVoucher.TransactionDate,
                    DoccumentNumber = debitVoucher.DocumentNumber,
                    CreditAccount = accounts?.CreditAccount,
                    DepositAccount = accounts?.DebitAccount,
                    DoccumentType = AccountingConstant.DebitVoucherType,
                    BillId = requestDto.BillId,
                    Amount = requestDto.TotalMoneyVND.Value,
                    UserId = requestDto.UserId,
                    StorageId = requestDto.StorageId,
                });

                return debitVoucher;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function CreateDebitVoucher: " + ex.Message, _path);
                return null;
            }
        }

        public async Task<DebitVoucher> UpdateDebitVoucher(UpdateDebitVoucherRequestDto requestDto)
        {
            try
            {
                var debitVoucher = _context.DebitVouchers.SingleOrDefault(x => x.DocumentNumber == requestDto.DocumentNumber);

                if (debitVoucher != null)
                {
                    var paymentMethod = GetPaymentMethodInformation(requestDto.PaymentMethodCode);
                    var accounts = GetAccountInfor(requestDto.PaymentMethodCode);

                    debitVoucher.ShiftId = requestDto.ShiftId;
                    debitVoucher.UserId = requestDto.UserId;
                    debitVoucher.CreditAccount = accounts.CreditAccount;
                    debitVoucher.DebitAccount = accounts.DebitAccount;
                    debitVoucher.Description = requestDto.Description;
                    debitVoucher.ExchangeRate = requestDto.ExchangeRate;
                    debitVoucher.Reason = requestDto.Reason;
                    debitVoucher.ReceiverName = requestDto.ReceiverName;
                    debitVoucher.TotalMoneyVND = requestDto.TotalMoneyVND;
                    debitVoucher.NTMoney = requestDto.NTMoney;
                    debitVoucher.PaymentMethodId = paymentMethod.PaymentMethodId;

                    _context.SaveChanges();

                    // Add activity logs
                    _context.ActivityLog.Add(new ActivityLog()
                    {
                        UserId = debitVoucher.UserId.Value,
                        Action = "Update Debit Voucher: " + debitVoucher.DocumentNumber.ToString(),
                        Source = "UpdateDebitVoucher",
                        DateModified = DateTime.Now,
                    });

                    await _context.SaveChangesAsync();

                    return debitVoucher;
                }

                return null;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function UpdateDebitVoucher: " + ex.Message, _path);
                return null;
            }
            
        }

        public async Task<DebitVoucherResponseDto> GetDebitVouchereByDocumentNumber(int documentNumber)
        {
            string query = string.Format(@"
                    SELECT b.BranchCode
		                    ,b.BranchName
		                    ,b.[Address]
		                    ,CONCAT(u.FirstName, '''', u.LastName) AS EmployeeName
		                    ,u.UserId AS EmployeeId
		                    ,pv.ReceiverName
		                    ,pv.Description
		                    ,rt.ReasonName AS Reason
		                    ,pv.TotalMoneyVND
		                    ,pv.ExchangeRate
		                    ,pv.NTMoney
                            ,pv.DocumentNumber
                            ,pv.TransactionDate
		                    ,pm.PaymentMethodName
		                    ,pm.PaymentMethodCode
                    FROM dbo.DebitVouchers pv
                    LEFT JOIN AccountsDb.dbo.Users u ON pv.UserId = u.UserId
                    LEFT JOIN AccountsDb.dbo.UserBranchs ub ON ub.UserId = u.UserId
                    LEFT JOIN StoragesDb.dbo.Branches b ON ub.BranchId = b.BranchId
                    LEFT JOIN dbo.Recordingtransactions rt ON rt.ReasonCode = pv.Reason
                    JOIN StoragesDb.dbo.PaymentMethods pm ON pm.PaymentMethodId = pv.PaymentMethodId
                    WHERE pv.DocumentNumber = {0}
            ", documentNumber);

            try
            {
                var result = _context.ExecuteSqlForEntity<DebitVoucherResponseDto>(query).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<TPagination<DebitVoucherResponseDto>> SearchDebitVouchers(SearchCriteria criteria)
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

                var executeResult = await GenericSearchRepository<DebitVoucherResponseDto>.ExecutePagedStoredProcedureCommonAsync<DebitVoucherResponseDto>
                                                                                    (dbContext, "sp_SearchDebitVouchers", pageNumber, pageSize, parameters);

                // Process the results
                List<DebitVoucherResponseDto> pagedData = executeResult.Item1;
                int totalRecords = executeResult.Item2;

                var result = new TPagination<DebitVoucherResponseDto>();
                result.Items = pagedData;
                result.TotalItems = totalRecords;
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #region Private handle methods
        private PaymentMethodDto GetPaymentMethodInformation(string methodCode)
        {
            string query = string.Format(@"
                SELECT PaymentMethodId
		                ,PaymentMethodName
		                ,PaymentMethodCode
                FROM StoragesDb.dbo.PaymentMethods
                WHERE PaymentMethodCode = '{0}'
            ", methodCode);

            try
            {
                var paymentMethod = _context.ExecuteSqlForEntity<PaymentMethodDto>(query).FirstOrDefault();

                return paymentMethod;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function GetPaymentMethodInformation: " + ex.Message, _path);
                return null;
            }
        }

        private AccountsDto GetAccountInfor(string methodCode)
        {
            var query = string.Format(@"
                DROP TABLE IF EXISTS #map_method_transaction_reason
                CREATE TABLE #map_method_transaction_reason
                (
	                MethodCode VARCHAR(30)
	                ,ReasonCode VARCHAR(30)
                )

                INSERT INTO #map_method_transaction_reason(MethodCode,ReasonCode)
                VALUES ('CARD', 'TCK'), ('BANKING', 'TIEUDUNG'), ('MOMO', 'MOMO'), ('ZALO', 'BC017')

                SELECT tc.AccountCode AS CreditAccount
		                ,td.AccountCode AS DebitAccount
                FROM #map_method_transaction_reason t
                JOIN dbo.Recordingtransactions rt ON rt.ReasonCode = t.ReasonCode
                JOIN dbo.TypesOfAccounts tc ON tc.AccountId = rt.CreditAccountId
                JOIN dbo.TypesOfAccounts td ON td.AccountId = rt.DebitAccountId
                WHERE t.MethodCode = '{0}'
            ", methodCode);

            try
            {
                var result = _context.ExecuteSqlForEntity<AccountsDto>(query).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function GetAccountInfor: " + ex.Message, _path);
                return null;
            }
        }

        private string GetReasonByMethodCode(string methodCode)
        {
            string query = string.Format(@"
                DROP TABLE IF EXISTS #map_method_transaction_reason
                CREATE TABLE #map_method_transaction_reason
                (
	                MethodCode VARCHAR(30)
	                ,ReasonCode VARCHAR(30)
                )

                INSERT INTO #map_method_transaction_reason(MethodCode,ReasonCode)
                VALUES ('CARD', 'TCK'), ('BANKING', 'TIEUDUNG'), ('MOMO', 'MOMO'), ('ZALO', 'BC017')

                SELECT ReasonCode AS Value
                FROM #map_method_transaction_reason t
                WHERE t.MethodCode = '{0}'
            ", methodCode);

            try
            {
                var result = _context.CalculateScalarFunction<ScalarResult<string>>(query).Value;
                return result;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        #endregion
    }
}
