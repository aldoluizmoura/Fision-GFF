using AutoMapper;
using GestaoFluxoFinanceiro.Aplicacao.Extensions;
using GestaoFluxoFinanceiro.Aplicacao.ViewModels.Financeiro;
using GestaoFluxoFinanceiro.Negocio.Interfaces;
using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Aplicacao.Controllers.Financeiro
{
    [Authorize]
    public class CaixaController : BaseController
    {
        private readonly ICaixaRepository _entidadeRepository;
        private readonly ICaixaService _entidadeService;
        private readonly IMapper _mapper;

        public CaixaController(
                                  INotificador notificador,
                                  ICaixaRepository entidadeRepository,
                                  ICaixaService entidadeService,
                                  IMapper mapper): base(notificador, entidadeService)
        {
            _entidadeRepository = entidadeRepository;
            _entidadeService = entidadeService;
            _mapper = mapper;
        }

        [Route("caixas")]
        [ClaimsAuthorize("Adm", "Ger")]
        public async Task<IActionResult> Index()
        {
           
            IEnumerable<CaixaViewModel> caixaViewModels = _mapper.Map<IEnumerable<CaixaViewModel>>
                                                  (await _entidadeRepository.ObterCaixas());
            return View(caixaViewModels);
        }

        [Route("novo-caixa")]
        [ClaimsAuthorize("Adm", "Adicionar")]
        public IActionResult Create()
        { 
            return View();
        } 

        [ClaimsAuthorize("Adm", "Adicionar")]
        [Route("novo-caixa")]
        [HttpPost]
        public async Task<IActionResult> Create(CaixaViewModel entidadeViewModel)
        {
            if (!ModelState.IsValid) return View(entidadeViewModel);
            entidadeViewModel.Competencia += DateTime.Now.Year.ToString();

            if (await _entidadeRepository.ObterCaixaPorCompetencia(entidadeViewModel.Competencia) != null)
            {
                TempData["Erro"] = "Já existe um Caixa para " + RazorExtensions.converterCompetenciaDesc(entidadeViewModel.Competencia) + " de " + entidadeViewModel.Competencia.Substring(2, 4);
                return View(entidadeViewModel);
            }

            await _entidadeService.Adicionar(_mapper.Map<Caixa>(entidadeViewModel));
            if (!OperacaoValida()) return View(entidadeViewModel);

            TempData["Sucesso"] = "Caixa gerado com sucesso";
            return RedirectToAction("Index", entidadeViewModel);
        }

        [Route("detalhes-caixa")]
        [ClaimsAuthorize("Adm", "Editar")]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var caixaViewModel = _mapper.Map<CaixaViewModel>
                    (await _entidadeRepository.ObterCaixaPorId(Id));
            return View(caixaViewModel);
        }

        [Route("fechar-caixa")]
        [ClaimsAuthorize("Adm", "Ger")]
        [HttpPost]
        public async Task<IActionResult> FecharCaixa(Guid Id)
        {
            CaixaViewModel entidadeViewModel = _mapper.Map<CaixaViewModel>(await _entidadeRepository.ObterCaixaPorId(Id));
            
            if (entidadeViewModel.Situacao == 2)
            {
                TempData["Erro"] = "Caixa já está fechado!";
                return RedirectToAction("Edit", entidadeViewModel);
            }
            await _entidadeService.FecharCaixa(Id);
            if (!OperacaoValida()) return RedirectToAction("Edit",entidadeViewModel);
            TempData["Sucesso"] = "Caixa fechado com sucesso!";
            return RedirectToAction("Edit", entidadeViewModel);
        }

        [Route("reprocessar-caixa")]
        [ClaimsAuthorize("Adm", "Ger")]
        public async Task<IActionResult> Reprocessar(Guid Id)
        {
            var entidadeViewModel = _mapper.Map<CaixaViewModel>(await _entidadeRepository.ObterCaixaPorId(Id));
            if (entidadeViewModel == null) return NotFound();
           
            await _entidadeService.Reprocessar(entidadeViewModel.Id);
            if (!OperacaoValida()) return RedirectToAction("Edit", entidadeViewModel);

            TempData["Sucesso"] = "Caixa reprocessado com sucesso";
            return RedirectToAction("Edit", entidadeViewModel);
        }
    }
}