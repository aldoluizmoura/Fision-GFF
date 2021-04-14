using GestaoFluxoFinanceiro.Aplicacao.Extensions;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoFluxoFinanceiro.Aplicacao.ViewModels.Financeiro
{
    public class OutrosMovimentosViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Mês")]
        public string Competencia { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Moeda]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Tipo { get; set; }

        [DisplayName("Data do Movimento")]
        public DateTime DataMovimento { get; set; }
    }
}