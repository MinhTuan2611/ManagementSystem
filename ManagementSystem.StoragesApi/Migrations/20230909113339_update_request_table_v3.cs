using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class update_request_table_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestItem_Requests_RequestId",
                table: "RequestItem");

            migrationBuilder.AlterColumn<string>(
                name: "BillNumber",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "RequestItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestItem_Requests_RequestId",
                table: "RequestItem",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestItem_Requests_RequestId",
                table: "RequestItem");

            migrationBuilder.AlterColumn<int>(
                name: "BillNumber",
                table: "Requests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "RequestItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestItem_Requests_RequestId",
                table: "RequestItem",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId");
        }
    }
}
