using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class updatetoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1001,
                column: "Time",
                value: new DateTime(2024, 10, 20, 20, 58, 36, 579, DateTimeKind.Local).AddTicks(4157));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1002,
                column: "Time",
                value: new DateTime(2024, 9, 20, 20, 58, 36, 579, DateTimeKind.Local).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1003,
                column: "Time",
                value: new DateTime(2024, 8, 20, 20, 58, 36, 579, DateTimeKind.Local).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1004,
                column: "Time",
                value: new DateTime(2024, 7, 20, 20, 58, 36, 579, DateTimeKind.Local).AddTicks(4178));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1005,
                column: "Time",
                value: new DateTime(2024, 6, 20, 20, 58, 36, 579, DateTimeKind.Local).AddTicks(4179));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1006,
                column: "Time",
                value: new DateTime(2024, 5, 20, 20, 58, 36, 579, DateTimeKind.Local).AddTicks(4181));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1007,
                column: "Time",
                value: new DateTime(2024, 4, 20, 20, 58, 36, 579, DateTimeKind.Local).AddTicks(4182));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1008,
                column: "Time",
                value: new DateTime(2024, 3, 20, 20, 58, 36, 579, DateTimeKind.Local).AddTicks(4183));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1009,
                column: "Time",
                value: new DateTime(2024, 2, 20, 20, 58, 36, 579, DateTimeKind.Local).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1010,
                column: "Time",
                value: new DateTime(2024, 1, 20, 20, 58, 36, 579, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "Rental",
                keyColumn: "Id",
                keyValue: 1001,
                columns: new[] { "TimeEnd", "TimeStart" },
                values: new object[] { new DateTime(2024, 9, 20, 20, 58, 36, 579, DateTimeKind.Local).AddTicks(4217), new DateTime(2024, 8, 20, 20, 58, 36, 579, DateTimeKind.Local).AddTicks(4216) });

            migrationBuilder.UpdateData(
                table: "Rental",
                keyColumn: "Id",
                keyValue: 1002,
                column: "TimeStart",
                value: new DateTime(2024, 9, 20, 20, 58, 36, 579, DateTimeKind.Local).AddTicks(4221));

            migrationBuilder.UpdateData(
                table: "Rental",
                keyColumn: "Id",
                keyValue: 1003,
                column: "TimeStart",
                value: new DateTime(2024, 7, 20, 20, 58, 36, 579, DateTimeKind.Local).AddTicks(4224));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1001,
                column: "UserId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1002,
                column: "UserId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1003,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1002", 1002, 5m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1004,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1002", 1002, 5m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1005,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1003", 1003, 1m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1006,
                columns: new[] { "Content", "MotelId" },
                values: new object[] { "Review cho MotelId 1003", 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1007,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1003", 1003, 1m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1008,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1004", 1004, 5m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1009,
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1004", 1004, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1010,
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1004", 1004, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1011,
                column: "Rating",
                value: 2m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1012,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1005", 1005, 1m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1014,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 4m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1015,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1006", 1006, 4m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1016,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1006", 1006, 4m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1017,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1006", 1006, 4m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1018,
                column: "Rating",
                value: 2m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1019,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 1m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1020,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1007", 1007, 3m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1021,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1007", 1007, 1m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1022,
                column: "Rating",
                value: 3m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1023,
                column: "Rating",
                value: 3m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1024,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1008", 1008, 3m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1025,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1008", 1008, 1m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1026,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1008", 1008, 5m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1027,
                columns: new[] { "Content", "MotelId" },
                values: new object[] { "Review cho MotelId 1009", 1009 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1028,
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1010", 1010, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1029,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1010", 1010, 4m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1030,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1010", 1010, 5m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1031,
                column: "UserId",
                value: 1002);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1001,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 20, 20, 58, 36, 579, DateTimeKind.Local).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1002,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 20, 20, 58, 36, 579, DateTimeKind.Local).AddTicks(3806));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1003,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 20, 20, 58, 36, 579, DateTimeKind.Local).AddTicks(3808));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1001,
                column: "Time",
                value: new DateTime(2024, 10, 20, 20, 15, 59, 542, DateTimeKind.Local).AddTicks(2233));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1002,
                column: "Time",
                value: new DateTime(2024, 9, 20, 20, 15, 59, 542, DateTimeKind.Local).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1003,
                column: "Time",
                value: new DateTime(2024, 8, 20, 20, 15, 59, 542, DateTimeKind.Local).AddTicks(2244));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1004,
                column: "Time",
                value: new DateTime(2024, 7, 20, 20, 15, 59, 542, DateTimeKind.Local).AddTicks(2245));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1005,
                column: "Time",
                value: new DateTime(2024, 6, 20, 20, 15, 59, 542, DateTimeKind.Local).AddTicks(2246));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1006,
                column: "Time",
                value: new DateTime(2024, 5, 20, 20, 15, 59, 542, DateTimeKind.Local).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1007,
                column: "Time",
                value: new DateTime(2024, 4, 20, 20, 15, 59, 542, DateTimeKind.Local).AddTicks(2249));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1008,
                column: "Time",
                value: new DateTime(2024, 3, 20, 20, 15, 59, 542, DateTimeKind.Local).AddTicks(2250));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1009,
                column: "Time",
                value: new DateTime(2024, 2, 20, 20, 15, 59, 542, DateTimeKind.Local).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1010,
                column: "Time",
                value: new DateTime(2024, 1, 20, 20, 15, 59, 542, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.UpdateData(
                table: "Rental",
                keyColumn: "Id",
                keyValue: 1001,
                columns: new[] { "TimeEnd", "TimeStart" },
                values: new object[] { new DateTime(2024, 9, 20, 20, 15, 59, 542, DateTimeKind.Local).AddTicks(2269), new DateTime(2024, 8, 20, 20, 15, 59, 542, DateTimeKind.Local).AddTicks(2268) });

            migrationBuilder.UpdateData(
                table: "Rental",
                keyColumn: "Id",
                keyValue: 1002,
                column: "TimeStart",
                value: new DateTime(2024, 9, 20, 20, 15, 59, 542, DateTimeKind.Local).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "Rental",
                keyColumn: "Id",
                keyValue: 1003,
                column: "TimeStart",
                value: new DateTime(2024, 7, 20, 20, 15, 59, 542, DateTimeKind.Local).AddTicks(2274));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1001,
                column: "UserId",
                value: 1002);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1002,
                column: "UserId",
                value: 1002);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1003,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1001", 1001, 2m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1004,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1001", 1001, 3m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1005,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1002", 1002, 3m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1006,
                columns: new[] { "Content", "MotelId" },
                values: new object[] { "Review cho MotelId 1002", 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1007,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1002", 1002, 4m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1008,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1003", 1003, 4m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1009,
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1003", 1003, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1010,
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1003", 1003, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1011,
                column: "Rating",
                value: 3m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1012,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1004", 1004, 4m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1014,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 5m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1015,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1005", 1005, 1m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1016,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1005", 1005, 2m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1017,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1005", 1005, 3m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1018,
                column: "Rating",
                value: 1m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1019,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 5m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1020,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1006", 1006, 4m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1021,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1006", 1006, 2m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1022,
                column: "Rating",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1023,
                column: "Rating",
                value: 2m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1024,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1007", 1007, 4m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1025,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1007", 1007, 3m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1026,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1007", 1007, 2m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1027,
                columns: new[] { "Content", "MotelId" },
                values: new object[] { "Review cho MotelId 1008", 1008 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1028,
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1008", 1008, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1029,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1009", 1009, 5m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1030,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1009", 1009, 3m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1031,
                column: "UserId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1001,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 20, 20, 15, 59, 542, DateTimeKind.Local).AddTicks(2042));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1002,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 20, 20, 15, 59, 542, DateTimeKind.Local).AddTicks(2045));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1003,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 20, 20, 15, 59, 542, DateTimeKind.Local).AddTicks(2047));
        }
    }
}
