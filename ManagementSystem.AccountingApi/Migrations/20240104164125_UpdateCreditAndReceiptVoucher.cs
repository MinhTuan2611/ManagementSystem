using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class UpdateCreditAndReceiptVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "ReceiptVouchers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "CreditVouchers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillId",
                table: "ReceiptVouchers");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "CreditVouchers");
        }
    }
}
