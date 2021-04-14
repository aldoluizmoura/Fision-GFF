using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoFluxoFinanceiro.Aplicacao.ViewModels
{
    public class ProfissionalViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Telefone { get; set; }

        public EnderecosProfissionalViewModel Endereco { get; set; }        
        public ContratoFinanceiroProfissionalViewModel ContratoFinanceiroProfissional { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]        
        [DisplayName("Data de Nascimento")]        
        public DateTime DataNascimento { get; set; }
       
        public int CodEspecialidade { get; set; }
        [DisplayName("Especialidade")]
        public Guid EspecialidadeId { get; set; }
        public string  Especialidade { get; set; }

        [DisplayName("Sexo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int TipoSexo { get; set; }
 
        public string Matricula { get; set; }
        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
        [DisplayName("Data de Saída")]
        public DateTime DataSaida { get; set; }        

        //public IEnumerable<ItemMovimentoViewModel> ItemMovimentos { get; set; }
        //public IEnumerable<MovimentoViewMode> Movimento { get; set; }
    }
}
