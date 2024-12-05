using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class updateidfromdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Service_Bill",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Service_Bill_ServiceId",
                table: "Service_Bill",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Bill_Service_ServiceId",
                table: "Service_Bill",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Bill_Service_ServiceId",
                table: "Service_Bill");

            migrationBuilder.DropIndex(
                name: "IX_Service_Bill_ServiceId",
                table: "Service_Bill");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Service_Bill");
        }
    }
}
