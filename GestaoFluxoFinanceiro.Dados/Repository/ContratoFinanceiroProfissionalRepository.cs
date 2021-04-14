using GestaoFluxoFinanceiro.Data.Contexto;
using GestaoFluxoFinanceiro.Negocio.Interfaces;
using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Dados.Repository
{
    public class ContratoFinanceiroProfissionalRepository : Repository<ContratoFinanceiroProfissional>, IContratoFinanceiroProfissionalRepository
    {
        public ContratoFinanceiroProfissionalRepository(ContextoBD contexto):base(contexto){}

        public async Task<ContratoFinanceiroProfissional> ObterContratoFinanceiroPorProfissonal(Guid EntidadeId)
        {
            return await Db.contratoFinanceiroProfissional.AsNoTracking().FirstOrDefaultAsync(e => e.ProfissionalId == EntidadeId);           
        }

    }
}
