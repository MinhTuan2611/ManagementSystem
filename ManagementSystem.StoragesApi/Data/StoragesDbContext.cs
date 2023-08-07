using ManagementSystem.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ManagementSystem.StoragesApi.Data
{
    public class StoragesDbContext : DbContext
    {
        public StoragesDbContext(DbContextOptions<StoragesDbContext> options) : base(options)
        {
        }

        public DbSet<Branch> Branches { get; set; }

    }
}

