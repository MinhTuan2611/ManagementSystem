using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class UpdateSuplierRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "RequestSamples",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8575), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8584) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8590), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8590) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8592), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8592) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8593), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8593) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8594), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8594) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 6,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8596), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8596) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 7,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8597), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8597) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 8,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8598), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8598) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 9,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8599), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8599) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 10,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8601), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8601) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 11,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8603), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8603) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 12,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8604), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8604) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 13,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8605), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8605) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 14,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8606), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8606) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 15,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8607), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8607) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 16,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8608), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8608) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 17,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8609), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8609) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 18,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8611), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8611) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 19,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8612), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8612) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 20,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8613), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8613) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 21,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8614), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8614) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 22,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8615), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8615) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 23,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8616), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8616) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 24,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8617), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8617) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 25,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8618), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8618) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 26,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8619), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8619) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 27,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8620), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8620) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 28,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8621), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8621) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 29,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8622), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8622) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 30,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8623), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8623) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 31,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8624), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8624) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 32,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8625), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8625) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 33,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8626), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8626) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 34,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8628), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8628) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 35,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8629), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8629) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 36,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8630), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8631) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 37,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8631), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8632) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 38,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8632), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8633) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 39,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8633), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8634) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 40,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8634), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8635) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 41,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8636), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8636) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 42,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8637), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8637) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 43,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8638), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8638) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 44,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8639), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8639) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 45,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8640), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8640) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 46,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8641), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8641) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 47,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8642), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8642) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 48,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8643), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8643) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 49,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8644), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8644) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 50,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8645), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8645) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 51,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8646), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8646) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 52,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8647), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8647) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 53,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8648), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8648) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 54,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8649), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8649) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 55,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8650), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8650) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 56,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8651), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8651) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 57,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8652), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8652) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 58,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8653), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8654) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 59,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8654), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8655) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 60,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8655), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8656) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 61,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8656), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8657) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 62,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8657), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8658) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 63,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8658), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8659) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 64,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8685), new DateTime(2023, 9, 19, 0, 3, 37, 10, DateTimeKind.Local).AddTicks(8689) });

            migrationBuilder.CreateIndex(
                name: "IX_RequestSamples_SupplierId",
                table: "RequestSamples",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSamples_Suppliers_SupplierId",
                table: "RequestSamples",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestSamples_Suppliers_SupplierId",
                table: "RequestSamples");

            migrationBuilder.DropIndex(
                name: "IX_RequestSamples_SupplierId",
                table: "RequestSamples");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "RequestSamples");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6799), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6808) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6813), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6814) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6815), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6815) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6816), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6816) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6817), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6818) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 6,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6820), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6820) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 7,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6821), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6821) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 8,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6822), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6822) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 9,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6823), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6824) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 10,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6825), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6826) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 11,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6826), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6827) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 12,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6828), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6828) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 13,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6829), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6829) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 14,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6830), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6830) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 15,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6831), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6831) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 16,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6832), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6832) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 17,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6833), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6833) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 18,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6835), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6835) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 19,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6836), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6836) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 20,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6837), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6838) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 21,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6838), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6839) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 22,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6839), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 23,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6841), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6841) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 24,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6842), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6842) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 25,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6843), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6843) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 26,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6844), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6844) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 27,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6845), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6845) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 28,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6846), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6846) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 29,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6847), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6847) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 30,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6848), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6849) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 31,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6849), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 32,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6851), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6851) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 33,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6852), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6852) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 34,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6900), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6902) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 35,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6903), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6903) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 36,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6904), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6904) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 37,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6905), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6905) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 38,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6906), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6907) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 39,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6908), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6908) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 40,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6909), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6909) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 41,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6910), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 42,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6911), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6911) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 43,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6912), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6912) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 44,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6913), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6914) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 45,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6914), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6915) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 46,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6915), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6916) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 47,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6916), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6917) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 48,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6918), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6918) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 49,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6919), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6919) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 50,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6920), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6920) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 51,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6921), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6921) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 52,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6922), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6923) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 53,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6923), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6924) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 54,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6924), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6925) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 55,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6925), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6926) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 56,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6927), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6927) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 57,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6928), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6928) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 58,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6929), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6929) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 59,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6930), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 60,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6931), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6931) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 61,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6932), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6932) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 62,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6933), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6934) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 63,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6934), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6935) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 64,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6936), new DateTime(2023, 9, 18, 23, 52, 4, 610, DateTimeKind.Local).AddTicks(6936) });
        }
    }
}
