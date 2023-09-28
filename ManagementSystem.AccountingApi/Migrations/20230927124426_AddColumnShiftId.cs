using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class AddColumnShiftId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeShift",
                table: "InventoryVouchers",
                newName: "ShiftId");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "InventoryVouchers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryVoucherPaymentMethods");

            migrationBuilder.RenameColumn(
                name: "ShiftId",
                table: "InventoryVouchers",
                newName: "EmployeeShift");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "InventoryVouchers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
