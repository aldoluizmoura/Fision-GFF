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

namespace GestaoFluxoFinanceiro.Aplicacao.Controllers.Cadastro
{
    [Authorize]
    public class EspecialidadeController : BaseController
    {
        private readonly IEspecialidadeService _entidadeService;
        private readonly IEspecialidadeRepository _entidadeRepository;
        private readonly IMapper _mapper;  

        public EspecialidadeController(IEspecialidadeService entidadeService,
                                       IEspecialidadeRepository entidadeRepository,
                                       INotificador notificador,
                                       ICaixaService caixaservice,
                                       IProfissionalRepository profissionalrepository,
                                       IMapper mapper):base(notificador, caixaservice)
        {
            _entidadeService = entidadeService;
            _entidadeRepository = entidadeRepository;
            _mapper = mapper;
        }
        [Route("especialidades")]
        [ClaimsAuthorize("Adm", "Visual")]
        public async Task<IActionResult> Index()
        {
            var especialidades = _mapper.Map<IEnumerable<EspecialidadesViewModel>>
                                                (await _entidadeRepository.PegarEspecialidades());
            return View(especialidades);
        }

        [Route("nova-especialidade")]
        [ClaimsAuthorize("Adm", "Ger")]
        public IActionResult Create()
        {
            return View();
        }
        [Route("nova-especialidade")]
        [HttpPost]
        [ClaimsAuthorize("Adm", "Ger")]
        public async Task<IActionResult> Create(EspecialidadesViewModel entidadeViewModel)
        {
            if (!ModelState.IsValid) return View(entidadeViewModel);

            var especialidade = _mapper.Map<Especialidades>(entidadeViewModel); 
            await  _entidadeService.Adicionar(especialidade);
            if (!OperacaoValida()) return View();
            
            TempData["Sucesso"] = "Especialidade Cadastrada com sucesso!";            
            return RedirectToAction("Index", especialidade);     
        }
        [Route("excluir-especialidade")]
        [ClaimsAuthorize("Adm", "Ger")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var especialidade = _mapper.Map<EspecialidadesViewModel>
                                    (await _entidadeRepository.PegarEspecialidadePorId(Id));

            return View(especialidade);
        }
        [Route("excluir-especialidade")]
        [ClaimsAuthorize("Adm", "Ger")]

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid Id)
        {
            var especialidade = _mapper.Map<EspecialidadesViewModel>
                                    (await _entidadeRepository.PegarEspecialidadePorId(Id));

            if(especialidade == null)
            {
                return NotFound();
            }

            await _entidadeService.Remover(Id);
            if (!OperacaoValida()) return View(especialidade);

            TempData["Sucesso"] = "Especialidade excluída com sucesso!";

            return RedirectToAction("Index", especialidade);

        }     

    }
}
