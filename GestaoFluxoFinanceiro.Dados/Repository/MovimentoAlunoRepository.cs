using GestaoFluxoFinanceiro.Data.Contexto;
using GestaoFluxoFinanceiro.Negocio.Interfaces;
using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Dados.Repository
{
    public class MovimentoAlunoRepository : Repository<MovimentoAluno>, IMovimentoAlunoRepository
    {
        public MovimentoAlunoRepository(ContextoBD contexto): base(contexto) {  }

        public async Task<Caixa> BuscarCompetenciaCaixa()
        {
            var Caixa = await Db.Caixa.OrderBy(c => c.Competencia).LastOrDefaultAsync();
            return Caixa;
        }
        public async Task<IEnumerable<MovimentoAluno>> ObterMovimentosAluno()
        {
            return await Db.MovimentoAluno.ToListAsync();
        }
        public async Task<MovimentoAluno> ObterMovimentosAlunoPorAluno(Guid AlunoId)
        {
            return await Db.MovimentoAluno.OrderBy(a => a.Id).LastOrDefaultAsync(a=>a.AlunoId == AlunoId);
        }
        public async Task<MovimentoAluno> ObterMovimentosAlunoPorId(Guid MovimentoId)
        {
            return await Db.MovimentoAluno.OrderBy(a => a.Id).LastOrDefaultAsync(a => a.Id == MovimentoId);
        }
        public async Task<MovimentoAluno> ObterMovimentosPorAlunoCompetencia(Guid AlunoId, string competencia)
        {
            return await Db.MovimentoAluno.FirstOrDefaultAsync(m => m.AlunoId == AlunoId && m.CompetenciaMensalidade == competencia);
        }
        public async Task<IEnumerable<MovimentoAluno>> ObterMovimentosReceitaCompetencia(string competencia)
        {
            return await Db.MovimentoAluno.AsNoTracking().Where(m => m.CompetenciaPagamento == competencia && m.TipoMovimento == 1 && m.Situacao == 1).ToListAsync();
        }
    }
}
