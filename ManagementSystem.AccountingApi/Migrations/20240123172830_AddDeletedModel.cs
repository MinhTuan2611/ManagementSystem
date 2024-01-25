using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class AddDeletedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditVoucherDeleted",
                columns: table => new
                {
                    DocumentNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMoney = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreditAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebitAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillId = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditVoucherDeleted", x => x.DocumentNumber);
                });

            migrationBuilder.CreateTable(
                name: "InventoryVoucherDeleted",
                columns: table => new
                {
                    DocummentNumber = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftId = table.Column<int>(type: "int", nullable: true),
                    StorageId = table.Column<int>(type: "int", nullable: true),
                    PurchasingRepresentive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepresentivePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonFor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebitAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryVoucherDeleted", x => x.DocummentNumber);
                });

            migrationBuilder.CreateTable(
                name: "InventoryVoucherDetailDeleted",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DocummentNumber = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    DebitAccount = table.Column<int>(type: "int", nullable: true),
                    CreditAccount = table.Column<int>(type: "int", nullable: true),
                    TotalMoneyBeforeTax = table.Column<float>(type: "real", nullable: true),
                    DebitAccountMoney = table.Column<int>(type: "int", nullable: true),
                    CreditAccountMoney = table.Column<int>(type: "int", nullable: true),
                    PaymentDiscountAccount = table.Column<int>(type: "int", nullable: true),
                    PaymentDiscountMoney = table.Column<int>(type: "int", nullable: true),
                    TaxAccount = table.Column<int>(type: "int", nullable: true),
                    TaxMoney = table.Column<int>(type: "int", nullable: true),
                    TotalMoneyAfterTax = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryVoucherDetailDeleted", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegerDeleted",
                columns: table => new
                {
                    LegerId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreditAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepositAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoccumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoccumentNumber = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    StorageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegerDeleted", x => x.LegerId);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptVoucherDeleted",
                columns: table => new
                {
                    DocumentNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMoney = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptVoucherDeleted", x => x.DocumentNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditVoucherDeleted");

            migrationBuilder.DropTable(
                name: "InventoryVoucherDeleted");

            migrationBuilder.DropTable(
                name: "InventoryVoucherDetailDeleted");

            migrationBuilder.DropTable(
                name: "LegerDeleted");

            migrationBuilder.DropTable(
                name: "ReceiptVoucherDeleted");
        }
    }
}
