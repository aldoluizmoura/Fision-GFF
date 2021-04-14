using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoFluxoFinanceiro.Aplicacao.ViewModels
{
    public class ContratoFinanceiroAlunoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Observacao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Desconto { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Vencimento { get; set; }
       

        [HiddenInput]
        public Guid AlunoId { get; set; }

    }
}
