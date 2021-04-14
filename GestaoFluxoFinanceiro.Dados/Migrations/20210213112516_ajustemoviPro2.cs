using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoFluxoFinanceiro.Dados.Migrations
{
    public partial class ajustemoviPro2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantidadeAlunos",
                table: "MovimentoProfissional",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValorUnitario",
                table: "MovimentoProfissional",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeAlunos",
                table: "MovimentoProfissional");

            migrationBuilder.DropColumn(
                name: "ValorUnitario",
                table: "MovimentoProfissional");
        }
    }
}
