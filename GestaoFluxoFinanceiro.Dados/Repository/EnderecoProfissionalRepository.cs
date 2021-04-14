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
    public class EnderecoProfissionalRepository : Repository<EnderecoProfissional>, IEnderecoProfissionalRepository
    {
        public EnderecoProfissionalRepository(ContextoBD contexto):base(contexto){}

        public async Task<EnderecoProfissional> ObterEndereco(Guid EntidadeId)
        {
            return await Db.EnderecoProf.AsNoTracking().FirstOrDefaultAsync(e => e.ProfissionalId == EntidadeId);
        }        
    }
}
