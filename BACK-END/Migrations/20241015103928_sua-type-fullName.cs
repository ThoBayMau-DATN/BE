using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class suatypefullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1035);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1036);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "User",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1001,
                column: "Time",
                value: new DateTime(2024, 10, 15, 17, 39, 27, 922, DateTimeKind.Local).AddTicks(6961));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1002,
                column: "Time",
                value: new DateTime(2024, 9, 15, 17, 39, 27, 922, DateTimeKind.Local).AddTicks(6963));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1003,
                column: "Time",
                value: new DateTime(2024, 8, 15, 17, 39, 27, 922, DateTimeKind.Local).AddTicks(6972));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1004,
                column: "Time",
                value: new DateTime(2024, 7, 15, 17, 39, 27, 922, DateTimeKind.Local).AddTicks(6973));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1005,
                column: "Time",
                value: new DateTime(2024, 6, 15, 17, 39, 27, 922, DateTimeKind.Local).AddTicks(6974));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1006,
                column: "Time",
                value: new DateTime(2024, 5, 15, 17, 39, 27, 922, DateTimeKind.Local).AddTicks(6976));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1007,
                column: "Time",
                value: new DateTime(2024, 4, 15, 17, 39, 27, 922, DateTimeKind.Local).AddTicks(6977));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1008,
                column: "Time",
                value: new DateTime(2024, 3, 15, 17, 39, 27, 922, DateTimeKind.Local).AddTicks(6978));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1009,
                column: "Time",
                value: new DateTime(2024, 2, 15, 17, 39, 27, 922, DateTimeKind.Local).AddTicks(6979));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1010,
                column: "Time",
                value: new DateTime(2024, 1, 15, 17, 39, 27, 922, DateTimeKind.Local).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "Rental",
                keyColumn: "Id",
                keyValue: 1001,
                columns: new[] { "TimeEnd", "TimeStart" },
                values: new object[] { new DateTime(2024, 9, 15, 17, 39, 27, 922, DateTimeKind.Local).AddTicks(7007), new DateTime(2024, 8, 15, 17, 39, 27, 922, DateTimeKind.Local).AddTicks(7006) });

            migrationBuilder.UpdateData(
                table: "Rental",
                keyColumn: "Id",
                keyValue: 1002,
                column: "TimeStart",
                value: new DateTime(2024, 9, 15, 17, 39, 27, 922, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "Rental",
                keyColumn: "Id",
                keyValue: 1003,
                column: "TimeStart",
                value: new DateTime(2024, 7, 15, 17, 39, 27, 922, DateTimeKind.Local).AddTicks(7014));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1001,
                column: "Rating",
                value: 1m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1002", 1002, 1m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1003,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1002", 1002, 5m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1004,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 5m, 1001 });

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
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 3m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1007,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 5m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1008,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 2m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1009,
                column: "Rating",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1010,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1003", 1003, 5m, 1003 });

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
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 2m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1013,
                column: "Rating",
                value: 3m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1014,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1004", 1004, 1m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1015,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1005", 1005, 3m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1016,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 1m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1017,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 2m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1018,
                column: "Rating",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1019,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1006", 1006, 5m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1020,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 1m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1021,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1008", 1008, 5m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1022,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 2m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1023,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 2m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1024,
                column: "Rating",
                value: 1m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1025,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1009", 1009, 4m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1026,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1009", 1009, 5m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1027,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 3m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1028,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 3m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1029,
                column: "UserId",
                value: 1003);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1030,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1010", 1010, 5m });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1001,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 15, 17, 39, 27, 922, DateTimeKind.Local).AddTicks(6712));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1002,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 15, 17, 39, 27, 922, DateTimeKind.Local).AddTicks(6715));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1003,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 15, 17, 39, 27, 922, DateTimeKind.Local).AddTicks(6717));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "User",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1001,
                column: "Time",
                value: new DateTime(2024, 10, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(340));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1002,
                column: "Time",
                value: new DateTime(2024, 9, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(341));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1003,
                column: "Time",
                value: new DateTime(2024, 8, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(349));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1004,
                column: "Time",
                value: new DateTime(2024, 7, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(351));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1005,
                column: "Time",
                value: new DateTime(2024, 6, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(352));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1006,
                column: "Time",
                value: new DateTime(2024, 5, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(355));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1007,
                column: "Time",
                value: new DateTime(2024, 4, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(356));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1008,
                column: "Time",
                value: new DateTime(2024, 3, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(358));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1009,
                column: "Time",
                value: new DateTime(2024, 2, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(359));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1010,
                column: "Time",
                value: new DateTime(2024, 1, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(360));

            migrationBuilder.UpdateData(
                table: "Rental",
                keyColumn: "Id",
                keyValue: 1001,
                columns: new[] { "TimeEnd", "TimeStart" },
                values: new object[] { new DateTime(2024, 9, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(383), new DateTime(2024, 8, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(383) });

            migrationBuilder.UpdateData(
                table: "Rental",
                keyColumn: "Id",
                keyValue: 1002,
                column: "TimeStart",
                value: new DateTime(2024, 9, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(388));

            migrationBuilder.UpdateData(
                table: "Rental",
                keyColumn: "Id",
                keyValue: 1003,
                column: "TimeStart",
                value: new DateTime(2024, 7, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(390));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1001,
                column: "Rating",
                value: 3m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1001", 1001, 3m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1003,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1001", 1001, 2m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1004,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 3m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1005,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1003", 1003, 4m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1006,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 4m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1007,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 2m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1008,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 3m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1009,
                column: "Rating",
                value: 1m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1010,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1004", 1004, 2m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1011,
                column: "Rating",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1012,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 1m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1013,
                column: "Rating",
                value: 1m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1014,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1005", 1005, 5m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1015,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1006", 1006, 1m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1016,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 5m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1017,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 3m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1018,
                column: "Rating",
                value: 4m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1019,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1007", 1007, 3m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1020,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 2m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1021,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1007", 1007, 1m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1022,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 1m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1023,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 3m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1024,
                column: "Rating",
                value: 2m);

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
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1008", 1008, 3m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1027,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 2m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1028,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 4m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1029,
                column: "UserId",
                value: 1002);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1030,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1009", 1009, 2m });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "Content", "MotelId", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1031, "Review cho MotelId 1009", 1009, 5m, 1001 },
                    { 1032, "Review cho MotelId 1010", 1010, 3m, 1003 },
                    { 1033, "Review cho MotelId 1010", 1010, 1m, 1003 },
                    { 1034, "Review cho MotelId 1010", 1010, 2m, 1003 },
                    { 1035, "Review cho MotelId 1010", 1010, 2m, 1001 },
                    { 1036, "Review cho MotelId 1010", 1010, 2m, 1001 }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1001,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(121));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1002,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(124));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1003,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(125));
        }
    }
}
