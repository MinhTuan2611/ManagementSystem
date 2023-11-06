using ManagementSystem.AccountingApi.Data;
using ManagementSystem.Common;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ManagementSystem.AccountingApi.Services
{
    public class DocumentGroupService : IDocumentGroupService
    {
        private readonly IConfiguration _configuration;
        private readonly AccountingDbContext _context;
        public DocumentGroupService(IConfiguration configuration, AccountingDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        public async Task<TPagination<DocumentGroupResponseDto>> GetAllLegerInformation(SearchCriteria criteria)
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

                var executeResult = await GenericSearchRepository<DocumentGroupResponseDto>.ExecutePagedStoredProcedureCommonAsync<DocumentGroupResponseDto>
                                                                                    (dbContext, "sp_SearchDocumentGroup", pageNumber, pageSize, parameters);

                // Process the results
                List<DocumentGroupResponseDto> pagedData = executeResult.Item1;
                int totalRecords = executeResult.Item2;

                var result = new TPagination<DocumentGroupResponseDto>();
                result.Items = pagedData;
                result.TotalItems = totalRecords;
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
