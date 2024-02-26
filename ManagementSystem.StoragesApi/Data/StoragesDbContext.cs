using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Entities.Bills;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<RevenueGroup> RevenueGroups { get; set; }
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
        public DbSet<ProductUnitBranch> ProductUnitBranches { get; set; }
        public DbSet<BillDeleted> BillDeleted { get; set; }
        public DbSet<BillPaymentDeleted> BillPaymentDeleted { get; set; }
        public DbSet<BillDetailDeleted> BillDetailDeleted { get; set; }
        public DbSet<BranchVerification> BranchVerifications { get; set; }

        // Response Value
        public DbSet<CustomerResponseDto> customerResponseDtos { get; set; }
        public DbSet<BillSearchingResponseDto> billSearchingResponseDtos { get; set; }
        public DbSet<BillDetailResponseDto> BillDetailResponseDtos { get; set; }
        public DbSet<BillPaymentDetailResponseDto> BillPaymentDetailResponseDtos { get; set; }
        public DbSet<PaymentMethodDto> PaymentMethodDtos { get; set; }
        public DbSet<ProductAutoGenerationResponseDto> ProductAutoGenerationResponseDtos { get; set; }
        public DbSet<EmployeeShiftInformationDto> EmployeeShiftInformationDtos { get; set; }
        public DbSet<ProductUnitBranchResponseDto> ProductUnitBranchResponseDtos { get; set; }
        public DbSet<DiscountInformationDto> DiscountInformationDtos { get; set; }
        public DbSet<BillRevenueInformationDto> BillRevenueInformationDtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductUnitBranch>().HasKey(x => new {x.Id, x.ProductUnitId, x.BranchId});
            modelBuilder.Entity<RequestSampleItem>().HasKey(x => new {x.ProductId, x.RequestSampleId, x.UnitId});
            modelBuilder.Entity<ProductSupplier>().HasKey(x => new { x.SupplierId, x.ProductId });
            modelBuilder.Entity<CustomerResponseDto>().ToTable(nameof(CustomerResponseDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<BillSearchingResponseDto>().ToTable(nameof(BillSearchingResponseDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<BillDetailResponseDto>().ToTable(nameof(BillDetailResponseDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<BillPaymentDetailResponseDto>().ToTable(nameof(BillPaymentDetailResponseDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<PaymentMethodDto>().ToTable(nameof(PaymentMethodDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ProductAutoGenerationResponseDto>().ToTable(nameof(ProductAutoGenerationResponseDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<EmployeeShiftInformationDto>().ToTable(nameof(EmployeeShiftInformationDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ProductUnitBranchResponseDto>().ToTable(nameof(ProductUnitBranchResponseDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<DiscountInformationDto>().ToTable(nameof(DiscountInformationDto), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<BillRevenueInformationDto>().ToTable(nameof(BillRevenueInformationDto), t => t.ExcludeFromMigrations());

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(x => x.ProductUnSignSearching)
                    .IsUnique(false)
                    .IsClustered(false)
                    .HasDatabaseName("idx_productUnSignSearch");
            });

            modelBuilder.Entity<ProductUnit>(entity =>
            {
                entity.HasIndex(x => x.Barcode)
                    .IsUnique(false)
                    .IsClustered(false)
                    .HasDatabaseName("idx_productUnitBarcode");
            });
        }
    }
}

