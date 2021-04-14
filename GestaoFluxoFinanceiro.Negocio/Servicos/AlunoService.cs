using GestaoFluxoFinanceiro.Negocio.Interfaces;
using GestaoFluxoFinanceiro.Negocio.Models;
using GestaoFluxoFinanceiro.Negocio.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Servicos
{
    public class AlunoService : BaseService, IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IContratoFinanceiroAlunoRepository _contratofinanceiroRepository;
        private readonly IMovimentoAlunoRepository _movimentoRepository;

        public AlunoService(IAlunoRepository alunoRepository,
                             IEnderecoRepository enderecoRepository,
                             IContratoFinanceiroAlunoRepository contratoFinanceiro,
                             IMovimentoAlunoRepository movimentoRepository,
                             INotificador notificador) : base(notificador)
        {
            _alunoRepository = alunoRepository;
            _enderecoRepository = enderecoRepository;
            _contratofinanceiroRepository = contratoFinanceiro;
            _movimentoRepository = movimentoRepository;
        }
        public async Task Adicionar(Alunos entidade)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), entidade.Endereco)) return;
            if (!ExecutarValidacao(new ContratoFinanceiroAlunoValidation(), entidade.ContratoFinanceiroAluno)) return;

            if (_alunoRepository.Buscar(a=>a.CPF == entidade.CPF).Result.Any())
            {
                Notificar("Já existe um Aluno com este CPF.");
                return;
            }
            entidade.Ativo = true;            
            await _alunoRepository.Adicionar(entidade);
        }
        public async Task Atualizar(Alunos entidade)
        {
            if (entidade.Ativo) entidade.DataSaida = DateTime.Parse("01/01/0001");   
            else { entidade.DataSaida = DateTime.Now; }
            await _alunoRepository.Atualizar(entidade);            
        }       
        public async Task Remover(Guid id)
        {
            var endereco = await _enderecoRepository.ObterEndereco(id);            
            var contratofinanceiro = await _contratofinanceiroRepository.ObterContratoFinanceiroPorAluno(id);

            if (await _movimentoRepository.ObterMovimentosAlunoPorAluno(id) != null)
            {
                Notificar("Impossivel excluir pois o Aluno já possui movimentos financeiros!");
                return;
            }   

            if (endereco != null && contratofinanceiro != null)
            {
                await _enderecoRepository.Remover(endereco.Id);
                await _contratofinanceiroRepository.Remover(contratofinanceiro.Id);
            }
            await _alunoRepository.Remover(id);
        }        
        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;            
            await _enderecoRepository.Atualizar(endereco);
        }
        public async Task AtualizarContrato(ContratoFinanceiroAluno contrato)
        {
            await _contratofinanceiroRepository.Atualizar(contrato);
        }
        public async Task<bool> VerificarAdimplencia(Guid AlunoId)
        {
            var movimento = await _movimentoRepository.ObterMovimentosAlunoPorAluno(AlunoId);
            if (movimento == null) return false;
            if (movimento.Situacao == 3 && (DateTime.Now - movimento.DataVencimento).Days > 30)
            {   
                return true;
            }
            return false;
        }
        public bool VerificarAtivo(Guid Id)
        {
            var aluno = _alunoRepository.ObterAlunoPorId(Id).Result;
            if (aluno.Ativo) return true;
            else
            {
                Notificar("O Aluno "+aluno.Nome+" está inativo");
                return false;
            }
        }
        public void Dispose()
        {
            _alunoRepository.Dispose();                        
            _enderecoRepository.Dispose();
        }       
    }
}
