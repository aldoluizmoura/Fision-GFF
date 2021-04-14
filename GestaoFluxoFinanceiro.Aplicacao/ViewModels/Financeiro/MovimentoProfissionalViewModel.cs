using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoFluxoFinanceiro.Aplicacao.ViewModels.Financeiro
{
    public class MovimentoProfissionalViewModel
    {
        public Guid Id { get; set; }
        public Guid ProfissionalId { get; set; }
        public decimal ValorPago { get; set; }
        public decimal ValorReceber { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorProfissional { get; set; }
        public decimal ValorUnitario { get; set; }
        public int QuantidadeAlunos { get; set; }
        public DateTime DataPagamento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CompetenciaCobranca { get; set; }
        public string CompetenciaPagamento { get; set; }
        public int Situacao { get; set; }
        public int TipoMovimento { get; set; }
        public string Profissional { get; set; }
        public string Observacao { get; set; }
    }
}
