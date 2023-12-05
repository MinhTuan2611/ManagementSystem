using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class updateforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryVoucherDetails",
                table: "InventoryVoucherDetails");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "InventoryVoucherDetails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryVoucherDetails",
                table: "InventoryVoucherDetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryVoucherDetails_DocummentNumber",
                table: "InventoryVoucherDetails",
                column: "DocummentNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryVoucherDetails",
                table: "InventoryVoucherDetails");

            migrationBuilder.DropIndex(
                name: "IX_InventoryVoucherDetails_DocummentNumber",
                table: "InventoryVoucherDetails");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "InventoryVoucherDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryVoucherDetails",
                table: "InventoryVoucherDetails",
                columns: new[] { "DocummentNumber", "ProductId", "UnitId" });
        }
    }
}
