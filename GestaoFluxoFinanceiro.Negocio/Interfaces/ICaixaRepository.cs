using GestaoFluxoFinanceiro.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Interfaces
{
    public interface ICaixaRepository : IRepository<Caixa>, IDisposable
    {
        Task<Caixa> ObterCaixaPorCompetencia(string competencia);

        Task<Caixa> ObterExtratoCaixa(string competencia);

        Task<Caixa> ObterCaixaPorId(Guid CaixaId);

        Task<IEnumerable<Caixa>> ObterCaixas();       
    }
}
