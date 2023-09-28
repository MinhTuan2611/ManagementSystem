using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class addtransactionRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentTransactionRef",
                table: "BillPayments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5049), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5057) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5065), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5065) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5066), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5067) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5068), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5068) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5069), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5070) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 6,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5075), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5075) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 7,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5077), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5077) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 8,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5078), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5079) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 9,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5080), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5080) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 10,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5082), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5083) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 11,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5084), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5084) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 12,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5085), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5086) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 13,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5087), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5087) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 14,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5089), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5089) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 15,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5090), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5091) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 16,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5092), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5092) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 17,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5093), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5094) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 18,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5096), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5096) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 19,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5097), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5098) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 20,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5099), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5099) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 21,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5101), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5101) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 22,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5102), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5102) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 23,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5141), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5141) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 24,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5142), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5143) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 25,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5144), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5144) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 26,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5146), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5146) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 27,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5147), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5148) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 28,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5149), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5149) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 29,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5150), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5151) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 30,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5152), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5152) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 31,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5153), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5154) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 32,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5155), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5155) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 33,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5156), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5157) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 34,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5159), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5159) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 35,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5161), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5161) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 36,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5162), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5162) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 37,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5164), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5164) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 38,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5165), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5166) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 39,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5167), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5167) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 40,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5168), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5169) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 41,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5170), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5170) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 42,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5171), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5172) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 43,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5173), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5173) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 44,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5175), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5175) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 45,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5176), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5177) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 46,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5178), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5178) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 47,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5179), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5180) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 48,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5181), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5181) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 49,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5182), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5183) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 50,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5184), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5184) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 51,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5185), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5186) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 52,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5187), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5187) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 53,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5188), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5189) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 54,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5190), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5190) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 55,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5191), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 56,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5193), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5193) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 57,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5194), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5195) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 58,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5196), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5196) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 59,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5197), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5198) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 60,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5199), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5199) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 61,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5200), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5201) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 62,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5202), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5202) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 63,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5203), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5204) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 64,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5205), new DateTime(2023, 9, 23, 23, 31, 55, 823, DateTimeKind.Local).AddTicks(5205) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentTransactionRef",
                table: "BillPayments");

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
    }
}
