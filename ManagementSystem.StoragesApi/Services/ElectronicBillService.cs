using Dapper;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.Data.SqlClient;

namespace ManagementSystem.StoragesApi.Services
{
    public class ElectronicBillService : IElectronicService
    {
        private IConfiguration _configuration;
        public ElectronicBillService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ElectronicPattern> GetLastestPattern()
        {
            string connectionString = _configuration.GetConnectionString("StoragesDbConnStr");
            ElectronicPattern pattern = new ElectronicPattern();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = @"
                                SELECT *
                                FROM dbo.ELectronicPattern
                                WHERE PatternYear = 
                            " + DateTime.Now.Year;

                    pattern = connection.Query<ElectronicPattern>(query).FirstOrDefault();
                }

                return pattern;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
