using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class themDuLieuMau : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Term",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Term", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(10)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Address = table.Column<string>(type: "ntext", nullable: false),
                    Location = table.Column<string>(type: "ntext", nullable: false),
                    TotalRoom = table.Column<byte>(type: "tinyint", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motel_Term_TermId",
                        column: x => x.TermId,
                        principalTable: "Term",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motel_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Water = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Electric = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Other = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Price_Motel_MotelId",
                        column: x => x.MotelId,
                        principalTable: "Motel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rental_Motel_MotelId",
                        column: x => x.MotelId,
                        principalTable: "Motel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rental_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<decimal>(type: "decimal(18,1)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Motel_MotelId",
                        column: x => x.MotelId,
                        principalTable: "Motel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,1)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    MotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Motel_MotelId",
                        column: x => x.MotelId,
                        principalTable: "Motel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Motel_MotelId",
                        column: x => x.MotelId,
                        principalTable: "Motel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consumption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Water = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Electric = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumption_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotelId = table.Column<int>(type: "int", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Media_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Media_Motel_MotelId",
                        column: x => x.MotelId,
                        principalTable: "Motel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Media_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Term",
                columns: new[] { "Id", "Link" },
                values: new object[,]
                {
                    { 1001, "https://example.com/link3" },
                    { 1002, "https://example.com/link2" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "Email", "FullName", "Phone", "Status", "TimeCreated" },
                values: new object[,]
                {
                    { 1001, "avatar1.png", "vana@example.com", "Nguyễn Văn A", "0901234567", (byte)1, new DateTime(2024, 10, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(121) },
                    { 1002, "avatar2.png", "thib@example.com", "Trần Thị B", "0902345678", (byte)1, new DateTime(2024, 10, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(124) },
                    { 1003, "avatar3.png", "vanc@example.com", "Lê Văn C", "0903456789", (byte)1, new DateTime(2024, 10, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(125) }
                });

            migrationBuilder.InsertData(
                table: "Motel",
                columns: new[] { "Id", "Address", "Location", "Name", "Status", "TermId", "TotalRoom", "UserId" },
                values: new object[,]
                {
                    { 1001, "123 Đường Biển, Quận 1, TP. HCM", "10.762622, 106.660172", "Tro A", (byte)1, 1001, (byte)20, 1001 },
                    { 1002, "456 Đường Sông, Quận 2, TP. HCM", "10.762623, 106.660173", "Tro B", (byte)0, 1002, (byte)15, 1002 },
                    { 1003, "789 Đường Núi, Quận 3, TP. HCM", "10.762624, 106.660174", "Tro C", (byte)1, 1001, (byte)30, 1003 },
                    { 1004, "101 Đường Biển, Quận 4, TP. HCM", "10.762625, 106.660175", "Tro D", (byte)1, 1002, (byte)18, 1001 },
                    { 1005, "202 Đường Mặt Trăng, Quận 5, TP. HCM", "10.762626, 106.660176", "Tro E", (byte)0, 1001, (byte)12, 1002 },
                    { 1006, "303 Đường Bình Yên, Quận 6, TP. HCM", "10.762627, 106.660177", "Tro f", (byte)1, 1002, (byte)25, 1003 },
                    { 1007, "404 Đường Hồng Hà, Quận 7, TP. HCM", "10.762628, 106.660178", "Tro g", (byte)1, 1001, (byte)16, 1001 },
                    { 1008, "505 Đường Biển Xanh, Quận 8, TP. HCM", "10.762629, 106.660179", "Tro H", (byte)0, 1002, (byte)20, 1002 },
                    { 1009, "606 Đường Núi Ngàn, Quận 9, TP. HCM", "10.762630, 106.660180", "Tro I", (byte)1, 1001, (byte)22, 1003 },
                    { 1010, "707 Đường An Bình, Quận 10, TP. HCM", "10.762631, 106.660181", "Tro j", (byte)1, 1002, (byte)30, 1001 }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "Content", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 1001, "Hệ thống sẽ bảo trì vào lúc 22h tối nay.", (byte)1, "Cập nhật hệ thống", "Thông báo khẩn cấp", 1001 },
                    { 1002, "Bạn có thông báo mới từ ban quản lý.", (byte)0, "Tin nhắn từ ban quản lý", "Tin nhắn mới", 1002 },
                    { 1003, "Bạn còn nợ tiền thuê phòng tháng này.", (byte)1, "Nhắc nhở thanh toán", "Nhắc nhở", 1003 }
                });

            migrationBuilder.InsertData(
                table: "Price",
                columns: new[] { "Id", "Electric", "IsActive", "MotelId", "Other", "Water" },
                values: new object[,]
                {
                    { 1001, 3000.75m, true, 1001, 1000.2m, 5000.5m },
                    { 1002, 3500.5m, true, 1002, 1500.3m, 6000.25m },
                    { 1003, 3200m, false, 1003, 1200m, 5500m },
                    { 1004, 3400.55m, true, 1004, 1300.15m, 6200.1m },
                    { 1005, 3100.85m, false, 1005, 1400.45m, 5800.75m },
                    { 1006, 3600.95m, true, 1006, 1600.35m, 6100.65m },
                    { 1007, 3300.7m, true, 1007, 1100.8m, 5700.2m },
                    { 1008, 3400.3m, false, 1008, 1700.5m, 5900.4m },
                    { 1009, 3200.6m, true, 1009, 1800.25m, 5600.1m },
                    { 1010, 3500.2m, true, 1010, 1900.55m, 6000.8m }
                });

            migrationBuilder.InsertData(
                table: "Rental",
                columns: new[] { "Id", "MotelId", "Status", "TimeEnd", "TimeStart", "UserId" },
                values: new object[,]
                {
                    { 1001, 1001, (byte)0, new DateTime(2024, 9, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(383), new DateTime(2024, 8, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(383), 1001 },
                    { 1002, 1002, (byte)1, null, new DateTime(2024, 9, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(388), 1002 },
                    { 1003, 1003, (byte)1, null, new DateTime(2024, 7, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(390), 1003 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "Content", "MotelId", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1001, "Review cho MotelId 1001", 1001, 3m, 1001 },
                    { 1002, "Review cho MotelId 1001", 1001, 3m, 1002 },
                    { 1003, "Review cho MotelId 1001", 1001, 2m, 1001 },
                    { 1004, "Review cho MotelId 1002", 1002, 3m, 1002 },
                    { 1005, "Review cho MotelId 1003", 1003, 4m, 1002 },
                    { 1006, "Review cho MotelId 1003", 1003, 4m, 1002 },
                    { 1007, "Review cho MotelId 1003", 1003, 2m, 1003 },
                    { 1008, "Review cho MotelId 1003", 1003, 3m, 1001 },
                    { 1009, "Review cho MotelId 1003", 1003, 1m, 1001 },
                    { 1010, "Review cho MotelId 1004", 1004, 2m, 1001 },
                    { 1011, "Review cho MotelId 1004", 1004, 5m, 1002 },
                    { 1012, "Review cho MotelId 1004", 1004, 1m, 1002 },
                    { 1013, "Review cho MotelId 1004", 1004, 1m, 1003 },
                    { 1014, "Review cho MotelId 1005", 1005, 5m, 1003 },
                    { 1015, "Review cho MotelId 1006", 1006, 1m, 1002 },
                    { 1016, "Review cho MotelId 1006", 1006, 5m, 1003 },
                    { 1017, "Review cho MotelId 1006", 1006, 3m, 1002 },
                    { 1018, "Review cho MotelId 1006", 1006, 4m, 1001 },
                    { 1019, "Review cho MotelId 1007", 1007, 3m, 1001 },
                    { 1020, "Review cho MotelId 1007", 1007, 2m, 1003 },
                    { 1021, "Review cho MotelId 1007", 1007, 1m, 1001 },
                    { 1022, "Review cho MotelId 1008", 1008, 1m, 1001 },
                    { 1023, "Review cho MotelId 1008", 1008, 3m, 1001 },
                    { 1024, "Review cho MotelId 1008", 1008, 2m, 1003 },
                    { 1025, "Review cho MotelId 1008", 1008, 1m, 1001 },
                    { 1026, "Review cho MotelId 1008", 1008, 3m, 1003 },
                    { 1027, "Review cho MotelId 1009", 1009, 2m, 1001 },
                    { 1028, "Review cho MotelId 1009", 1009, 4m, 1003 },
                    { 1029, "Review cho MotelId 1009", 1009, 3m, 1002 },
                    { 1030, "Review cho MotelId 1009", 1009, 2m, 1001 },
                    { 1031, "Review cho MotelId 1009", 1009, 5m, 1001 },
                    { 1032, "Review cho MotelId 1010", 1010, 3m, 1003 },
                    { 1033, "Review cho MotelId 1010", 1010, 1m, 1003 },
                    { 1034, "Review cho MotelId 1010", 1010, 2m, 1003 },
                    { 1035, "Review cho MotelId 1010", 1010, 2m, 1001 },
                    { 1036, "Review cho MotelId 1010", 1010, 2m, 1001 }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "Area", "MotelId", "Price", "RoomNumber", "Status" },
                values: new object[,]
                {
                    { 1001, 25m, 1001, 500000m, 101, (byte)1 },
                    { 1002, 30m, 1002, 600000m, 102, (byte)0 },
                    { 1003, 35m, 1003, 700000m, 103, (byte)1 },
                    { 1004, 40m, 1004, 800000m, 104, (byte)1 },
                    { 1005, 45m, 1005, 900000m, 105, (byte)0 },
                    { 1006, 50m, 1006, 1000000m, 106, (byte)1 },
                    { 1007, 55m, 1007, 1100000m, 107, (byte)1 },
                    { 1008, 60m, 1008, 1200000m, 108, (byte)0 },
                    { 1009, 65m, 1009, 1300000m, 109, (byte)1 },
                    { 1010, 70m, 1010, 1400000m, 110, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "Id", "Content", "MotelId", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 1001, "Phòng 101 gặp vấn đề với hệ thống nước.", 1001, (byte)1, "Hệ thống nước gặp sự cố", "Yêu cầu sửa chữa", 1001 },
                    { 1002, "Khách hàng phàn nàn về dịch vụ phòng 102.", 1002, (byte)0, "Chất lượng dịch vụ kém", "Khiếu nại", 1002 },
                    { 1003, "Phòng 103 cần kiểm tra lại hệ thống điện.", 1003, (byte)1, "Kiểm tra hệ thống điện", "Yêu cầu bảo trì", 1003 },
                    { 1004, "Phòng 104 cần sửa chữa điều hòa.", 1004, (byte)1, "Sửa chữa điều hòa", "Yêu cầu bảo trì", 1001 },
                    { 1005, "Cửa phòng 105 gặp vấn đề cần sửa chữa.", 1005, (byte)0, "Cửa phòng bị hỏng", "Yêu cầu sửa chữa", 1002 },
                    { 1006, "Khách hàng phòng 106 phàn nàn về tiếng ồn từ phòng bên.", 1006, (byte)1, "Tiếng ồn từ phòng bên cạnh", "Khiếu nại", 1003 },
                    { 1007, "Giường phòng 107 bị hỏng cần sửa chữa.", 1007, (byte)0, "Sửa chữa giường", "Yêu cầu bảo trì", 1001 },
                    { 1008, "Khách hàng phòng 108 khiếu nại về thái độ phục vụ của nhân viên.", 1008, (byte)1, "Nhân viên phục vụ không thân thiện", "Khiếu nại", 1002 },
                    { 1009, "Phòng 109 gặp vấn đề với WiFi, cần kiểm tra.", 1009, (byte)0, "Hệ thống WiFi chập chờn", "Yêu cầu sửa chữa", 1003 },
                    { 1010, "Phòng 110 không có nước nóng, cần kiểm tra.", 1010, (byte)1, "Thiếu nước nóng", "Khiếu nại", 1001 }
                });

            migrationBuilder.InsertData(
                table: "Consumption",
                columns: new[] { "Id", "Electric", "RoomId", "Time", "Water" },
                values: new object[,]
                {
                    { 1001, 120.5m, 1001, new DateTime(2024, 10, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(340), 50.25m },
                    { 1002, 110.75m, 1002, new DateTime(2024, 9, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(341), 40m },
                    { 1003, 130m, 1003, new DateTime(2024, 8, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(349), 60.3m },
                    { 1004, 115.25m, 1004, new DateTime(2024, 7, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(351), 55.5m },
                    { 1005, 125.75m, 1005, new DateTime(2024, 6, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(352), 52.75m },
                    { 1006, 118.6m, 1006, new DateTime(2024, 5, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(355), 58m },
                    { 1007, 122.4m, 1007, new DateTime(2024, 4, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(356), 61.1m },
                    { 1008, 119.9m, 1008, new DateTime(2024, 3, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(358), 53.6m },
                    { 1009, 121.5m, 1009, new DateTime(2024, 2, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(359), 56.8m },
                    { 1010, 123.75m, 1010, new DateTime(2024, 1, 15, 17, 26, 52, 233, DateTimeKind.Local).AddTicks(360), 59.25m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Consumption_RoomId",
                table: "Consumption",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_ImageId",
                table: "Media",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_MotelId",
                table: "Media",
                column: "MotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_TicketId",
                table: "Media",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Motel_TermId",
                table: "Motel",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_Motel_UserId",
                table: "Motel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_MotelId",
                table: "Price",
                column: "MotelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rental_MotelId",
                table: "Rental",
                column: "MotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_UserId",
                table: "Rental",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_MotelId",
                table: "Review",
                column: "MotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_MotelId",
                table: "Room",
                column: "MotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_MotelId",
                table: "Ticket",
                column: "MotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UserId",
                table: "Ticket",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Consumption");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "Rental");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Motel");

            migrationBuilder.DropTable(
                name: "Term");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
