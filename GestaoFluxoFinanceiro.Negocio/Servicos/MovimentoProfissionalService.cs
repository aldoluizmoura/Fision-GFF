using GestaoFluxoFinanceiro.Negocio.Interfaces;
using GestaoFluxoFinanceiro.Negocio.Models;
using System;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Servicos
{
    public class MovimentoProfissionalService : BaseService, IMovimentoProfissionalService
    {
        private readonly IMovimentoProfissionalRepository _entidadeRepository;
        private readonly IContratoFinanceiroProfissionalRepository _contratoRepository;
        private readonly IProfissionalRepository _profissionalRepository;
        public MovimentoProfissionalService(IMovimentoProfissionalRepository entidadeRepository,
                                           IContratoFinanceiroProfissionalRepository contratoRepository,
                                           IProfissionalRepository profissionalRepository,
                                           INotificador notificador) : base(notificador)
        {
            _entidadeRepository = entidadeRepository;
            _contratoRepository = contratoRepository;
            _profissionalRepository = profissionalRepository;
        }
        public async Task<MovimentoProfissional> GerarMovimentoProfissionais(string competencia, Guid ProfissionalId, Guid ContratoId)
        {
            var contrato = await _contratoRepository.ObterPorId(ContratoId);

            MovimentoProfissional movimento = new MovimentoProfissional();
            movimento.ProfissionalId = ProfissionalId;
            movimento.CompetenciaCobranca = competencia;
            movimento.CompetenciaPagamento = null;
            movimento.ValorTotal = contrato.ValorUnitario * contrato.QuantidadeAlunos;
            movimento.ValorReceber = ((contrato.ValorUnitario * contrato.QuantidadeAlunos) * (contrato.MargemLucro) / 100);
            movimento.ValorProfissional = ((contrato.ValorUnitario * contrato.QuantidadeAlunos) - (((contrato.ValorUnitario * contrato.QuantidadeAlunos) * (contrato.MargemLucro) / 100)));
            movimento.Observacao = contrato.Observacao;
            movimento.Situacao = 3;
            movimento.TipoMovimento = 1;
            movimento.QuantidadeAlunos = contrato.QuantidadeAlunos;
            movimento.ValorUnitario = contrato.ValorUnitario;
            return movimento;            
        }
        public async Task<bool> VerificarMovimentoCompetencia(string competencia, Guid AlunoId)
        {
            var movimento = await _entidadeRepository.ObterMovimentoProfissionalCompetencia(AlunoId, competencia);
            if (movimento == null) return false;
            else
            {
                Notificar("Já existe valor gerado na " + competencia + " para o Profissional " + _profissionalRepository.ObterProfissinalPorId(AlunoId).Result.Nome);
                return true;
            }
        }
        public async Task GerarPagamento(Guid MovimentoId)
        {
            var movimento = await _entidadeRepository.ObterMovimentoPorId(MovimentoId);
            if (movimento.Situacao == 1)
            {
                return;
            }

            movimento.ValorPago = movimento.ValorReceber;
            movimento.ValorReceber = 0;
            movimento.Situacao = 1;
            movimento.DataPagamento = DateTime.Now;
            movimento.CompetenciaPagamento = await BuscarCompetenciaPagamento(movimento.CompetenciaCobranca);

            await _entidadeRepository.Atualizar(movimento);
        }
        public async Task<bool> VerificarPagamento(Guid MovimentoId)
        {
            var pagamento = await _entidadeRepository.ObterMovimentoPorId(MovimentoId);
            if (pagamento.Situacao == 3)
            {
                Notificar("O pagamento de " + pagamento.CompetenciaCobranca + " ainda não está quitado!");
                return true;
            }
            else
            {
                Notificar("O pagamento de " + pagamento.CompetenciaCobranca + " já está quitado!");
                return false;
            }
        }
        public async Task DesfazerPagamento(Guid MovimentoId, Guid ContratoId)
        {
            var movimento = await _entidadeRepository.ObterMovimentoPorId(MovimentoId);
            if (movimento.Situacao == 3)
            {
                Notificar("O pagamento ainda não está quitado!");
                return;
            }
            var contrato = await _contratoRepository.ObterPorId(ContratoId);

            movimento.Situacao = 3;
            movimento.ValorReceber = ((contrato.ValorUnitario * contrato.QuantidadeAlunos) - (((contrato.ValorUnitario * contrato.QuantidadeAlunos) * (contrato.MargemLucro) / 100)));
            movimento.ValorPago = 0;
            movimento.CompetenciaPagamento = null;
            movimento.DataPagamento = DateTime.Parse("01/01/0001");
            await _entidadeRepository.Atualizar(movimento);
        }

        public async Task<string> BuscarCompetenciaPagamento(string competencia)
        {
            var caixa = await _entidadeRepository.BuscarCompetenciaCaixa();

            if (caixa == null)
            {
                return competencia;
            }

            var MesCompetenciaValida = caixa.Competencia.Substring(0, 2);

            if (int.Parse(MesCompetenciaValida) == 12)
            {
                MesCompetenciaValida = 0.ToString();
            }

            if (caixa.Situacao == 1) return caixa.Competencia;
            else
            {
                var CompetenciaValida = int.Parse(MesCompetenciaValida.Substring(0, 2)) + 1;
                return (CompetenciaValida.ToString() + DateTime.Now.Year).PadLeft(6, '0');
            }

        }
        public void Dispose()
        {
            _entidadeRepository?.Dispose();
        }

       
    }
}
