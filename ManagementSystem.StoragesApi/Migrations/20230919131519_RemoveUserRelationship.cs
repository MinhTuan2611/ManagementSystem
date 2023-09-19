using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class RemoveUserRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLog_User_UserId",
                table: "ActivityLog");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_ActivityLog_UserId",
                table: "ActivityLog");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLog_UserId",
                table: "ActivityLog",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLog_User_UserId",
                table: "ActivityLog",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
