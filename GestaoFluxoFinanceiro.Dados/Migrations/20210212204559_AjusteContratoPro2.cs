using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoFluxoFinanceiro.Dados.Migrations
{
    public partial class AjusteContratoPro2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataVencimento",
                table: "MovimentoProfissional");

            migrationBuilder.DropColumn(
                name: "MargemLucro",
                table: "MovimentoProfissional");

            migrationBuilder.RenameColumn(
                name: "ValorPagar",
                table: "MovimentoProfissional",
                newName: "ValorTotal");

            migrationBuilder.RenameColumn(
                name: "ValorMensal",
                table: "MovimentoProfissional",
                newName: "ValorReceber");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorProfissional",
                table: "MovimentoProfissional",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorProfissional",
                table: "MovimentoProfissional");

            migrationBuilder.RenameColumn(
                name: "ValorTotal",
                table: "MovimentoProfissional",
                newName: "ValorPagar");

            migrationBuilder.RenameColumn(
                name: "ValorReceber",
                table: "MovimentoProfissional",
                newName: "ValorMensal");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataVencimento",
                table: "MovimentoProfissional",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MargemLucro",
                table: "MovimentoProfissional",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
