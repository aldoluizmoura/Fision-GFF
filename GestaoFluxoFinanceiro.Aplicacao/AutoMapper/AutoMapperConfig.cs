using AutoMapper;
using GestaoFluxoFinanceiro.Aplicacao.ViewModels;
using GestaoFluxoFinanceiro.Aplicacao.ViewModels.Acesso;
using GestaoFluxoFinanceiro.Aplicacao.ViewModels.Financeiro;
using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.AspNetCore.Identity;

namespace GestaoFluxoFinanceiro.Aplicacao.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Profissional, ProfissionalViewModel>().ReverseMap();
            CreateMap<Alunos, AlunoViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecosViewModel>().ReverseMap();
            CreateMap<EnderecoProfissional, EnderecosProfissionalViewModel>().ReverseMap();
            CreateMap<ContratoFinanceiroAluno, ContratoFinanceiroAlunoViewModel>().ReverseMap();
            CreateMap<ContratoFinanceiroProfissional, ContratoFinanceiroProfissionalViewModel>().ReverseMap();
            CreateMap<Especialidades, EspecialidadesViewModel>().ReverseMap();
            CreateMap<MovimentoAluno, MovimentoAlunoViewModel>().ReverseMap();
            CreateMap<MovimentoProfissional, MovimentoProfissionalViewModel>().ReverseMap();
            CreateMap<MovimentosOutros, OutrosMovimentosViewModel>().ReverseMap();
            CreateMap<Caixa, CaixaViewModel>().ReverseMap();
            CreateMap<IdentityUser, UsuariosViewModel>().ReverseMap();

        }
    }
}
