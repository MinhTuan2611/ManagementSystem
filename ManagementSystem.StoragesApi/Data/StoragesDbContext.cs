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
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStorage> ProductStorages { get; set; }
        public DbSet<ProductUnit> ProductUnit { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

    }
}

