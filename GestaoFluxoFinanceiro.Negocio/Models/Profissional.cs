using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoFluxoFinanceiro.Negocio.Models
{
    public class Profissional : Entity
    {
        public Guid EspecialidadeId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }             
        public DateTime DataNascimento { get; set; }
        public string Matricula { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public Especialidades CodigoEspecialidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public TipoSexo TipoSexo { get; set; }        
        public DateTime DataSaida { get; set; }
        public EnderecoProfissional Endereco { get; set; }        
        public ContratoFinanceiroProfissional ContratoFinanceiroProfissional { get; set; }
        public IEnumerable<MovimentoProfissional> MovimentoProfissional { get; set; }

        


    }
}
