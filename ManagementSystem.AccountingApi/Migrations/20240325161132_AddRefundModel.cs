using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class AddRefundModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExchangeItemVouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    RefundAmount = table.Column<float>(type: "real", nullable: false),
                    TotalExchangeProduct = table.Column<int>(type: "int", nullable: false),
                    TotalReturnProduct = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeItemVouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeProducts",
                columns: table => new
                {
                    ExchangeItemVoucherId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeProducts", x => new { x.ExchangeItemVoucherId, x.ProductId });
                });

            migrationBuilder.CreateTable(
                name: "ReturnProducts",
                columns: table => new
                {
                    ExchangeItemVoucherId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ReasonRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnProducts", x => new { x.ExchangeItemVoucherId, x.ProductId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeItemVouchers");

            migrationBuilder.DropTable(
                name: "ExchangeProducts");

            migrationBuilder.DropTable(
                name: "ReturnProducts");
        }
    }
}
