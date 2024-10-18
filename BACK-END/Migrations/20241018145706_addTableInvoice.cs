using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class addTableInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Water = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Electric = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Other = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 4m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1001", 1001, 4m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1003,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1001", 1001, 3m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1004,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1001", 1001, 1m, 1003 });

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
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1002", 1002, 4m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1007,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 2m, 1002 });

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
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 3m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1010,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 1m, 1002 });

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
                column: "Rating",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1013,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 4m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1014,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1005", 1005, 3m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1015,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1006", 1006, 5m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1016,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 2m, 1003 });

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
                value: 1m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1019,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 2m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1020,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 3m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1021,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1007", 1007, 2m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1022,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1007", 1007, 4m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1023,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1007", 1007, 1m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1024,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1007", 1007, 2m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1025,
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1008", 1008, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1026,
                column: "Rating",
                value: 4m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1027,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 1m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1028,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 2m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1029,
                columns: new[] { "Content", "MotelId" },
                values: new object[] { "Review cho MotelId 1010", 1010 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1030,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 2m, 1003 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_RoomId",
                table: "Invoice",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

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
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 1m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1002", 1002, 1m, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1003,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1002", 1002, 5m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1004,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1002", 1002, 5m, 1001 });

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
                values: new object[] { "Review cho MotelId 1003", 1003, 3m, 1003 });

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
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 5m, 1001 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1010,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 5m, 1003 });

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
                column: "Rating",
                value: 2m);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1013,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 3m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1014,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1004", 1004, 1m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1015,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1005", 1005, 3m, 1002 });

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
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 5m, 1001 });

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
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1008", 1008, 5m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1022,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1008", 1008, 2m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1023,
                columns: new[] { "Content", "MotelId", "Rating", "UserId" },
                values: new object[] { "Review cho MotelId 1008", 1008, 2m, 1003 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1024,
                columns: new[] { "Content", "MotelId", "Rating" },
                values: new object[] { "Review cho MotelId 1008", 1008, 1m });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1025,
                columns: new[] { "Content", "MotelId", "UserId" },
                values: new object[] { "Review cho MotelId 1009", 1009, 1002 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1026,
                column: "Rating",
                value: 5m);

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
                columns: new[] { "Content", "MotelId" },
                values: new object[] { "Review cho MotelId 1009", 1009 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1030,
                columns: new[] { "Rating", "UserId" },
                values: new object[] { 5m, 1001 });

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
    }
}
