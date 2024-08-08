using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbonnementManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "applications",
                columns: table => new
                {
                    Id_App = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applications", x => x.Id_App);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id_Client = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id_Client);
                });

            migrationBuilder.CreateTable(
                name: "abonnements",
                columns: table => new
                {
                    Id_Abon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdApp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abonnements", x => x.Id_Abon);
                    table.ForeignKey(
                        name: "FK_abonnements_applications_IdApp",
                        column: x => x.IdApp,
                        principalTable: "applications",
                        principalColumn: "Id_App",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_abonnements_clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "clients",
                        principalColumn: "Id_Client",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_abonnements_IdApp",
                table: "abonnements",
                column: "IdApp");

            migrationBuilder.CreateIndex(
                name: "IX_abonnements_IdClient",
                table: "abonnements",
                column: "IdClient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "abonnements");

            migrationBuilder.DropTable(
                name: "applications");

            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
