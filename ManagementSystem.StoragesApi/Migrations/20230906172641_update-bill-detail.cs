using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class updatebilldetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "BillDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_BillId",
                table: "BillDetails",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_Bills_BillId",
                table: "BillDetails",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_Bills_BillId",
                table: "BillDetails");

            migrationBuilder.DropIndex(
                name: "IX_BillDetails_BillId",
                table: "BillDetails");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "BillDetails");
        }
    }
}
