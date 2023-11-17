using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class addbranchtobill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Bills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BranchId",
                table: "Bills",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Branches_BranchId",
                table: "Bills",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Branches_BranchId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_BranchId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Bills");
        }
    }
}
