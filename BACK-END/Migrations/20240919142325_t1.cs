using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class t1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_NguoiDung_NguoiDungId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NguoiDungId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NguoiDungId",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NguoiDungId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NguoiDungId",
                table: "AspNetUsers",
                column: "NguoiDungId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_NguoiDung_NguoiDungId",
                table: "AspNetUsers",
                column: "NguoiDungId",
                principalTable: "NguoiDung",
                principalColumn: "Id");
        }
    }
}
