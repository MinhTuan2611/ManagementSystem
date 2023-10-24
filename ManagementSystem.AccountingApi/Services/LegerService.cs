using ManagementSystem.AccountingApi.Data;
using ManagementSystem.AccountingApi.Repositories;
using ManagementSystem.AccountingApi.Repositories.GenericRepository;
using ManagementSystem.Common;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ManagementSystem.AccountingApi.Services
{
    public class LegerService : ILegerService
    {
        private readonly AccountingDbContext _context;
        private readonly IConfiguration _configuration;

        public LegerService(AccountingDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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


    }
}
