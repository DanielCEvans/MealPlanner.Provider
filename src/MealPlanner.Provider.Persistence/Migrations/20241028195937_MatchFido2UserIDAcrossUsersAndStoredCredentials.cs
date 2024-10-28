using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealPlanner.Provider.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MatchFido2UserIDAcrossUsersAndStoredCredentials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoredCredentials_Users_UserId1",
                table: "StoredCredentials");

            migrationBuilder.DropIndex(
                name: "IX_StoredCredentials_UserId1",
                table: "StoredCredentials");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "StoredCredentials");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "StoredCredentials",
                newName: "Fido2Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Fido2Id",
                table: "Users",
                column: "Fido2Id");

            migrationBuilder.CreateIndex(
                name: "IX_StoredCredentials_Fido2Id",
                table: "StoredCredentials",
                column: "Fido2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoredCredentials_Users_Fido2Id",
                table: "StoredCredentials",
                column: "Fido2Id",
                principalTable: "Users",
                principalColumn: "Fido2Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoredCredentials_Users_Fido2Id",
                table: "StoredCredentials");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Fido2Id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_StoredCredentials_Fido2Id",
                table: "StoredCredentials");

            migrationBuilder.RenameColumn(
                name: "Fido2Id",
                table: "StoredCredentials",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "StoredCredentials",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StoredCredentials_UserId1",
                table: "StoredCredentials",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StoredCredentials_Users_UserId1",
                table: "StoredCredentials",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
