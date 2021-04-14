using GestaoFluxoFinanceiro.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Aplicacao.Controllers
{
    public class BaseController : Controller
    {
        private readonly INotificador _notificador;
        private readonly ICaixaService _caixaService;

        protected BaseController(INotificador notificador, ICaixaService caixaservice)
        {
            _notificador = notificador;
            _caixaService = caixaservice;
        }
        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }
        protected string GerarCodigoMatricula(Object entidade, string UltimaMatricula)
        {
            int matricula = Convert.ToInt32(UltimaMatricula) + 1;

            if (entidade.GetType().Name == "AlunoViewModel")
            {   
                return "A" + DateTime.Now.Year + Convert.ToString(matricula).PadLeft(4,'0'); 
            }
            if (entidade.GetType().Name == "ProfissionalViewModel")
            {
                return "P" + DateTime.Now.Year + Convert.ToString(matricula).PadLeft(4,'0');
            }
            return null;
        }               
    }
}
