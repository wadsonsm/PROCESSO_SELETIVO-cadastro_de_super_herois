using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudSuperHeroes.Infra.Migrations
{
    public partial class SuperPowersRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Herois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeHeroi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herois", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperPoderes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuperPoder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperPoderes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroisSuperPoderes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroiId = table.Column<int>(type: "int", nullable: false),
                    SuperPoderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroisSuperPoderes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeroisSuperPoderes_Herois_HeroiId",
                        column: x => x.HeroiId,
                        principalTable: "Herois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroisSuperPoderes_SuperPoderes_SuperPoderId",
                        column: x => x.SuperPoderId,
                        principalTable: "SuperPoderes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SuperPoderes",
                columns: new[] { "Id", "Descricao", "SuperPoder" },
                values: new object[] { 1, "pode gerar um campo de energia , permitindo que ele se mova livremente e levite", "Voa" });

            migrationBuilder.InsertData(
                table: "SuperPoderes",
                columns: new[] { "Id", "Descricao", "SuperPoder" },
                values: new object[] { 2, "é a habilidade de realizar proezas sobre-humanas de força física ou exercer força física além do escopo do que um humano é capaz", "Super Força" });

            migrationBuilder.CreateIndex(
                name: "IX_HeroisSuperPoderes_HeroiId",
                table: "HeroisSuperPoderes",
                column: "HeroiId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroisSuperPoderes_SuperPoderId",
                table: "HeroisSuperPoderes",
                column: "SuperPoderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroisSuperPoderes");

            migrationBuilder.DropTable(
                name: "Herois");

            migrationBuilder.DropTable(
                name: "SuperPoderes");
        }
    }
}
