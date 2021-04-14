using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoFluxoFinanceiro.Dados.Migrations
{
    public partial class AjusteMensalidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Competencia",
                table: "MovimentoAluno",
                newName: "CompetenciaPagamento");

            migrationBuilder.AddColumn<string>(
                name: "CompetenciaMensalidade",
                table: "MovimentoAluno",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompetenciaMensalidade",
                table: "MovimentoAluno");

            migrationBuilder.RenameColumn(
                name: "CompetenciaPagamento",
                table: "MovimentoAluno",
                newName: "Competencia");
        }
    }
}
