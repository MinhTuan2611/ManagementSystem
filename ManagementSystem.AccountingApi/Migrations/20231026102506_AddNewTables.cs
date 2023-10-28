using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class AddNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.CreateTable(
                name: "CreditVouchers",
                columns: table => new
                {
                    DocumentNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    ForReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMoney = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditVouchers", x => x.DocumentNumber);
                    table.ForeignKey(
                        name: "FK_CreditVouchers_DocumentGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "DocumentGroups",
                        principalColumn: "GroupId");
                });

            migrationBuilder.CreateTable(
                name: "DebitVouchers",
                columns: table => new
                {
                    DocumentNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    DebitAccount = table.Column<int>(type: "int", nullable: true),
                    CreditAccount = table.Column<int>(type: "int", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalMoneyVND = table.Column<int>(type: "int", nullable: true),
                    ExchangeRate = table.Column<int>(type: "int", nullable: true),
                    NTMoney = table.Column<int>(type: "int", nullable: true),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitVouchers", x => x.DocumentNumber);
                    table.ForeignKey(
                        name: "FK_DebitVouchers_DocumentGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "DocumentGroups",
                        principalColumn: "GroupId");
                });

            migrationBuilder.CreateTable(
                name: "ReceiptVouchers",
                columns: table => new
                {
                    DocumentNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    ForReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMoney = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptVouchers", x => x.DocumentNumber);
                    table.ForeignKey(
                        name: "FK_ReceiptVouchers_DocumentGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "DocumentGroups",
                        principalColumn: "GroupId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditVouchers_GroupId",
                table: "CreditVouchers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitVouchers_GroupId",
                table: "DebitVouchers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptVouchers_GroupId",
                table: "ReceiptVouchers",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditVouchers");

            migrationBuilder.DropTable(
                name: "DebitVouchers");

            migrationBuilder.DropTable(
                name: "ReceiptVouchers");

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    DocumentNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    ForReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalMoney = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.DocumentNumber);
                    table.ForeignKey(
                        name: "FK_Receipts_DocumentGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "DocumentGroups",
                        principalColumn: "GroupId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_GroupId",
                table: "Receipts",
                column: "GroupId");
        }
    }
}
