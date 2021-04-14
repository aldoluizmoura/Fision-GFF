using GestaoFluxoFinanceiro.Negocio.Models;
using System;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Interfaces
{
    public interface IOutrosMovimentosService : IDisposable
    {
        Task Adicionar(MovimentosOutros entidade);

        Task Atualizar(MovimentosOutros entidade);

        Task Remover(Guid id);
    }
}
