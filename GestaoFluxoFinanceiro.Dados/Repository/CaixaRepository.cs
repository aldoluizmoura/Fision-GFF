using GestaoFluxoFinanceiro.Data.Contexto;
using GestaoFluxoFinanceiro.Negocio.Interfaces;
using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Dados.Repository
{
    public class CaixaRepository : Repository<Caixa>, ICaixaRepository
    {
        public CaixaRepository(ContextoBD context) : base(context){}

        public async Task<IEnumerable<Caixa>> ObterCaixas()
        {
            return await Db.Caixa.ToListAsync();
        }       
        public async Task<Caixa> ObterCaixaPorId(Guid CaixaId)
        {
            return await Db.Caixa.FirstOrDefaultAsync(c => c.Id == CaixaId);
        }
        public async Task<Caixa> ObterCaixaPorCompetencia(string competencia)
        {
             return await Db.Caixa.FirstOrDefaultAsync(c => c.Competencia == competencia);
        }
        public Task<Caixa> ObterExtratoCaixa(string competencia)
        {
            throw new NotImplementedException();
        }

    }
}