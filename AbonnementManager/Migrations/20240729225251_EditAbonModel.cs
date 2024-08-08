using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbonnementManager.Migrations
{
    /// <inheritdoc />
    public partial class EditAbonModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_abonnements_applications_Id_App",
                table: "abonnements");

            migrationBuilder.DropIndex(
                name: "IX_abonnements_Id_App",
                table: "abonnements");

            migrationBuilder.DropColumn(
                name: "Id_App",
                table: "abonnements");

            migrationBuilder.CreateIndex(
                name: "IX_abonnements_IdApp",
                table: "abonnements",
                column: "IdApp");

            migrationBuilder.AddForeignKey(
                name: "FK_abonnements_applications_IdApp",
                table: "abonnements",
                column: "IdApp",
                principalTable: "applications",
                principalColumn: "Id_App",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_abonnements_applications_IdApp",
                table: "abonnements");

            migrationBuilder.DropIndex(
                name: "IX_abonnements_IdApp",
                table: "abonnements");

            migrationBuilder.AddColumn<int>(
                name: "Id_App",
                table: "abonnements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_abonnements_Id_App",
                table: "abonnements",
                column: "Id_App");

            migrationBuilder.AddForeignKey(
                name: "FK_abonnements_applications_Id_App",
                table: "abonnements",
                column: "Id_App",
                principalTable: "applications",
                principalColumn: "Id_App",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
