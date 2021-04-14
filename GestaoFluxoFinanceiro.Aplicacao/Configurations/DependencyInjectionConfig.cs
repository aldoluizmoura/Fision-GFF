using GestaoFluxoFinanceiro.Dados.Repository;
using GestaoFluxoFinanceiro.Data.Contexto;
using GestaoFluxoFinanceiro.Negocio.Interfaces;
using GestaoFluxoFinanceiro.Negocio.Notificacoes;
using GestaoFluxoFinanceiro.Negocio.Servicos;
using Microsoft.Extensions.DependencyInjection;


namespace GestaoFluxoFinanceiro.Aplicacao.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ContextoBD>();
            services.AddScoped<IProfissionalRepository, ProfissionaisRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IEnderecoProfissionalRepository, EnderecoProfissionalRepository>();
            services.AddScoped<IContratoFinanceiroAlunoRepository, ContratoFinanceiroAlunoRepository>();
            services.AddScoped<IContratoFinanceiroProfissionalRepository, ContratoFinanceiroProfissionalRepository>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IProfissionalService, ProfissionalService>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
            services.AddScoped<IEspecialidadeService, EspecialidadeService>();
            services.AddScoped<IMovimentoAlunoRepository, MovimentoAlunoRepository>();
            services.AddScoped<IMovimentoProfissionalRepository, MovimentoProfissionalRepository>();
            services.AddScoped<IMovimentoProfissionalService, MovimentoProfissionalService>();
            services.AddScoped<IOutrosMovimentosRepository, OutrosMovimentosRepository>();
            services.AddScoped<IOutrosMovimentosService, OutrosMovimentosService>();
            services.AddScoped<IMovimentoAunoService, MovimentoAlunoService>();
            services.AddScoped<ICaixaRepository, CaixaRepository>();
            services.AddScoped<ICaixaService, CaixaService>();

            return services;
        }
    }
}