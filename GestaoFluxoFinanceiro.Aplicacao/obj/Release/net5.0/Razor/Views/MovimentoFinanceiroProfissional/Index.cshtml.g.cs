#pragma checksum "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd6b8858b1557cc2aaef54efeb2cbd186aae911c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MovimentoFinanceiroProfissional_Index), @"mvc.1.0.view", @"/Views/MovimentoFinanceiroProfissional/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\_ViewImports.cshtml"
using GestaoFluxoFinanceiro.Aplicacao;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd6b8858b1557cc2aaef54efeb2cbd186aae911c", @"/Views/MovimentoFinanceiroProfissional/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c080f270ca945005a9c841075672aa230114b2fb", @"/Views/_ViewImports.cshtml")]
    public class Views_MovimentoFinanceiroProfissional_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GestaoFluxoFinanceiro.Aplicacao.ViewModels.Financeiro.MovimentoProfissionalViewModel>>
    {
        private global::AspNetCore.Views_MovimentoFinanceiroProfissional_Index.__Generated__SummaryViewComponentTagHelper __SummaryViewComponentTagHelper;
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("supress-by-claim-name", "Adm", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("supress-by-claim-value", "Adicionar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "MovimentoFinanceiroProfissional", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::GestaoFluxoFinanceiro.Aplicacao.Extensions.ApagaElementoTagHelper __GestaoFluxoFinanceiro_Aplicacao_Extensions_ApagaElementoTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"album py-5 bg-light\">\r\n    <div class=\"container\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("vc:Summary", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd6b8858b1557cc2aaef54efeb2cbd186aae911c6044", async() => {
            }
            );
            __SummaryViewComponentTagHelper = CreateTagHelper<global::AspNetCore.Views_MovimentoFinanceiroProfissional_Index.__Generated__SummaryViewComponentTagHelper>();
            __tagHelperExecutionContext.Add(__SummaryViewComponentTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h4 class=""card-title"">Valores Mensais dos Profissionais</h4>
                    </div>
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-md-6"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("p", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd6b8858b1557cc2aaef54efeb2cbd186aae911c7416", async() => {
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd6b8858b1557cc2aaef54efeb2cbd186aae911c7707", async() => {
                    WriteLiteral("Novos Valores");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
            }
            );
            __GestaoFluxoFinanceiro_Aplicacao_Extensions_ApagaElementoTagHelper = CreateTagHelper<global::GestaoFluxoFinanceiro.Aplicacao.Extensions.ApagaElementoTagHelper>();
            __tagHelperExecutionContext.Add(__GestaoFluxoFinanceiro_Aplicacao_Extensions_ApagaElementoTagHelper);
            __GestaoFluxoFinanceiro_Aplicacao_Extensions_ApagaElementoTagHelper.IdentityClaimName = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __GestaoFluxoFinanceiro_Aplicacao_Extensions_ApagaElementoTagHelper.IdentityClaimValue = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </div>
                        </div>

                        <div class=""row"">
                            <div class=""col-lg-12 feature_col"">
                                <table class=""table table-hover"" id=""tbl"">
                                    <thead class=""thead-dark"">
                                        <tr>
                                            <th>
                                                Nome
                                            </th>
                                            <th>
                                                Valor Total
                                            </th>
                                            <th>
                                                Valor a Receber
                                            </th>
                                            <th>
                                                Valor do Profissional
                                            </th>
   ");
            WriteLiteral(@"                                         <th>
                                                Mês
                                            </th>
                                            <th>
                                                Situação
                                            </th>
                                            <th>

                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 53 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Index.cshtml"
                                         foreach (var item in Model)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 57 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Index.cshtml"
                                               Write(Html.DisplayFor(itemmodel => item.Profissional));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 60 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Index.cshtml"
                                               Write(item.ValorTotal.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 63 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Index.cshtml"
                                               Write(item.ValorReceber.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 66 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Index.cshtml"
                                               Write(item.ValorProfissional.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 69 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Index.cshtml"
                                               Write(Html.DisplayFor(itemmodel => item.CompetenciaCobranca));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n\r\n");
#nullable restore
#line 72 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Index.cshtml"
                                                 if (item.Situacao == 3)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <td><p style=\"color:cornflowerblue\">Em aberto</p></td>\r\n");
#nullable restore
#line 75 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Index.cshtml"
                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Index.cshtml"
                                                 if (item.Situacao == 1)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <td><p style=\"color:darkgreen\"><strong>Quitado</strong></p></td>\r\n");
#nullable restore
#line 79 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Index.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                <td class=\"text-right\">\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd6b8858b1557cc2aaef54efeb2cbd186aae911c16353", async() => {
                WriteLiteral("<spam class=\"fas fa-money-bill-wave\"></spam> ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 82 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Index.cshtml"
                                                                                                                                                    WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                </td>\r\n                                            </tr>\r\n");
#nullable restore
#line 85 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </tbody>\r\n                                </table>\r\n                            </div>\r\n                        </div>\r\n                        <a class=\"btn btn-info\"");
            BeginWriteAttribute("href", " href=\"", 4868, "\"", 4908, 1);
#nullable restore
#line 90 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Index.cshtml"
WriteAttributeValue("", 4875, Url.Action("Index","Financeiro"), 4875, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Voltar</a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n\r\n");
#nullable restore
#line 100 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Index.cshtml"
          await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script type=\"text/javascript\" src=\"https://cdn.datatables.net/v/dt/dt-1.10.23/datatables.min.js\"></script>\r\n\r\n        <script>\r\n            $(document).ready(function () {\r\n                Paginacao();\r\n            });\r\n        </script>\r\n    ");
            }
            );
            WriteLiteral("}\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GestaoFluxoFinanceiro.Aplicacao.ViewModels.Financeiro.MovimentoProfissionalViewModel>> Html { get; private set; }
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute("vc:summary")]
        public class __Generated__SummaryViewComponentTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
        {
            private readonly global::Microsoft.AspNetCore.Mvc.IViewComponentHelper __helper = null;
            public __Generated__SummaryViewComponentTagHelper(global::Microsoft.AspNetCore.Mvc.IViewComponentHelper helper)
            {
                __helper = helper;
            }
            [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNotBoundAttribute, global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewContextAttribute]
            public global::Microsoft.AspNetCore.Mvc.Rendering.ViewContext ViewContext { get; set; }
            public override async global::System.Threading.Tasks.Task ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext __context, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput __output)
            {
                (__helper as global::Microsoft.AspNetCore.Mvc.ViewFeatures.IViewContextAware)?.Contextualize(ViewContext);
                var __helperContent = await __helper.InvokeAsync("Summary", new {  });
                __output.TagName = null;
                __output.Content.SetHtmlContent(__helperContent);
            }
        }
    }
}
#pragma warning restore 1591
