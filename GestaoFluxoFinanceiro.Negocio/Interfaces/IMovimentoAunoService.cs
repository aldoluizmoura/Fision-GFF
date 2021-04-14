using GestaoFluxoFinanceiro.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Interfaces
{
    public interface IMovimentoAunoService : IDisposable
    {
        Task<MovimentoAluno> GerarMovimentoAluno(string competencia, Guid AlunoId, Guid ContratoId);
        Task GerarPagamento(Guid MovimentoId);
        Task DesfazerPagamento(Guid MovimentoId, Guid ContratoId);
        Task<bool> VerificarMovimentoCompetencia(string competencia, Guid AlunoId);
        Task<bool> VerificarPagamento(Guid MovimentoId);
        Task<string> BuscarCompetenciaPagamento(string competencia);
    }
}
