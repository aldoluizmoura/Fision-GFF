using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using System;

namespace GestaoFluxoFinanceiro.Aplicacao.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataDocumento(string documento) => Convert.ToUInt64(documento).ToString("000\\.000\\.000\\-00");

        public static string FormataTelefone(string telefone) => long.Parse(telefone).ToString("(00) 00000-0000");

        public static string converterCompetenciaDesc(string competencia)
        {
            switch (competencia.Substring(0, 2))
            {
                case "01":
                    return "Janeiro";
                case "02":
                    return "Fevereiro";
                case "03":
                    return "Março";
                case "04":
                    return "Abril";
                case "05":
                    return "Maio";
                case "06":
                    return "Junho";
                case "07":
                    return "Julho";
                case "08":
                    return "Agosto";
                case "09":
                    return "Setembro";
                case "10":
                    return "Outubro";
                case "11":
                    return "Novembro";
                case "12":
                    return "Dezembro";
                default:
                    return competencia;
            }
        }

        public static string converterCompetenciaValue(string competencia)
        {
            switch (competencia.Substring(0, 2))
            {
                case "01":
                    return "01";
                case "02":
                    return "02";
                case "03":
                    return "03";
                case "04":
                    return "04";
                case "05":
                    return "05";
                case "06":
                    return "06";
                case "07":
                    return "07";
                case "08":
                    return "08";
                case "09":
                    return "09";
                case "10":
                    return "10";
                case "11":
                    return "11";
                case "12":
                    return "12";
                default:
                    return competencia;
            }
        }

        public static bool IfClaim(this RazorPage page, string claimName, string claimValue) => CustomAuthorization.ValidarClaimsUsuario(page.Context, claimName, claimValue);

        public static string IfClaimShow(this RazorPage page, string claimName, string claimValue) => !CustomAuthorization.ValidarClaimsUsuario(page.Context, claimName, claimValue) ? "disabled" : "";

        public static IHtmlContent IfClaimShow(
          this IHtmlContent page,
          HttpContext context,
          string claimName,
          string claimValue)
        {
            return !CustomAuthorization.ValidarClaimsUsuario(context, claimName, claimValue) ? (IHtmlContent)null : page;
        }
    }
}
