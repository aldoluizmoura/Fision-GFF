#pragma checksum "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9e037c7e70c343b0ef6e7868c36874a70dea8f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MovimentoFinanceiroProfissional_Edit), @"mvc.1.0.view", @"/Views/MovimentoFinanceiroProfissional/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9e037c7e70c343b0ef6e7868c36874a70dea8f9", @"/Views/MovimentoFinanceiroProfissional/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c080f270ca945005a9c841075672aa230114b2fb", @"/Views/_ViewImports.cshtml")]
    public class Views_MovimentoFinanceiroProfissional_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GestaoFluxoFinanceiro.Aplicacao.ViewModels.Financeiro.MovimentoProfissionalViewModel>
    {
        private global::AspNetCore.Views_MovimentoFinanceiroProfissional_Edit.__Generated__SummaryViewComponentTagHelper __SummaryViewComponentTagHelper;
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""album py-5 bg-light"">
    <div class=""container"">
        <div class=""row"" id=""row-recibo"">
            <div class=""col-md-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <center><h4 class=""card-title"">Quitar Documentos</h4></center>
                    </div>
                    <div class=""row"">
                        <div class=""col-md-12"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9e037c7e70c343b0ef6e7868c36874a70dea8f95692", async() => {
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("vc:Summary", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9e037c7e70c343b0ef6e7868c36874a70dea8f95982", async() => {
                }
                );
                __SummaryViewComponentTagHelper = CreateTagHelper<global::AspNetCore.Views_MovimentoFinanceiroProfissional_Edit.__Generated__SummaryViewComponentTagHelper>();
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
                                    <div class=""col-md-12 order-md-2 mb-4"">
                                        <h4 class=""d-flex justify-content-between align-items-center mb-3"">
                                            <span class=""text-muted"">");
#nullable restore
#line 22 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                                Write(Model.Profissional);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span><br />\r\n                                            <span class=\"text-muted\">");
#nullable restore
#line 23 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                                Write(Model.Competencia);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
                                        </h4>
                                        <ul class=""list-group mb-3"">
                                            <li class=""list-group-item d-flex justify-content-between lh-condensed"">
                                                <div>
                                                    <p class=""my-0"">Valor Unitário:</p>
                                                </div>
                                                <span class=""text-muted"">");
#nullable restore
#line 30 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                                    Write(Model.ValorUnitario.ToString("C"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
                                            </li>
                                            <li class=""list-group-item d-flex justify-content-between lh-condensed"">
                                                <div>
                                                    <p class=""my-0"">Quantidade de Alunos:</p>
                                                </div>
                                                <span class=""text-muted"">");
#nullable restore
#line 36 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                                    Write(Model.QuantidadeAlunos);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
                                            </li>
                                            <li class=""list-group-item d-flex justify-content-between lh-condensed"">
                                                <div>
                                                    <h6 class=""my-0"">Total Mensal</h6>
                                                </div>
                                                <span class=""text-muted"">");
#nullable restore
#line 42 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                                    Write(Model.ValorTotal.ToString("C"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
                                            </li>
                                            <li class=""list-group-item d-flex justify-content-between lh-condensed"">
                                                <div>
                                                    <h6 class=""my-0"">Valor do Profissional</h6>
                                                </div>
                                                <span class=""text-muted"">");
#nullable restore
#line 48 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                                     Write((Model.ValorProfissional*100)/Model.ValorTotal);

#line default
#line hidden
#nullable disable
                WriteLiteral("% : ");
#nullable restore
#line 48 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                                                                                         Write(Model.ValorProfissional.ToString("C"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
                                            </li>
                                            <li class=""list-group-item d-flex justify-content-between lh-condensed"">
                                                <div>
                                                    <h6 class=""my-0"">Valor a Receber</h6>
                                                </div>
                                                <span class=""text-muted"">");
#nullable restore
#line 54 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                                    Write(Model.ValorReceber.ToString("C"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
                                            </li>
                                            <li class=""list-group-item d-flex justify-content-between lh-condensed"">
                                                <div>
                                                    <h6 class=""my-0"">Data de Pagamento</h6>
                                                </div>
");
#nullable restore
#line 60 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                 if (Model.DataPagamento == DateTime.Parse("01/01/0001"))
                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                    <span class=\"text-muted\">Documento não Pago</span>\r\n");
#nullable restore
#line 63 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                    <span class=\"text-muted\">");
#nullable restore
#line 66 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                                        Write(Model.DataPagamento.ToShortDateString());

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n");
#nullable restore
#line 67 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            </li>\r\n                                            <li class=\"list-group-item d-flex justify-content-between bg-light\">\r\n");
#nullable restore
#line 70 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                 if (Model.ValorPago == 0)
                                                {
                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                    <div class=""text-success"">
                                                        <h6 class=""my-0"">Valor Recebido</h6>
                                                    </div>
                                                    <span class=""text-success"">");
#nullable restore
#line 78 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                                          Write(Model.ValorPago.ToString("C"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n");
#nullable restore
#line 79 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </li>
                                            <li class=""list-group-item d-flex justify-content-between"">
                                                <strong>Observação:&nbsp;</strong>
                                                <strong>");
#nullable restore
#line 84 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                   Write(Model.Observacao);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong>\r\n                                            </li>\r\n                                            <li class=\"list-group-item d-flex justify-content-between\">\r\n                                                <span>Total</span>\r\n");
#nullable restore
#line 88 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                 if (Model.ValorReceber == 0)
                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                    <p style=\"color:green\">Quitado</p>\r\n");
#nullable restore
#line 91 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                    <strong style=\"color:red\">");
#nullable restore
#line 94 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                                         Write(Model.ValorReceber.ToString("C"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong>\r\n");
#nullable restore
#line 95 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
                                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                            </li>\r\n                                        </ul>\r\n\r\n                                        <center>\r\n                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e9e037c7e70c343b0ef6e7868c36874a70dea8f918805", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 101 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                            <input type=\"submit\" value=\"Quitar\" class=\"btn btn-success\" /> |\r\n                                            <a");
                BeginWriteAttribute("href", " href=\"", 6971, "\"", 7070, 1);
#nullable restore
#line 103 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
WriteAttributeValue("", 6978, this.Url.Action("DesfazerQuitacao","MovimentoFinanceiroProfissional", new {Id = Model.Id }), 6978, 92, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-danger\">Desfazer Quitação</a> |\r\n                                            <a");
                BeginWriteAttribute("href", " href=\"", 7166, "\"", 7260, 1);
#nullable restore
#line 104 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
WriteAttributeValue("", 7173, this.Url.Action("GerarRecibo","MovimentoFinanceiroProfissional", new {Id = Model.Id }), 7173, 87, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-warning\">Gerar Recibo</a> |\r\n                                        </center>\r\n                                    </div>\r\n                                </div>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            <div>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9e037c7e70c343b0ef6e7868c36874a70dea8f923248", async() => {
                WriteLiteral("Voltar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                            <br />\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 122 "C:\dev\Fision\GestaoFluxoFinanceiro\GestaoFluxoFinanceiro.Aplicacao\Views\MovimentoFinanceiroProfissional\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");
    

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GestaoFluxoFinanceiro.Aplicacao.ViewModels.Financeiro.MovimentoProfissionalViewModel> Html { get; private set; }
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
