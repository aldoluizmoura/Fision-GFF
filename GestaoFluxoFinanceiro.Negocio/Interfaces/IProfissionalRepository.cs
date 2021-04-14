using GestaoFluxoFinanceiro.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Interfaces
{
    public interface IProfissionalRepository : IRepository<Profissional>
    {
        Task<Profissional> ObterProfissinalPorId(Guid Id);
        Task<IEnumerable<Profissional>> ObterTodosProfissionais();
        Task<IEnumerable<Profissional>> ObterTodosProfissionaisAtivos();
        Task<Profissional> ObterEnderecoProfissional(Guid id);
        Task<IEnumerable<Profissional>> ProfissionalPorEspecialidade(Guid id);
        string ObterUltimaMatricula();

    }
}
