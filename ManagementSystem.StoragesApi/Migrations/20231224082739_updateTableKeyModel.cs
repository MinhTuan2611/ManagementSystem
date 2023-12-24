using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class updateTableKeyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductUnitBranches",
                table: "ProductUnitBranches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductUnitBranches",
                table: "ProductUnitBranches",
                columns: new[] { "Id", "ProductUnitId", "BranchId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductUnitBranches",
                table: "ProductUnitBranches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductUnitBranches",
                table: "ProductUnitBranches",
                column: "Id");
        }
    }
}
