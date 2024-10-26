using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class suaMotelAndRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acreage",
                table: "Motel");

            migrationBuilder.AddColumn<byte>(
                name: "Area",
                table: "Room",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "PriceLatest",
                table: "Room",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4108));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4110));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1004,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4111));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1005,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4112));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1006,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4113));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1007,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1008,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4115));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1009,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4117));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1010,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4118));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4146));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4151));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4152));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1004,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4153));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1005,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4154));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1006,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4155));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1007,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4156));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1008,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4157));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1009,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4159));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1010,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(4160));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1001,
                column: "Rating",
                value: 1f);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 4f, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1003,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1002", 1002, 2f });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1004,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1003", 1003, 3f, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1005,
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1003", 1003, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1006,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1003", 1003, 1f, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1007,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1004", 1004, 3f, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1008,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 2f, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1009,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1005", 1005, 3f, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1010,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1005", 1005, 5f, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1011,
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1006", 1006, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1012,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1006", 1006, 3f });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1013,
                column: "Rating",
                value: 3f);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1014,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1006", 1006, 3f, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1015,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1006", 1006, 5f, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1016,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1007", 1007, 5f, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1017,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1007", 1007, 3f });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1018,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1007", 1007, 4f, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1019,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1007", 1007, 1f, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1020,
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1007", 1007, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1021,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1008", 1008, 4f, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1022,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1008", 1008, 5f, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1023,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1008", 1008, 4f, 1003 });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "Content", "MotelId", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1024, "Review cho MotelId 1008", 1008, 4f, 1001 },
                    { 1025, "Review cho MotelId 1008", 1008, 2f, 1003 },
                    { 1026, "Review cho MotelId 1009", 1009, 1f, 1001 },
                    { 1027, "Review cho MotelId 1009", 1009, 1f, 1002 },
                    { 1028, "Review cho MotelId 1009", 1009, 4f, 1001 },
                    { 1029, "Review cho MotelId 1009", 1009, 1f, 1002 },
                    { 1030, "Review cho MotelId 1009", 1009, 4f, 1002 },
                    { 1031, "Review cho MotelId 1010", 1010, 3f, 1002 },
                    { 1032, "Review cho MotelId 1010", 1010, 3f, 1002 },
                    { 1033, "Review cho MotelId 1010", 1010, 3f, 1003 },
                    { 1034, "Review cho MotelId 1010", 1010, 5f, 1001 }
                });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1001,
                columns: new[] { "Area", "PriceLatest" },
                values: new object[] { (byte)0, null });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "Area", "PriceLatest" },
                values: new object[] { (byte)0, null });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1003,
                columns: new[] { "Area", "PriceLatest" },
                values: new object[] { (byte)0, null });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1004,
                columns: new[] { "Area", "PriceLatest" },
                values: new object[] { (byte)0, null });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1005,
                columns: new[] { "Area", "PriceLatest" },
                values: new object[] { (byte)0, null });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1006,
                columns: new[] { "Area", "PriceLatest" },
                values: new object[] { (byte)0, null });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1007,
                columns: new[] { "Area", "PriceLatest" },
                values: new object[] { (byte)0, null });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1008,
                columns: new[] { "Area", "PriceLatest" },
                values: new object[] { (byte)0, null });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1009,
                columns: new[] { "Area", "PriceLatest" },
                values: new object[] { (byte)0, null });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1010,
                columns: new[] { "Area", "PriceLatest" },
                values: new object[] { (byte)0, null });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(3950));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(3953));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreateDate",
                value: new DateTime(2024, 10, 24, 13, 51, 7, 142, DateTimeKind.Local).AddTicks(3955));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1024);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1025);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1026);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1027);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1028);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1029);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1030);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1031);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1032);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1033);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1034);

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "PriceLatest",
                table: "Room");

            migrationBuilder.AddColumn<byte>(
                name: "Acreage",
                table: "Motel",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1001,
                columns: new[] { "Acreage", "CreateDate" },
                values: new object[] { (byte)0, new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1474) });

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "Acreage", "CreateDate" },
                values: new object[] { (byte)0, new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1480) });

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1003,
                columns: new[] { "Acreage", "CreateDate" },
                values: new object[] { (byte)0, new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1482) });

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1004,
                columns: new[] { "Acreage", "CreateDate" },
                values: new object[] { (byte)0, new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1483) });

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1005,
                columns: new[] { "Acreage", "CreateDate" },
                values: new object[] { (byte)0, new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1484) });

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1006,
                columns: new[] { "Acreage", "CreateDate" },
                values: new object[] { (byte)0, new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1485) });

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1007,
                columns: new[] { "Acreage", "CreateDate" },
                values: new object[] { (byte)0, new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1511) });

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1008,
                columns: new[] { "Acreage", "CreateDate" },
                values: new object[] { (byte)0, new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1513) });

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1009,
                columns: new[] { "Acreage", "CreateDate" },
                values: new object[] { (byte)0, new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1514) });

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1010,
                columns: new[] { "Acreage", "CreateDate" },
                values: new object[] { (byte)0, new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1515) });

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1547));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1549));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1004,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1550));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1005,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1551));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1006,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1552));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1007,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1008,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1554));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1009,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1556));

            migrationBuilder.UpdateData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1010,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1557));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1001,
                column: "Rating",
                value: 3f);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 1f, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1003,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1001", 1001, 5f });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1004,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1002", 1002, 2f, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1005,
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1002", 1002, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1006,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1002", 1002, 2f, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1007,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1003", 1003, 1f, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1008,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 4f, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1009,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1004", 1004, 4f, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1010,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1004", 1004, 4f, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1011,
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1005", 1005, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1012,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1005", 1005, 5f });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1013,
                column: "Rating",
                value: 1f);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1014,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1007", 1007, 4f, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1015,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1007", 1007, 4f, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1016,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1008", 1008, 3f, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1017,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1008", 1008, 4f });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1018,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1008", 1008, 3f, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1019,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1008", 1008, 5f, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1020,
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1008", 1008, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1021,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1009", 1009, 1f, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1022,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1010", 1010, 1f, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1023,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1010", 1010, 5f, 1001 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1354));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1357));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1358));
        }
    }
}
