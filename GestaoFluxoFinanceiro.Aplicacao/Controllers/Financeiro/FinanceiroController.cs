using GestaoFluxoFinanceiro.Aplicacao.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoFluxoFinanceiro.Aplicacao.Controllers.Financeiro
{
    [Authorize]
    public class FinanceiroController : Controller
    {
        [Route("opções-financeiras")]
        [ClaimsAuthorize("Adm", "Visual")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
