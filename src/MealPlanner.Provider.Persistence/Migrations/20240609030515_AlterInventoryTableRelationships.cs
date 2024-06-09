using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealPlanner.Provider.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AlterInventoryTableRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingredient_inventory_InventoryIngredientId",
                table: "ingredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory",
                table: "inventory");

            migrationBuilder.DropIndex(
                name: "IX_ingredient_InventoryIngredientId",
                table: "ingredient");

            migrationBuilder.AddColumn<int>(
                name: "inventory_id",
                table: "inventory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "ingredient",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory",
                table: "inventory",
                columns: new[] { "inventory_id", "ingredient_id" });

            migrationBuilder.CreateIndex(
                name: "IX_inventory_ingredient_id",
                table: "inventory",
                column: "ingredient_id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingredient_inventory_InventoryId_InventoryIngredientId",
                table: "ingredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory",
                table: "inventory");

            migrationBuilder.DropIndex(
                name: "IX_inventory_ingredient_id",
                table: "inventory");

            migrationBuilder.DropIndex(
                name: "IX_ingredient_InventoryId_InventoryIngredientId",
                table: "ingredient");

            migrationBuilder.DropColumn(
                name: "inventory_id",
                table: "inventory");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "ingredient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory",
                table: "inventory",
                column: "ingredient_id");

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_InventoryIngredientId",
                table: "ingredient",
                column: "InventoryIngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ingredient_inventory_InventoryIngredientId",
                table: "ingredient",
                column: "InventoryIngredientId",
                principalTable: "inventory",
                principalColumn: "ingredient_id");
        }
    }
}
