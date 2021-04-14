using GestaoFluxoFinanceiro.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Interfaces
{
    public interface IOutrosMovimentosRepository : IRepository<MovimentosOutros>, IDisposable
    {
        Task<MovimentosOutros> ObterMovimentoPorId(Guid Id);

        Task<IEnumerable<MovimentosOutros>> ObterTodosMovimentos();

        Task<MovimentosOutros> ObterMovimentoPorTipo(int tipo);

        Task<IEnumerable<MovimentosOutros>> ObterMovimentosPorCompetencia(
          string competencia);

        Task<IEnumerable<MovimentosOutros>> ObterMovimentosDespesaCompetencia(
          string competencia);

        Task<IEnumerable<MovimentosOutros>> ObterMovimentosReceitaCompetencia(
          string competencia);
    }
}