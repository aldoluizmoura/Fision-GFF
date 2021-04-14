using GestaoFluxoFinanceiro.Negocio.Interfaces;
using GestaoFluxoFinanceiro.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Servicos
{
    public class EspecialidadeService : BaseService, IEspecialidadeService
    {
        private readonly IEspecialidadeRepository _entidadeRepository ;
        private readonly IProfissionalRepository _profissionalRepository;
        public EspecialidadeService(IEspecialidadeRepository entidadeRepository,
                                    IProfissionalRepository profissionalRepository,
                                    INotificador notificador): base(notificador)
        {
            _entidadeRepository = entidadeRepository;
            _profissionalRepository = profissionalRepository;
        }

        public async Task Adicionar(Especialidades entidade)
        {
            var especialidade = await _entidadeRepository.PegarEspecialidadesProDescricao(entidade.Descricao);
            if(especialidade != null)
            {
                Notificar("Já há uma especialidade cadastrada com essa descrição");
                return;
            }
            await _entidadeRepository.Adicionar(entidade);            
        }

        public async Task Atualizar(Especialidades entidade)
        {
            var especialidade = _entidadeRepository.PegarEspecialidadePorId(entidade.Id);
            if(especialidade == null )
            {
                Notificar("Especialidade não encontrada");
                return;
            }
            await _entidadeRepository.Atualizar(entidade);
        }

        public async Task Remover(Guid id)
        {
            var especialidade = await _entidadeRepository.PegarEspecialidadePorId(id);
            var especialidadePrestador = await _profissionalRepository.ProfissionalPorEspecialidade(id);

            if (especialidadePrestador.Count() != 0)
            {
                Notificar("Ação impossivel: essa especialidade já está vinculada a algum Profissional");
                return;
            }

            if (especialidade == null)
            {
                Notificar("Especialidade não encontrada");
                return;
            }
            await _entidadeRepository.Remover(especialidade.Id);
        }
        public void Dispose()
        {
            _entidadeRepository?.Dispose();
        }

    }
}
