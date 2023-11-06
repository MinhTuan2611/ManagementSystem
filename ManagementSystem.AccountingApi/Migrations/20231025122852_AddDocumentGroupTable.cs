using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class AddDocumentGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Receipts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "PaymentVouchers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "OtherAccountEntries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "InventoryVouchers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DocumentGroups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentGroups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "ScalarResult<int>",
                columns: table => new
                {
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_GroupId",
                table: "Receipts",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentVouchers_GroupId",
                table: "PaymentVouchers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherAccountEntries_GroupId",
                table: "OtherAccountEntries",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryVouchers_GroupId",
                table: "InventoryVouchers",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryVouchers_DocumentGroups_GroupId",
                table: "InventoryVouchers",
                column: "GroupId",
                principalTable: "DocumentGroups",
                principalColumn: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherAccountEntries_DocumentGroups_GroupId",
                table: "OtherAccountEntries",
                column: "GroupId",
                principalTable: "DocumentGroups",
                principalColumn: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentVouchers_DocumentGroups_GroupId",
                table: "PaymentVouchers",
                column: "GroupId",
                principalTable: "DocumentGroups",
                principalColumn: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_DocumentGroups_GroupId",
                table: "Receipts",
                column: "GroupId",
                principalTable: "DocumentGroups",
                principalColumn: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryVouchers_DocumentGroups_GroupId",
                table: "InventoryVouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherAccountEntries_DocumentGroups_GroupId",
                table: "OtherAccountEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentVouchers_DocumentGroups_GroupId",
                table: "PaymentVouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_DocumentGroups_GroupId",
                table: "Receipts");

            migrationBuilder.DropTable(
                name: "DocumentGroups");

            migrationBuilder.DropTable(
                name: "ScalarResult<int>");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_GroupId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_PaymentVouchers_GroupId",
                table: "PaymentVouchers");

            migrationBuilder.DropIndex(
                name: "IX_OtherAccountEntries_GroupId",
                table: "OtherAccountEntries");

            migrationBuilder.DropIndex(
                name: "IX_InventoryVouchers_GroupId",
                table: "InventoryVouchers");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "PaymentVouchers");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "OtherAccountEntries");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "InventoryVouchers");
        }
    }
}