using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoYou.Infra.Migrations
{
    public partial class ajusteTabelasMesaComanda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FkMesa",
                table: "Comanda",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_FkMesa",
                table: "Comanda",
                column: "FkMesa");

            migrationBuilder.AddForeignKey(
                name: "FK_Comanda_Mesa_FkMesa",
                table: "Comanda",
                column: "FkMesa",
                principalTable: "Mesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comanda_Mesa_FkMesa",
                table: "Comanda");

            migrationBuilder.DropIndex(
                name: "IX_Comanda_FkMesa",
                table: "Comanda");

            migrationBuilder.DropColumn(
                name: "FkMesa",
                table: "Comanda");
        }
    }
}
