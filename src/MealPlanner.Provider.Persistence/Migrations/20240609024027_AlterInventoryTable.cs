using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MealPlanner.Provider.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AlterInventoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingredient_inventory_inventory_id",
                table: "ingredient");

            migrationBuilder.DropIndex(
                name: "IX_ingredient_inventory_id",
                table: "ingredient");

            migrationBuilder.DropColumn(
                name: "inventory_id",
                table: "ingredient");

            migrationBuilder.RenameColumn(
                name: "inventory_id",
                table: "inventory",
                newName: "ingredient_id");

            migrationBuilder.AlterColumn<int>(
                name: "ingredient_id",
                table: "inventory",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "InventoryIngredientId",
                table: "ingredient",
                type: "integer",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_ingredient_ingredient_id",
                table: "inventory",
                column: "ingredient_id",
                principalTable: "ingredient",
                principalColumn: "ingredient_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingredient_inventory_InventoryIngredientId",
                table: "ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_ingredient_ingredient_id",
                table: "inventory");

            migrationBuilder.DropIndex(
                name: "IX_ingredient_InventoryIngredientId",
                table: "ingredient");

            migrationBuilder.DropColumn(
                name: "InventoryIngredientId",
                table: "ingredient");

            migrationBuilder.RenameColumn(
                name: "ingredient_id",
                table: "inventory",
                newName: "inventory_id");

            migrationBuilder.AlterColumn<int>(
                name: "inventory_id",
                table: "inventory",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "inventory_id",
                table: "ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_inventory_id",
                table: "ingredient",
                column: "inventory_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ingredient_inventory_inventory_id",
                table: "ingredient",
                column: "inventory_id",
                principalTable: "inventory",
                principalColumn: "inventory_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
