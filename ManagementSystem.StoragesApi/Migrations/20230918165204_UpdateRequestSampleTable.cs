using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class UpdateRequestSampleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestSampleItem_Products_ProductId",
                table: "RequestSampleItem");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSampleItem_RequestSamples_RequestSampleId",
                table: "RequestSampleItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestSampleItem",
                table: "RequestSampleItem");

            migrationBuilder.DropIndex(
                name: "IX_RequestSampleItem_ProductId",
                table: "RequestSampleItem");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "RequestSamples");

            migrationBuilder.DropColumn(
                name: "RequestSampleItemId",
                table: "RequestSampleItem");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "RequestSampleItem");

            migrationBuilder.RenameTable(
                name: "RequestSampleItem",
                newName: "RequestSampleItems");

            migrationBuilder.RenameColumn(
                name: "StorageId",
                table: "RequestSamples",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "RequestSamples",
                newName: "RequestSampleNote");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "RequestSampleItems",
                newName: "ItemNote");

            migrationBuilder.RenameIndex(
                name: "IX_RequestSampleItem_RequestSampleId",
                table: "RequestSampleItems",
                newName: "IX_RequestSampleItems_RequestSampleId");

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
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "RequestSampleItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestSampleItems",
                table: "RequestSampleItems",
                columns: new[] { "ProductId", "RequestSampleId", "UnitId" });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLog",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionUserId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLog", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_ActivityLog_User_ActionUserId",
                        column: x => x.ActionUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RequestSampleItems_UnitId",
                table: "RequestSampleItems",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLog_ActionUserId",
                table: "ActivityLog",
                column: "ActionUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSampleItems_Products_ProductId",
                table: "RequestSampleItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSampleItems_RequestSamples_RequestSampleId",
                table: "RequestSampleItems",
                column: "RequestSampleId",
                principalTable: "RequestSamples",
                principalColumn: "RequestSampleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSampleItems_Unit_UnitId",
                table: "RequestSampleItems",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestSampleItems_Products_ProductId",
                table: "RequestSampleItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSampleItems_RequestSamples_RequestSampleId",
                table: "RequestSampleItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSampleItems_Unit_UnitId",
                table: "RequestSampleItems");

            migrationBuilder.DropTable(
                name: "ActivityLog");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestSampleItems",
                table: "RequestSampleItems");

            migrationBuilder.DropIndex(
                name: "IX_RequestSampleItems_UnitId",
                table: "RequestSampleItems");

            migrationBuilder.RenameTable(
                name: "RequestSampleItems",
                newName: "RequestSampleItem");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "RequestSamples",
                newName: "StorageId");

            migrationBuilder.RenameColumn(
                name: "RequestSampleNote",
                table: "RequestSamples",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "ItemNote",
                table: "RequestSampleItem",
                newName: "Note");

            migrationBuilder.RenameIndex(
                name: "IX_RequestSampleItems_RequestSampleId",
                table: "RequestSampleItem",
                newName: "IX_RequestSampleItem_RequestSampleId");

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "RequestSamples",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "RequestSampleItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<int>(
                name: "RequestSampleId",
                table: "RequestSampleItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "RequestSampleItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<int>(
                name: "RequestSampleItemId",
                table: "RequestSampleItem",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "RequestSampleItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestSampleItem",
                table: "RequestSampleItem",
                column: "RequestSampleItemId");

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

            migrationBuilder.CreateIndex(
                name: "IX_RequestSampleItem_ProductId",
                table: "RequestSampleItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSampleItem_Products_ProductId",
                table: "RequestSampleItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSampleItem_RequestSamples_RequestSampleId",
                table: "RequestSampleItem",
                column: "RequestSampleId",
                principalTable: "RequestSamples",
                principalColumn: "RequestSampleId");
        }
    }
}
