using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OMR_Service.Migrations
{
    public partial class UpdateDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TransferTime",
                table: "Transaction",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 248, DateTimeKind.Local).AddTicks(4367),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 7, 2, 34, 39, 27, DateTimeKind.Local).AddTicks(3483));

            migrationBuilder.AlterColumn<int>(
                name: "Days",
                table: "Transaction",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Days",
                table: "Service",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Notification",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 238, DateTimeKind.Local).AddTicks(5848),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 7, 2, 34, 39, 21, DateTimeKind.Local).AddTicks(3554));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedback",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 234, DateTimeKind.Local).AddTicks(4622),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 7, 2, 34, 39, 19, DateTimeKind.Local).AddTicks(3536));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Employee",
                nullable: true,
                defaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 224, DateTimeKind.Local).AddTicks(4449),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 5, 7, 2, 34, 39, 10, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Customer",
                nullable: true,
                defaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 252, DateTimeKind.Local).AddTicks(7029),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 5, 7, 2, 34, 39, 30, DateTimeKind.Local).AddTicks(3489));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Days",
                table: "Service");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransferTime",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 7, 2, 34, 39, 27, DateTimeKind.Local).AddTicks(3483),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 248, DateTimeKind.Local).AddTicks(4367));

            migrationBuilder.AlterColumn<int>(
                name: "Days",
                table: "Transaction",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 7, 2, 34, 39, 21, DateTimeKind.Local).AddTicks(3554),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 238, DateTimeKind.Local).AddTicks(5848));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedback",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 7, 2, 34, 39, 19, DateTimeKind.Local).AddTicks(3536),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 234, DateTimeKind.Local).AddTicks(4622));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Employee",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 5, 7, 2, 34, 39, 10, DateTimeKind.Local).AddTicks(2090),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 224, DateTimeKind.Local).AddTicks(4449));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 5, 7, 2, 34, 39, 30, DateTimeKind.Local).AddTicks(3489),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 252, DateTimeKind.Local).AddTicks(7029));
        }
    }
}
