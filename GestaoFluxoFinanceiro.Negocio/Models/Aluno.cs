using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoFluxoFinanceiro.Negocio.Models
{
    public class Alunos : Entity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }             
        public DateTime DataNascimento { get; set; }
        public string Matricula { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public TipoSexo TipoSexo { get; set; }        
        public DateTime DataSaida { get; set; }
        public Endereco Endereco { get; set; }
        public ContratoFinanceiroAluno ContratoFinanceiroAluno { get; set; }        
        public IEnumerable<MovimentoAluno> MovimentoAluno { get; set; }
        


    }
}
