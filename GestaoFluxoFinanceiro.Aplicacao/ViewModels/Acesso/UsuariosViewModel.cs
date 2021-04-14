using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Aplicacao.ViewModels.Acesso
{
    public class UsuariosViewModel
    {
        public string Nome { get; set; }
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string grupo { get; set; }
        public bool Ativo { get; set; }
    }
}
