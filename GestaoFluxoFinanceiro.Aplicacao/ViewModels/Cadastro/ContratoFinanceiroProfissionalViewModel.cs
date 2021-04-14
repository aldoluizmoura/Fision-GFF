using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoFluxoFinanceiro.Aplicacao.ViewModels
{
    public class ContratoFinanceiroProfissionalViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProfissionalId { get; set; }
        
        [DisplayName("Observação")]
        public string Observacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Valor Unitário")]
        public decimal ValorUnitario { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Quantidade de Alunos")]
        public int QuantidadeAlunos { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Margem de Lucro")]
        public int MargemLucro { get; set; }

        [HiddenInput]
        public ProfissionalViewModel profissional { get; set; }

    }
}
