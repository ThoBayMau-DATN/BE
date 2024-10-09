using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class suadulieumau : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "BoardingHouseId", "TimeCreate" },
                values: new object[] { -5, new DateTime(2024, 10, 10, 0, 7, 17, 289, DateTimeKind.Local).AddTicks(1431) });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "BoardingHouseId", "TimeCreate" },
                values: new object[] { -4, new DateTime(2024, 10, 10, 0, 7, 17, 289, DateTimeKind.Local).AddTicks(1428) });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "BoardingHouseId", "TimeCreate" },
                values: new object[] { -3, new DateTime(2024, 10, 10, 0, 7, 17, 289, DateTimeKind.Local).AddTicks(1425) });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "BoardingHouseId", "TimeCreate" },
                values: new object[] { -2, new DateTime(2024, 10, 10, 0, 7, 17, 289, DateTimeKind.Local).AddTicks(1421) });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -1,
                column: "TimeCreate",
                value: new DateTime(2024, 10, 10, 0, 7, 17, 289, DateTimeKind.Local).AddTicks(1416));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "BoardingHouseId", "TimeCreate" },
                values: new object[] { -4, new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(882) });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "BoardingHouseId", "TimeCreate" },
                values: new object[] { -3, new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "BoardingHouseId", "TimeCreate" },
                values: new object[] { -2, new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(878) });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "BoardingHouseId", "TimeCreate" },
                values: new object[] { -1, new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(876) });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -1,
                column: "TimeCreate",
                value: new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(871));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -5,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -4,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -3,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(1138));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -2,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -1,
                column: "TimeCreated",
                value: new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(1134));
        }
    }
}
