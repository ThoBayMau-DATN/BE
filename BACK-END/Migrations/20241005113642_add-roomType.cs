using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class addroomType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardingHouse_FIle_BoardingHouse_BoardingHouseId",
                table: "BoardingHouse_FIle");

            migrationBuilder.DropColumn(
                name: "DayTroId",
                table: "BoardingHouse_FIle");

            migrationBuilder.AddColumn<int>(
                name: "RoomTypeId",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "BoardingHouseId",
                table: "BoardingHouse_FIle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomTypeId",
                table: "Room",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardingHouse_FIle_BoardingHouse_BoardingHouseId",
                table: "BoardingHouse_FIle",
                column: "BoardingHouseId",
                principalTable: "BoardingHouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomType_RoomTypeId",
                table: "Room",
                column: "RoomTypeId",
                principalTable: "RoomType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardingHouse_FIle_BoardingHouse_BoardingHouseId",
                table: "BoardingHouse_FIle");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomType_RoomTypeId",
                table: "Room");

            migrationBuilder.DropTable(
                name: "RoomType");

            migrationBuilder.DropIndex(
                name: "IX_Room_RoomTypeId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "Room");

            migrationBuilder.AlterColumn<int>(
                name: "BoardingHouseId",
                table: "BoardingHouse_FIle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DayTroId",
                table: "BoardingHouse_FIle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardingHouse_FIle_BoardingHouse_BoardingHouseId",
                table: "BoardingHouse_FIle",
                column: "BoardingHouseId",
                principalTable: "BoardingHouse",
                principalColumn: "Id");
        }
    }
}
