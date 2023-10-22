using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountsApi.Migrations
{
    public partial class RenameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "UserBrands",
                newName: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBrands_UserId",
                table: "UserBrands",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBrands_Users_UserId",
                table: "UserBrands",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBrands_Users_UserId",
                table: "UserBrands");

            migrationBuilder.DropIndex(
                name: "IX_UserBrands_UserId",
                table: "UserBrands");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "UserBrands",
                newName: "BrandId");
        }
    }
}
