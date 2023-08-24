using ManagementSystem.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ManagementSystem.AccountingApi.Data
{
    public class AccountingDbContext : DbContext
    {
        public AccountingDbContext(DbContextOptions<AccountingDbContext> options) : base(options)
        {
        }

        public DbSet<TypesOfAccounts> TypesOfAccounts { get; set; }
        public DbSet<Recordingtransaction> Recordingtransactions { get; set; }
    }
}
