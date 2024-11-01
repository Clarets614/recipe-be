using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipeback.Migrations
{
    /// <inheritdoc />
    public partial class recipedbChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Directions",
                table: "recipes",
                newName: "directions");

            migrationBuilder.RenameColumn(
                name: "CookTime",
                table: "recipes",
                newName: "cook_time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "directions",
                table: "recipes",
                newName: "Directions");

            migrationBuilder.RenameColumn(
                name: "cook_time",
                table: "recipes",
                newName: "CookTime");
        }
    }
}
