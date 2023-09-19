using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class AddAnimalPartRefCodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalPartRefCodes",
                columns: table => new
                {
                    AnimalPartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalPartRefCodes", x => x.AnimalPartId);
                });

            migrationBuilder.InsertData(
                table: "AnimalPartRefCodes",
                columns: new[] { "AnimalPartId", "PartName", "RefCode" },
                values: new object[,]
                {
                    { 1, "Mũi", "001" },
                    { 2, "Nọng/má", "002" },
                    { 3, "Thủ/đầu", "003" },
                    { 4, "Tai", "004" },
                    { 5, "Cổ", "005" },
                    { 6, "Sườn vai", "006" },
                    { 7, "Thịt vai", "007" },
                    { 8, "Bắp giò", "008" },
                    { 9, "Dựng/Móng giò", "009" },
                    { 10, "Mỡ lưng", "010" },
                    { 11, "Cốt lết", "011" },
                    { 12, "Thăn", "012" },
                    { 13, "Sườn", "013" },
                    { 14, "Ba rọi", "014" },
                    { 15, "Thịt mông", "015" },
                    { 16, "Thịt đùi", "016" },
                    { 17, "Đuôi", "017" }
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6653), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6668) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6700), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6703) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6704), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6704) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6705), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6705) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6706), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6706) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 6,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6712), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6713) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 7,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6781), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6783) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 8,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6788), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6788) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 9,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6789), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6789) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 10,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6791), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6791) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 11,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6792), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6792) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 12,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6793), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6793) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 13,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6794), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6795) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 14,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6795), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6796) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 15,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6796), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6797) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 16,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6798), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6798) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 17,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6799), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6799) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 18,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6800), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6801) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 19,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6802), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6802) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 20,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6803), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6803) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 21,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6804), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6804) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 22,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6805), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6805) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 23,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6806), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6806) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 24,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6807), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6807) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 25,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6808), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6808) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 26,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6809), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6810) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 27,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6810), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6811) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 28,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6811), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6812) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 29,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6813), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6813) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 30,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6814), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6814) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 31,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6815), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6815) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 32,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6816), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6816) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 33,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6817), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6817) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 34,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6819), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6819) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 35,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6820), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6820) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 36,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6821), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6821) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 37,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6822), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6822) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 38,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6823), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6824) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 39,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6824), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6825) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 40,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6825), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6826) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 41,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6826), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6827) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 42,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6828), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6828) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 43,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6829), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6829) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 44,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6830), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6830) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 45,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6831), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6831) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 46,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6832), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6832) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 47,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6833), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6833) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 48,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6834), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6835) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 49,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6835), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6836) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 50,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6836), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6837) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 51,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6838), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6838) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 52,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6839), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6839) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 53,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6840), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 54,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6841), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6841) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 55,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6842), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6842) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 56,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6843), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6843) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 57,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6844), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6844) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 58,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6845), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6846) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 59,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6846), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6847) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 60,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6847), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6848) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 61,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6848), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6849) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 62,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6850), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 63,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6851), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6851) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 64,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6852), new DateTime(2023, 9, 16, 19, 9, 32, 712, DateTimeKind.Local).AddTicks(6852) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalPartRefCodes");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1008), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1020) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1026), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1026) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1028), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1028) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1029), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1029) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1030), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 6,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1033), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1033) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 7,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1034), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1034) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 8,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1035), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1036) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 9,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1036), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1037) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 10,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1038), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1039) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 11,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1039), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 12,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1040), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1041) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 13,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1042), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1042) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 14,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1043), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1043) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 15,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1044), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1044) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 16,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1045), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1045) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 17,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1046), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1046) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 18,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1048), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1048) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 19,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1049), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1049) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 20,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1050), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 21,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1051), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1051) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 22,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1052), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1053) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 23,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1053), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1054) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 24,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1055), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1055) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 25,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1056), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1056) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 26,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1057), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1057) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 27,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1058), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1058) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 28,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1059), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1059) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 29,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1060), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 30,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1061), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1061) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 31,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1062), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1063) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 32,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1063), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1064) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 33,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1064), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1065) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 34,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1067), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1067) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 35,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1068), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1068) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 36,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1069), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1069) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 37,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1070), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 38,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1071), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1071) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 39,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1072), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1073) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 40,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1073), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1074) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 41,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1074), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1075) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 42,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1076), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1076) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 43,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1077), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1077) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 44,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1078), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 45,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1079), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1079) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 46,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1080), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1080) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 47,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1081), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1081) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 48,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1082), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 49,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1083), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1083) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 50,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1084), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1085) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 51,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1085), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1086) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 52,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1087), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1087) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 53,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1088), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1089) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 54,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1089), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1090) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 55,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1090), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1091) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 56,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1091), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1092) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 57,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1093), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1093) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 58,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1094), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1094) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 59,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1095), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1095) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 60,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1122), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1124) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 61,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1125), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1125) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 62,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1126), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1127) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 63,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1127), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1128) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 64,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1128), new DateTime(2023, 9, 16, 18, 18, 6, 295, DateTimeKind.Local).AddTicks(1129) });
        }
    }
}
