using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BACK_END.Migrations
{
    /// <inheritdoc />
    public partial class updateRelationtoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_ImageId",
                table: "Image",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Image_ImageId",
                table: "Image",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Image_ImageId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_ImageId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Image");
        }
    }
}
