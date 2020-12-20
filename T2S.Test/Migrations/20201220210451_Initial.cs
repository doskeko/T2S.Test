using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace T2S.Test.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conteiner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumCntr = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteiner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoMovimentacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConteinerMovimentacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConteinerId = table.Column<int>(type: "int", nullable: false),
                    MovimentacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConteinerMovimentacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConteinerMovimentacao_Conteiner_ConteinerId",
                        column: x => x.ConteinerId,
                        principalTable: "Conteiner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConteinerMovimentacao_Movimentacao_MovimentacaoId",
                        column: x => x.MovimentacaoId,
                        principalTable: "Movimentacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConteinerMovimentacao_ConteinerId",
                table: "ConteinerMovimentacao",
                column: "ConteinerId");

            migrationBuilder.CreateIndex(
                name: "IX_ConteinerMovimentacao_MovimentacaoId",
                table: "ConteinerMovimentacao",
                column: "MovimentacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConteinerMovimentacao");

            migrationBuilder.DropTable(
                name: "Conteiner");

            migrationBuilder.DropTable(
                name: "Movimentacao");
        }
    }
}
