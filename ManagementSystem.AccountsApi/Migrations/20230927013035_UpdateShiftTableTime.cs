using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountsApi.Migrations
{
    public partial class UpdateShiftTableTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "EmployeeShifts");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "EmployeeShifts");

            migrationBuilder.AddColumn<int>(
                name: "EndHour",
                table: "EmployeeShifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EndMinute",
                table: "EmployeeShifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartHour",
                table: "EmployeeShifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartMinute",
                table: "EmployeeShifts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndHour",
                table: "EmployeeShifts");

            migrationBuilder.DropColumn(
                name: "EndMinute",
                table: "EmployeeShifts");

            migrationBuilder.DropColumn(
                name: "StartHour",
                table: "EmployeeShifts");

            migrationBuilder.DropColumn(
                name: "StartMinute",
                table: "EmployeeShifts");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "EmployeeShifts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "EmployeeShifts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
