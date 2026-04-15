using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorsoCS.Handlers.Migrations
{
    /// <inheritdoc />
    public partial class Flagged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Flagged",
                table: "Notes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Flagged",
                table: "Notes");
        }
    }
}
