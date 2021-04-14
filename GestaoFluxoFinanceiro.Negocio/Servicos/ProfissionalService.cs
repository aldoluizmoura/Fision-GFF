using GestaoFluxoFinanceiro.Negocio.Interfaces;
using GestaoFluxoFinanceiro.Negocio.Models;
using GestaoFluxoFinanceiro.Negocio.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Servicos
{
    public class ProfissionalService : BaseService, IProfissionalService
    {
        private readonly IProfissionalRepository _profissionalRepository;
        private readonly IEnderecoProfissionalRepository _enderecoRepository;        
        private readonly IContratoFinanceiroProfissionalRepository _contratofinanProfRepository;
        private readonly IMovimentoProfissionalRepository _movimentoRepository;
        public ProfissionalService(IProfissionalRepository profissionalRepository,
                             IEnderecoProfissionalRepository enderecoRepository,                             
                             IContratoFinanceiroProfissionalRepository contratoProfFinanceiro,
                             IMovimentoProfissionalRepository movimentoRepository,
                             INotificador notificador) : base(notificador)
        {
            _profissionalRepository = profissionalRepository;
            _enderecoRepository = enderecoRepository;            
            _contratofinanProfRepository = contratoProfFinanceiro;
            _movimentoRepository = movimentoRepository;
        }
        public async Task Adicionar(Profissional entidade)
        {
            if (!ExecutarValidacao(new EnderecoProfissionalValidation(), entidade.Endereco)) return;
            if (!ExecutarValidacao(new ContratoFinanceiroProfissionalValidation(), entidade.ContratoFinanceiroProfissional)) return;

            if (_profissionalRepository.Buscar(a=>a.CPF == entidade.CPF).Result.Any())
            {
                Notificar("Já existe um Profissional com este CPF.");                
            }
            entidade.Ativo = true;            
            await _profissionalRepository.Adicionar(entidade);
        }

        public async Task Atualizar(Profissional entidade)
        {
            if (entidade.Ativo) entidade.DataSaida = DateTime.Parse("01/01/0001");
            else { entidade.DataSaida = DateTime.Now; }
            await _profissionalRepository.Atualizar(entidade);            
        }                
        public async Task Remover(Guid id)
        {
            var endereco = await _enderecoRepository.ObterEndereco(id);
            var contratofinanceiro = await _contratofinanProfRepository.ObterContratoFinanceiroPorProfissonal(id);

            if (await  _movimentoRepository.ObterMovimentoPorProfissional(id) != null)
            {
                Notificar("Impossivel excluir pois o Profissional já possui movimentos financeiros!");
                return;
            }

            if (endereco != null && contratofinanceiro != null)
            {
                await _enderecoRepository.Remover(endereco.Id);
                await _contratofinanProfRepository.Remover(contratofinanceiro.Id);
            }

            await _profissionalRepository.Remover(id);
        }
        public async Task AtualizarEndereco(EnderecoProfissional endereco)
        {
            if (!ExecutarValidacao(new EnderecoProfissionalValidation(), endereco)) return;

            await _enderecoRepository.Atualizar(endereco);
        }
        public async Task AtualizarContrato(ContratoFinanceiroProfissional contrato)
        {
            await _contratofinanProfRepository.Atualizar(contrato);
        }

        public bool VerificarAdimplencia(int matricula)
        {
            throw new NotImplementedException();
        }
        public bool VerificarAtivo(Guid Id)
        {
            var profissional = _profissionalRepository.ObterProfissinalPorId(Id).Result;
            if (profissional.Ativo) return true;
            else
            {
                Notificar("O Profissional " + profissional.Nome + " está inativo");
                return false;
            }
        }
        public void Dispose()
        {
            _profissionalRepository.Dispose();           
            _contratofinanProfRepository.Dispose();
            _enderecoRepository.Dispose();
        }       
    }
}
