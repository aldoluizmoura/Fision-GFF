using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoFluxoFinanceiro.Dados.Migrations
{
    public partial class ajusteDocProf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Competencia",
                table: "MovimentoProfissional",
                newName: "CompetenciaPagamento");

            migrationBuilder.AddColumn<string>(
                name: "CompetenciaCobranca",
                table: "MovimentoProfissional",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompetenciaCobranca",
                table: "MovimentoProfissional");

            migrationBuilder.RenameColumn(
                name: "CompetenciaPagamento",
                table: "MovimentoProfissional",
                newName: "Competencia");
        }
    }
}
