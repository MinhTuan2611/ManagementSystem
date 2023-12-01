using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class UpdateAccountingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryVoucherDetails",
                table: "InventoryVoucherDetails");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "ReceiptVouchers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "OtherAccountEntries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Legers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "InventoryVouchers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "InventoryVoucherDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "CreditVouchers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryVoucherDetails",
                table: "InventoryVoucherDetails",
                columns: new[] { "DocummentNumber", "ProductId", "UnitId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryVoucherDetails",
                table: "InventoryVoucherDetails");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "ReceiptVouchers");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "OtherAccountEntries");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Legers");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "InventoryVouchers");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "InventoryVoucherDetails");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "CreditVouchers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryVoucherDetails",
                table: "InventoryVoucherDetails",
                columns: new[] { "DocummentNumber", "ProductId" });
        }
    }
}
