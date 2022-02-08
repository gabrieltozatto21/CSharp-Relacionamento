using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace FilmesApi.Migrations
{
    public partial class Adicionandorelacionamentoentregerenteecinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gerentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gerentes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_GerenteFK",
                table: "Cinemas",
                column: "GerenteFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_gerentes_GerenteFK",
                table: "Cinemas",
                column: "GerenteFK",
                principalTable: "gerentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_gerentes_GerenteFK",
                table: "Cinemas");

            migrationBuilder.DropTable(
                name: "gerentes");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_GerenteFK",
                table: "Cinemas");
        }
    }
}
