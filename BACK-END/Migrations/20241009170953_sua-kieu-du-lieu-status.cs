using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class suakieudulieustatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "RoomType",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "RoomRental",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -5,
                column: "TimeCreate",
                value: new DateTime(2024, 10, 10, 0, 9, 53, 370, DateTimeKind.Local).AddTicks(8551));

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -4,
                column: "TimeCreate",
                value: new DateTime(2024, 10, 10, 0, 9, 53, 370, DateTimeKind.Local).AddTicks(8549));

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -3,
                column: "TimeCreate",
                value: new DateTime(2024, 10, 10, 0, 9, 53, 370, DateTimeKind.Local).AddTicks(8542));

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -2,
                column: "TimeCreate",
                value: new DateTime(2024, 10, 10, 0, 9, 53, 370, DateTimeKind.Local).AddTicks(8539));

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -1,
                column: "TimeCreate",
                value: new DateTime(2024, 10, 10, 0, 9, 53, 370, DateTimeKind.Local).AddTicks(8536));

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: -5,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: -4,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: -3,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: -2,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: -1,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -5,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 10, 0, 9, 53, 370, DateTimeKind.Local).AddTicks(8833));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -4,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 10, 0, 9, 53, 370, DateTimeKind.Local).AddTicks(8831));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -3,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 10, 0, 9, 53, 370, DateTimeKind.Local).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -2,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 10, 0, 9, 53, 370, DateTimeKind.Local).AddTicks(8829));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -1,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 10, 0, 9, 53, 370, DateTimeKind.Local).AddTicks(8827));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "RoomType",
                type: "bit",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "RoomRental",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -5,
                column: "TimeCreate",
                value: new DateTime(2024, 10, 10, 0, 7, 17, 289, DateTimeKind.Local).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -4,
                column: "TimeCreate",
                value: new DateTime(2024, 10, 10, 0, 7, 17, 289, DateTimeKind.Local).AddTicks(1428));

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -3,
                column: "TimeCreate",
                value: new DateTime(2024, 10, 10, 0, 7, 17, 289, DateTimeKind.Local).AddTicks(1425));

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -2,
                column: "TimeCreate",
                value: new DateTime(2024, 10, 10, 0, 7, 17, 289, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -1,
                column: "TimeCreate",
                value: new DateTime(2024, 10, 10, 0, 7, 17, 289, DateTimeKind.Local).AddTicks(1416));

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: -5,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: -4,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: -3,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: -2,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: -1,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -5,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 10, 0, 7, 17, 289, DateTimeKind.Local).AddTicks(1709));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -4,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 10, 0, 7, 17, 289, DateTimeKind.Local).AddTicks(1707));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -3,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 10, 0, 7, 17, 289, DateTimeKind.Local).AddTicks(1706));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -2,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 10, 0, 7, 17, 289, DateTimeKind.Local).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -1,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 10, 0, 7, 17, 289, DateTimeKind.Local).AddTicks(1701));
        }
    }
}
