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
    public class ContratoFinanceiroAlunoRepository : Repository<ContratoFinanceiroAluno>, IContratoFinanceiroAlunoRepository
    {
        public ContratoFinanceiroAlunoRepository(ContextoBD contexto):base(contexto){}

        public async Task<ContratoFinanceiroAluno> ObterContratoFinanceiroPorAluno(Guid EntidadeId)
        {
            return await Db.contratoFinanceiroAluno.AsNoTracking().FirstOrDefaultAsync(e => e.AlunoId == EntidadeId);           
        }

    }
}
