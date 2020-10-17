using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoYou.Infra.Migrations
{
    public partial class ajusteTabelaComandaEUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FkUsuario",
                table: "Comanda",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_FkUsuario",
                table: "Comanda",
                column: "FkUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Comanda_Usuario_FkUsuario",
                table: "Comanda",
                column: "FkUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comanda_Usuario_FkUsuario",
                table: "Comanda");

            migrationBuilder.DropIndex(
                name: "IX_Comanda_FkUsuario",
                table: "Comanda");

            migrationBuilder.DropColumn(
                name: "FkUsuario",
                table: "Comanda");
        }
    }
}
