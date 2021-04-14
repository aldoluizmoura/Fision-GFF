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
    public class AlunoRepository : Repository<Alunos>, IAlunoRepository
    {
        public AlunoRepository(ContextoBD context) : base(context) { }
        public async Task<Alunos> ObterAlunoPorId(Guid Id)
        {
            return await Db.Alunos.AsNoTracking().FirstOrDefaultAsync(a => a.Id == Id);
        }        
        public async Task<Alunos> ObterEnderecoAluno(Guid id)
        {
            return await Db.Alunos.AsNoTracking()
                .Include(end => end.Endereco)
                .FirstOrDefaultAsync(end => end.Id == id);
        }       
        public async Task<IEnumerable<Alunos>> ObterTodosAlunos()
        {
            return await Db.Alunos.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Alunos>> ObterTodosAlunosAtivos()
        {
            return await Db.Alunos.AsNoTracking().Where(a=>a.Ativo == true).ToListAsync();
        }

        public string ObterUltimaMatricula()
        {
            if (Db.Alunos.FirstOrDefault() == null) return "0000";
            var matricula = Db.Alunos.OrderBy(a=>a.Matricula).LastOrDefault();
            return matricula.Matricula.Substring(5,4);
        }
    }
}
