using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MealPlanner.Provider.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIngredientTableToUseNaturalKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meal_ingredients_ingredient_ingredient_id",
                table: "meal_ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_meal_ingredients",
                table: "meal_ingredients");

            migrationBuilder.DropIndex(
                name: "IX_meal_ingredients_ingredient_id",
                table: "meal_ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ingredient",
                table: "ingredient");

            migrationBuilder.DropColumn(
                name: "ingredient_id",
                table: "meal_ingredients");

            migrationBuilder.DropColumn(
                name: "ingredient_id",
                table: "ingredient");

            migrationBuilder.AddColumn<string>(
                name: "measurement_unit",
                table: "meal_ingredients",
                type: "text",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "meal_name", "ingredient_name", "measurement_unit" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ingredient",
                table: "ingredient",
                columns: new[] { "ingredient_name", "measurement_unit" });

            migrationBuilder.CreateIndex(
                name: "IX_meal_ingredients_ingredient_name_measurement_unit",
                table: "meal_ingredients",
                columns: new[] { "ingredient_name", "measurement_unit" });

            migrationBuilder.AddForeignKey(
                name: "FK_meal_ingredients_ingredient_ingredient_name_measurement_unit",
                table: "meal_ingredients",
                columns: new[] { "ingredient_name", "measurement_unit" },
                principalTable: "ingredient",
                principalColumns: new[] { "ingredient_name", "measurement_unit" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meal_ingredients_ingredient_ingredient_name_measurement_unit",
                table: "meal_ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_meal_ingredients",
                table: "meal_ingredients");

            migrationBuilder.DropIndex(
                name: "IX_meal_ingredients_ingredient_name_measurement_unit",
                table: "meal_ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ingredient",
                table: "ingredient");

            migrationBuilder.DropColumn(
                name: "measurement_unit",
                table: "meal_ingredients");

            migrationBuilder.AddColumn<int>(
                name: "ingredient_id",
                table: "meal_ingredients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ingredient_name",
                table: "ingredient",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "ingredient_id",
                table: "ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_meal_ingredients",
                table: "meal_ingredients",
                columns: new[] { "meal_name", "ingredient_name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ingredient",
                table: "ingredient",
                column: "ingredient_id");

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
        }
    }
}
