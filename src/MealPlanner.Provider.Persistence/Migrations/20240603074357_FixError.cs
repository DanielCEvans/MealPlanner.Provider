using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealPlanner.Provider.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_meal_ingredients",
                table: "meal_ingredients");

            migrationBuilder.AddColumn<string>(
                name: "meal_name",
                table: "meal_ingredients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ingredient_name",
                table: "meal_ingredients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_meal_ingredients",
                table: "meal_ingredients",
                columns: new[] { "meal_name", "ingredient_name" });

            migrationBuilder.CreateIndex(
                name: "IX_meal_ingredients_meal_id",
                table: "meal_ingredients",
                column: "meal_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_meal_ingredients",
                table: "meal_ingredients");

            migrationBuilder.DropIndex(
                name: "IX_meal_ingredients_meal_id",
                table: "meal_ingredients");

            migrationBuilder.DropColumn(
                name: "meal_name",
                table: "meal_ingredients");

            migrationBuilder.DropColumn(
                name: "ingredient_name",
                table: "meal_ingredients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_meal_ingredients",
                table: "meal_ingredients",
                columns: new[] { "meal_id", "ingredient_id" });
        }
    }
}
