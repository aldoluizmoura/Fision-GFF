using GestaoFluxoFinanceiro.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Interfaces
{
    public interface IContratoFinanceiroProfissionalRepository : IRepository<ContratoFinanceiroProfissional>
    {
        Task<ContratoFinanceiroProfissional> ObterContratoFinanceiroPorProfissonal(Guid ProfissionalId);               
    }
}
