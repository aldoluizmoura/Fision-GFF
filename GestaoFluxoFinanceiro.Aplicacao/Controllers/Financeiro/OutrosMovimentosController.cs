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
    public class OutrosMovimentosController : BaseController
    {
        private readonly IOutrosMovimentosRepository _entidadeRepository;
        private readonly IOutrosMovimentosService _entidadeService;
        private readonly IMapper _mapper;

        public OutrosMovimentosController(IOutrosMovimentosRepository entidadeRepository,
                                          INotificador notificador,
                                          IMapper mapper,
                                          ICaixaService caixaservice,
                                          IOutrosMovimentosService entidadeService) : base(notificador,caixaservice)
        {
            _entidadeRepository = entidadeRepository;
            _mapper = mapper;
            _entidadeService = entidadeService;
        }

        [Route("lista-outros-movimentos")]
        [ClaimsAuthorize("Adm", "Ger")]
        public async Task<IActionResult> Index()
        {
            OutrosMovimentosController movimentosController = this;
            IMapper mapper = movimentosController._mapper;
            IEnumerable<OutrosMovimentosViewModel> movimentosViewModels = mapper.Map<IEnumerable<OutrosMovimentosViewModel>>
                                                      (await movimentosController._entidadeRepository.ObterTodosMovimentos());
            return movimentosController.View(movimentosViewModels);
        }

        [Route("novo-movimento")]
        [ClaimsAuthorize("Adm", "Ger")]
        public IActionResult Create()
        {
            return View();
        } 

        [Route("novo-movimento")]
        [ClaimsAuthorize("Adm", "Ger")]
        [HttpPost]
        public async Task<IActionResult> Create(OutrosMovimentosViewModel entidadeViewModel)
        {
            if (!ModelState.IsValid) return View(entidadeViewModel);

            MovimentosOutros entidade = _mapper.Map<MovimentosOutros>(entidadeViewModel);
            entidade.Competencia += DateTime.Now.Year.ToString();

            
            await _entidadeService.Adicionar(entidade);
            
            if (!OperacaoValida())return View(entidadeViewModel);
            TempData["Sucesso"] = "Movimento gerado com sucesso!";
            
            return RedirectToAction("Index");
        }

        [Route("detalhes-novo-movimento")]
        [ClaimsAuthorize("Adm", "Ger")]
        public async Task<IActionResult> Details(Guid Id)
        { 
            OutrosMovimentosViewModel movimentosViewModel = _mapper.Map<OutrosMovimentosViewModel>
                                        (await _entidadeRepository.ObterMovimentoPorId(Id));


            if (movimentosViewModel == null) NotFound();

            return View(movimentosViewModel);
        }

        [Route("editar-outro-movimento")]
        [ClaimsAuthorize("Adm", "Editar")]
        public async Task<IActionResult> Edit(Guid Id)
        {
            OutrosMovimentosViewModel movimentosViewModel = _mapper.Map<OutrosMovimentosViewModel>
                (await _entidadeRepository.ObterMovimentoPorId(Id));

            return View(movimentosViewModel);
        }

        [HttpPost]
        [Route("editar-outro-movimento")]
        [ClaimsAuthorize("Adm", "Editar")]
        public async Task<IActionResult> Edit(Guid Id,OutrosMovimentosViewModel entidadeViewModel)
        {
            if (Id != entidadeViewModel.Id) return NotFound();
            if (!ModelState.IsValid) return View(entidadeViewModel);
            
            var movimento = _mapper.Map<MovimentosOutros>(entidadeViewModel);

            

            await _entidadeService.Atualizar(movimento);
            
            if (!OperacaoValida()) return RedirectToAction("Index");

            return RedirectToAction("Index",entidadeViewModel);
        }

        [Route("Excluir-movimento")]
        [ClaimsAuthorize("Adm", "Excluir")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            OutrosMovimentosViewModel movimentosViewModel = _mapper.Map<OutrosMovimentosViewModel>
                                (await _entidadeRepository.ObterMovimentoPorId(Id));
            if(movimentosViewModel == null) return NotFound();
            return View(movimentosViewModel); 
        }

        [Route("Excluir-movimento")]
        [ClaimsAuthorize("Adm", "Excluir")]
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid Id)
        {
           
            OutrosMovimentosViewModel entidadeViewModel = _mapper.Map<OutrosMovimentosViewModel>
                                                            (await _entidadeRepository.ObterMovimentoPorId(Id));
           
            if (entidadeViewModel == null )return NotFound();

            

            await _entidadeService.Remover(Id);
            
            if (!OperacaoValida()) return View(entidadeViewModel);            
            TempData["Sucesso"] = "Movimento excluido com sucesso!";
            
            return RedirectToAction("Index");
        }
    }
}

