using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class addtimeCreateToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Receiver",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeCreated",
                table: "Invoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                column: "Rating",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 2m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1003,
                column: "Rating",
                value: 2m);

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
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1002", 1002, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1006,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 5m, 1003 });

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
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 4m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1009,
                column: "UserId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1010,
                column: "Rating",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1011,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 3m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1012,
                column: "Rating",
                value: 4m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1013,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1005", 1005, 5m, 1002 });

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
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1005", 1005, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1017,
                columns: new[] { "Content", "MotelId" },
                values: new object[] { "Review cho MotelId 1005", 1005 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1019,
                column: "Rating",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1020,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1006", 1006, 4m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1021,
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1006", 1006, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1022,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 5m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1023,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 2m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1024,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 4m, 1001 });

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
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1007", 1007, 2m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1027,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1008", 1008, 3m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1028,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1008", 1008, 1m });

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
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1009", 1009, 3m, 1001 });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { 1031, "Review cho MotelId 1010", 1010, 3m, 1001 });

            migrationBuilder.UpdateData(
                table: "Ticket",
                keyColumn: "Id",
                keyValue: 1001,
                column: "Receiver",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ticket",
                keyColumn: "Id",
                keyValue: 1002,
                column: "Receiver",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ticket",
                keyColumn: "Id",
                keyValue: 1003,
                column: "Receiver",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ticket",
                keyColumn: "Id",
                keyValue: 1004,
                column: "Receiver",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ticket",
                keyColumn: "Id",
                keyValue: 1005,
                column: "Receiver",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ticket",
                keyColumn: "Id",
                keyValue: 1006,
                column: "Receiver",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ticket",
                keyColumn: "Id",
                keyValue: 1007,
                column: "Receiver",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ticket",
                keyColumn: "Id",
                keyValue: 1008,
                column: "Receiver",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ticket",
                keyColumn: "Id",
                keyValue: 1009,
                column: "Receiver",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ticket",
                keyColumn: "Id",
                keyValue: 1010,
                column: "Receiver",
                value: null);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1031);

            migrationBuilder.DropColumn(
                name: "Receiver",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "TimeCreated",
                table: "Invoice");

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1001,
                column: "Time",
                value: new DateTime(2024, 10, 18, 21, 57, 5, 784, DateTimeKind.Local).AddTicks(1259));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1002,
                column: "Time",
                value: new DateTime(2024, 9, 18, 21, 57, 5, 784, DateTimeKind.Local).AddTicks(1261));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1003,
                column: "Time",
                value: new DateTime(2024, 8, 18, 21, 57, 5, 784, DateTimeKind.Local).AddTicks(1269));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1004,
                column: "Time",
                value: new DateTime(2024, 7, 18, 21, 57, 5, 784, DateTimeKind.Local).AddTicks(1271));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1005,
                column: "Time",
                value: new DateTime(2024, 6, 18, 21, 57, 5, 784, DateTimeKind.Local).AddTicks(1272));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1006,
                column: "Time",
                value: new DateTime(2024, 5, 18, 21, 57, 5, 784, DateTimeKind.Local).AddTicks(1273));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1007,
                column: "Time",
                value: new DateTime(2024, 4, 18, 21, 57, 5, 784, DateTimeKind.Local).AddTicks(1275));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1008,
                column: "Time",
                value: new DateTime(2024, 3, 18, 21, 57, 5, 784, DateTimeKind.Local).AddTicks(1276));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1009,
                column: "Time",
                value: new DateTime(2024, 2, 18, 21, 57, 5, 784, DateTimeKind.Local).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "Consumption",
                keyColumn: "Id",
                keyValue: 1010,
                column: "Time",
                value: new DateTime(2024, 1, 18, 21, 57, 5, 784, DateTimeKind.Local).AddTicks(1279));

            migrationBuilder.UpdateData(
                table: "Rental",
                keyColumn: "Id",
                keyValue: 1001,
                columns: new[] { "TimeEnd", "TimeStart" },
                values: new object[] { new DateTime(2024, 9, 18, 21, 57, 5, 784, DateTimeKind.Local).AddTicks(1303), new DateTime(2024, 8, 18, 21, 57, 5, 784, DateTimeKind.Local).AddTicks(1302) });

            migrationBuilder.UpdateData(
                table: "Rental",
                keyColumn: "Id",
                keyValue: 1002,
                column: "TimeStart",
                value: new DateTime(2024, 9, 18, 21, 57, 5, 784, DateTimeKind.Local).AddTicks(1308));

            migrationBuilder.UpdateData(
                table: "Rental",
                keyColumn: "Id",
                keyValue: 1003,
                column: "TimeStart",
                value: new DateTime(2024, 7, 18, 21, 57, 5, 784, DateTimeKind.Local).AddTicks(1309));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1001,
                column: "Rating",
                value: 4m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 4m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1003,
                column: "Rating",
                value: 3m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1004,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 1m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1005,
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1001", 1001, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1006,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 4m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1007,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1003", 1003, 2m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1008,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 3m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1009,
                column: "UserId",
                value: 1002);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1010,
                column: "Rating",
                value: 1m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1011,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 5m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1012,
                column: "Rating",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1013,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1004", 1004, 4m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1014,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 3m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1015,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1006", 1006, 5m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1016,
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1006", 1006, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1017,
                columns: new[] { "Content", "MotelId" },
                values: new object[] { "Review cho MotelId 1006", 1006 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1019,
                column: "Rating",
                value: 2m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1020,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1007", 1007, 3m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1021,
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1007", 1007, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1022,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 4m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1023,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 1m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1024,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 2m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1025,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1008", 1008, 4m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1026,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1009", 1009, 4m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1027,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1009", 1009, 1m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1028,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1009", 1009, 2m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1029,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1010", 1010, 3m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1030,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1010", 1010, 2m, 1003 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1001,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 18, 21, 57, 5, 784, DateTimeKind.Local).AddTicks(1028));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1002,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 18, 21, 57, 5, 784, DateTimeKind.Local).AddTicks(1031));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1003,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 18, 21, 57, 5, 784, DateTimeKind.Local).AddTicks(1033));
        }
    }
}
