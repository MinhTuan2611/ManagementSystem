﻿using ManagementSystem.Common.Entities;
using ManagementSystem.StoragesApi.Controllers.SeedingData;
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
        public DbSet<TypesOfAccounts> TypesOfAccounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStorage> ProductStorages { get; set; }
        public DbSet<ProductUnit> ProductUnit { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<BillPayment> BillPayments { get; set; }
        public DbSet<RequestSample> RequestSamples { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<AnimalPartRefCode> AnimalPartRefCodes { get; set; }
        public DbSet<RequestSampleItem> RequestSampleItems { get; set; }
        public DbSet<ActivityLog> ActivityLog { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(CategoriesSeeding.GetCategoies());
            modelBuilder.Entity<AnimalPartRefCode>().HasData(AnimalPartRefCodesSeeding.GenerateAnimalPartRefCodes());

            modelBuilder.Entity<RequestSampleItem>().HasKey(x => new {x.ProductId, x.RequestSampleId, x.UnitId});
            modelBuilder.Entity<ProductSupplier>().HasKey(x => new { x.SupplierId, x.ProductId });
        }
    }
}

