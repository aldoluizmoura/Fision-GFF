using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoFluxoFinanceiro.Aplicacao.ViewModels
{
    public class EspecialidadesViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage ="o Campo {0} é obrigatório")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }        
        public IEnumerable<ProfissionalViewModel> Entidades { get; set; }

    }
}
