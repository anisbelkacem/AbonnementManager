using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbonnementManager.Migrations
{
    /// <inheritdoc />
    public partial class AddDateToAbonnement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateDebut",
                table: "abonnements",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateFin",
                table: "abonnements",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDebut",
                table: "abonnements");

            migrationBuilder.DropColumn(
                name: "DateFin",
                table: "abonnements");
        }
    }
}
