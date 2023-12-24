using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class updateShiftReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TotalOtherAmount",
                table: "ShiftReports",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalOtherAmount",
                table: "ShiftReports");
        }
    }
}
