using ManagementSystem.AccountingApi.Data;
using ManagementSystem.AccountingApi.Repositories.GenericRepository;
using ManagementSystem.Common;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.Data.SqlClient;

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
                await _context.SaveChangesAsync();

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
                                                                                (dbContext, "sp_SearchLegers", pageNumber, pageSize, parameters);

            // Process the results
            List<LegerResponseDto> pagedData = executeResult.Item1;

            var exportViews = pagedData.Select(item => new LegerExcelView
            {
                TransactionDate = item.TransactionDate,
                DoccumentNumber = item.DoccumentNumber,
                CreditAccount = item.CreditAccount,
                DepositAccount = item.DepositAccount,
                Amount = item.Amount,
                DoccumentType = item.DoccumentType,
                LegerDescription = item.LegerDescription,
            }).ToList();


            // Headers
            var headers = new[] { "TransactionDate", "DoccumentNumber", "CreditAccount", "DepositAccount", "Amount", "DoccumentType", "LegerDescription" };

            // Handle file path
            string filePath = string.Format(AccountingConstant.filePathFomat, DateTime.Now.ToString("yyyyMMdd"), string.Format("{0}.xlsx", DateTime.Now.Ticks));

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
    }
}
