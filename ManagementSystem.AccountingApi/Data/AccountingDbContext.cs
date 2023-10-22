﻿using ManagementSystem.Common;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.MigrationConfigurations;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Runtime.Intrinsics.X86;

namespace ManagementSystem.AccountingApi.Data
{
    public class AccountingDbContext : DbContext
    {
        private readonly MigrationsConfiguration _migrationConfiguration;

        public AccountingDbContext(DbContextOptions<AccountingDbContext> options, MigrationsConfiguration migrationConfiguration) : base(options)
        {
            _migrationConfiguration = migrationConfiguration;
        }

        public DbSet<TypesOfAccounts> TypesOfAccounts { get; set; }
        public DbSet<Recordingtransaction> Recordingtransactions { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<InventoryVoucher> InventoryVouchers { get; set; }
        public DbSet<InventoryVoucherDetail> InventoryVoucherDetails { get; set; }
        public DbSet<PaymentVoucher> PaymentVouchers { get; set; }
        public DbSet<ActivityLog> ActivityLog { get; set; }
        public DbSet<Leger> Legers { get; set; }
        public DbSet<OtherAccountEntry> OtherAccountEntries { get; set; }
        public DbSet<ShiftEndReport> ShiftEndReports { get; set; }
        public DbSet<ShiftHandovers> ShiftHandovers { get; set; }
        public DbSet<ShiftHandoverCashDetail> ShiftHandoverCashDetails { get; set; }
        public DbSet<InventoryAuditDetail> InventoryAuditDetails { get; set; }
        public DbSet<ShiftReport> ShiftReports { get; set; }
        public DbSet<ShiftEndReportView> ShiftEndReportViews { get; set; }

        // Add context to return tabbles
        public DbSet<InventoryVoucherResponseDto> InventoryVoucherResponseDto { get; set; }
        public DbSet<InventoryVoucherDetailResponseDto> InventoryVoucherDetailResponses { get; set; }
        public DbSet<ReceiptResponseDto> ReceiptResponseDtos { get; set; }
        public DbSet<ProductResponseDto> ProductResponseDtos { get; set; }
        public DbSet<PaymentMethodResponseDto> PaymentMethodResponseDtos { get; set; }
        public DbSet<UnitResponseDto> UnitResponseDtos { get; set; }
        public DbSet<LegerResponseDto> LegerResponseDtos { get; set; }
        public DbSet<ProductStorageInformationDto> ProductStorageInformationDtos { get; set; }
        public DbSet<PaymentVoucherResponseDto> PaymentVoucherResponseDtos { get; set; }
        public DbSet<OtherAccountEntryResponseDto> OtherAccountEntryResponseDtos { get; set; }
        public DbSet<BillPaymentDetailResponseDto> BillPaymentDetailResponseDtos { get; set; }
        public DbSet<ShiftEndResponseDto> ShiftEndResponseDtos { get; set; }
        public DbSet<ShiftHandoverResponseDto> ShiftHandoverResponseDtos { get; set; }
        public DbSet<ShiftReportResponseDto> ShiftReportResponseDtos { get; set; }
        public DbSet<AccountsDto> AccountDtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InventoryVoucherDetail>().HasKey(x => new { x.DocummentNumber, x.ProductId });
            modelBuilder.Entity<ShiftHandoverCashDetail>().HasKey(x => new { x.ShiftEndId, x.Denomination });
            modelBuilder.Entity<InventoryAuditDetail>().HasKey(x => new { x.ShiftEndId, x.ProductId, x.UnitId });

            // Dynamic Response functions

            foreach (var entityType in AccountingTableName.GenerateDynamicResponseDbSet())
            {
                modelBuilder.Entity(entityType);
            }

            // Exclude migration tables
            ConfigureExcluedTables(modelBuilder);

        }
        private void ConfigureExcluedTables(ModelBuilder modelBuilder)
        {
            try
            {
                var entityTypes = modelBuilder.Model.GetEntityTypes().ToList();
                int count = entityTypes.Count();
                for (int i = 0 ; i < count; i++)
                {
                    var entityType = entityTypes[i];
                    var tableName = entityType.GetTableName();
                    if (_migrationConfiguration.ExcludedTableTypes.Contains(entityType.ClrType) ||
                        _migrationConfiguration.ExcludedTableNames.Contains(tableName))
                    {
                        modelBuilder.Ignore(entityType.ClrType);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public IEnumerable<TEntity> ExecuteSqlForEntity<TEntity>(string sql) where TEntity : class
        {
            if (AccountingTableName.GenerateDynamicResponseDbSet().Contains(typeof(TEntity)))
            {
                return Set<TEntity>().FromSqlRaw(sql).AsNoTracking().ToList();
            }
            else
            {
                throw new ArgumentException("Invalid entity type.");
            }
        }

        // Create a function to calculate a scalar value
        public TResult CalculateScalarFunction<TResult>(string sql) where TResult : class
        {
            var resultCollection = Set<TResult>().FromSqlRaw(sql).AsNoTracking().ToList();

            // Now you can safely modify resultCollection if needed

            return resultCollection.Single();
        }

    }
}
