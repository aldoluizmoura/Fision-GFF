using AutoMapper;
using GestaoFluxoFinanceiro.Aplicacao.Extensions;
using GestaoFluxoFinanceiro.Aplicacao.ViewModels;
using GestaoFluxoFinanceiro.Aplicacao.ViewModels.Financeiro;
using GestaoFluxoFinanceiro.Negocio.Interfaces;
using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Aplicacao.Controllers.Financeiro
{
    [Authorize]
    public class MovimentoFinanceiroProfissionalController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IMovimentoProfissionalRepository _entidadeRepository;
        private readonly IMovimentoProfissionalService _entidadeService;
        private readonly IProfissionalRepository _profissionalRepository;
        private readonly IProfissionalService _profissionalService;
        private readonly IContratoFinanceiroProfissionalRepository _contratorepository;
        private readonly ICaixaRepository _caixaRepository;
        public MovimentoFinanceiroProfissionalController(INotificador notificador,
                                             IMovimentoProfissionalRepository entidadeRepository,
                                             IMovimentoProfissionalService entidadeService,
                                             IProfissionalService profissionalService,
                                             IContratoFinanceiroProfissionalRepository contratorepository,
                                             IProfissionalRepository profissionalRepository,
                                              ICaixaService caixaservice, ICaixaRepository caixaRepository,
                                              IMapper mapper) : base(notificador, caixaservice)
        {
            _mapper = mapper;
            _entidadeRepository = entidadeRepository;
            _entidadeService = entidadeService;
            _profissionalRepository = profissionalRepository;
            _contratorepository = contratorepository;
            _profissionalService = profissionalService;
            _caixaRepository = caixaRepository;
        }
        [ClaimsAuthorize("Adm", "Ger")]
        [Route("lista-docfinanceiros-profissionais")]
        public async Task<IActionResult> Index()
        {
            var listamovimentos = _mapper.Map<IEnumerable<MovimentoProfissionalViewModel>>
                (await _entidadeRepository.ObterMovimentos());

            foreach (var item in listamovimentos)
            {
                var profissional = await ObterProfissional(item.ProfissionalId);
                item.Profissional = profissional.Nome;
            }
            return View(listamovimentos);
        }
        [Route("gerar-valores-profissionais")]
        [ClaimsAuthorize("Adm", "Ger")]
        public IActionResult Create()
        {
            return View();
        }
        [Route("gerar-valores-profissionais")]
        [ClaimsAuthorize("Adm", "Ger")]
        [HttpPost]
        public async Task<IActionResult> Create(MovimentoProfissionalViewModel entidadeViewModel)
        {
            if (!ModelState.IsValid) return View(entidadeViewModel);

            var competencia = entidadeViewModel.CompetenciaCobranca + DateTime.Now.Year;


            var listaprofissionais = _mapper.Map<IEnumerable<ProfissionalViewModel>>
                               (await _profissionalRepository.ObterTodosProfissionaisAtivos());

            if (listaprofissionais.Count() == 0)
            {
                TempData["Erro"] = "Ação impossivel: ainda não há Profissionais Ativos cadastrados!";
                return RedirectToAction("Index");
            }

            foreach (var item in listaprofissionais)
            {
                Guid ProfissionalId = item.Id;
                var contrato = await ObterContratoFinanceiro(ProfissionalId);
                if (await _entidadeService.VerificarMovimentoCompetencia(competencia, ProfissionalId))
                {
                    TempData["ErroParcial"] = "Alguns profissionais já possuem documentos para a competencia " + RazorExtensions.converterCompetenciaDesc(entidadeViewModel.CompetenciaCobranca);
                    return RedirectToAction("Index");
                }
                var movimentoAluno = _mapper.Map<MovimentoProfissional>
                       (await GerarMovimento(competencia, ProfissionalId, contrato.Id));
                await _entidadeRepository.Adicionar(movimentoAluno);
            }

            if (!OperacaoValida()) return View(entidadeViewModel);
            TempData["Sucesso"] = "Valores financeiros dos Profissionais para " + competencia + " foram gerados com sucesso!";
            return RedirectToAction("Index");
        }
        [Route("quitar-documento")]
        [ClaimsAuthorize("Adm", "Ger")]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var movimentoViewModel = _mapper.Map<MovimentoProfissionalViewModel>(
                                                await _entidadeRepository.ObterPorId(Id));
            var profissional = _profissionalRepository.ObterProfissinalPorId(movimentoViewModel.ProfissionalId).Result;
            movimentoViewModel.Profissional = profissional.Nome;

            return View(movimentoViewModel);
        }
        [Route("quitar-documento")]
        [ClaimsAuthorize("Adm", "Ger")]
        [HttpPost]
        public async Task<IActionResult> Edit(MovimentoProfissionalViewModel movimentoProfissional)
        {
            ModelState.Remove("CompetenciaCobranca");

            if (!ModelState.IsValid) return View(movimentoProfissional);

            await _entidadeService.GerarPagamento(movimentoProfissional.Id);

            if (!OperacaoValida()) return View(movimentoProfissional);

            movimentoProfissional = _mapper.Map<MovimentoProfissionalViewModel>
                                        (await _entidadeRepository.ObterMovimentoPorId(movimentoProfissional.Id));

            var profissional = await _profissionalRepository.ObterProfissinalPorId(movimentoProfissional.ProfissionalId);
            movimentoProfissional.Profissional = profissional.Nome;

            ViewBag.Sucesso = "Quitação feita com sucesso!";
            return View(movimentoProfissional);
        }
        [Route("desfazer-pagamento-profissional")]
        [ClaimsAuthorize("Adm", "Ger")]
        public async Task<IActionResult> DesfazerQuitacao(MovimentoProfissionalViewModel movimentoProfissional)
        {
            ModelState.Remove("CompetenciaCobranca");

            if (!ModelState.IsValid) return View(movimentoProfissional);

            var movimento = await _entidadeRepository.ObterMovimentoPorId(movimentoProfissional.Id);
            var contrato = await ObterContratoFinanceiro(movimento.ProfissionalId);


            var caixa = await _caixaRepository.ObterCaixaPorCompetencia(movimento.CompetenciaPagamento);
            if (caixa != null)
            {
                if (caixa.Competencia == movimento.CompetenciaPagamento)
                {
                    TempData["Erro"] = "Caixa de " + RazorExtensions.converterCompetenciaDesc(movimento.CompetenciaPagamento) + " já está fechado!";
                    return RedirectToAction("Edit", movimentoProfissional);
                }
            }
            await _entidadeService.DesfazerPagamento(movimentoProfissional.Id, contrato.Id);

            if (!OperacaoValida())
            {
                TempData["Erro"] = "O pagamento não está quitado!";
                return RedirectToAction("Edit", movimentoProfissional);
            }

            TempData["Sucesso"] = "Pagamento desfeito com sucesso!";
            return RedirectToAction("Edit", movimentoProfissional);
        }
        [Route("gerar-recibo-profissional")]
        [ClaimsAuthorize("Adm", "Ger")]
        public async Task<IActionResult> GerarRecibo(Guid Id)
        {
            var movimento = _mapper.Map<MovimentoProfissionalViewModel>(await _entidadeRepository.ObterMovimentoPorId(Id));
            if (await _entidadeService.VerificarPagamento(movimento.Id))
            {
                TempData["Erro"] = "O pagamento não está quitado!";
                return RedirectToAction("Edit", movimento);
            }
            else
            {
                var profissional = _profissionalRepository.ObterProfissinalPorId(movimento.ProfissionalId).Result;
                movimento.Profissional = profissional.Nome;
                var pdf = new ViewAsPdf
                {
                    ViewName = "ReciboProfissional",
                    Model = movimento,
                    FileName = movimento.Id.ToString() + ".pdf",
                    PageSize = Size.A4,
                    IsGrayScale = false,
                    PageMargins = new Margins { Bottom = 5, Left = 5, Right = 5, Top = 5 },
                };
                return pdf;
            }
        }
        private async Task<ContratoFinanceiroProfissionalViewModel> ObterContratoFinanceiro(Guid id)
        {
            return _mapper.Map<ContratoFinanceiroProfissionalViewModel>(await _contratorepository.ObterContratoFinanceiroPorProfissonal(id));
        }
        private async Task<MovimentoProfissionalViewModel> GerarMovimento(string competencia, Guid ProfissionalId, Guid ContratoId)
        {
            return _mapper.Map<MovimentoProfissionalViewModel>(await _entidadeService.GerarMovimentoProfissionais(competencia, ProfissionalId, ContratoId));
        }
        private async Task<ProfissionalViewModel> ObterProfissional(Guid ProfissionalId)
        {
            return _mapper.Map<ProfissionalViewModel>(await _profissionalRepository.ObterProfissinalPorId(ProfissionalId));
        }
    }
}
