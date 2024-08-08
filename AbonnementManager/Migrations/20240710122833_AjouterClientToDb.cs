using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AbonnementManager.Migrations
{
    /// <inheritdoc />
    public partial class AjouterClientToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "Id_Client", "Description", "Email", "LastName", "Name", "Tel" },
                values: new object[,]
                {
                    { 1, "hello my name is anis", "Anis@gmail.com", "Belkacem", "Anis", "+216 29172360" },
                    { 2, "hello my name is Test", "Test@gmail.com", "Test", "Test", "+216 29172360" },
                    { 3, "hello my name is Admin", "Admin@gmail.com", "Admin", "Admin", "+216 29172360" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "Id_Client",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "Id_Client",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "Id_Client",
                keyValue: 3);
        }
    }
}
