using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class UpdateProductTableFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TypesOfAccounts_AccountId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "TypesOfAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Products_AccountId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "BalanceType",
                table: "Products",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceType",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "TypesOfAccounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountParentId = table.Column<int>(type: "int", nullable: true),
                    AccountRank = table.Column<int>(type: "int", nullable: false),
                    BalanceType = table.Column<int>(type: "int", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HasAccountItem = table.Column<int>(type: "int", nullable: true),
                    HasCosting = table.Column<int>(type: "int", nullable: true),
                    ModifyBy = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TypesOfAccounts_AccountId",
                table: "Products",
                column: "AccountId",
                principalTable: "TypesOfAccounts",
                principalColumn: "AccountId");
        }
    }
}
