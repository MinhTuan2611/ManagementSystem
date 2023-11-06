using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class UpdateInventoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryVoucherPaymentMethods");

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "InventoryVouchers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillId",
                table: "InventoryVouchers");

            migrationBuilder.CreateTable(
                name: "InventoryVoucherPaymentMethods",
                columns: table => new
                {
                    DocumentNumber = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    InventoryVoucherDocummentNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryVoucherPaymentMethods", x => new { x.DocumentNumber, x.PaymentMethodId });
                    table.ForeignKey(
                        name: "FK_InventoryVoucherPaymentMethods_InventoryVouchers_InventoryVoucherDocummentNumber",
                        column: x => x.InventoryVoucherDocummentNumber,
                        principalTable: "InventoryVouchers",
                        principalColumn: "DocummentNumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryVoucherPaymentMethods_InventoryVoucherDocummentNumber",
                table: "InventoryVoucherPaymentMethods",
                column: "InventoryVoucherDocummentNumber");
        }
    }
}
