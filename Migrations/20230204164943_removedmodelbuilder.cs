using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace egenAPI.Migrations
{
    /// <inheritdoc />
    public partial class removedmodelbuilder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facts_Categories_CategoryId",
                table: "Facts");

            migrationBuilder.DropIndex(
                name: "IX_Facts_CategoryId",
                table: "Facts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Facts_CategoryId",
                table: "Facts",
                column: "CategoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_Categories_CategoryId",
                table: "Facts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
