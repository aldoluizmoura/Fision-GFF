using GestaoFluxoFinanceiro.Negocio.Interfaces;
using GestaoFluxoFinanceiro.Negocio.Models;
using System;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Servicos
{
    public class MovimentoAlunoService : BaseService, IMovimentoAunoService
    {
        private readonly IMovimentoAlunoRepository _entidadeRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IContratoFinanceiroAlunoRepository _contratoRepository;
        
        public MovimentoAlunoService(IMovimentoAlunoRepository entidadeRepository,
                                      IAlunoRepository alunoRepository,
                                      IContratoFinanceiroAlunoRepository contratoRepository,
                                      INotificador notificador) : base(notificador)
        {
            _entidadeRepository = entidadeRepository;
            _alunoRepository = alunoRepository;
            _contratoRepository = contratoRepository;
        }
        public async Task<MovimentoAluno> GerarMovimentoAluno(string competencia, Guid AlunoId, Guid ContratoId)
        {
            var contrato = await _contratoRepository.ObterPorId(ContratoId);
            MovimentoAluno _movimento = new MovimentoAluno();

            _movimento.AlunoId = AlunoId;
            _movimento.CompetenciaMensalidade = competencia;
            _movimento.Situacao = 3;
            _movimento.TipoMovimento = 1;
            _movimento.ValorMensalidade = contrato.Valor;
            _movimento.Desconto = (contrato.Valor * (contrato.Desconto) / 100);
            _movimento.ValorPagar = (contrato.Valor) - (contrato.Valor * (contrato.Desconto) / 100);
            _movimento.DataVencimento = Convert.ToDateTime(DefinirDataVencimento(contrato.Vencimento, competencia));
            _movimento.Observacao = contrato.Observacao;

            return _movimento;
        }
        public string DefinirDataVencimento(string Vencimento, string Competencia)
        {
            var DataVencimento = Vencimento + "/" + Competencia.Substring(0, 2) + "/" + DateTime.Now.Year;
            return DataVencimento;
        }        
        public async Task GerarPagamento(Guid MovimentoId)
        {
            var movimento = await _entidadeRepository.ObterMovimentosAlunoPorId(MovimentoId);
            if (movimento.Situacao == 1)
            {
                Notificar("Mensalidade já está paga");
                return;
            }
            movimento.ValorPago = movimento.ValorPagar;
            movimento.ValorPagar = 0;
            movimento.Situacao = 1;
            movimento.CompetenciaPagamento = await BuscarCompetenciaPagamento(movimento.CompetenciaMensalidade);
            movimento.DataPagamento = DateTime.Now;

            await _entidadeRepository.Atualizar(movimento);
        }
        public async Task DesfazerPagamento(Guid MovimentoId, Guid ContratoId)
        {
            var movimento = await _entidadeRepository.ObterMovimentosAlunoPorId(MovimentoId);
            if (movimento.Situacao == 3)
            {
                Notificar("Mensalidade ainda não está quitada!");
                return;
            }
            var contrato = await _contratoRepository.ObterPorId(ContratoId);
            movimento.Situacao = 3;
            movimento.ValorPagar = (contrato.Valor) - (contrato.Valor * (contrato.Desconto) / 100);
            movimento.ValorPago = 0;
            movimento.CompetenciaPagamento = null;
            movimento.DataPagamento = DateTime.Parse("01/01/0001");
            await _entidadeRepository.Atualizar(movimento);
        }
        public async Task<bool> VerificarMovimentoCompetencia(string competencia, Guid AlunoId)
        {
            var movimento = await _entidadeRepository.ObterMovimentosPorAlunoCompetencia(AlunoId, competencia);
            if (movimento == null) return false;
            else return true;                     
        }
        public async Task<bool> VerificarPagamento(Guid MovimentoId)
        {
            var pagamento = await _entidadeRepository.ObterMovimentosAlunoPorId(MovimentoId);
            if (pagamento.Situacao == 3) 
            {
                Notificar("A mensalidade de " + pagamento.CompetenciaMensalidade + " ainda não está quitada!");
                return true;
            }
            else
            {
                Notificar("A mensalidade de "+pagamento.CompetenciaMensalidade + " já está quitada!");
                return false;
            }
        }
        public async Task<string> BuscarCompetenciaPagamento(string competencia)
        {
            var caixa = await _entidadeRepository.BuscarCompetenciaCaixa();

            if (caixa == null)
            {
                return competencia;
            }

            var MesCompetenciaValida = caixa.Competencia.Substring(0,2);

            if (int.Parse(MesCompetenciaValida) == 12)
            {
                MesCompetenciaValida = 0.ToString();
            } 
            
            if (caixa.Situacao == 1)return caixa.Competencia;
            else
            {
                var CompetenciaValida = int.Parse(MesCompetenciaValida.Substring(0, 2)) + 1;
                return (CompetenciaValida.ToString() + DateTime.Now.Year).PadLeft(6, '0');
            }          

        }
        public void Dispose()
        {
            _alunoRepository?.Dispose();
            _entidadeRepository?.Dispose();
        }        
    }
}
