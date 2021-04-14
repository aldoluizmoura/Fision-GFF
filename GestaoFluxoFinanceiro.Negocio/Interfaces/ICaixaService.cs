using GestaoFluxoFinanceiro.Negocio.Models;
using System;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Interfaces
{
    public interface ICaixaService : IDisposable
    {
        Task Adicionar(Caixa caixa);

        Task Atualizar(Caixa caixa);

        Task<decimal> GerarReceita(string competencia);

        Task<decimal> GerarDespesa(string competencia);

        Task<Caixa> ObterValoresFinaisCaixa(Guid Id);              
        Task FecharCaixa(Guid Id);
        Task Reprocessar(Guid Id);
    }
}