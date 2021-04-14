using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoFluxoFinanceiro.Dados.Migrations
{
    public partial class ok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SaldoFinal",
                table: "Caixa",
                newName: "TotalReceita");

            migrationBuilder.RenameColumn(
                name: "Receita",
                table: "Caixa",
                newName: "TotalProfissionais");

            migrationBuilder.RenameColumn(
                name: "Despesa",
                table: "Caixa",
                newName: "TotalOutrosMovimentos");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Caixa",
                newName: "Situacao");

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Caixa",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Caixa",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAlunos",
                table: "Caixa",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalDespesa",
                table: "Caixa",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalFinal",
                table: "Caixa",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "MovimentosOutros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Competencia = table.Column<string>(type: "varchar(100)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(300)", nullable: true),
                    Observacao = table.Column<string>(type: "varchar(100)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    DataMovimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentosOutros", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentosOutros");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Caixa");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Caixa");

            migrationBuilder.DropColumn(
                name: "TotalAlunos",
                table: "Caixa");

            migrationBuilder.DropColumn(
                name: "TotalDespesa",
                table: "Caixa");

            migrationBuilder.DropColumn(
                name: "TotalFinal",
                table: "Caixa");

            migrationBuilder.RenameColumn(
                name: "TotalReceita",
                table: "Caixa",
                newName: "SaldoFinal");

            migrationBuilder.RenameColumn(
                name: "TotalProfissionais",
                table: "Caixa",
                newName: "Receita");

            migrationBuilder.RenameColumn(
                name: "TotalOutrosMovimentos",
                table: "Caixa",
                newName: "Despesa");

            migrationBuilder.RenameColumn(
                name: "Situacao",
                table: "Caixa",
                newName: "Codigo");
        }
    }
}
