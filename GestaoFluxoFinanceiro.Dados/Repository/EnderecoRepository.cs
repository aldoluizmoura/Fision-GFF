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
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ContextoBD contexto):base(contexto){}

        public async Task<Endereco> ObterEndereco(Guid EntidadeId)
        {
            return await Db.Enderecos.AsNoTracking().FirstOrDefaultAsync(e => e.AlunoId == EntidadeId);
        }        
    }
}
