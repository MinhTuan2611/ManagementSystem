using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class AddMissingAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreditAccount",
                table: "OtherAccountEntries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DebitAccount",
                table: "OtherAccountEntries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreditAccount",
                table: "CreditVouchers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DebitAccount",
                table: "CreditVouchers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditAccount",
                table: "OtherAccountEntries");

            migrationBuilder.DropColumn(
                name: "DebitAccount",
                table: "OtherAccountEntries");

            migrationBuilder.DropColumn(
                name: "CreditAccount",
                table: "CreditVouchers");

            migrationBuilder.DropColumn(
                name: "DebitAccount",
                table: "CreditVouchers");
        }
    }
}
