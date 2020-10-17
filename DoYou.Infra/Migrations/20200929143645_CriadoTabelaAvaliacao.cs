using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoYou.Infra.Migrations
{
    public partial class CriadoTabelaAvaliacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Estrelas = table.Column<int>(maxLength: 1, nullable: false),
                    Comentario = table.Column<string>(maxLength: 200, nullable: true),
                    FkEmpresa = table.Column<Guid>(nullable: true),
                    FkUsuario = table.Column<Guid>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Empresa_FkEmpresa",
                        column: x => x.FkEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Usuario_FkUsuario",
                        column: x => x.FkUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_FkEmpresa",
                table: "Avaliacao",
                column: "FkEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_FkUsuario",
                table: "Avaliacao",
                column: "FkUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");
        }
    }
}
