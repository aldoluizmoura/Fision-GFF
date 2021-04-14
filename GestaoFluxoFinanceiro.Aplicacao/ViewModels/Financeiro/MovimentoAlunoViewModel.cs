using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoFluxoFinanceiro.Aplicacao.ViewModels.Financeiro
{
    public class MovimentoAlunoViewModel
    {
        public Guid Id { get; set; }
        public Guid AlunoId { get; set; }
        public decimal ValorPagar { get; set; }
        public decimal ValorMensalidade { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Mês da Mensalidade")]
        public string CompetenciaMensalidade { get; set; }

        [DisplayName("Mês de Pagamento")]       
        public string CompetenciaPagamento { get; set; }
        public int Situacao { get; set; }
        public string SituacaoDesc { get; set; }
        public int TipoMovimento { get; set; }
        public int TipoPagamento { get; set; }
        public string Observacao { get; set; }
        public string Aluno { get; set; }
    }
}
