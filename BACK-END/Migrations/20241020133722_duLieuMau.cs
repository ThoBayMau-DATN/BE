using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class duLieuMau : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Motel",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpriryDate",
                table: "Motel",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "CreateDate", "Email", "FullName", "Phone", "RoomId", "Status" },
                values: new object[,]
                {
                    { 1001, "avatar1.png", new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6240), "vana@example.com", "Nguyễn Văn A", "0901234567", null, (byte)1 },
                    { 1002, "avatar2.png", new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6243), "thib@example.com", "Trần Thị B", "0902345678", null, (byte)1 },
                    { 1003, "avatar3.png", new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6245), "vanc@example.com", "Lê Văn C", "0903456789", null, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Motel",
                columns: new[] { "Id", "Acreage", "Address", "CreateDate", "ExpriryDate", "Location", "Name", "RegisterDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 1001, (byte)0, "123 Đường Biển, Quận 1, TP. HCM", new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6418), null, "10.762622, 106.660172", "Tro A", null, (byte)1, 1001 },
                    { 1002, (byte)0, "456 Đường Sông, Quận 2, TP. HCM", new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6425), null, "10.762623, 106.660173", "Tro B", null, (byte)0, 1002 },
                    { 1003, (byte)0, "789 Đường Núi, Quận 3, TP. HCM", new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6428), null, "10.762624, 106.660174", "Tro C", null, (byte)1, 1003 },
                    { 1004, (byte)0, "101 Đường Biển, Quận 4, TP. HCM", new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6429), null, "10.762625, 106.660175", "Tro D", null, (byte)1, 1001 },
                    { 1005, (byte)0, "202 Đường Mặt Trăng, Quận 5, TP. HCM", new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6430), null, "10.762626, 106.660176", "Tro E", null, (byte)0, 1002 },
                    { 1006, (byte)0, "303 Đường Bình Yên, Quận 6, TP. HCM", new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6431), null, "10.762627, 106.660177", "Tro f", null, (byte)1, 1003 },
                    { 1007, (byte)0, "404 Đường Hồng Hà, Quận 7, TP. HCM", new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6433), null, "10.762628, 106.660178", "Tro g", null, (byte)1, 1001 },
                    { 1008, (byte)0, "505 Đường Biển Xanh, Quận 8, TP. HCM", new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6434), null, "10.762629, 106.660179", "Tro H", null, (byte)0, 1002 },
                    { 1009, (byte)0, "606 Đường Núi Ngàn, Quận 9, TP. HCM", new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6435), null, "10.762630, 106.660180", "Tro I", null, (byte)1, 1003 },
                    { 1010, (byte)0, "707 Đường An Bình, Quận 10, TP. HCM", new DateTime(2024, 10, 20, 20, 37, 21, 513, DateTimeKind.Local).AddTicks(6436), null, "10.762631, 106.660181", "Tro j", null, (byte)1, 1001 }
                });

            migrationBuilder.InsertData(
                table: "Price",
                columns: new[] { "Id", "Electric", "IsActive", "MotelId", "Other", "Water" },
                values: new object[,]
                {
                    { 1001, 3000, true, 1001, 1000, 5000 },
                    { 1002, 3500, true, 1002, 1500, 6000 },
                    { 1003, 3200, false, 1003, 1200, 5500 },
                    { 1004, 3400, true, 1004, 1300, 6200 },
                    { 1005, 3100, false, 1005, 1400, 5800 },
                    { 1006, 3600, true, 1006, 1600, 6100 },
                    { 1007, 3300, true, 1007, 1100, 5700 },
                    { 1008, 3400, false, 1008, 1700, 5900 },
                    { 1009, 3200, true, 1009, 1800, 5600 },
                    { 1010, 3500, true, 1010, 1900, 6000 }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "MotelId", "Price", "RoomNumber", "Status" },
                values: new object[,]
                {
                    { 1001, 1001, 500000, 101, (byte)1 },
                    { 1002, 1002, 600000, 102, (byte)0 },
                    { 1003, 1003, 700000, 103, (byte)1 },
                    { 1004, 1004, 800000, 104, (byte)1 },
                    { 1005, 1005, 900000, 105, (byte)0 },
                    { 1006, 1006, 1000000, 106, (byte)1 },
                    { 1007, 1007, 1100000, 107, (byte)1 },
                    { 1008, 1008, 1200000, 108, (byte)0 },
                    { 1009, 1009, 1300000, 109, (byte)1 },
                    { 1010, 1010, 1400000, 110, (byte)1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "Price",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "Motel",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Motel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpriryDate",
                table: "Motel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
