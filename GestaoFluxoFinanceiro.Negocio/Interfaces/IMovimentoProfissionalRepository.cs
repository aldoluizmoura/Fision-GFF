using GestaoFluxoFinanceiro.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Interfaces
{
    public interface IMovimentoProfissionalRepository : IRepository<MovimentoProfissional>
    {
        Task<MovimentoProfissional> ObterMovimentoPorProfissional(Guid ProfissionalId);
        Task<MovimentoProfissional> ObterMovimentoPorId(Guid MovimentoId);
        Task<MovimentoProfissional> ObterMovimentoProfissionalCompetencia(Guid ProfissionalId, string competencia);
        Task<IEnumerable<MovimentoProfissional>> ObterMovimentos();
        Task<IEnumerable<MovimentoProfissional>> ObterMovimentosReceitaCompetencia(string competencia);
        Task<Caixa> BuscarCompetenciaCaixa();
    }
}
