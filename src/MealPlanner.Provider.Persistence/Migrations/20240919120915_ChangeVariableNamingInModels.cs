using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealPlanner.Provider.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeVariableNamingInModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserIngredientId",
                table: "UserIngredients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ShoppingListId",
                table: "ShoppingLists",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ShoppingListItemId",
                table: "ShoppingListItems",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RecipeName",
                table: "Recipes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "Recipes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RecipeIngredientId",
                table: "RecipeIngredients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IngredientName",
                table: "Ingredients",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "Ingredients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "IngredientCategories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "IngredientCategories",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientCategories_CategoryName",
                table: "IngredientCategories",
                newName: "IX_IngredientCategories_Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserIngredients",
                newName: "UserIngredientId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShoppingLists",
                newName: "ShoppingListId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShoppingListItems",
                newName: "ShoppingListItemId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Recipes",
                newName: "RecipeName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Recipes",
                newName: "RecipeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RecipeIngredients",
                newName: "RecipeIngredientId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Ingredients",
                newName: "IngredientName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ingredients",
                newName: "IngredientId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "IngredientCategories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "IngredientCategories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientCategories_Name",
                table: "IngredientCategories",
                newName: "IX_IngredientCategories_CategoryName");
        }
    }
}
