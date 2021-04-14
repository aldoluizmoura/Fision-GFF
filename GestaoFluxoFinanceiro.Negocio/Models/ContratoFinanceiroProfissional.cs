using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoFluxoFinanceiro.Negocio.Models
{
    public class ContratoFinanceiroProfissional : Entity
    {
        public Guid ProfissionalId { get; set; }
        public string Observacao { get; set; }
        public decimal ValorUnitario { get; set; }
        public int QuantidadeAlunos { get; set; }
        public int MargemLucro { get; set; }
        public DateTime DataCadastro { get; set; }

        public Profissional Profissionais { get; set; }
    }
}
