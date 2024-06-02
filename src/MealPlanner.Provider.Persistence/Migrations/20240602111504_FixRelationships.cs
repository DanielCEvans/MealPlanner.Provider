using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealPlanner.Provider.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_meal_ingredients",
                table: "meal_ingredients");

            migrationBuilder.DropColumn(
                name: "meal",
                table: "meal_ingredients");

            migrationBuilder.DropColumn(
                name: "ingredient",
                table: "meal_ingredients");

            migrationBuilder.AddColumn<int>(
                name: "meal_id",
                table: "meal_ingredients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ingredient_id",
                table: "meal_ingredients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "meal_name",
                table: "meal",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ingredient_name",
                table: "ingredient",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_meal_ingredients",
                table: "meal_ingredients",
                columns: new[] { "meal_id", "ingredient_id" });

            migrationBuilder.CreateIndex(
                name: "IX_meal_ingredients_ingredient_id",
                table: "meal_ingredients",
                column: "ingredient_id");

            migrationBuilder.AddForeignKey(
                name: "FK_meal_ingredients_ingredient_ingredient_id",
                table: "meal_ingredients",
                column: "ingredient_id",
                principalTable: "ingredient",
                principalColumn: "ingredient_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_meal_ingredients_meal_meal_id",
                table: "meal_ingredients",
                column: "meal_id",
                principalTable: "meal",
                principalColumn: "meal_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meal_ingredients_ingredient_ingredient_id",
                table: "meal_ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_meal_ingredients_meal_meal_id",
                table: "meal_ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_meal_ingredients",
                table: "meal_ingredients");

            migrationBuilder.DropIndex(
                name: "IX_meal_ingredients_ingredient_id",
                table: "meal_ingredients");

            migrationBuilder.DropColumn(
                name: "meal_id",
                table: "meal_ingredients");

            migrationBuilder.DropColumn(
                name: "ingredient_id",
                table: "meal_ingredients");

            migrationBuilder.AddColumn<string>(
                name: "meal",
                table: "meal_ingredients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ingredient",
                table: "meal_ingredients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "meal_name",
                table: "meal",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ingredient_name",
                table: "ingredient",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_meal_ingredients",
                table: "meal_ingredients",
                columns: new[] { "meal", "ingredient" });
        }
    }
}
