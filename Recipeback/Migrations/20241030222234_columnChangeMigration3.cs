using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipeback.Migrations
{
    /// <inheritdoc />
    public partial class columnChangeMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Steps",
                table: "recipes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Steps",
                table: "recipes",
                type: "text",
                nullable: true);
        }
    }
}
