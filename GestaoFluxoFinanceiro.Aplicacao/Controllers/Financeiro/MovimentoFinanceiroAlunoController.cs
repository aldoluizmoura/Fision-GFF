using AutoMapper;
using GestaoFluxoFinanceiro.Aplicacao.Controllers.Financeiro;
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

namespace GestaoFluxoFinanceiro.Aplicacao.Controllers
{
    [Authorize]
    public class MovimentoFinanceiroAlunoController : BaseController
    {
        private readonly IMovimentoAlunoRepository _entidadeRepository;
        private readonly IMovimentoAunoService _entidadeService;
        private readonly IMapper _mapper;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IAlunoService _alunoService;
        private readonly IContratoFinanceiroAlunoRepository _contratoRepository;
        private readonly ICaixaService _caixaService;
        private readonly ICaixaRepository _caixaRepository;
        public MovimentoFinanceiroAlunoController(IMovimentoAlunoRepository entidaderepository,
                                        IMovimentoAunoService entidadeService,
                                        IAlunoRepository alunoRepository,
                                        IAlunoService alunoService,
                                        IContratoFinanceiroAlunoRepository contratoRepository,
                                        IMapper mapper,
                                        ICaixaService caixaservice, ICaixaRepository caixaRepository,
                                        INotificador notificador) : base(notificador, caixaservice)
        {
            _entidadeRepository = entidaderepository;
            _entidadeService = entidadeService;
            _mapper = mapper;
            _contratoRepository = contratoRepository;
            _alunoRepository = alunoRepository;
            _alunoService = alunoService;
            _caixaService = caixaservice;
            _caixaRepository = caixaRepository;
        }
        [ClaimsAuthorize("Adm", "Ger")]
        [Route("mensalidades")]
        public async Task<IActionResult> Index()
        {
            var Listamovimentos = _mapper.Map<IEnumerable<MovimentoAlunoViewModel>>
                    (await _entidadeRepository.ObterMovimentosAluno());

            foreach (var item in Listamovimentos)
            {
                var aluno = await ObterAluno(item.AlunoId);
                item.Aluno = aluno.Nome;
            }

            return View(Listamovimentos);
        }
        [ClaimsAuthorize("Adm", "Ger")]
        [Route("gerar-mensalidades")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("gerar-mensalidades")]
        [ClaimsAuthorize("Adm", "Ger")]
        public async Task<IActionResult> Create(MovimentoAlunoViewModel entidadeViewModel)
        {
            if (!ModelState.IsValid) return View(entidadeViewModel);

            string competencia = entidadeViewModel.CompetenciaMensalidade + DateTime.Now.Year.ToString();

         
            IEnumerable<AlunoViewModel> ListaAlunos = _mapper.Map<IEnumerable<AlunoViewModel>>
                            (await _alunoRepository.ObterTodosAlunosAtivos());

            if (ListaAlunos.Count() == 0) 
            { 
                TempData["Erro"] = "Não há alunos ativos cadastrados";
                return View();
            }

            foreach (var item in ListaAlunos)
            {
                Guid AlunoId = item.Id;
                ContratoFinanceiroAlunoViewModel contrato = await ObterContratoFinanceiro(AlunoId);

                if (await _entidadeService.VerificarMovimentoCompetencia(competencia, AlunoId))
                {
                    TempData["ErroParcial"] = "Alguns alunos já possuem mensalidades para a competencia " + RazorExtensions.converterCompetenciaDesc(entidadeViewModel.CompetenciaMensalidade);
                    return RedirectToAction("Index");
                }

               var movimentoAluno = _mapper.Map<MovimentoAluno>(await GerarMovimento(competencia, AlunoId, contrato.Id));
               await _entidadeRepository.Adicionar(movimentoAluno);       
            }
            
            TempData["Sucesso"] = "Mensalidades para " + RazorExtensions.converterCompetenciaDesc(entidadeViewModel.CompetenciaMensalidade) + " geradas com sucesso";
            return RedirectToAction("Index");

        }
        [Route("pagar-mensalidade")]
        [ClaimsAuthorize("Adm", "Ger")]
        public async Task<IActionResult> Edit(Guid Id)
        {
            
            var movimentoViewModel = _mapper.Map<MovimentoAlunoViewModel>(
                                                await _entidadeRepository.ObterPorId(Id));

            movimentoViewModel.Aluno = ObterAluno(movimentoViewModel.AlunoId).Result.Nome;            

            return View(movimentoViewModel);
        }
        [Route("pagar-mensalidade")]
        [ClaimsAuthorize("Adm", "Ger")]
        [HttpPost]
        public async Task<IActionResult> Edit(MovimentoAlunoViewModel movimentoAluno)
        {
            ModelState.Remove("CompetenciaMensalidade");

            if (!ModelState.IsValid) return View(movimentoAluno);

            await _entidadeService.GerarPagamento(movimentoAluno.Id);
            if (!OperacaoValida()) return View(movimentoAluno);

            movimentoAluno = _mapper.Map<MovimentoAlunoViewModel>(
                                                await _entidadeRepository.ObterPorId(movimentoAluno.Id));

            movimentoAluno.Aluno = ObterAluno(movimentoAluno.AlunoId).Result.Nome;

            ViewBag.Sucesso = "Quitação feita com sucesso!";
            return View(movimentoAluno);
        }
        [Route("desfazer-pagamento")]
        [ClaimsAuthorize("Adm", "Ger")]
        public async Task<IActionResult> DesfazerQuitacao(MovimentoAlunoViewModel movimentoAluno)
        {
            ModelState.Remove("CompetenciaMensalidade");
            if (!ModelState.IsValid) return View(movimentoAluno);
            var movimento = await _entidadeRepository.ObterMovimentosAlunoPorId(movimentoAluno.Id);
            var contrato = await ObterContratoFinanceiro(movimento.AlunoId);

            var caixa = await _caixaRepository.ObterCaixaPorCompetencia(movimento.CompetenciaPagamento);
            if (caixa != null )
            {
                if(caixa.Competencia == movimento.CompetenciaPagamento)
                {
                    TempData["Erro"] = "Caixa de " + RazorExtensions.converterCompetenciaDesc(movimento.CompetenciaPagamento) + " já está fechado!";
                    return RedirectToAction("Edit", movimentoAluno);
                }                
            }

            await _entidadeService.DesfazerPagamento(movimentoAluno.Id, contrato.Id);
            if (!OperacaoValida()) 
            {
                TempData["Erro"] = "A mensalidade não está quitada!";
                return RedirectToAction("Edit", movimentoAluno); 
            }

            TempData["Sucesso"] = "Pagamento desfeito com sucesso!";
            return RedirectToAction("Edit",movimentoAluno);
        }
        [Route("gerar-recibo-aluno")]
        [ClaimsAuthorize("Adm", "Visual")]
        public async Task<IActionResult> GerarRecibo(Guid Id)
        {
            var movimento = _mapper.Map<MovimentoAlunoViewModel>(await _entidadeRepository.ObterMovimentosAlunoPorId(Id));
            if (await _entidadeService.VerificarPagamento(movimento.Id)) 
            {  
                TempData["Erro"] = "A mensalidade não está quitada!";
                return RedirectToAction("Edit", movimento); 
            }             
            else
            {
                var aluno = _alunoRepository.ObterAlunoPorId(movimento.AlunoId).Result;
                movimento.Aluno = aluno.Nome;
                var pdf = new ViewAsPdf
                {
                    ViewName = "ReciboAluno",
                    Model = movimento,
                    FileName = movimento.Id.ToString()+".pdf",
                    PageSize = Size.A4,
                    IsGrayScale = false,
                    PageMargins = new Margins { Bottom = 5, Left = 5, Right = 5, Top = 5 },
                };
                return pdf;
            }
        }
        private async Task<ContratoFinanceiroAlunoViewModel> ObterContratoFinanceiro(Guid id)
        {
            return _mapper.Map<ContratoFinanceiroAlunoViewModel>(await _contratoRepository.ObterContratoFinanceiroPorAluno(id));
        }
        private async Task<MovimentoAlunoViewModel> GerarMovimento(string _competencia, Guid AlunoId, Guid ContratoId)
        {
            return _mapper.Map<MovimentoAlunoViewModel>(await _entidadeService.GerarMovimentoAluno(_competencia, AlunoId, ContratoId));
        }
        private async Task<AlunoViewModel> ObterAluno(Guid AlunoId)
        {
            return _mapper.Map<AlunoViewModel>(await _alunoRepository.ObterAlunoPorId(AlunoId));
        }

    }
}
