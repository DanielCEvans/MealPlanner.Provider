using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealPlanner.Provider.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraintToUserIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserIngredients_UserId",
                table: "UserIngredients");

            migrationBuilder.CreateIndex(
                name: "IX_UserIngredients_UserId_IngredientId",
                table: "UserIngredients",
                columns: new[] { "UserId", "IngredientId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserIngredients_UserId_IngredientId",
                table: "UserIngredients");

            migrationBuilder.CreateIndex(
                name: "IX_UserIngredients_UserId",
                table: "UserIngredients",
                column: "UserId");
        }
    }
}
