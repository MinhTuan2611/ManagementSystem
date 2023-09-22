using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class AddSupplierAccoutForProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductSuppliers",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSuppliers", x => new { x.SupplierId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductSuppliers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSuppliers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfAccounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountParentId = table.Column<int>(type: "int", nullable: true),
                    HasAccountItem = table.Column<int>(type: "int", nullable: true),
                    HasCosting = table.Column<int>(type: "int", nullable: true),
                    BalanceType = table.Column<int>(type: "int", nullable: true),
                    AccountRank = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfAccounts", x => x.AccountId);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5270), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5281) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5290), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5291) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5293), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5294) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5295), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5296) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5297), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5298) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 6,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5303), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5303) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 7,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5305), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5305) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 8,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5307), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5307) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 9,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5310), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5311) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 10,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5314), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5314) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 11,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5316), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5316) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 12,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5318), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5318) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 13,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5319), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5320) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 14,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5321), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5322) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 15,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5323), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5324) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 16,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5325), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5326) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 17,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5327), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5328) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 18,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5379), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5380) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 19,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5383), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5384) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 20,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5385), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5386) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 21,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5387), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5388) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 22,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5391), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5392) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 23,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5393), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5394) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 24,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5395), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5396) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 25,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5397), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5398) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 26,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5399), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5400) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 27,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5401), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5402) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 28,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5403), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5404) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 29,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5405), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5406) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 30,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5407), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5408) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 31,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5409), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5410) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 32,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5411), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5411) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 33,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5413), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5413) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 34,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5416), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5417) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 35,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5418), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5419) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 36,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5420), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5421) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 37,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5422), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5423) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 38,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5424), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5425) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 39,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5426), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5426) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 40,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5428), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5428) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 41,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5430), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5430) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 42,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5433), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5434) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 43,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5435), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5436) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 44,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5437), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5438) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 45,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5439), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5439) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 46,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5441), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5441) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 47,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5443), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5443) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 48,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5444), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5445) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 49,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5446), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5447) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 50,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5448), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5449) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 51,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5450), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5451) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 52,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5452), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5453) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 53,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5454), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5455) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 54,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5456), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5456) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 55,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5458), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5458) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 56,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5460), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 57,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5462), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5462) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 58,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5463), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5464) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 59,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5465), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5466) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 60,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5467), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5468) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 61,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5469), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 62,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5473), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5474) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 63,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5475), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5475) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 64,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5477), new DateTime(2023, 9, 22, 21, 32, 48, 976, DateTimeKind.Local).AddTicks(5477) });

            migrationBuilder.CreateIndex(
                name: "IX_Products_AccountId",
                table: "Products",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSuppliers_ProductId",
                table: "ProductSuppliers",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TypesOfAccounts_AccountId",
                table: "Products",
                column: "AccountId",
                principalTable: "TypesOfAccounts",
                principalColumn: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TypesOfAccounts_AccountId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductSuppliers");

            migrationBuilder.DropTable(
                name: "TypesOfAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Products_AccountId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6490), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6501) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6510), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6510) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6511), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6512) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6513), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6513) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6514), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6514) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 6,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6518), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6518) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 7,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6519), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 8,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6520), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6521) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 9,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6521), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6522) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 10,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6523), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6524) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 11,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6524), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6525) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 12,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6526), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6526) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 13,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6527), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6527) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 14,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6528), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6528) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 15,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6529), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6529) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 16,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6530), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 17,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6531), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6531) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 18,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6533), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 19,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6564), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6567) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 20,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6568), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6568) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 21,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6569), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6570) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 22,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6570), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6571) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 23,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6572), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6572) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 24,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6573), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6573) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 25,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6574), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6574) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 26,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6575), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6575) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 27,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6576), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6576) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 28,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6577), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6577) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 29,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6578), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6578) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 30,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6579), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6580) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 31,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6580), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6581) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 32,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6581), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6582) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 33,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6583), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6583) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 34,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6584), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6585) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 35,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6586), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6586) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 36,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6587), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6587) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 37,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6588), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6588) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 38,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6589), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6589) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 39,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6590), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6590) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 40,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6591), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6591) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 41,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6592), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6593) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 42,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6593), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6594) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 43,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6594), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6595) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 44,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6595), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6596) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 45,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6597), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6597) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 46,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6598), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6598) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 47,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6599), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6599) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 48,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6600), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6600) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 49,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6601), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6601) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 50,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6602), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6602) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 51,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6603), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6604) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 52,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6604), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6605) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 53,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6605), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6606) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 54,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6607), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6607) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 55,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6608), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6608) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 56,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6609), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6609) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 57,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6610), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 58,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6611), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6611) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 59,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6612), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6612) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 60,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6613), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6613) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 61,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6614), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6614) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 62,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6615), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6616) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 63,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6616), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6617) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 64,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6617), new DateTime(2023, 9, 19, 20, 15, 18, 940, DateTimeKind.Local).AddTicks(6618) });
        }
    }
}
