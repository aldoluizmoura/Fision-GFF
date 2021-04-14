using GestaoFluxoFinanceiro.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Interfaces
{
    public interface IProfissionalService : IDisposable
    {
        Task Adicionar(Profissional entidade);
        Task Atualizar(Profissional entidade);
        Task Remover(Guid id);        
        Task AtualizarEndereco(EnderecoProfissional endereco);
        Task AtualizarContrato(ContratoFinanceiroProfissional contrato);
        bool VerificarAdimplencia(int matricula);
        bool VerificarAtivo(Guid Id);
    }
}
