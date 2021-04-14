using System;

namespace GestaoFluxoFinanceiro.Negocio.Models
{
    public  class MovimentoAluno : Entity
    {
        public Guid AlunoId { get; set; }
        public decimal ValorPagar { get; set; }
        public decimal ValorMensalidade { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public string CompetenciaMensalidade { get; set; }
        public string CompetenciaPagamento { get; set; }
        public int Situacao { get; set; }
        public int TipoMovimento { get; set; }
        public int TipoPagamento { get; set; }
        public string Observacao { get; set; }
        public Alunos Aluno { get; set; }

    }
}
