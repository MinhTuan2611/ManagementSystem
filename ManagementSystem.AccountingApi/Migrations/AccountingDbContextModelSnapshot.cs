﻿// <auto-generated />
using System;
using ManagementSystem.AccountingApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    [DbContext(typeof(AccountingDbContext))]
    partial class AccountingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ManagementSystem.Common.Entities.Accountings.InventoryVoucherPaymentMethod", b =>
                {
                    b.Property<int>("DocumentNumber")
                        .HasColumnType("int");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<int?>("InventoryVoucherDocummentNumber")
                        .HasColumnType("int");

                    b.HasKey("DocumentNumber", "PaymentMethodId");

                    b.HasIndex("InventoryVoucherDocummentNumber");

                    b.ToTable("InventoryVoucherPaymentMethods");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.ActivityLog", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActivityId"), 1L, 1);

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ActivityId");

                    b.ToTable("ActivityLog");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.InventoryVoucher", b =>
                {
                    b.Property<int>("DocummentNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocummentNumber"), 1L, 1);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PurchasingRepresentive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonFor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepresentivePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShiftId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DocummentNumber");

                    b.ToTable("InventoryVouchers");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.InventoryVoucherDetail", b =>
                {
                    b.Property<int>("DocummentNumber")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("CreditAccount")
                        .HasColumnType("int");

                    b.Property<int?>("CreditAccountMoney")
                        .HasColumnType("int");

                    b.Property<int?>("DebitAccount")
                        .HasColumnType("int");

                    b.Property<int?>("DebitAccountMoney")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PaymentDiscountAccount")
                        .HasColumnType("int");

                    b.Property<int?>("PaymentDiscountMoney")
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("StorageId")
                        .HasColumnType("int");

                    b.Property<int?>("TaxAccount")
                        .HasColumnType("int");

                    b.Property<int?>("TaxMoney")
                        .HasColumnType("int");

                    b.Property<int?>("TotalMoneyAfterTax")
                        .HasColumnType("int");

                    b.Property<int?>("TotalMoneyBeforeTax")
                        .HasColumnType("int");

                    b.HasKey("DocummentNumber", "ProductId");

                    b.ToTable("InventoryVoucherDetails");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.Leger", b =>
                {
                    b.Property<int>("LegerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LegerId"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("BillId")
                        .HasColumnType("int");

                    b.Property<int?>("CreditAccount")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("DepositAccount")
                        .HasColumnType("int");

                    b.Property<int>("DoccumentNumber")
                        .HasColumnType("int");

                    b.Property<string>("DoccumentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StorageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LegerId");

                    b.ToTable("Legers");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.OtherAccountEntry", b =>
                {
                    b.Property<int>("DocumentNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentNumber"), 1L, 1);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DocumentNumber");

                    b.ToTable("OtherAccountEntries");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.PaymentVoucher", b =>
                {
                    b.Property<int>("DocumentNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentNumber"), 1L, 1);

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<int?>("CreditAccount")
                        .HasColumnType("int");

                    b.Property<int?>("DebitAccount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExchangeRate")
                        .HasColumnType("int");

                    b.Property<int?>("NTMoney")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShiftId")
                        .HasColumnType("int");

                    b.Property<int?>("TotalMoneyVND")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DocumentNumber");

                    b.ToTable("PaymentVouchers");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.Receipt", b =>
                {
                    b.Property<int>("DocumentNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentNumber"), 1L, 1);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("ForReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TotalMoney")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DocumentNumber");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.Recordingtransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreateBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreditAccountId")
                        .HasColumnType("int");

                    b.Property<int>("DebitAccountId")
                        .HasColumnType("int");

                    b.Property<string>("DocumentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpenseItem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ModifyBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Recordingtransactions");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.TypesOfAccounts", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"), 1L, 1);

                    b.Property<string>("AccountCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AccountParentId")
                        .HasColumnType("int");

                    b.Property<int>("AccountRank")
                        .HasColumnType("int");

                    b.Property<int?>("BalanceType")
                        .HasColumnType("int");

                    b.Property<int?>("CreateBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HasAccountItem")
                        .HasColumnType("int");

                    b.Property<int?>("HasCosting")
                        .HasColumnType("int");

                    b.Property<int?>("ModifyBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AccountId");

                    b.ToTable("TypesOfAccounts");
                });

            modelBuilder.Entity("ManagementSystem.Common.Models.Dtos.Accounting.OtherAccountEntryResponseDto", b =>
                {
                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("BranchCode")
                        .HasColumnType("int");

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("OtherAccountEntryResponseDto", null, t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("ManagementSystem.Common.Models.Dtos.Accounting.PaymentVoucherResponseDto", b =>
                {
                    b.Property<string>("BranchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BrandCode")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Receiver")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.ToTable("PaymentVoucherResponseDto", null, t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("ManagementSystem.Common.Models.Dtos.Accounting.ProductStorageInformationDto", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("StorageId")
                        .HasColumnType("int");

                    b.ToTable("ProductStorageInformationDto", null, t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("ManagementSystem.Common.Models.Dtos.Accounting.UnitResponseDto", b =>
                {
                    b.Property<string>("UnitName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UnitResponseDtos", null, t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("ManagementSystem.Common.Models.Dtos.InventoryVoucherDetailResponseDto", b =>
                {
                    b.Property<int?>("CreditAccount")
                        .HasColumnType("int");

                    b.Property<int?>("CreditAccountMoney")
                        .HasColumnType("int");

                    b.Property<int?>("DebitAccount")
                        .HasColumnType("int");

                    b.Property<int?>("DebitAccountMoney")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PaymentDiscountAccount")
                        .HasColumnType("int");

                    b.Property<int?>("PaymentDiscountMoney")
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("TaxAccount")
                        .HasColumnType("int");

                    b.Property<int?>("TaxMoney")
                        .HasColumnType("int");

                    b.Property<int?>("TotalMoneyAfterTax")
                        .HasColumnType("int");

                    b.Property<int?>("TotalMoneyBeforeTax")
                        .HasColumnType("int");

                    b.Property<string>("UnitName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("InventoryVoucherDetailResponseDto", null, t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("ManagementSystem.Common.Models.Dtos.InventoryVoucherResponseDto", b =>
                {
                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocummentNumber")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethodName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PurchasingRepresentive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonFor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepresentivePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StorageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.ToTable("InventoryVoucherResponseDto", null, t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("ManagementSystem.Common.Models.Dtos.LegerResponseDto", b =>
                {
                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("BillId")
                        .HasColumnType("int");

                    b.Property<int?>("CreditAccount")
                        .HasColumnType("int");

                    b.Property<int?>("DepositAccount")
                        .HasColumnType("int");

                    b.Property<int?>("DoccumentNumber")
                        .HasColumnType("int");

                    b.Property<string>("DoccumentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.ToTable("LegerResponseDto", null, t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("ManagementSystem.Common.Models.Dtos.PaymentMethodResponseDto", b =>
                {
                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.ToTable("PaymentMethodResponseDto", null, t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("ManagementSystem.Common.Models.Dtos.ProductResponseDto", b =>
                {
                    b.Property<int?>("CreditAccountId")
                        .HasColumnType("int");

                    b.Property<int?>("DebitAccountId")
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("PriceBeforeTax")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ProductResponseDto", null, t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("ManagementSystem.Common.Models.Dtos.ReceiptResponseDto", b =>
                {
                    b.Property<string>("Cashier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("int");

                    b.Property<string>("ForReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Payer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TotalMoney")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.ToTable("ReceiptResponseDto", null, t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.Accountings.InventoryVoucherPaymentMethod", b =>
                {
                    b.HasOne("ManagementSystem.Common.Entities.InventoryVoucher", null)
                        .WithMany("PaymentMethods")
                        .HasForeignKey("InventoryVoucherDocummentNumber");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.InventoryVoucherDetail", b =>
                {
                    b.HasOne("ManagementSystem.Common.Entities.InventoryVoucher", "InventoryVoucher")
                        .WithMany("Details")
                        .HasForeignKey("DocummentNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InventoryVoucher");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.InventoryVoucher", b =>
                {
                    b.Navigation("Details");

                    b.Navigation("PaymentMethods");
                });
#pragma warning restore 612, 618
        }
    }
}
