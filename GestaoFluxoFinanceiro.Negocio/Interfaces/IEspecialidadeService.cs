using GestaoFluxoFinanceiro.Negocio.Models;
using System;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Interfaces
{
    public interface IEspecialidadeService : IDisposable
    {
        Task Adicionar(Especialidades entidade);
        Task Atualizar(Especialidades entidade);
        Task Remover(Guid id);
    }
}
