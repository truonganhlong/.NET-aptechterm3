using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OMR_Service.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TransferTime",
                table: "Transaction",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 15, 21, 11, 0, 791, DateTimeKind.Local).AddTicks(8953),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 802, DateTimeKind.Local).AddTicks(5525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Notification",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 15, 21, 11, 0, 773, DateTimeKind.Local).AddTicks(4628),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 796, DateTimeKind.Local).AddTicks(4274));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedback",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 15, 21, 11, 0, 766, DateTimeKind.Local).AddTicks(2993),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 793, DateTimeKind.Local).AddTicks(4093));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Employee",
                nullable: true,
                defaultValue: new DateTime(2023, 5, 15, 21, 11, 0, 740, DateTimeKind.Local).AddTicks(5401),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 782, DateTimeKind.Local).AddTicks(7529));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Customer",
                nullable: true,
                defaultValue: new DateTime(2023, 5, 15, 21, 11, 0, 801, DateTimeKind.Local).AddTicks(9069),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 805, DateTimeKind.Local).AddTicks(5533));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TransferTime",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 802, DateTimeKind.Local).AddTicks(5525),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2023, 5, 15, 21, 11, 0, 791, DateTimeKind.Local).AddTicks(8953));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 796, DateTimeKind.Local).AddTicks(4274),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2023, 5, 15, 21, 11, 0, 773, DateTimeKind.Local).AddTicks(4628));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedback",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 793, DateTimeKind.Local).AddTicks(4093),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2023, 5, 15, 21, 11, 0, 766, DateTimeKind.Local).AddTicks(2993));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Employee",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 782, DateTimeKind.Local).AddTicks(7529),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 5, 15, 21, 11, 0, 740, DateTimeKind.Local).AddTicks(5401));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 5, 13, 2, 0, 52, 805, DateTimeKind.Local).AddTicks(5533),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 5, 15, 21, 11, 0, 801, DateTimeKind.Local).AddTicks(9069));
        }
    }
}
