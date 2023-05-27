using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OMR_Service.Migrations
{
    public partial class updatedatabseuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserDescription",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "User",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransferTime",
                table: "Transaction",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 802, DateTimeKind.Local).AddTicks(5525),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 248, DateTimeKind.Local).AddTicks(4367));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Notification",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 796, DateTimeKind.Local).AddTicks(4274),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 238, DateTimeKind.Local).AddTicks(5848));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedback",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 793, DateTimeKind.Local).AddTicks(4093),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 234, DateTimeKind.Local).AddTicks(4622));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Employee",
                nullable: true,
                defaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 782, DateTimeKind.Local).AddTicks(7529),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 224, DateTimeKind.Local).AddTicks(4449));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Customer",
                nullable: true,
                defaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 805, DateTimeKind.Local).AddTicks(5533),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 252, DateTimeKind.Local).AddTicks(7029));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "UserDescription",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransferTime",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 248, DateTimeKind.Local).AddTicks(4367),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 802, DateTimeKind.Local).AddTicks(5525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 238, DateTimeKind.Local).AddTicks(5848),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 796, DateTimeKind.Local).AddTicks(4274));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedback",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 234, DateTimeKind.Local).AddTicks(4622),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 793, DateTimeKind.Local).AddTicks(4093));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Employee",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 224, DateTimeKind.Local).AddTicks(4449),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 782, DateTimeKind.Local).AddTicks(7529));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Employee",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 5, 10, 0, 32, 40, 252, DateTimeKind.Local).AddTicks(7029),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 805, DateTimeKind.Local).AddTicks(5533));
        }
    }
}
