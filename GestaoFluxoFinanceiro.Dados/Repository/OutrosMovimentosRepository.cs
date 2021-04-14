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
    public class OutrosMovimentosRepository : Repository<MovimentosOutros>, IOutrosMovimentosRepository
    {
        public OutrosMovimentosRepository(ContextoBD contexto)
          : base(contexto)
        {
        }

        public async Task<MovimentosOutros> ObterMovimentoPorId(Guid Id)
        { 
             return await Db.OutrosMovimentos.FirstOrDefaultAsync(m => m.Id == Id);
        }

        public async Task<MovimentosOutros> ObterMovimentoPorTipo(int tipo) 
        {
            return await Db.OutrosMovimentos.FirstOrDefaultAsync(m => m.Tipo == tipo);
        } 

        public async Task<IEnumerable<MovimentosOutros>> ObterMovimentosPorCompetencia(string competencia)
        {
            return await Db.OutrosMovimentos.AsNoTracking().Where(m => m.Competencia == competencia).ToListAsync();
        }

        public async Task<IEnumerable<MovimentosOutros>> ObterTodosMovimentos()
        {
            return await Db.OutrosMovimentos.ToListAsync();
        }

        public async Task<IEnumerable<MovimentosOutros>> ObterMovimentosDespesaCompetencia(string competencia)
        {
            return await Db.OutrosMovimentos.AsNoTracking().Where(m => m.Competencia == competencia && m.Tipo == 2).ToListAsync();
        }

        public async Task<IEnumerable<MovimentosOutros>> ObterMovimentosReceitaCompetencia(string competencia)
        {
            return await Db.OutrosMovimentos.AsNoTracking().Where(m => m.Competencia == competencia && m.Tipo == 1).ToListAsync();
        }
    }
}
