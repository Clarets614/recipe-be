using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipeback.Migrations
{
    /// <inheritdoc />
    public partial class NewRecipeFieldMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Steps",
                table: "recipes",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Steps",
                table: "recipes");
        }
    }
}
