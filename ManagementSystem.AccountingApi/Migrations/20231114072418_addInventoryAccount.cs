using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class addInventoryAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreditAccount",
                table: "InventoryVouchers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DebitAccount",
                table: "InventoryVouchers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ScalarResult<int>",
                columns: table => new
                {
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScalarResult<int>");

            migrationBuilder.DropColumn(
                name: "CreditAccount",
                table: "InventoryVouchers");

            migrationBuilder.DropColumn(
                name: "DebitAccount",
                table: "InventoryVouchers");
        }
    }
}
