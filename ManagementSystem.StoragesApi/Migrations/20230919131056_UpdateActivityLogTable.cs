using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class UpdateActivityLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLog_User_ActionUserId",
                table: "ActivityLog");

            migrationBuilder.RenameColumn(
                name: "ActionUserId",
                table: "ActivityLog",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityLog_ActionUserId",
                table: "ActivityLog",
                newName: "IX_ActivityLog_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "ItemNote",
                table: "RequestSampleItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "RequestSampleItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<int>(
                name: "RequestSampleId",
                table: "RequestSampleItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "RequestSampleItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5217), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5227) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5234), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5235) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5236), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5236) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5237), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5237) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5238), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5239) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 6,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5243), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5244) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 7,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5245), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5245) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 8,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5246), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5246) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 9,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5247), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5247) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 10,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5249), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5249) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 11,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5250), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5251) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 12,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5252), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5252) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 13,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5253), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5253) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 14,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5254), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5254) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 15,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5255), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5255) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 16,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5256), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5256) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 17,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5257), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5257) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 18,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5260), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5260) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 19,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5261), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5261) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 20,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5262), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5262) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 21,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5263), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5263) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 22,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5264), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5264) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 23,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5265), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5265) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 24,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5266), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5266) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 25,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5267), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5267) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 26,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5268), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5268) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 27,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5269), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5269) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 28,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5270), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5271) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 29,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5271), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5272) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 30,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5272), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5273) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 31,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5273), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5274) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 32,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5274), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5275) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 33,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5275), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5276) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 34,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5277), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5277) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 35,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5278), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5279) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 36,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5279), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5280) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 37,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5280), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5281) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 38,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5281), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5282) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 39,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5282), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5283) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 40,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5283), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5284) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 41,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5285), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5285) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 42,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5286), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5286) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 43,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5287), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5287) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 44,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5288), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5288) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 45,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5289), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5289) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 46,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5290), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5290) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 47,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5291), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5291) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 48,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5292), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5292) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 49,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5293), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5293) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 50,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5294), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5294) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 51,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5295), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5295) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 52,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5296), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5296) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 53,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5297), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5297) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 54,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5298), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5298) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 55,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5299), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5299) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 56,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5300), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5300) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 57,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5301), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5301) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 58,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5302), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5302) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 59,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5303), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5303) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 60,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5304), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5305) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 61,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5305), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5306) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 62,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5306), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5307) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 63,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5307), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5308) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 64,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5308), new DateTime(2023, 9, 19, 20, 10, 55, 809, DateTimeKind.Local).AddTicks(5309) });

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLog_User_UserId",
                table: "ActivityLog",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLog_User_UserId",
                table: "ActivityLog");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ActivityLog",
                newName: "ActionUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityLog_UserId",
                table: "ActivityLog",
                newName: "IX_ActivityLog_ActionUserId");

            migrationBuilder.AlterColumn<string>(
                name: "ItemNote",
                table: "RequestSampleItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "RequestSampleItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<int>(
                name: "RequestSampleId",
                table: "RequestSampleItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "RequestSampleItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 2);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLog_User_ActionUserId",
                table: "ActivityLog",
                column: "ActionUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
