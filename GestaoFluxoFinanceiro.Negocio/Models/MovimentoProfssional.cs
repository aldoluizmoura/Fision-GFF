using System;

namespace GestaoFluxoFinanceiro.Negocio.Models
{
    public  class MovimentoProfissional : Entity
    {
        public Guid ProfissionalId { get; set; }
        public decimal ValorPago { get; set; }
        public decimal ValorReceber { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorProfissional { get; set; }
        public decimal ValorUnitario { get; set; }
        public int QuantidadeAlunos { get; set; }
        public DateTime DataPagamento { get; set; }
        public string CompetenciaCobranca { get; set; }
        public string CompetenciaPagamento { get; set; }
        public int Situacao { get; set; }
        public int TipoMovimento { get; set; }
        public int TipoPagamento { get; set; }
        public Profissional Profissionais { get; set; }
        public string Observacao { get; set; }       

    }
}
