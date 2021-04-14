using GestaoFluxoFinanceiro.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Interfaces
{
    public interface IMovimentoProfissionalService : IDisposable
    {
        Task<MovimentoProfissional> GerarMovimentoProfissionais(string competencia, Guid ProfissionalId, Guid ContratoId);
        Task<bool> VerificarMovimentoCompetencia(string competencia, Guid AlunoId);
        Task<string> BuscarCompetenciaPagamento(string competencia);
        Task GerarPagamento(Guid MovimentoId);
        Task<bool> VerificarPagamento(Guid MovimentoId);
        Task DesfazerPagamento(Guid MovimentoId, Guid ContratoId);

    }
}
