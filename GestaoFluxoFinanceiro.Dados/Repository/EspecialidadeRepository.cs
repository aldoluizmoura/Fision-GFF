using GestaoFluxoFinanceiro.Data.Contexto;
using GestaoFluxoFinanceiro.Negocio.Interfaces;
using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Dados.Repository
{
    public class EspecialidadeRepository : Repository<Especialidades>, IEspecialidadeRepository
    {
        public EspecialidadeRepository(ContextoBD contexto) : base(contexto) {  }

        public async Task<Especialidades> PegarEspecialidadePorId(Guid Id)
        {
            return  await Db.especialidade.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<Especialidades>> PegarEspecialidades()
        {
            return await Db.especialidade.AsNoTracking().ToListAsync();
        }

        public async Task<Especialidades> PegarEspecialidadesProDescricao(string descricao)
        {
            return await Db.especialidade.FirstOrDefaultAsync(e => e.Descricao == descricao);
        }
       
    }
}
