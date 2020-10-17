using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoYou.Infra.Migrations
{
    public partial class CriadoTabelasRestaurante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proprietario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    Senha = table.Column<string>(maxLength: 32, nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Celular = table.Column<string>(maxLength: 11, nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    EmpresaUltimoAcesso = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 100, nullable: false),
                    Fantasia = table.Column<string>(maxLength: 100, nullable: false),
                    Cnpj = table.Column<string>(maxLength: 18, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(maxLength: 14, nullable: false),
                    Categoria = table.Column<int>(nullable: false),
                    EndCep = table.Column<string>(maxLength: 10, nullable: true),
                    EndUf = table.Column<string>(maxLength: 10, nullable: true),
                    EndComplemento = table.Column<string>(maxLength: 200, nullable: true),
                    EndNumero = table.Column<int>(maxLength: 10, nullable: true),
                    EndBairro = table.Column<string>(maxLength: 100, nullable: true),
                    EndLogradouro = table.Column<string>(maxLength: 100, nullable: true),
                    EndMunicipio = table.Column<string>(maxLength: 100, nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    ProprietarioId = table.Column<Guid>(nullable: true),
                    FkProprietario = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresa_Proprietario_FkProprietario",
                        column: x => x.FkProprietario,
                        principalTable: "Proprietario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empresa_Proprietario_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Proprietario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false),
                    Valor = table.Column<double>(maxLength: 40, nullable: false),
                    Foto = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    FkEmpresa = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Empresa_FkEmpresa",
                        column: x => x.FkEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mesa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<int>(maxLength: 10, nullable: false),
                    Ocupada = table.Column<bool>(nullable: false),
                    FkEmpresa = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesa_Empresa_FkEmpresa",
                        column: x => x.FkEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_FkProprietario",
                table: "Empresa",
                column: "FkProprietario");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_ProprietarioId",
                table: "Empresa",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_FkEmpresa",
                table: "Item",
                column: "FkEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Mesa_FkEmpresa",
                table: "Mesa",
                column: "FkEmpresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Mesa");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Proprietario");
        }
    }
}
