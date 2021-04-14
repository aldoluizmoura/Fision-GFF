using GestaoFluxoFinanceiro.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Interfaces
{
    public interface IMovimentoAlunoRepository : IRepository<MovimentoAluno>
    {
        Task<IEnumerable<MovimentoAluno>> ObterMovimentosAluno();
        Task<MovimentoAluno> ObterMovimentosAlunoPorAluno(Guid AlunoId);
        Task<MovimentoAluno> ObterMovimentosAlunoPorId(Guid MovimentoId);
        Task<MovimentoAluno> ObterMovimentosPorAlunoCompetencia(Guid AlunoId, string competencia);
        Task<IEnumerable<MovimentoAluno>> ObterMovimentosReceitaCompetencia(string competencia);
        Task<Caixa> BuscarCompetenciaCaixa();

    }
}
