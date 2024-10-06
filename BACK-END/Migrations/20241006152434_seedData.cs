using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FileType",
                table: "File",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "File",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.InsertData(
                table: "RoomType",
                columns: new[] { "Id", "Description", "Name", "Status" },
                values: new object[,]
                {
                    { -5, "Phòng nhỏ, giá rẻ, phù hợp cho sinh viên hoặc người có thu nhập thấp", "Phòng tiết kiệm", true },
                    { -4, "Phòng trọ cao cấp, tiện nghi hiện đại, có view đẹp, diện tích lớn", "Phòng VIP", true },
                    { -3, "Phòng trọ dành cho gia đình, không gian rộng, có bếp và phòng tắm riêng", "Phòng gia đình", true },
                    { -2, "Phòng trọ dành cho hai người ở, không gian rộng rãi hơn, có tiện nghi đầy đủ", "Phòng đôi", true },
                    { -1, "Phòng trọ dành cho một người ở, không gian nhỏ gọn, tiện nghi cơ bản", "Phòng đơn", true }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "Email", "FullName", "PhoneNumber", "Status", "TimeCreated" },
                values: new object[,]
                {
                    { -5, "charlie_avatar.png", "charliewhite@example.com", "Charlie White", "6677889900", (byte)1, new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(1141) },
                    { -4, "bob_avatar.png", "bobjohnson@example.com", "Bob Johnson", "5566778899", (byte)0, new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(1139) },
                    { -3, "alice_avatar.png", "alicebrown@example.com", "Alice Brown", "1122334455", (byte)1, new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(1138) },
                    { -2, "jane_avatar.png", "janesmith@example.com", "Jane Smith", "0987654321", (byte)1, new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(1137) },
                    { -1, "john_avatar.png", "johndoe@example.com", "John Doe", "1234567890", (byte)1, new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(1134) }
                });

            migrationBuilder.InsertData(
                table: "BoardingHouse",
                columns: new[] { "Id", "Address", "Status", "UserId" },
                values: new object[,]
                {
                    { -5, "202 Birch Ln", (byte)1, -5 },
                    { -4, "101 Maple Dr", (byte)0, -4 },
                    { -3, "789 Pine Rd", (byte)1, -3 },
                    { -2, "456 Oak Ave", (byte)2, -2 },
                    { -1, "123 Main St", (byte)1, -1 }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "Area", "BoardingHouseId", "Description", "Price", "Quantity", "RoomTypeId", "Status", "TimeCreate" },
                values: new object[,]
                {
                    { -5, 15.0m, -4, "Phòng tiết kiệm, nhỏ gọn, gần chợ", 800000m, 1, -1, (byte)1, new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(882) },
                    { -4, 40.0m, -3, "Phòng cao cấp, có view nhìn ra công viên", 3500000m, 1, -3, (byte)1, new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(880) },
                    { -3, 20.0m, -2, "Phòng nhỏ, phù hợp cho sinh viên", 1000000m, 1, -1, (byte)1, new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(878) },
                    { -2, 30.0m, -1, "Phòng trọ rộng rãi, có điều hòa và ban công", 2000000m, 2, -2, (byte)1, new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(876) },
                    { -1, 25.5m, -1, "Phòng trọ gần trường, đầy đủ tiện nghi", 1500000m, 1, -1, (byte)1, new DateTime(2024, 10, 6, 22, 24, 33, 836, DateTimeKind.Local).AddTicks(871) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BoardingHouse",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "BoardingHouse",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "BoardingHouse",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "BoardingHouse",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "BoardingHouse",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AlterColumn<string>(
                name: "FileType",
                table: "File",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "File",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");
        }
    }
}
