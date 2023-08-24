using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class update_Type_of_account_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LiabilityType",
                table: "TypesOfAccounts",
                newName: "HasCosting");

            migrationBuilder.RenameColumn(
                name: "IsLiability",
                table: "TypesOfAccounts",
                newName: "HasAccountItem");

            migrationBuilder.AddColumn<int>(
                name: "BalanceType",
                table: "TypesOfAccounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentType",
                table: "Recordingtransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceType",
                table: "TypesOfAccounts");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Recordingtransactions");

            migrationBuilder.RenameColumn(
                name: "HasCosting",
                table: "TypesOfAccounts",
                newName: "LiabilityType");

            migrationBuilder.RenameColumn(
                name: "HasAccountItem",
                table: "TypesOfAccounts",
                newName: "IsLiability");
        }
    }
}
