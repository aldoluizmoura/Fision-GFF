using AutoMapper;
using GestaoFluxoFinanceiro.Aplicacao.Extensions;
using GestaoFluxoFinanceiro.Aplicacao.ViewModels;
using GestaoFluxoFinanceiro.Negocio.Interfaces;
using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Aplicacao.Controllers
{
    [Authorize]
    public class AlunoController : BaseController
    {
        private readonly IAlunoRepository _entidadeRepository;
        private readonly IMapper _mapper;
        private readonly IAlunoService _entidadeService;
        private readonly IContratoFinanceiroAlunoRepository _contratoRepsository;        

        public AlunoController(IAlunoRepository entidaderepository,
                               IMapper mapper,
                               IAlunoService entidadeservice,
                               ICaixaService caixaservice,
                               IContratoFinanceiroAlunoRepository contratorepository,
                               INotificador notificador) : base(notificador, caixaservice)
        {
            _entidadeRepository = entidaderepository;
            _mapper = mapper;
            _entidadeService = entidadeservice;
            _contratoRepsository = contratorepository;
        }
        [ClaimsAuthorize("Adm", "Visual")]
        [Route("lista-Alunos")]       
        public async Task<IActionResult> Index()
        {            
            var listaalunos = _mapper.Map<IEnumerable<AlunoViewModel>>
                                         (await _entidadeRepository.ObterTodosAlunos());
            foreach (var item in listaalunos)
            {
                item.Situacao = await VerificarSituacao(item.Id);               
            }           
            return View(listaalunos);
        }   
        [Route("novo-Aluno")]
        [ClaimsAuthorize("Adm", "Adicionar")]       
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ClaimsAuthorize("Adm", "Adicionar")]
        [Route("novo-Aluno")]
        public async Task<IActionResult> Create(AlunoViewModel entidadeViewModel)
        {
            if (!ModelState.IsValid) return View(entidadeViewModel);
            
            var entidade = _mapper.Map<Alunos>(entidadeViewModel);
            var contrato = _mapper.Map<ContratoFinanceiroAluno>(entidadeViewModel.ContratoFinanceiro);

            entidade.ContratoFinanceiroAluno = contrato;

            string UltimaMatricula = _entidadeRepository.ObterUltimaMatricula();
            entidade.Matricula = GerarCodigoMatricula(entidadeViewModel, UltimaMatricula);

            await _entidadeService.Adicionar(entidade);

            if (!OperacaoValida()) return View(entidadeViewModel);

            return RedirectToAction("Index");
        }
        [Route("Editar-Aluno")]
        [ClaimsAuthorize("Adm", "Editar")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var alunoViewModel = await ObterAlunoEndereco(id);
            var contrato = await ObterContratoFinanceiro(id);

            alunoViewModel.ContratoFinanceiro = contrato;

            if (alunoViewModel == null)
            {
                return NotFound();
            }
            return View(alunoViewModel);

        }
        [HttpPost]
        [Route("Editar-Aluno")]
        [ClaimsAuthorize("Adm", "Editar")]
        public async Task<IActionResult> Edit(Guid Id, AlunoViewModel entidadeViewModel)
        {
            if (Id != entidadeViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(entidadeViewModel);

            var contrato = await ObterContratoFinanceiro(Id);

            entidadeViewModel.ContratoFinanceiro = contrato;

            var aluno = _mapper.Map<Alunos>(entidadeViewModel);
            await _entidadeService.Atualizar(aluno);

            if (!OperacaoValida()) return View(await ObterAlunoEndereco(Id));

            return RedirectToAction("Index");
        }
        [Route("Excluir-Aluno")]
        [ClaimsAuthorize("Adm", "Excluir")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entidadeViewModel = await ObterAlunoEndereco(id);
            var contrato = await ObterContratoFinanceiro(id);

            entidadeViewModel.ContratoFinanceiro = contrato;

            if (entidadeViewModel == null)
            {
                return NotFound();
            }

            return View(entidadeViewModel);
        }
        [Route("Excluir-Aluno")]
        [ClaimsAuthorize("Adm", "Excluir")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var entidadeViewModel = await ObterAlunoEndereco(id);
            var contrato = await ObterContratoFinanceiro(id);

            entidadeViewModel.ContratoFinanceiro = contrato;

            if (entidadeViewModel == null) return NotFound();

            await _entidadeService.Remover(id);

            if (!OperacaoValida()) return View(entidadeViewModel);

            TempData["Sucesso"] = "Aluno excluido com sucesso!";

            return RedirectToAction("Index");
        }

        [ClaimsAuthorize("Adm", "Visual")]
        [Route("detalhes-Aluno")]
        public async Task<IActionResult> Details(Guid id)
        {
            var entidadeViewModel = await ObterAlunoEndereco(id);
            var contrato = await ObterContratoFinanceiro(id);                            

            entidadeViewModel.ContratoFinanceiro = contrato;

            if (entidadeViewModel == null)
            {
                NotFound();
            }
            return View(entidadeViewModel);
           
        }
        [Route("atualizar-endereco-aluno/{id:guid}")]
        [ClaimsAuthorize("Adm", "Editar")]
        public async Task<IActionResult> AtualizarEndereco(Guid id)
        {
            var aluno = await ObterAlunoEndereco(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return PartialView("_AtualizarEndereco", new AlunoViewModel { Endereco = aluno.Endereco });
        }
        [Route("atualizar-endereco-aluno/{id:guid}")]
        [HttpPost]
        [ClaimsAuthorize("Adm", "Editar")]
        public async Task<IActionResult> AtualizarEndereco(AlunoViewModel entidadeViewModel)
        {
            ModelState.Remove("Nome");
            ModelState.Remove("CPF");
            ModelState.Remove("Email");
            ModelState.Remove("Telefone");

            if (!ModelState.IsValid) return PartialView("_AtualizarEndereco", entidadeViewModel);

                await _entidadeService.AtualizarEndereco(_mapper.Map<Endereco>(entidadeViewModel.Endereco));            
           
            if (!OperacaoValida()) return PartialView("_AtualizarEndereco", entidadeViewModel);

            var url = Url.Action("ObterEndereco", "Aluno", new { id = entidadeViewModel.Endereco.AlunoId });
            return Json(new { success = true, url });
        }
        private async Task<IActionResult> ObterEndereco(Guid id)
        {
            var aluno = await ObterAlunoEndereco(id);
            
            if (aluno == null)
            {
                return NotFound();
            }

            return PartialView("_DetalhesEndereco", aluno);
        }
        private async Task<AlunoViewModel> ObterAlunoEndereco(Guid id)
        {
            return _mapper.Map<AlunoViewModel>(await _entidadeRepository.ObterEnderecoAluno(id));
        }

        [Route("atualizar-ContratoFinanceiro-aluno/{id:guid}")]
        [ClaimsAuthorize("Adm", "Editar")]
        public async Task<IActionResult> AtualizarContratoFinanceiro(Guid id)
        {
            var aluno = await ObterContratoFinanceiro(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return PartialView("_AtualizarContrato", new AlunoViewModel { ContratoFinanceiro = aluno });
        }
        [Route("atualizar-ContratoFinanceiro-aluno/{id:guid}")]
        [HttpPost]
        [ClaimsAuthorize("Adm", "Editar")]
        public async Task<IActionResult> AtualizarContratoFinanceiro(AlunoViewModel entidadeViewModel)
        {
            ModelState.Remove("Nome");
            ModelState.Remove("CPF");
            ModelState.Remove("Email");
            ModelState.Remove("Telefone");

            if (!ModelState.IsValid) return PartialView("_AtualizarContratoFinanceiro", entidadeViewModel);

            await _entidadeService.AtualizarContrato(_mapper.Map<ContratoFinanceiroAluno>(entidadeViewModel.ContratoFinanceiro));

            if (!OperacaoValida()) return PartialView("_AtualizarContratoFinanceiro", entidadeViewModel);

            var url = Url.Action("ObterContrato", "Aluno", new { id = entidadeViewModel.ContratoFinanceiro.AlunoId });
            return Json(new { success = true, url });
        }
        //private async Task<IActionResult> ObterContrato(Guid id)
        //{
        //    var aluno = await ObterContratoFinanceiro(id);

        //    if (aluno == null)
        //    {
        //        return NotFound();
        //    }

        //    return PartialView("_DetalhesContratoFinanceiroAluno", aluno);
        //}
        private async Task<ContratoFinanceiroAlunoViewModel> ObterContratoFinanceiro(Guid id)
        {
            return _mapper.Map<ContratoFinanceiroAlunoViewModel>(await _contratoRepsository.ObterContratoFinanceiroPorAluno(id));
        }
        private async Task<bool> VerificarSituacao(Guid id)
        {
            return  await _entidadeService.VerificarAdimplencia(id);
        }
    }
}
