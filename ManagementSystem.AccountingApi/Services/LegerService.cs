using ManagementSystem.AccountingApi.Data;
using ManagementSystem.AccountingApi.Repositories.GenericRepository;
using ManagementSystem.AccountingApi.Utility;
using ManagementSystem.Common;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Loggers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.AccountingApi.Services
{
    public class LegerService : ILegerService
    {
        private readonly AccountingDbContext _context;
        private readonly IConfiguration _configuration;
        private ResponseDto _responseDto;

        public LegerService(AccountingDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _responseDto = new ResponseDto();
        }


        public async Task<TPagination<LegerResponseDto>> GetAllLegerInformation(SearchCriteria criteria)
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

                var executeResult = await GenericSearchRepository<LegerResponseDto>.ExecutePagedStoredProcedureCommonAsync<LegerResponseDto>
                                                                                    (dbContext, "sp_SearchLegers", pageNumber, pageSize, parameters);

                // Process the results
                List<LegerResponseDto> pagedData = executeResult.Item1;
                int totalRecords = executeResult.Item2;

                var result = new TPagination<LegerResponseDto>();
                result.Items = pagedData;
                result.TotalItems = totalRecords;

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<Leger> CreateLegers(Leger leger)
        {
            try
            {
                _context.Legers.Add(leger);
                _context.SaveChanges();

                return leger;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ResponseDto> ExportExcelFile(SearchCriteria criteria)
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

            var executeResult = await GenericSearchRepository<LegerResponseDto>.ExecutePagedStoredProcedureCommonAsync<LegerResponseDto>
                                                                                (dbContext, "sp_ExportLegersData", pageNumber, pageSize, parameters);

            // Process the results
            List<LegerResponseDto> pagedData = executeResult.Item1;

            var exportViews = pagedData.Select(item => new LegerExcelView
            {
                TransactionDate = item.TransactionDate,
                DepositAccount = item.DepositAccount,
                CreditAccount = item.CreditAccount,
                DoccumentType = item.DoccumentType,
                DoccumentNumber = item.DoccumentNumber,             
                CustomerId = string.IsNullOrEmpty(item.CustomerId.ToString()) ? "KL" : item.CustomerId.ToString(),
                CustomerName = string.IsNullOrEmpty(item.CustomerName) ? "Khách Lẻ": item.CustomerName,
                Amount = item.Amount,
            }).ToList();


            // Headers
            var headers = new[] { "Ngày", "Nợ", "Có", "Loại Phiếu", "Số CT", "Mã Đối Tượng", "Tên Đối Tượng", "Giá Trị", "Nội dung" };

            // Handle file path
            string dateFormat = DateTime.Now.ToString("yyyyMMdd");
            string filePath = string.Format(AccountingConstant.filePathFomat, dateFormat, string.Format("SoCai_{0}_{1}.xlsx", dateFormat, DateTime.Now.Ticks));

            // Get the directory path
            string directoryPath = Path.GetDirectoryName(filePath);

            // Check if the directory exists, and if not, create it
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            try
            {
                // Call the generic function
                var excelExporter = new ExcelExporter();
                excelExporter.ExportToExcel(exportViews, headers, filePath);

                _responseDto.Result = filePath;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }

        public async Task<ResponseDto> ExportLeggerWithoutPaymentExcelFile(SearchCriteria criteria)
        {
            string fromDate = criteria.Criterias["FromDate"].ToString();
            string toDate = criteria.Criterias["ToDate"].ToString();

            string query = string.Format(@"
                    SELECT a.TransactionDate
		                    ,a.DepositAccount
		                    ,a.CreditAccount
		                    ,a.DoccumentType
		                    ,a.DoccumentNumber
		                    ,a.BillId
		                    ,COALESCE(d.CustomerCode, 'KL') AS CustomerCode
		                    ,COALESCE(d.CustomerName, N'Khách lẻ') AS CustomerName
		                    ,a.Amount
		                    ,COALESCE(b.ForReason, c.ForReason) AS ForReason
                    FROM Legers a
                    LEFT JOIN StoragesProdDb.dbo.Customers d ON d.CustomerId = a.CustomerId
                    LEFT JOIN [dbo].[ReceiptVouchers] b ON b.DocumentNumber = a.DoccumentNumber and a.DoccumentType = 'THU'
                    LEFT JOIN [dbo].[CreditVouchers] c ON c.DocumentNumber = a.DoccumentNumber and a.DoccumentType = 'BAOCO'
                    WHERE DoccumentType <> 'Chi'
	                    AND a.TransactionDate between CONVERT(DATETIME, '{0}') AND CONVERT(DATETIME, '{1}')
                    ORDER BY a.TransactionDate DESC
            ", fromDate, toDate);

            try
            {
                // Process the results
                var result = _context.LegerExportExcelResponseDtos.FromSqlRaw(query).ToList();

                // Headers
                var headers = new[] { "Ngày", "Nợ", "Có", "Loại Phiếu", "Số CT", "Mã Đối Tượng", "Tên Đối Tượng", "Giá Trị", "Nội dung" };

                // Handle file path
                string dateFormat = DateTime.Now.ToString("yyyyMMdd");
                string filePath = string.Format(AccountingConstant.filePathFomat, dateFormat, string.Format("SoCai_{0}_{1}.xlsx", dateFormat, DateTime.Now.Ticks));

                // Get the directory path
                string directoryPath = Path.GetDirectoryName(filePath);

                // Check if the directory exists, and if not, create it
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                // Call the generic function
                var excelExporter = new ExcelExporter();
                excelExporter.ExportToExcel(result, headers, filePath);

                _responseDto.Result = filePath;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }

        public async Task<ResponseDto> ExportPaymentVouchersInformationExcelFile(SearchCriteria model)
        {
            try
            {

                // Headers
                var headers = new[] { "Ngày Ghi Sổ", "Mã Đơn Vị", "Tên Đơn Vị", "Ca Bán", "Số CT", "TK Nợ", "TK Có", "Giá Trị", "Người Nhận Tiền", "Lý Do", "Diễn giải", "NV  Tạo Phiếu" };

                // Handle file path
                string dateFormat = DateTime.Now.ToString("yyyyMMdd");
                string filePath = string.Format(StorageContant.billFilePathFomat, dateFormat, string.Format("PaymentVoucherInfomation_{0}_{1}.xlsx", dateFormat, DateTime.Now.Ticks));

                // Get the directory path
                string directoryPath = Path.GetDirectoryName(filePath);

                // Check if the directory exists, and if not, create it
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                var resul = await GetPaymentVoucherInformations(model);
                // Call the generic function
                var excelExporter = new ExcelExporter();
                excelExporter.ExportToExcel(resul, headers, filePath);

                _responseDto.Result = filePath;

            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }

        public async Task<List<PaymentMethodInformationDto>> ViewPaymentVoucherInformation(SearchCriteria model)
        {
            try
            {
                var result = await GetPaymentVoucherInformations(model);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #region Private methods
        private async Task<List<PaymentMethodInformationDto>> GetPaymentVoucherInformations(SearchCriteria criteria)
        {
            string fromDate = criteria.Criterias["fromDate"].ToString();
            string toDate = criteria.Criterias["toDate"].ToString();

            string query = string.Format(@"
                SELECT FORMAT(TransactionDate, 'dd-MM-yyy HH:MM:ss') AS TransactionDate
		                ,COALESCE(BranchCode, '') AS BranchCode
		                ,COALESCE(BranchName,'') AS BranchName
		                ,ShiftId
		                ,DocumentNumber
		                ,DebitAccount
		                ,CreditAccount
		                ,TotalMoneyVND
		                ,ReceiverName
		                ,Reason
		                ,coalesce(Description, '') AS Description
		                ,concat(u.firstName, ' ', u.LastName) AS CreatedUser
                FROM PaymentVouchers a
                LEFT JOIN {0}.dbo.Users u on u.UserId = a.UserId
                WHERE Reason <> 'KETCHUYEN'
	                AND Reason <> 'TIEN'
	                AND Reason <> 'THIEU'
	                AND Reason <> 'THUA'
	                AND (FORMAT(TransactionDate, 'yyyy-MM-dd') between CONVERT(DATETIME, '{1}') AND CONVERT(DATETIME, '{2}'))
                order by  BranchCode, TransactionDate
            ", SD.AccountDbName, fromDate, toDate);

            var result = _context.PaymentMethodInformationDtos.FromSqlRaw(query).ToList();

            return result;
        }
        #endregion
    }
}
