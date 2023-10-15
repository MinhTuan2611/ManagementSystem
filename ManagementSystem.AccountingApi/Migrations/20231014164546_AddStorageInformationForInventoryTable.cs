using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class AddStorageInformationForInventoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "InventoryVoucherDetails");

            migrationBuilder.AddColumn<int>(
                name: "StorageId",
                table: "InventoryVouchers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "InventoryVouchers");

            migrationBuilder.AddColumn<int>(
                name: "StorageId",
                table: "InventoryVoucherDetails",
                type: "int",
                nullable: true);
        }
    }
}
