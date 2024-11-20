using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class suaTen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateStart",
                table: "Service",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "DateEnd",
                table: "Service",
                newName: "EndDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Service",
                newName: "DateStart");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Service",
                newName: "DateEnd");
        }
    }
}
