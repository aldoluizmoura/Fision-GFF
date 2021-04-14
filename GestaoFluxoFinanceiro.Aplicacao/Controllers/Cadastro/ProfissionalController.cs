using AutoMapper;
using GestaoFluxoFinanceiro.Aplicacao.Extensions;
using GestaoFluxoFinanceiro.Aplicacao.ViewModels;
using GestaoFluxoFinanceiro.Negocio.Interfaces;
using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Aplicacao.Controllers
{
    [Authorize]
    public class ProfissionalController : BaseController
    {
        private readonly IProfissionalRepository _entidadeRepsository;
        private readonly IProfissionalService _entidadeService;
        private readonly IMapper _mapper;
        private readonly IContratoFinanceiroProfissionalRepository _contratoRepsository;
        private readonly IEspecialidadeRepository _especialidadeRepository;        
        public ProfissionalController(IProfissionalRepository entidadeRepsository,
                                       IProfissionalService entidadeService,
                                       IEspecialidadeRepository especialidadeRepository,
                                       IMapper mapper,
                                       ICaixaService caixaservice,
                                       IContratoFinanceiroProfissionalRepository contratorepository,
                                       INotificador notificador) : base(notificador, caixaservice)
        {
            _entidadeRepsository = entidadeRepsository;
            _entidadeService = entidadeService;
            _mapper = mapper;
            _contratoRepsository = contratorepository;
            _especialidadeRepository = especialidadeRepository;
        }
        [Route("lista-profissionais")]
        [ClaimsAuthorize("Adm", "Visual")]
        public async Task<IActionResult> Index()
        {   
            var listaprofissionais = _mapper.Map<IEnumerable<ProfissionalViewModel>>
                                        (await _entidadeRepsository.ObterTodosProfissionais());

            return View(listaprofissionais);           
        }

        [Route("detalhes-profissionais")]
        [ClaimsAuthorize("Adm", "Visual")]
        public async Task<IActionResult> Details(Guid id)
        {
            var entidadeViewModel = await ObterProfissionalEndereco(id);
            var contrato = await ObterContratoFinanceiro(id);            

            entidadeViewModel.ContratoFinanceiroProfissional = contrato;
            
            var especialidade = await _especialidadeRepository.PegarEspecialidadePorId(entidadeViewModel.EspecialidadeId);
            entidadeViewModel.Especialidade = especialidade.Descricao;

            if (entidadeViewModel == null)
            {
                return NotFound();
            }
            return View(entidadeViewModel);
        }
        [Route("novo-profissional")]
        [ClaimsAuthorize("Adm", "Adicionar")]
        public async Task<IActionResult> Create()
        {
           var Lista = _mapper.Map<IEnumerable<EspecialidadesViewModel>>
                (await _especialidadeRepository.PegarEspecialidades());

            ViewBag.Especialidades = new SelectList(Lista, "Id", "Descricao", "");
            return View();
        }
        [Route("novo-profissional")]
        [ClaimsAuthorize("Adm", "Adicionar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfissionalViewModel entidadeViewModel)
        {
            if (!ModelState.IsValid) return View(entidadeViewModel);

            var entidade = _mapper.Map<Profissional>(entidadeViewModel);
            var contrato = _mapper.Map<ContratoFinanceiroProfissional>(entidadeViewModel.ContratoFinanceiroProfissional);

            entidade.EspecialidadeId = entidadeViewModel.EspecialidadeId;

            entidade.ContratoFinanceiroProfissional = contrato;

            string UltimaMatricula = _entidadeRepsository.ObterUltimaMatricula();
            entidade.Matricula = GerarCodigoMatricula(entidadeViewModel, UltimaMatricula);

            await _entidadeService.Adicionar(entidade);

            if (!OperacaoValida()) return View(entidadeViewModel);

            return RedirectToAction("Index");
        }
        [Route("editar-profissional")]
        [ClaimsAuthorize("Adm", "Editar")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var Lista = _mapper.Map<IEnumerable<EspecialidadesViewModel>>
                   (await _especialidadeRepository.PegarEspecialidades());
            
            var entidadeViewModel = await ObterProfissionalEndereco(id);
            var contrato = await ObterContratoFinanceiro(id);

            var especialidade = await _especialidadeRepository.PegarEspecialidadePorId(entidadeViewModel.EspecialidadeId);
            entidadeViewModel.Especialidade = especialidade.Descricao;


            ViewBag.Especialidades = new SelectList(Lista, "Id", "Descricao", "");

            entidadeViewModel.ContratoFinanceiroProfissional = contrato;

            if (entidadeViewModel == null)
            {
                return NotFound();
            }
            return View(entidadeViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar-profissional")]
        [ClaimsAuthorize("Adm", "Editar")]
        public async Task<IActionResult> Edit(Guid id, ProfissionalViewModel entidadeViewModel)
        {
            if (id != entidadeViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(entidadeViewModel);

            var contrato = await ObterContratoFinanceiro(id);

            entidadeViewModel.ContratoFinanceiroProfissional = contrato;

            entidadeViewModel.EspecialidadeId = entidadeViewModel.EspecialidadeId;

            var profissional = _mapper.Map<Profissional>(entidadeViewModel);
            await _entidadeService.Atualizar(profissional);

            if (!OperacaoValida()) return View(await ObterProfissionalEndereco(id));

            return RedirectToAction("Index", entidadeViewModel.Id);
        }
        [Route("excluir-profissional")]
        [ClaimsAuthorize("Adm", "Excluir")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entidadeViewModel = await ObterProfissionalEndereco(id);
            var contrato = await ObterContratoFinanceiro(id);

            entidadeViewModel.ContratoFinanceiroProfissional = contrato;

            if (entidadeViewModel == null)
            {
                return NotFound();
            }
            return View(entidadeViewModel);
        }
        [Route("excluir-profissional")]
        [ClaimsAuthorize("Adm", "Excluir")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var entidadeViewModel = await ObterProfissionalEndereco(id);
            var contrato = await ObterContratoFinanceiro(id);

            entidadeViewModel.ContratoFinanceiroProfissional = contrato;

            if (entidadeViewModel == null) return NotFound();

            await _entidadeService.Remover(id);

            if (!OperacaoValida()) return View(entidadeViewModel);

            return RedirectToAction("Index");
        }
        [Route("atualizar-endereco-profissional/{id:guid}")]
        [ClaimsAuthorize("Adm", "Editar")]
        public async Task<IActionResult> AtualizarEndereco(Guid id)
        {
            var profissional = await ObterProfissionalEndereco(id);

            if (profissional == null)
            {
                return NotFound();
            }

            return PartialView("_AtualizarEndereco", new ProfissionalViewModel { Endereco = profissional.Endereco });
        }
        [Route("atualizar-endereco-profissional/{id:guid}")]
        [HttpPost]
        [ClaimsAuthorize("Adm", "Editar")]
        public async Task<IActionResult> AtualizarEndereco(ProfissionalViewModel entidadeViewModel)
        {
            ModelState.Remove("Nome");
            ModelState.Remove("CPF");
            ModelState.Remove("Email");
            ModelState.Remove("Telefone");

            if (!ModelState.IsValid) return PartialView("_AtualizarEndereco", entidadeViewModel);

            await _entidadeService.AtualizarEndereco(_mapper.Map<EnderecoProfissional>(entidadeViewModel.Endereco));

            if (!OperacaoValida()) return PartialView("_AtualizarEndereco", entidadeViewModel);

            var url = Url.Action("ObterEndereco", "Profissional", new { id = entidadeViewModel.Endereco.ProfissionalId });
            return Json(new { success = true, url });
        }
        private async Task<IActionResult> ObterEndereco(Guid id)
        {
            var profissional = await ObterProfissionalEndereco(id);

            if (profissional == null)
            {
                return NotFound();
            }

            return PartialView("_DetalhesEndereco", profissional);
        }
        [Route("atualizar-ContratoFinanceiro-profissional/{id:guid}")]
        [ClaimsAuthorize("Adm", "Editar")]
        public async Task<IActionResult> AtualizarContratoFinanceiroProfissional(Guid id)
        {
            var profissional = await ObterContratoFinanceiro(id);

            if (profissional == null)
            {
                return NotFound();
            }

            return PartialView("_AtualizarContrato", new ProfissionalViewModel { ContratoFinanceiroProfissional = profissional });
        }
        [Route("atualizar-ContratoFinanceiro-profissional/{id:guid}")]
        [ClaimsAuthorize("Adm", "Editar")]
        [HttpPost]
        public async Task<IActionResult> AtualizarContratoFinanceiroProfissional(ProfissionalViewModel entidadeViewModel)
        {
            ModelState.Remove("Nome");
            ModelState.Remove("CPF");
            ModelState.Remove("Email");
            ModelState.Remove("Telefone");

            if (!ModelState.IsValid) return PartialView("_AtualizarContrato", entidadeViewModel);

            await _entidadeService.AtualizarContrato(_mapper.Map<ContratoFinanceiroProfissional>(entidadeViewModel.ContratoFinanceiroProfissional));

            if (!OperacaoValida()) return PartialView("_AtualizarContrato", entidadeViewModel);

            var url = Url.Action("ObterContrato", "Profissional", new { id = entidadeViewModel.ContratoFinanceiroProfissional.ProfissionalId });
            return Json(new { success = true, url });
        }
        private async Task<IActionResult> ObterContrato(Guid id)
        {
            var profissional = await ObterContratoFinanceiroProfissional(id);

            if (profissional == null)
            {
                return NotFound();
            }

            return PartialView("_DetalhesContratoFinanceiroProfissional", profissional);
        }
        private async Task<ProfissionalViewModel> ObterProfissionalEndereco(Guid id)
        {   
            return _mapper.Map<ProfissionalViewModel>(await _entidadeRepsository.ObterEnderecoProfissional(id));
        }
        private async Task<ContratoFinanceiroProfissionalViewModel> ObterContratoFinanceiro(Guid id)
        {
            return _mapper.Map<ContratoFinanceiroProfissionalViewModel>(await _contratoRepsository.ObterContratoFinanceiroPorProfissonal(id));
        }
        private async Task<ContratoFinanceiroProfissionalViewModel> ObterContratoFinanceiroProfissional(Guid id)
        {
            return _mapper.Map<ContratoFinanceiroProfissionalViewModel>(await _contratoRepsository.ObterContratoFinanceiroPorProfissonal(id));
        }
    }
}

