using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class AddDocumentInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityLog",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLog", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "InventoryVouchers",
                columns: table => new
                {
                    DocummentNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeShift = table.Column<int>(type: "int", nullable: false),
                    PurchasingRepresentive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepresentivePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonFor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryVouchers", x => x.DocummentNumber);
                });

            migrationBuilder.CreateTable(
                name: "PaymentVouchers",
                columns: table => new
                {
                    DocumentNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    DebitAccount = table.Column<int>(type: "int", nullable: false),
                    CreditAccount = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentVouchers", x => x.DocumentNumber);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    DocumentNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ForReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMoney = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.DocumentNumber);
                });

            migrationBuilder.CreateTable(
                name: "InventoryVoucherDetails",
                columns: table => new
                {
                    DocummentNumber = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    DebitAccount = table.Column<int>(type: "int", nullable: false),
                    CreditAccount = table.Column<int>(type: "int", nullable: false),
                    TotalMoneyBeforeTax = table.Column<int>(type: "int", nullable: false),
                    DebitAccountMoney = table.Column<int>(type: "int", nullable: false),
                    CreditAccountMoney = table.Column<int>(type: "int", nullable: false),
                    PaymentDiscountAccount = table.Column<int>(type: "int", nullable: false),
                    PaymentDiscountMoney = table.Column<int>(type: "int", nullable: false),
                    TaxAccount = table.Column<int>(type: "int", nullable: false),
                    TaxMoney = table.Column<int>(type: "int", nullable: false),
                    TotalMoneyAfterTax = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryVoucherDetails", x => new { x.DocummentNumber, x.ProductId });
                    table.ForeignKey(
                        name: "FK_InventoryVoucherDetails_InventoryVouchers_DocummentNumber",
                        column: x => x.DocummentNumber,
                        principalTable: "InventoryVouchers",
                        principalColumn: "DocummentNumber",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLog");

            migrationBuilder.DropTable(
                name: "InventoryVoucherDetails");

            migrationBuilder.DropTable(
                name: "PaymentVouchers");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "InventoryVouchers");
        }
    }
}
