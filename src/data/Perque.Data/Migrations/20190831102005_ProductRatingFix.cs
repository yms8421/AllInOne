using Microsoft.EntityFrameworkCore.Migrations;

namespace Perque.Data.Migrations
{
    public partial class ProductRatingFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                schema: "Productivity",
                table: "Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Point",
                schema: "Productivity",
                table: "Product",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFeatured",
                schema: "Productivity",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Point",
                schema: "Productivity",
                table: "Product");
        }
    }
}
