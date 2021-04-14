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

    public class MovimentoProfissionalRepository : Repository<MovimentoProfissional>, IMovimentoProfissionalRepository
    {
        public MovimentoProfissionalRepository(ContextoBD contexto) : base(contexto){ }

        public async Task<IEnumerable<MovimentoProfissional>> ObterMovimentos()
        {
            return await Db.MovimentoProfissional.ToListAsync();
        }
        public async Task<Caixa> BuscarCompetenciaCaixa()
        {
            var Caixa = await Db.Caixa.OrderBy(c => c.Competencia).LastOrDefaultAsync();
            return Caixa;
        }
        public async Task<MovimentoProfissional> ObterMovimentoPorId(Guid MovimentoId)
        {
            return await Db.MovimentoProfissional.FirstOrDefaultAsync(m => m.Id == MovimentoId);
        }
        public async Task<MovimentoProfissional> ObterMovimentoPorProfissional(Guid ProfissionalId)
        {
            return await Db.MovimentoProfissional.FirstOrDefaultAsync(m => m.ProfissionalId == ProfissionalId);
        }
        public async Task<MovimentoProfissional> ObterMovimentoProfissionalCompetencia(Guid ProfissionalId, string competencia)
        {
            return await Db.MovimentoProfissional.FirstOrDefaultAsync(m => m.ProfissionalId == ProfissionalId && m.CompetenciaCobranca == competencia);
        }
        public async Task<IEnumerable<MovimentoProfissional>> ObterMovimentosReceitaCompetencia(string competencia)
        {
            return await Db.MovimentoProfissional.AsNoTracking().Where(m => m.CompetenciaPagamento == competencia && m.Situacao == 1 && m.TipoMovimento == 1).ToListAsync();
        }
    }
}
