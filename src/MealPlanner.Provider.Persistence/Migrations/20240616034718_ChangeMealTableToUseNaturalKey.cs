using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MealPlanner.Provider.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMealTableToUseNaturalKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meal_ingredients_meal_meal_id",
                table: "meal_ingredients");

            migrationBuilder.DropIndex(
                name: "IX_meal_ingredients_meal_id",
                table: "meal_ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_meal",
                table: "meal");

            migrationBuilder.DropColumn(
                name: "meal_id",
                table: "meal_ingredients");

            migrationBuilder.DropColumn(
                name: "meal_id",
                table: "meal");

            migrationBuilder.AlterColumn<string>(
                name: "meal_name",
                table: "meal",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_meal",
                table: "meal",
                column: "meal_name");

            migrationBuilder.AddForeignKey(
                name: "FK_meal_ingredients_meal_meal_name",
                table: "meal_ingredients",
                column: "meal_name",
                principalTable: "meal",
                principalColumn: "meal_name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meal_ingredients_meal_meal_name",
                table: "meal_ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_meal",
                table: "meal");

            migrationBuilder.AddColumn<int>(
                name: "meal_id",
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

            migrationBuilder.AddColumn<int>(
                name: "meal_id",
                table: "meal",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_meal",
                table: "meal",
                column: "meal_id");

            migrationBuilder.CreateIndex(
                name: "IX_meal_ingredients_meal_id",
                table: "meal_ingredients",
                column: "meal_id");

            migrationBuilder.AddForeignKey(
                name: "FK_meal_ingredients_meal_meal_id",
                table: "meal_ingredients",
                column: "meal_id",
                principalTable: "meal",
                principalColumn: "meal_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
