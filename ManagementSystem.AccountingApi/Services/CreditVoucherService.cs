using ManagementSystem.AccountingApi.Data;
using ManagementSystem.AccountingApi.Utility;
using ManagementSystem.Common;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Loggers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.Data.SqlClient;

namespace ManagementSystem.AccountingApi.Services
{
    public class CreditVoucherService : ICreditVoucherService
    {
        private readonly AccountingDbContext _context;
        private readonly ILegerService _legerService;
        private readonly string _path = string.Empty;
        private IConfiguration _configuration;

        public CreditVoucherService(AccountingDbContext context, ILegerService legerService, IConfiguration configuration)
        {
            _context = context;
            _path = @"C:\\Logs\\Accounting\\CreditVoucher";
            _legerService = legerService;
            _configuration = configuration;

        }

        public async Task<CreditVoucher> CreateCreditVoucher(NewCreditVoucherRequestDto request)
        {
            try
            {
                var accounts = GetAccountInfor(request.PaymentMethodCode);
                var paymentMethod = GetPaymentMethodInformation(request.PaymentMethodCode);
                string reason = GetReasonByMethodCode(request.PaymentMethodCode);

                var creditVoucher = new CreditVoucher();
                creditVoucher.CustomerId = request.CustomerId;
                creditVoucher.CustomerName = request.CustomerId == null && request.CustomerName != null ? request.CustomerName : string.Empty;
                creditVoucher.ForReason = string.IsNullOrEmpty(request.ForReason) || request.ForReason.Length <= 0 ? reason : request.ForReason;
                creditVoucher.TotalMoney = request.TotalMoney;
                creditVoucher.UserId = request.UserId;
                creditVoucher.TransactionDate = DateTime.Now;
                creditVoucher.GroupId = request.GroupId == null || request.GroupId == 0 ? 1 : request.GroupId; // Auto Generate Group
                creditVoucher.PaymentMethodId = paymentMethod?.PaymentMethodId;
                creditVoucher.CreditAccount = accounts?.CreditAccount;
                creditVoucher.DebitAccount = accounts?.DebitAccount;

                _context.CreditVouchers.Add(creditVoucher);
                _context.SaveChanges();

                

                // Add activity logs
                _context.ActivityLog.Add(new ActivityLog()
                {
                    UserId = request.UserId,
                    Action = "Create Credit Voucher: " + creditVoucher.DocumentNumber.ToString(),
                    Source = "CreditVoucher",
                    DateModified = DateTime.Now,
                });
                _context.SaveChanges();

                await _legerService.CreateLegers(new Leger()
                {
                    CustomerId = creditVoucher.CustomerId,
                    TransactionDate = creditVoucher.TransactionDate,
                    CustomerName = request.CustomerId == null && request.CustomerName != null ? request.CustomerName : string.Empty,
                    DoccumentNumber = creditVoucher.DocumentNumber,
                    CreditAccount = accounts?.CreditAccount,
                    DepositAccount = accounts?.DebitAccount,
                    DoccumentType = AccountingConstant.CreditVoucherType,
                    BillId = request.BillId,
                    Amount = request.TotalMoney,
                    UserId = request.UserId,
                    StorageId = GetStorageInfor(request.BrandId.Value, request.UserId, request.ProductId.Value),
                });

                return creditVoucher;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function CreateCreditVoucher: " + ex.Message, _path);
                return null;
            }
        }

        public async Task<CreditVoucher> UpdateCreditVoucher(UpdateCreditVoucherRequestDto request)
        {
            var existingCredit = _context.CreditVouchers.FirstOrDefault(x => x.DocumentNumber == request.DocumentNumber);

            if (existingCredit != null)
            {
                var paymentMethod = GetPaymentMethodInformation(request.PaymentMethodCode);
                string reason = GetReasonByMethodCode(request.PaymentMethodCode);
                var accounts = GetAccountInfor(request.PaymentMethodCode);

                // existingCredit.UserId = request.UserId;
                existingCredit.UpdatedDate = DateTime.Now;
                existingCredit.CustomerId = request.CustomerId;
                existingCredit.CustomerName = request.CustomerId == null && request.CustomerName != null ? request.CustomerName : string.Empty;
                existingCredit.ForReason = reason;
                existingCredit.TotalMoney = request.TotalMoney;
                existingCredit.PaymentMethodId = paymentMethod?.PaymentMethodId;
                existingCredit.CreditAccount = accounts?.CreditAccount;
                existingCredit.DebitAccount = accounts?.DebitAccount;

                _context.SaveChanges();
                return existingCredit;
            }

            return null;
        }

        public async Task<TPagination<CreditVoucherResponseDto>> SearchCreditVouchers(SearchCriteria criteria)
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

                var executeResult = await GenericSearchRepository<CreditVoucherResponseDto>.ExecutePagedStoredProcedureCommonAsync<CreditVoucherResponseDto>
                                                                                    (dbContext, "sp_SearchCreditVouchers", pageNumber, pageSize, parameters);

                // Process the results
                List<CreditVoucherResponseDto> pagedData = executeResult.Item1;
                int totalRecords = executeResult.Item2;

                var result = new TPagination<CreditVoucherResponseDto>();
                result.Items = pagedData;
                result.TotalItems = totalRecords;
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CreditVoucherResponseDto> GetCreditVouchereByDocumentNumber(int documentNumber)
        {
            string query = string.Format(@"
                SELECT r.DocumentNumber
		                ,r.TransactionDate
		                ,c.CustomerId
		                ,c.CustomerName
		                ,c.CustomerName AS Payer
		                ,rt.ReasonName AS ForReason
		                ,r.TotalMoney
		                ,u.UserId
		                ,u.UserName AS Cashier
		                ,pm.PaymentMethodCode
		                ,pm.PaymentMethodName
                        ,r.DebitAccount AS DebitAccount
						,r.CreditAccount AS CreditAccount
                FROM dbo.CreditVouchers r
                LEFT JOIN {0}.dbo.Customers c ON r.CustomerId = c.CustomerId
                LEFT JOIN {1}.dbo.Users u ON u.UserId = r.UserId
                JOIN {0}.dbo.PaymentMethods pm ON pm.PaymentMethodId = r.PaymentMethodId
                JOIN dbo.Recordingtransactions rt ON rt.ReasonCode = r.ForReason
                WHERE r.DocumentNumber = {2}
            ",SD.StorageDbName, SD.AccountDbName, documentNumber);

            try
            {
                var result = _context.ExecuteSqlForEntity<CreditVoucherResponseDto>(query).FirstOrDefault();

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
                FROM {0}.dbo.PaymentMethods
                WHERE PaymentMethodCode = '{1}'
            ",SD.StorageDbName, methodCode);

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
                VALUES ('CARD', 'TCK'), ('BANKING', 'TIEUDUNG'), ('MOMO', 'MOMO'), ('ZALO', 'BC017'), ('POINT', 'DOIDIEM')
                        ,('OTHER', 'TIEUDUNG'), ('VNPAY', 'BCDT02'), ('SAMSUNG', 'TIEUDUNG'), ('DISCOUNT', 'TMH')

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
                VALUES ('CARD', 'TCK'), ('BANKING', 'TIEUDUNG'), ('MOMO', 'MOMO'), ('ZALO', 'BC017'), ('POINT', 'DOIDIEM')
                        ,('OTHER', 'TIEUDUNG'), ('VNPAY', 'BCDT02'), ('SAMSUNG', 'TIEUDUNG'), ('DISCOUNT', 'TMH')

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

        private int? GetStorageInfor(int branchId, int userId, int productId)
        {
            string query = string.Empty;

            if (branchId != null && branchId > 0)
            {
                query = string.Format(@"
                    SELECT TOP 1 StorageId AS Value
                    FROM {0}.dbo.Storages 
                    WHERE BranchId = {1}
                ",SD.StorageDbName, branchId);
            }
            else
            {
                query = string.Format(@"SELECT TOP 1 s.StorageId AS Value
                                        FROM AccountsDb.dbo.UserBranchs ub
                                        JOIN {0}.dbo.Storages s ON s.BranchId = ub.BranchId
                                        WHERE ub.UserId = {1}",SD.StorageDbName, userId);
            }

            try
            {
                var result = _context.CalculateScalarFunction<ScalarResult<int?>>(query).Value;

                if (result == null)
                {
                    query = string.Format(@"
                                    SELECT TOP 1 ps.StorageId AS Value
                                    FROM {0}.dbo.ProductStorages ps
                                    WHERE ps.ProductId = {1}",SD.StorageDbName, productId);

                    result = _context.CalculateScalarFunction<ScalarResult<int?>>(query).Value;
                }
                return result != null ? result : 1;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        #endregion
    }
}
