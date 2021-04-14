using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoFluxoFinanceiro.Negocio.Models
{
    public class Especialidades : Entity
    {
        public string Descricao { get; set; }
        public IEnumerable<Profissional> Profissionais { get; set; }
    }
}
