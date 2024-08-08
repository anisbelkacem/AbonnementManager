﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbonnementManager.Migrations
{
    /// <inheritdoc />
    public partial class EditAbonModel1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_abonnements_clients_Id_Client",
                table: "abonnements");

            migrationBuilder.DropIndex(
                name: "IX_abonnements_Id_Client",
                table: "abonnements");

            migrationBuilder.DropColumn(
                name: "Id_Client",
                table: "abonnements");

            migrationBuilder.CreateIndex(
                name: "IX_abonnements_IdClient",
                table: "abonnements",
                column: "IdClient");

            migrationBuilder.AddForeignKey(
                name: "FK_abonnements_clients_IdClient",
                table: "abonnements",
                column: "IdClient",
                principalTable: "clients",
                principalColumn: "Id_Client",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_abonnements_clients_IdClient",
                table: "abonnements");

            migrationBuilder.DropIndex(
                name: "IX_abonnements_IdClient",
                table: "abonnements");

            migrationBuilder.AddColumn<int>(
                name: "Id_Client",
                table: "abonnements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_abonnements_Id_Client",
                table: "abonnements",
                column: "Id_Client");

            migrationBuilder.AddForeignKey(
                name: "FK_abonnements_clients_Id_Client",
                table: "abonnements",
                column: "Id_Client",
                principalTable: "clients",
                principalColumn: "Id_Client",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
