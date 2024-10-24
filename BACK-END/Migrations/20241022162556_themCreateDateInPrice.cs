using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class themCreateDateInPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Price",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1474));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1004,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1483));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1005,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1484));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1006,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1485));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1007,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1511));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1008,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1513));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1009,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1010,
                column: "CreateDate",
                value: new DateTime(2024, 10, 22, 23, 25, 54, 955, DateTimeKind.Local).AddTicks(1515));

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

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "Content", "MotelId", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1001, "Review cho MotelId 1001", 1001, 3f, 1002 },
                    { 1002, "Review cho MotelId 1001", 1001, 1f, 1001 },
                    { 1003, "Review cho MotelId 1001", 1001, 5f, 1001 },
                    { 1004, "Review cho MotelId 1002", 1002, 2f, 1002 },
                    { 1005, "Review cho MotelId 1002", 1002, 2f, 1002 },
                    { 1006, "Review cho MotelId 1002", 1002, 2f, 1003 },
                    { 1007, "Review cho MotelId 1003", 1003, 1f, 1001 },
                    { 1008, "Review cho MotelId 1004", 1004, 4f, 1002 },
                    { 1009, "Review cho MotelId 1004", 1004, 4f, 1002 },
                    { 1010, "Review cho MotelId 1004", 1004, 4f, 1001 },
                    { 1011, "Review cho MotelId 1005", 1005, 2f, 1003 },
                    { 1012, "Review cho MotelId 1005", 1005, 5f, 1003 },
                    { 1013, "Review cho MotelId 1006", 1006, 1f, 1002 },
                    { 1014, "Review cho MotelId 1007", 1007, 4f, 1003 },
                    { 1015, "Review cho MotelId 1007", 1007, 4f, 1003 },
                    { 1016, "Review cho MotelId 1008", 1008, 3f, 1003 },
                    { 1017, "Review cho MotelId 1008", 1008, 4f, 1002 },
                    { 1018, "Review cho MotelId 1008", 1008, 3f, 1002 },
                    { 1019, "Review cho MotelId 1008", 1008, 5f, 1002 },
                    { 1020, "Review cho MotelId 1008", 1008, 5f, 1003 },
                    { 1021, "Review cho MotelId 1009", 1009, 1f, 1001 },
                    { 1022, "Review cho MotelId 1010", 1010, 1f, 1003 },
                    { 1023, "Review cho MotelId 1010", 1010, 5f, 1001 }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1013);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1014);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1015);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1017);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1018);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1019);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1020);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1021);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1022);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1023);

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Price");

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreateDate",
                value: new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreateDate",
                value: new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6425));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreateDate",
                value: new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6428));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1004,
                column: "CreateDate",
                value: new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6429));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1005,
                column: "CreateDate",
                value: new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1006,
                column: "CreateDate",
                value: new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6431));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1007,
                column: "CreateDate",
                value: new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6433));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1008,
                column: "CreateDate",
                value: new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1009,
                column: "CreateDate",
                value: new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1010,
                column: "CreateDate",
                value: new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6436));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreateDate",
                value: new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreateDate",
                value: new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6243));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreateDate",
                value: new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6245));
        }
    }
}
