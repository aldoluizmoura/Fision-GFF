using GestaoFluxoFinanceiro.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Interfaces
{
    public interface IAlunoService : IDisposable
    {
        Task Adicionar(Alunos entidade);
        Task Atualizar(Alunos entidade);
        Task Remover(Guid id);                
        Task AtualizarEndereco(Endereco endereco);
        Task AtualizarContrato(ContratoFinanceiroAluno contrato);
        Task<bool> VerificarAdimplencia(Guid AlunoId);
        bool VerificarAtivo(Guid AlunoId);
    }
}
