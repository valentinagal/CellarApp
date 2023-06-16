using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineCellar.API.Migrations
{
    /// <inheritdoc />
    public partial class ImagePossibility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Wines",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Wines");
        }
    }
}
