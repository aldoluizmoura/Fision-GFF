﻿using System;

namespace GestaoFluxoFinanceiro.Negocio.Models
{
    public class Endereco : Entity
    {
        public Guid? AlunoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }        
        public Alunos Aluno { get; set; }



}
}
