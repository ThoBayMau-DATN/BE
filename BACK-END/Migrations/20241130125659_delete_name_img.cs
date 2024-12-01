using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class delete_name_img : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Image",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
