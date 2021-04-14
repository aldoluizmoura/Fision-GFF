using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoFluxoFinanceiro.Dados.Migrations
{
    public partial class AjusteContratoPro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MargemLucro",
                table: "MovimentoProfissional",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MargemLucro",
                table: "MovimentoProfissional",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
