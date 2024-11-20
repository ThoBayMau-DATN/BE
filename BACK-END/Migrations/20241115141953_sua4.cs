using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class sua4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "New_Price",
                table: "Service");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "Service",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStart",
                table: "Service",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "DateStart",
                table: "Service");

            migrationBuilder.AddColumn<int>(
                name: "New_Price",
                table: "Service",
                type: "int",
                nullable: true);
        }
    }
}
