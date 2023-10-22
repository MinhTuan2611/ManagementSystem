using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountsApi.Migrations
{
    public partial class updateTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBrands_Users_UserId",
                table: "UserBrands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBrands",
                table: "UserBrands");

            migrationBuilder.RenameTable(
                name: "UserBrands",
                newName: "UserBranchs");

            migrationBuilder.RenameIndex(
                name: "IX_UserBrands_UserId",
                table: "UserBranchs",
                newName: "IX_UserBranchs_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBranchs",
                table: "UserBranchs",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranchs_Users_UserId",
                table: "UserBranchs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBranchs_Users_UserId",
                table: "UserBranchs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBranchs",
                table: "UserBranchs");

            migrationBuilder.RenameTable(
                name: "UserBranchs",
                newName: "UserBrands");

            migrationBuilder.RenameIndex(
                name: "IX_UserBranchs_UserId",
                table: "UserBrands",
                newName: "IX_UserBrands_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBrands",
                table: "UserBrands",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBrands_Users_UserId",
                table: "UserBrands",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
