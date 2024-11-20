using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class suaBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Electric",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "Other",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Bill");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Service",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Room_History",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Water",
                table: "Bill",
                newName: "PriceRoom");

            migrationBuilder.RenameColumn(
                name: "TimeCreated",
                table: "Bill",
                newName: "CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Service",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Room_History",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "PriceRoom",
                table: "Bill",
                newName: "Water");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Bill",
                newName: "TimeCreated");

            migrationBuilder.AddColumn<int>(
                name: "Electric",
                table: "Bill",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Other",
                table: "Bill",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Bill",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
