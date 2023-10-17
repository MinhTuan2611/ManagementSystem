using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class AddKetCa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShiftEndReports",
                columns: table => new
                {
                    ShiftEndId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ShiftId = table.Column<int>(type: "int", nullable: true),
                    ShiftEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyMoneyTransferred = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftEndReports", x => x.ShiftEndId);
                });

            migrationBuilder.CreateTable(
                name: "InventoryAuditDetails",
                columns: table => new
                {
                    ShiftEndId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    ActualAmount = table.Column<int>(type: "int", nullable: false),
                    SystemAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryAuditDetails", x => new { x.ShiftEndId, x.ProductId, x.UnitId });
                    table.ForeignKey(
                        name: "FK_InventoryAuditDetails_ShiftEndReports_ShiftEndId",
                        column: x => x.ShiftEndId,
                        principalTable: "ShiftEndReports",
                        principalColumn: "ShiftEndId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftHandoverCashDetails",
                columns: table => new
                {
                    ShiftEndId = table.Column<int>(type: "int", nullable: false),
                    Denomination = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftHandoverCashDetails", x => new { x.ShiftEndId, x.Denomination });
                    table.ForeignKey(
                        name: "FK_ShiftHandoverCashDetails_ShiftEndReports_ShiftEndId",
                        column: x => x.ShiftEndId,
                        principalTable: "ShiftEndReports",
                        principalColumn: "ShiftEndId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftHandovers",
                columns: table => new
                {
                    HandoverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageId = table.Column<int>(type: "int", nullable: true),
                    CashHandover = table.Column<int>(type: "int", nullable: true),
                    SenderUserId1 = table.Column<int>(type: "int", nullable: true),
                    SenderUserI2 = table.Column<int>(type: "int", nullable: true),
                    ReceiverUserId = table.Column<int>(type: "int", nullable: true),
                    TotalShiftMoney = table.Column<int>(type: "int", nullable: true),
                    CompanyMoneyTransferred = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftEndId = table.Column<int>(type: "int", nullable: false),
                    HandoverTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftHandovers", x => x.HandoverId);
                    table.ForeignKey(
                        name: "FK_ShiftHandovers_ShiftEndReports_ShiftEndId",
                        column: x => x.ShiftEndId,
                        principalTable: "ShiftEndReports",
                        principalColumn: "ShiftEndId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftReports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftId = table.Column<int>(type: "int", nullable: true),
                    UserCreatedId = table.Column<int>(type: "int", nullable: true),
                    HandoverId = table.Column<int>(type: "int", nullable: true),
                    TotalBill = table.Column<int>(type: "int", nullable: false),
                    TotalShiftInMoney = table.Column<int>(type: "int", nullable: false),
                    TotalRevenue = table.Column<int>(type: "int", nullable: false),
                    TotalCashAmount = table.Column<int>(type: "int", nullable: false),
                    TotalVoucherAmount = table.Column<int>(type: "int", nullable: false),
                    TotalInternalConsumption = table.Column<int>(type: "int", nullable: false),
                    TotalMOMOAmount = table.Column<int>(type: "int", nullable: false),
                    TotalExpenses = table.Column<int>(type: "int", nullable: false),
                    OtherExpense = table.Column<int>(type: "int", nullable: false),
                    ActualMoneyForNextShift = table.Column<int>(type: "int", nullable: false),
                    RemindMoneyForNextShift = table.Column<int>(type: "int", nullable: false),
                    ExcessMoney = table.Column<int>(type: "int", nullable: false),
                    LackOfMoney = table.Column<int>(type: "int", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftReports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_ShiftReports_ShiftHandovers_HandoverId",
                        column: x => x.HandoverId,
                        principalTable: "ShiftHandovers",
                        principalColumn: "HandoverId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShiftHandovers_ShiftEndId",
                table: "ShiftHandovers",
                column: "ShiftEndId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftReports_HandoverId",
                table: "ShiftReports",
                column: "HandoverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryAuditDetails");

            migrationBuilder.DropTable(
                name: "ShiftHandoverCashDetails");

            migrationBuilder.DropTable(
                name: "ShiftReports");

            migrationBuilder.DropTable(
                name: "ShiftHandovers");

            migrationBuilder.DropTable(
                name: "ShiftEndReports");
        }
    }
}
