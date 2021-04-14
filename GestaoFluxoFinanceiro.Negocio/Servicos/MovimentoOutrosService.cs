using GestaoFluxoFinanceiro.Negocio.Interfaces;
using GestaoFluxoFinanceiro.Negocio.Models;
using System;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Servicos
{
    public class OutrosMovimentosService : BaseService, IOutrosMovimentosService, IDisposable
    {
        private readonly IOutrosMovimentosRepository _entidadeRepository;
        public OutrosMovimentosService(INotificador notificador,
                                       IOutrosMovimentosRepository entidadeRepository) : base(notificador)
        {
            _entidadeRepository = entidadeRepository;
        }

        public async Task Adicionar(MovimentosOutros entidade)
        {
            entidade.DataMovimento = DateTime.Now;
            await _entidadeRepository.Adicionar(entidade);
        }

        public async Task Atualizar(MovimentosOutros entidade)
        {
            entidade.DataMovimento  = _entidadeRepository.ObterMovimentoPorId(entidade.Id).Result.DataMovimento;
            entidade.Competencia += DateTime.Now.Year.ToString();
            await _entidadeRepository.Atualizar(entidade);
        }
        public async Task Remover(Guid id) 
        { 
            await _entidadeRepository.Remover(id); 
        }

        public void Dispose() 
        {
           _entidadeRepository?.Dispose();
        } 
        
    }
}