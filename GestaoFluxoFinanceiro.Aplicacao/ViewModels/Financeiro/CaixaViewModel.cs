using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoFluxoFinanceiro.Aplicacao.ViewModels.Financeiro
{
    public class CaixaViewModel
    {
        public Guid Id { get; set; }

        public decimal TotalAlunos { get; set; }

        public decimal TotalProfissionais { get; set; }

        public decimal TotalOutrosMovimentos { get; set; }

        public decimal TotalDespesa { get; set; }

        public decimal TotalReceita { get; set; }

        public decimal TotalFinal { get; set; }

        public string Status { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }

        public int Situacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Mês")]
        public string Competencia { get; set; }

        public DateTime DataCaixa { get; set; }
    }
}