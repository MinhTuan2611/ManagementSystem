using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class UpdateVerifyBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchVerifications",
                table: "BranchVerifications");

            migrationBuilder.AlterColumn<string>(
                name: "VerifyPassword",
                table: "BranchVerifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BranchVerifications",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchVerifications",
                table: "BranchVerifications",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BranchVerifications_BranchId",
                table: "BranchVerifications",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchVerifications_Branches_BranchId",
                table: "BranchVerifications",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchVerifications_Branches_BranchId",
                table: "BranchVerifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchVerifications",
                table: "BranchVerifications");

            migrationBuilder.DropIndex(
                name: "IX_BranchVerifications_BranchId",
                table: "BranchVerifications");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BranchVerifications");

            migrationBuilder.AlterColumn<string>(
                name: "VerifyPassword",
                table: "BranchVerifications",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchVerifications",
                table: "BranchVerifications",
                columns: new[] { "BranchId", "VerifyPassword" });
        }
    }
}
