using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class renameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_branchVerifications",
                table: "branchVerifications");

            migrationBuilder.RenameTable(
                name: "branchVerifications",
                newName: "BranchVerifications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchVerifications",
                table: "BranchVerifications",
                columns: new[] { "BranchId", "VerifyPassword" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchVerifications",
                table: "BranchVerifications");

            migrationBuilder.RenameTable(
                name: "BranchVerifications",
                newName: "branchVerifications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_branchVerifications",
                table: "branchVerifications",
                columns: new[] { "BranchId", "VerifyPassword" });
        }
    }
}
