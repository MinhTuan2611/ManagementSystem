using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ManagementSystem.Common
{
    public class DbContextFactory
    {
        private readonly IConfiguration _configuration;

        public DbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TDbContext CreateDbContext<TDbContext>(string connectionStringName) where TDbContext : DbContext
        {
            string connectionStr = _configuration.GetConnectionString(connectionStringName);
            var options = new DbContextOptionsBuilder<TDbContext>()
                .UseSqlServer(connectionStr)
                .Options;

            return (TDbContext)Activator.CreateInstance(typeof(TDbContext), options);
        }
    }
}
