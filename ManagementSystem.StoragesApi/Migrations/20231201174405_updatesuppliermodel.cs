using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class updatesuppliermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayAddress",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MSThue",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PTTT",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayAddress",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "MSThue",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "PTTT",
                table: "Suppliers");
        }
    }
}
