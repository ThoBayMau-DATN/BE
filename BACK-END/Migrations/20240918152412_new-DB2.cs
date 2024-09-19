using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class newDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayTro_KhacHang_KhachHangId",
                table: "DayTro");

            migrationBuilder.DropForeignKey(
                name: "FK_ThueTro_KhacHang_KhachHangId",
                table: "ThueTro");

            migrationBuilder.DropForeignKey(
                name: "FK_XuLy_Ticket_NhanVien_NhanVienId",
                table: "XuLy_Ticket");

            migrationBuilder.DropTable(
                name: "KhacHang");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.RenameColumn(
                name: "NhanVienId",
                table: "XuLy_Ticket",
                newName: "NguoiDungId");

            migrationBuilder.RenameIndex(
                name: "IX_XuLy_Ticket_NhanVienId",
                table: "XuLy_Ticket",
                newName: "IX_XuLy_Ticket_NguoiDungId");

            migrationBuilder.RenameColumn(
                name: "KhachHangId",
                table: "ThueTro",
                newName: "NguoiDungId");

            migrationBuilder.RenameIndex(
                name: "IX_ThueTro_KhachHangId",
                table: "ThueTro",
                newName: "IX_ThueTro_NguoiDungId");

            migrationBuilder.RenameColumn(
                name: "KhachHangId",
                table: "DayTro",
                newName: "NguoiDungId");

            migrationBuilder.RenameIndex(
                name: "IX_DayTro_KhachHangId",
                table: "DayTro",
                newName: "IX_DayTro_NguoiDungId");

            migrationBuilder.AddColumn<int>(
                name: "NguoiDungId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_NguoiDungId",
                table: "Ticket",
                column: "NguoiDungId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayTro_NguoiDung_NguoiDungId",
                table: "DayTro",
                column: "NguoiDungId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThueTro_NguoiDung_NguoiDungId",
                table: "ThueTro",
                column: "NguoiDungId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_NguoiDung_NguoiDungId",
                table: "Ticket",
                column: "NguoiDungId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_XuLy_Ticket_NguoiDung_NguoiDungId",
                table: "XuLy_Ticket",
                column: "NguoiDungId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayTro_NguoiDung_NguoiDungId",
                table: "DayTro");

            migrationBuilder.DropForeignKey(
                name: "FK_ThueTro_NguoiDung_NguoiDungId",
                table: "ThueTro");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_NguoiDung_NguoiDungId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_XuLy_Ticket_NguoiDung_NguoiDungId",
                table: "XuLy_Ticket");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_NguoiDungId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "NguoiDungId",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "NguoiDungId",
                table: "XuLy_Ticket",
                newName: "NhanVienId");

            migrationBuilder.RenameIndex(
                name: "IX_XuLy_Ticket_NguoiDungId",
                table: "XuLy_Ticket",
                newName: "IX_XuLy_Ticket_NhanVienId");

            migrationBuilder.RenameColumn(
                name: "NguoiDungId",
                table: "ThueTro",
                newName: "KhachHangId");

            migrationBuilder.RenameIndex(
                name: "IX_ThueTro_NguoiDungId",
                table: "ThueTro",
                newName: "IX_ThueTro_KhachHangId");

            migrationBuilder.RenameColumn(
                name: "NguoiDungId",
                table: "DayTro",
                newName: "KhachHangId");

            migrationBuilder.RenameIndex(
                name: "IX_DayTro_NguoiDungId",
                table: "DayTro",
                newName: "IX_DayTro_KhachHangId");

            migrationBuilder.CreateTable(
                name: "KhacHang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhacHang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DayTro_KhacHang_KhachHangId",
                table: "DayTro",
                column: "KhachHangId",
                principalTable: "KhacHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThueTro_KhacHang_KhachHangId",
                table: "ThueTro",
                column: "KhachHangId",
                principalTable: "KhacHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_XuLy_Ticket_NhanVien_NhanVienId",
                table: "XuLy_Ticket",
                column: "NhanVienId",
                principalTable: "NhanVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
