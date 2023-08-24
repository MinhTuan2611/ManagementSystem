using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class update_recording_transaction_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeOfVoucherName",
                table: "Recordingtransactions",
                newName: "ReasonName");

            migrationBuilder.RenameColumn(
                name: "TypeOfVoucherCode",
                table: "Recordingtransactions",
                newName: "ReasonGroup");

            migrationBuilder.AddColumn<string>(
                name: "ExpenseItem",
                table: "Recordingtransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReasonCode",
                table: "Recordingtransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpenseItem",
                table: "Recordingtransactions");

            migrationBuilder.DropColumn(
                name: "ReasonCode",
                table: "Recordingtransactions");

            migrationBuilder.RenameColumn(
                name: "ReasonName",
                table: "Recordingtransactions",
                newName: "TypeOfVoucherName");

            migrationBuilder.RenameColumn(
                name: "ReasonGroup",
                table: "Recordingtransactions",
                newName: "TypeOfVoucherCode");
        }
    }
}
