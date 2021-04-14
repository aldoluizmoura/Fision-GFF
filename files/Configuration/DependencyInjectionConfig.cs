using GestaoFluxoFinanceiro.Aplicacao.Extensions;
using GestaoFluxoFinanceiro.Dados.Repository;
using GestaoFluxoFinanceiro.Data.Contexto;
using GestaoFluxoFinanceiro.Negocio.Interfaces;
using GestaoFluxoFinanceiro.Negocio.Servicos;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoFluxoFinanceiro.Aplicacao.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ContextoBD>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IAlunoRepository, AlunosRepository>();
            services.AddScoped<IProfissionaisRepository, ProfissionalRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IAlunosService, AlunoService>();
            services.AddScoped<IProfissionaisService, ProfissionaisService>();

            return services;
        }
    }
}