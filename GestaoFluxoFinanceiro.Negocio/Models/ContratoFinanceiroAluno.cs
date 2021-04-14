using System;

namespace GestaoFluxoFinanceiro.Negocio.Models
{
    public class ContratoFinanceiroAluno : Entity
    {
        public Guid AlunoId { get; set; }      
        public decimal Valor { get; set; }
        public string Observacao { get; set; }        
        public int Desconto { get; set; }
        public string Vencimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public Alunos aluno { get; set; }
        
    }
}
