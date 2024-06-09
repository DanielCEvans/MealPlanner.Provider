using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealPlanner.Provider.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveInventoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingredient_inventory_InventoryId_InventoryIngredientId",
                table: "ingredient");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropIndex(
                name: "IX_ingredient_InventoryId_InventoryIngredientId",
                table: "ingredient");

            migrationBuilder.DropColumn(
                name: "measurement_unit",
                table: "meal_ingredients");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "ingredient");

            migrationBuilder.DropColumn(
                name: "InventoryIngredientId",
                table: "ingredient");

            migrationBuilder.RenameColumn(
                name: "ingredient_amount",
                table: "meal_ingredients",
                newName: "meal_ingredient_amount");

            migrationBuilder.AddColumn<int>(
                name: "ingredient_amount",
                table: "ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ingredient_amount",
                table: "ingredient");

            migrationBuilder.RenameColumn(
                name: "meal_ingredient_amount",
                table: "meal_ingredients",
                newName: "ingredient_amount");

            migrationBuilder.AddColumn<string>(
                name: "measurement_unit",
                table: "meal_ingredients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "ingredient",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryIngredientId",
                table: "ingredient",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    inventory_id = table.Column<int>(type: "integer", nullable: false),
                    ingredient_id = table.Column<int>(type: "integer", nullable: false),
                    inventory_amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => new { x.inventory_id, x.ingredient_id });
                });

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_InventoryId_InventoryIngredientId",
                table: "ingredient",
                columns: new[] { "InventoryId", "InventoryIngredientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ingredient_inventory_InventoryId_InventoryIngredientId",
                table: "ingredient",
                columns: new[] { "InventoryId", "InventoryIngredientId" },
                principalTable: "inventory",
                principalColumns: new[] { "inventory_id", "ingredient_id" });
        }
    }
}
