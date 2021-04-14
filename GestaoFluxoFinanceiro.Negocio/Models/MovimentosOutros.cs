using System;

namespace GestaoFluxoFinanceiro.Negocio.Models
{
    public class MovimentosOutros : Entity
    {
        public string Competencia { get; set; }

        public string Descricao { get; set; }

        public string Observacao { get; set; }

        public Decimal Valor { get; set; }

        public int Tipo { get; set; }

        public DateTime DataMovimento { get; set; }
    }
}
