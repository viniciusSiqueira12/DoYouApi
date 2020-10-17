using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoYou.Infra.Migrations
{
    public partial class criadoTabelaComandaEComandaItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Abertura = table.Column<DateTime>(nullable: false),
                    Fechada = table.Column<DateTime>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    Gorjeta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemComanda",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    ValorItem = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 200, nullable: true),
                    FkItem = table.Column<Guid>(nullable: true),
                    FkComanda = table.Column<Guid>(nullable: true),
                    DataPedido = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemComanda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemComanda_Comanda_FkComanda",
                        column: x => x.FkComanda,
                        principalTable: "Comanda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemComanda_Item_FkItem",
                        column: x => x.FkItem,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemComanda_FkComanda",
                table: "ItemComanda",
                column: "FkComanda");

            migrationBuilder.CreateIndex(
                name: "IX_ItemComanda_FkItem",
                table: "ItemComanda",
                column: "FkItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemComanda");

            migrationBuilder.DropTable(
                name: "Comanda");
        }
    }
}
