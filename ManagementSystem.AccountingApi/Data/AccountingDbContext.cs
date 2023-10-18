using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.AccountingApi.Data
{
    public class AccountingDbContext : DbContext
    {
        public AccountingDbContext(DbContextOptions<AccountingDbContext> options) : base(options)
        {

        }

        public DbSet<TypesOfAccounts> TypesOfAccounts { get; set; }
        public DbSet<Recordingtransaction> Recordingtransactions { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<InventoryVoucher> InventoryVouchers { get; set;}
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

        
        // Add context to return tabbles
        public DbSet<InventoryVoucherResponseDto> InventoryVoucherResponseDto { get; set; }
        public DbSet<InventoryVoucherDetailResponseDto> InventoryVoucherDetailResponses { get; set; }
        public DbSet<ReceiptResponseDto> ReceiptResponseDtos { get; set; }
        public DbSet<ProductResponseDto> ProductResponseDtos { get; set; }
        public DbSet<PaymentMethodResponseDto> PaymentMethodResponseDtos { get; set; }
        public DbSet<UnitResponseDto> UnitResponseDtos  { get; set; }
        public DbSet<LegerResponseDto> LegerResponseDtos { get; set; }
        public DbSet<ProductStorageInformationDto> ProductStorageInformationDtos { get; set; }
        public DbSet<PaymentVoucherResponseDto> PaymentVoucherResponseDtos { get; set; }
        public DbSet<OtherAccountEntryResponseDto> OtherAccountEntryResponseDtos { get; set; }
        public DbSet<BillPaymentDetailResponseDto> BillPaymentDetailResponseDtos { get; set; }
        public DbSet<ShiftEndResponseDto> ShiftEndResponseDtos { get; set; }
        public DbSet<ShiftHandoverResponseDto> ShiftHandoverResponseDtos { get; set; }
        public DbSet<ShiftReportResponseDto> ShiftReportResponseDtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InventoryVoucherDetail>().HasKey(x => new { x.DocummentNumber, x.ProductId });
            modelBuilder.Entity<ShiftHandoverCashDetail>().HasKey(x => new {x.ShiftEndId, x.Denomination});
            modelBuilder.Entity<InventoryAuditDetail>().HasKey(x => new {x.ShiftEndId, x.ProductId, x.UnitId});

            // Exclude migration tables
            modelBuilder.Entity<InventoryVoucherResponseDto>().ToTable(nameof(InventoryVoucherResponseDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<InventoryVoucherDetailResponseDto>().ToTable(nameof(InventoryVoucherDetailResponseDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ReceiptResponseDto>().ToTable(nameof(ReceiptResponseDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ProductResponseDto>().ToTable(nameof(ProductResponseDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<PaymentMethodResponseDto>().ToTable(nameof(PaymentMethodResponseDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<UnitResponseDto>().ToTable(nameof(UnitResponseDtos), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ProductStorageInformationDto>().ToTable(nameof(ProductStorageInformationDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<LegerResponseDto>().ToTable(nameof(LegerResponseDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<PaymentVoucherResponseDto>().ToTable(nameof(PaymentVoucherResponseDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<OtherAccountEntryResponseDto>().ToTable(nameof(OtherAccountEntryResponseDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<BillPaymentDetailResponseDto>().ToTable(nameof(BillPaymentDetailResponseDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ShiftEndResponseDto>().ToTable(nameof(ShiftEndResponseDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ShiftHandoverResponseDto>().ToTable(nameof(ShiftHandoverResponseDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ShiftReportResponseDto>().ToTable(nameof(ShiftReportResponseDto), t => t.ExcludeFromMigrations());
        }
    }
}
