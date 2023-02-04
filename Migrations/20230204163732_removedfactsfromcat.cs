using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace egenAPI.Migrations
{
    /// <inheritdoc />
    public partial class removedfactsfromcat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Facts_CategoryId",
                table: "Facts");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_CategoryId",
                table: "Facts",
                column: "CategoryId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Facts_CategoryId",
                table: "Facts");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_CategoryId",
                table: "Facts",
                column: "CategoryId");
        }
    }
}
