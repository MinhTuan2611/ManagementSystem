using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class updatetablebill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAutoComplete",
                table: "Bills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "BillPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7041), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7050) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7059), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7059) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7061), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7061) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7063), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7063) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7064), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7065) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 6,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7073), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7073) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 7,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7074), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7075) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 8,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7076), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7076) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 9,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7078), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7078) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 10,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7080), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7081) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 11,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7082), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7082) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 12,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7083), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7084) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 13,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7085), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7086) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 14,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7087), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7087) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 15,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7088), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7089) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 16,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7090), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7090) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 17,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7092), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7092) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 18,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7094), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7095) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 19,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7096), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7096) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 20,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7098), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7098) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 21,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7099), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7100) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 22,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7101), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7102) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 23,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7103), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7103) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 24,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7104), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7105) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 25,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7106), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7107) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 26,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7108), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7108) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 27,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7110), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 28,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7111), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7112) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 29,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7113), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7113) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 30,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7114), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7115) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 31,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7116), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7117) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 32,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7118), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 33,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7119), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7120) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 34,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7122), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7122) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 35,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7124), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7124) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 36,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7125), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7126) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 37,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7127), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 38,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7129), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7129) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 39,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7130), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7131) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 40,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7132), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7132) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 41,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7134), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7134) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 42,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7135), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7136) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 43,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7137), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7137) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 44,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7138), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7139) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 45,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7140), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7141) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 46,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7142), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7142) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 47,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7143), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7144) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 48,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7145), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7146) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 49,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7147), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7147) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 50,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7148), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7149) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 51,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7150), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 52,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7152), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7152) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 53,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7153), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7154) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 54,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7155), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7155) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 55,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7157), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7157) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 56,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7158), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7159) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 57,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7160), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7160) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 58,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7162), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7162) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 59,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7163), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7164) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 60,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7165), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7165) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 61,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7166), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7167) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 62,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7168), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7169) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 63,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7170), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7170) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 64,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7171), new DateTime(2023, 9, 23, 22, 42, 7, 941, DateTimeKind.Local).AddTicks(7172) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAutoComplete",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "BillPayments");

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
