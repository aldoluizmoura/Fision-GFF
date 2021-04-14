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
    public class ProfissionaisRepository : Repository<Profissional>, IProfissionalRepository
    {
        public ProfissionaisRepository(ContextoBD context) : base(context) { }
        public async Task<Profissional> ObterProfissinalPorId(Guid Id)
        {
            return await Db.profissionais.AsNoTracking().FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<IEnumerable<Profissional>> ObterTodosProfissionaisAtivos()
        {
            return await Db.profissionais.AsNoTracking().Where(a => a.Ativo == true).ToListAsync();
        }
        public async Task<Profissional> ObterEnderecoProfissional(Guid id)
        {
            return await Db.profissionais.AsNoTracking()
                .Include(end => end.Endereco)
                .FirstOrDefaultAsync(end => end.Id == id);
        }
        public async Task<IEnumerable<Profissional>> ObterTodosProfissionais()
        {
            return await Db.profissionais.AsNoTracking().ToListAsync();
        }
        public string ObterUltimaMatricula()
        {
            if (Db.profissionais.FirstOrDefault() == null) return "0000";
            var matricula = Db.profissionais.OrderBy(a => a.Matricula).LastOrDefault();
            return matricula.Matricula.Substring(5, 4);
        }
        public async Task<IEnumerable<Profissional>> ProfissionalPorEspecialidade(Guid id)
        {
            return await Db.profissionais.AsNoTracking().Where(c => c.EspecialidadeId == id).ToListAsync();
        }

    }
}
