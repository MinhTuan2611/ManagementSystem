using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class UpdateProductColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BalanceType",
                table: "Products",
                newName: "DebitAccountId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Products",
                newName: "CreditAccountId");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2775), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2783) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2791), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2792) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2794), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2794) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2796) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2799), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2799) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 6,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2802), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2803) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 7,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2803), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2804) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 8,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2804), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2805) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 9,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2806), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2806) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 10,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2807), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2808) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 11,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2809), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2809) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 12,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2810), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2810) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 13,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2811), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2811) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 14,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2813), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2813) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 15,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2815), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2815) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 16,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2817), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2817) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 17,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2818), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2818) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 18,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2820), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2820) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 19,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2821), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2821) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 20,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2822), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2822) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 21,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2824), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2825) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 22,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2825), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2826) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 23,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2826), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2827) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 24,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2827), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 25,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2829), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2830) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 26,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2830), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2831) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 27,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2831), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2832) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 28,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2833), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2834) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 29,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2834), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2835) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 30,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2835), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2836) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 31,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2836), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2837) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 32,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2838), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2838) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 33,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2839), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2839) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 34,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2840), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2841) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 35,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2842), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2843) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 36,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2843), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2844) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 37,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2845), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2845) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 38,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2846), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2846) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 39,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2847), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2847) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 40,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2848), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2848) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 41,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2873), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2875) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 42,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2876), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2876) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 43,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2877), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2877) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 44,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2878), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2879) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 45,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2879), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2880) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 46,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2880), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2881) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 47,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2881), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2882) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 48,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2882), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2883) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 49,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2883), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2884) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 50,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2884), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2885) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 51,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2885), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 52,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2886), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2887) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 53,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2887), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2888) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 54,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2888), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2889) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 55,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2889), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2890) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 56,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2890), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2891) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 57,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2891), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2892) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 58,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2893), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2893) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 59,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2894), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2894) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 60,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2895), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2895) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 61,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2896), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 62,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2897), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2897) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 63,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2898), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2898) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 64,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2899), new DateTime(2023, 9, 26, 0, 46, 54, 734, DateTimeKind.Local).AddTicks(2899) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DebitAccountId",
                table: "Products",
                newName: "BalanceType");

            migrationBuilder.RenameColumn(
                name: "CreditAccountId",
                table: "Products",
                newName: "AccountId");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3214), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3225) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3232), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3232) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3234), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3234) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3235), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3235) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3236), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3237) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 6,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3239), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 7,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3240), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3241) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 8,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3242), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3242) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 9,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3243), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 10,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3245), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3245) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 11,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3246), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3246) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 12,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3247), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3247) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 13,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3248), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3248) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 14,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3249), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 15,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3250), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3251) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 16,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3251), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3252) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 17,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3253), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3253) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 18,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3254), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3255) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 19,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3255), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3256) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 20,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3257), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3257) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 21,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3258), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3258) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 22,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3259), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3259) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 23,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3260), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 24,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3261), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3261) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 25,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3262), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3262) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 26,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3263), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3263) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 27,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3264), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3265) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 28,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3265), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 29,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3266), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3267) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 30,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3267), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3268) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 31,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3269), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3269) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 32,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3270), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 33,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3271), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3271) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 34,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3273), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3273) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 35,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3274), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3274) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 36,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3275), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3276) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 37,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3276), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3277) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 38,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3277), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3278) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 39,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3278), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3279) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 40,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3279), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 41,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3281), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3281) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 42,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3282), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3282) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 43,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3311), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3313) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 44,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3314), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3315) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 45,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3316), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3316) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 46,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3317), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3317) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 47,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3318), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3318) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 48,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3319), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3319) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 49,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3320), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3320) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 50,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3321), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3321) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 51,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3322), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3322) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 52,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3323), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3324) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 53,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3324), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3325) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 54,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3325), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3326) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 55,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3326), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3327) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 56,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3328), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3328) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 57,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3329), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3329) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 58,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3330), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 59,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3331), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3331) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 60,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3332), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3332) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 61,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3333), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3333) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 62,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3334), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3334) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 63,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3335), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3335) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 64,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3336), new DateTime(2023, 9, 24, 22, 49, 27, 700, DateTimeKind.Local).AddTicks(3337) });
        }
    }
}
