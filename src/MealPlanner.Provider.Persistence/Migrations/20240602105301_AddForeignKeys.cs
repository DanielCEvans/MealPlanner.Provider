using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealPlanner.Provider.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingredient_meal_ingredients_MealIngredientsMeal_MealIngredi~",
                table: "ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_meal_meal_ingredients_MealIngredientsMeal_MealIngredientsIn~",
                table: "meal");

            migrationBuilder.DropIndex(
                name: "IX_meal_MealIngredientsMeal_MealIngredientsIngredient",
                table: "meal");

            migrationBuilder.DropIndex(
                name: "IX_ingredient_MealIngredientsMeal_MealIngredientsIngredient",
                table: "ingredient");

            migrationBuilder.DropColumn(
                name: "MealIngredientsIngredient",
                table: "meal");

            migrationBuilder.DropColumn(
                name: "MealIngredientsMeal",
                table: "meal");

            migrationBuilder.DropColumn(
                name: "MealIngredientsIngredient",
                table: "ingredient");

            migrationBuilder.DropColumn(
                name: "MealIngredientsMeal",
                table: "ingredient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MealIngredientsIngredient",
                table: "meal",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MealIngredientsMeal",
                table: "meal",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MealIngredientsIngredient",
                table: "ingredient",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MealIngredientsMeal",
                table: "ingredient",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_meal_MealIngredientsMeal_MealIngredientsIngredient",
                table: "meal",
                columns: new[] { "MealIngredientsMeal", "MealIngredientsIngredient" });

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_MealIngredientsMeal_MealIngredientsIngredient",
                table: "ingredient",
                columns: new[] { "MealIngredientsMeal", "MealIngredientsIngredient" });

            migrationBuilder.AddForeignKey(
                name: "FK_ingredient_meal_ingredients_MealIngredientsMeal_MealIngredi~",
                table: "ingredient",
                columns: new[] { "MealIngredientsMeal", "MealIngredientsIngredient" },
                principalTable: "meal_ingredients",
                principalColumns: new[] { "meal", "ingredient" });

            migrationBuilder.AddForeignKey(
                name: "FK_meal_meal_ingredients_MealIngredientsMeal_MealIngredientsIn~",
                table: "meal",
                columns: new[] { "MealIngredientsMeal", "MealIngredientsIngredient" },
                principalTable: "meal_ingredients",
                principalColumns: new[] { "meal", "ingredient" });
        }
    }
}
