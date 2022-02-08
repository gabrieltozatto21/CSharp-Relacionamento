using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace FilmesApi.Migrations
{
    public partial class Adicionandosessoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_gerentes_GerenteFK",
                table: "Cinemas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_gerentes",
                table: "gerentes");

            migrationBuilder.RenameTable(
                name: "gerentes",
                newName: "Gerentes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gerentes",
                table: "Gerentes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Sessoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FilmeId = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    HorarioEncerramento = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessoes_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessoes_Filmes_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_CinemaId",
                table: "Sessoes",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_FilmeId",
                table: "Sessoes",
                column: "FilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Gerentes_GerenteFK",
                table: "Cinemas",
                column: "GerenteFK",
                principalTable: "Gerentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Gerentes_GerenteFK",
                table: "Cinemas");

            migrationBuilder.DropTable(
                name: "Sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gerentes",
                table: "Gerentes");

            migrationBuilder.RenameTable(
                name: "Gerentes",
                newName: "gerentes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_gerentes",
                table: "gerentes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_gerentes_GerenteFK",
                table: "Cinemas",
                column: "GerenteFK",
                principalTable: "gerentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
