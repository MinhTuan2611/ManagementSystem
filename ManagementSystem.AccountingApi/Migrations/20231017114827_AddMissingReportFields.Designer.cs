﻿// <auto-generated />
using System;
using ManagementSystem.AccountingApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    [DbContext(typeof(AccountingDbContext))]
    [Migration("20231017114827_AddMissingReportFields")]
    partial class AddMissingReportFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

            modelBuilder.Entity("ManagementSystem.Common.Entities.InventoryAuditDetail", b =>
                {
                    b.Property<int>("ShiftEndId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<int>("ActualAmount")
                        .HasColumnType("int");

                    b.Property<int>("SystemAmount")
                        .HasColumnType("int");

                    b.HasKey("ShiftEndId", "ProductId", "UnitId");

                    b.ToTable("InventoryAuditDetails");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.InventoryVoucher", b =>
                {
                    b.Property<int>("DocummentNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocummentNumber"), 1L, 1);

                    b.Property<int?>("BillId")
                        .HasColumnType("int");

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

                    b.Property<int?>("StorageId")
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

            modelBuilder.Entity("ManagementSystem.Common.Entities.ShiftEndReport", b =>
                {
                    b.Property<int>("ShiftEndId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShiftEndId"), 1L, 1);

                    b.Property<int?>("CompanyMoneyTransferred")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShiftEndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ShiftId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ShiftEndId");

                    b.ToTable("ShiftEndReports");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.ShiftHandoverCashDetail", b =>
                {
                    b.Property<int>("ShiftEndId")
                        .HasColumnType("int");

                    b.Property<int>("Denomination")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("ShiftEndId", "Denomination");

                    b.ToTable("ShiftHandoverCashDetails");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.ShiftHandovers", b =>
                {
                    b.Property<int>("HandoverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HandoverId"), 1L, 1);

                    b.Property<int?>("CashHandover")
                        .HasColumnType("int");

                    b.Property<int?>("CompanyMoneyTransferred")
                        .HasColumnType("int");

                    b.Property<DateTime>("HandoverTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReceiverUserId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderUserI2")
                        .HasColumnType("int");

                    b.Property<int?>("SenderUserId1")
                        .HasColumnType("int");

                    b.Property<int>("ShiftEndId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StorageId")
                        .HasColumnType("int");

                    b.Property<int?>("TotalShiftMoney")
                        .HasColumnType("int");

                    b.HasKey("HandoverId");

                    b.HasIndex("ShiftEndId");

                    b.ToTable("ShiftHandovers");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.ShiftReport", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportId"), 1L, 1);

                    b.Property<int>("ActualMoneyForNextShift")
                        .HasColumnType("int");

                    b.Property<int>("ExcessMoney")
                        .HasColumnType("int");

                    b.Property<int?>("HandoverId")
                        .HasColumnType("int");

                    b.Property<int>("LackOfMoney")
                        .HasColumnType("int");

                    b.Property<int>("OtherExpense")
                        .HasColumnType("int");

                    b.Property<int>("RemindMoneyForNextShift")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReportDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ShiftId")
                        .HasColumnType("int");

                    b.Property<int>("TotalBill")
                        .HasColumnType("int");

                    b.Property<int>("TotalCardAmount")
                        .HasColumnType("int");

                    b.Property<int>("TotalCashAmount")
                        .HasColumnType("int");

                    b.Property<int>("TotalExpenses")
                        .HasColumnType("int");

                    b.Property<int>("TotalInternalConsumption")
                        .HasColumnType("int");

                    b.Property<int>("TotalMOMOAmount")
                        .HasColumnType("int");

                    b.Property<int>("TotalRevenue")
                        .HasColumnType("int");

                    b.Property<int>("TotalShiftInMoney")
                        .HasColumnType("int");

                    b.Property<int>("TotalVoucherAmount")
                        .HasColumnType("int");

                    b.Property<int?>("UserCreatedId")
                        .HasColumnType("int");

                    b.HasKey("ReportId");

                    b.HasIndex("HandoverId");

                    b.ToTable("ShiftReports");
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

            modelBuilder.Entity("ManagementSystem.Common.Models.Dtos.BillPaymentDetailResponseDto", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethodCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethodName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentTransactionRef")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BillPaymentDetailResponseDto", null, t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("ManagementSystem.Common.Models.Dtos.InventoryVoucherDetailResponseDto", b =>
                {
                    b.Property<string>("BarCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreditAccount")
                        .HasColumnType("int");

                    b.Property<int?>("CreditAccountMoney")
                        .HasColumnType("int");

                    b.Property<int?>("DebitAccount")
                        .HasColumnType("int");

                    b.Property<int?>("DebitAccountMoney")
                        .HasColumnType("int");

                    b.Property<int?>("DefaultPurchasePrice")
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

                    b.Property<int?>("Tax")
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
                    b.Property<int?>("BillId")
                        .HasColumnType("int");

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

                    b.Property<int?>("InventoryCreditAccout")
                        .HasColumnType("int");

                    b.Property<int?>("InventoryDebitAccount")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
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

            modelBuilder.Entity("ManagementSystem.Common.Models.Dtos.OtherAccountEntryResponseDto", b =>
                {
                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("BranchCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("ManagementSystem.Common.Models.Dtos.PaymentMethodResponseDto", b =>
                {
                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.ToTable("PaymentMethodResponseDto", null, t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("ManagementSystem.Common.Models.Dtos.PaymentVoucherResponseDto", b =>
                {
                    b.Property<string>("BranchCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExchangeRate")
                        .HasColumnType("int");

                    b.Property<int?>("NTMoney")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TotalMoneyVND")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.ToTable("PaymentVoucherResponseDto", null, t => t.ExcludeFromMigrations());
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

            modelBuilder.Entity("ManagementSystem.Common.Models.Dtos.ProductStorageInformationDto", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("StorageId")
                        .HasColumnType("int");

                    b.ToTable("ProductStorageInformationDto", null, t => t.ExcludeFromMigrations());
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

            modelBuilder.Entity("ManagementSystem.Common.Models.Dtos.UnitResponseDto", b =>
                {
                    b.Property<string>("UnitName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UnitResponseDtos", null, t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.InventoryAuditDetail", b =>
                {
                    b.HasOne("ManagementSystem.Common.Entities.ShiftEndReport", "ShiftEndReport")
                        .WithMany("InventoryAuditDetails")
                        .HasForeignKey("ShiftEndId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShiftEndReport");
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

            modelBuilder.Entity("ManagementSystem.Common.Entities.ShiftHandoverCashDetail", b =>
                {
                    b.HasOne("ManagementSystem.Common.Entities.ShiftEndReport", "ShiftEndReport")
                        .WithMany("ShiftHandoverCashDetails")
                        .HasForeignKey("ShiftEndId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShiftEndReport");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.ShiftHandovers", b =>
                {
                    b.HasOne("ManagementSystem.Common.Entities.ShiftEndReport", "ShiftEndReport")
                        .WithMany()
                        .HasForeignKey("ShiftEndId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShiftEndReport");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.ShiftReport", b =>
                {
                    b.HasOne("ManagementSystem.Common.Entities.ShiftHandovers", "ShiftHandovers")
                        .WithMany()
                        .HasForeignKey("HandoverId");

                    b.Navigation("ShiftHandovers");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.InventoryVoucher", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("ManagementSystem.Common.Entities.ShiftEndReport", b =>
                {
                    b.Navigation("InventoryAuditDetails");

                    b.Navigation("ShiftHandoverCashDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
