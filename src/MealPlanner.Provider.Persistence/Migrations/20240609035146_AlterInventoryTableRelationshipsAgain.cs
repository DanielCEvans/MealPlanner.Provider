using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealPlanner.Provider.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AlterInventoryTableRelationshipsAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_ingredient_ingredient_id",
                table: "inventory");

            migrationBuilder.DropIndex(
                name: "IX_inventory_ingredient_id",
                table: "inventory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_inventory_ingredient_id",
                table: "inventory",
                column: "ingredient_id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_ingredient_ingredient_id",
                table: "inventory",
                column: "ingredient_id",
                principalTable: "ingredient",
                principalColumn: "ingredient_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
