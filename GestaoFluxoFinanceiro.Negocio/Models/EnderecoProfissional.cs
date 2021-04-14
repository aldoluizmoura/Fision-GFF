﻿using System;

namespace GestaoFluxoFinanceiro.Negocio.Models
{
    public class EnderecoProfissional : Entity
    {
        public Guid ProfissionalId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }        
        public Profissional profissionais { get; set; }



}
}
