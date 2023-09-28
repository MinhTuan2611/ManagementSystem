using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class update_table_receipt_sample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ItemNote",
                table: "RequestSampleItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8242), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8257) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8270), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8271) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8273), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8273) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8324), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8325) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8327), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8327) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 6,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8334), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8334) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 7,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8335), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8336) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 8,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8337), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8337) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 9,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8338), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8339) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 10,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8342), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8343) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 11,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8344), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8344) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 12,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8345), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8346) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 13,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8347), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8347) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 14,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8348), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8349) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 15,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8350), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8350) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 16,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8351), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8352) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 17,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8354), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8355) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 18,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8357), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8358) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 19,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8359), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8359) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 20,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8360), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8361) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 21,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8362), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8362) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 22,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8363), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8364) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 23,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8365), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8365) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 24,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8366), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8367) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 25,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8368), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8369) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 26,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8370), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8370) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 27,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8371), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8372) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 28,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8373), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 29,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8374), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8375) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 30,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8376), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8376) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 31,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8377), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8378) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 32,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8379), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8380) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 33,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8381), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8381) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 34,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8384), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8384) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 35,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8385), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8386) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 36,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8387), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8387) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 37,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8389), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8389) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 38,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8390), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8391) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 39,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8392), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8393) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 40,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8394), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8395) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 41,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8396), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8396) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 42,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8400), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8400) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 43,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8401), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8402) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 44,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8403), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8403) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 45,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8405), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8405) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 46,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8406), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8406) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 47,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8408), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8408) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 48,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8409), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8410) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 49,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8411), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8411) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 50,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8412), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8413) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 51,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8414), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8414) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 52,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8415), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8415) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 53,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8417), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8417) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 54,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8418), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8418) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 55,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8420), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8421) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 56,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8422), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8422) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 57,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8423), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8424) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 58,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8426), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8426) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 59,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8427), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8428) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 60,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8429), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 61,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8431), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8431) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 62,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8432), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8433) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 63,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8434), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8434) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 64,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8435), new DateTime(2023, 9, 23, 17, 24, 47, 653, DateTimeKind.Local).AddTicks(8436) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "Requests",
                newName: "PaymentMethodId");

            migrationBuilder.AlterColumn<string>(
                name: "ItemNote",
                table: "RequestSampleItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
