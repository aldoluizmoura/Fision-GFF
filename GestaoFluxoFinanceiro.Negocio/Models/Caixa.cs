using System;

namespace GestaoFluxoFinanceiro.Negocio.Models
{
    public class Caixa : Entity
    {
        public decimal TotalAlunos { get; set; }

        public decimal TotalProfissionais { get; set; }

        public decimal TotalOutrosMovimentos { get; set; }

        public decimal TotalDespesa { get; set; }

        public decimal TotalReceita { get; set; }

        public decimal TotalFinal { get; set; }

        public string Status { get; set; }

        public string Observacao { get; set; }

        public int Situacao { get; set; }

        public string Competencia { get; set; }

        public DateTime DataCaixa { get; set; }
    }
}