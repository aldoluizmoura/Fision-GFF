using GestaoFluxoFinanceiro.Negocio.Interfaces;
using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Servicos
{
    [Authorize]
    public class CaixaService : BaseService, ICaixaService
    {
        private readonly IMovimentoAlunoRepository _movimentoAlunoRepository;
        private readonly IMovimentoProfissionalRepository _movimentoProfissionalRepository;
        private readonly IOutrosMovimentosRepository _outrosMovimentosRepository;
        private readonly ICaixaRepository _entidadeRepository;

        public CaixaService( INotificador notificador,
                              IMovimentoAlunoRepository movimentoAlunoRepository,
                              IMovimentoProfissionalRepository movimentoProfissionalRepository,
                              IOutrosMovimentosRepository outrosMovimentosRepository,
                              ICaixaRepository entidadeRepository)
                              : base(notificador)
        {
            _movimentoAlunoRepository = movimentoAlunoRepository;
            _movimentoProfissionalRepository = movimentoProfissionalRepository;
            _entidadeRepository = entidadeRepository;
            _outrosMovimentosRepository = outrosMovimentosRepository;
        }

        public async Task Adicionar(Caixa caixa)
        {
            caixa.TotalDespesa = await GerarDespesa(caixa.Competencia);
            caixa.TotalReceita = await GerarReceita(caixa.Competencia);
            caixa.TotalFinal = caixa.TotalReceita - caixa.TotalDespesa;
            caixa.Situacao = 1;
            caixa.DataCaixa = DateTime.Now;
            caixa.Status = DefinirStatus(caixa.TotalFinal);
            await _entidadeRepository.Adicionar(caixa);
        }

        public Task Atualizar(Caixa caixa) 
        {
            throw new NotImplementedException();
        }
        public async Task<decimal> GerarDespesa(string competencia)
        {
            var listaOutrosMovimentosDespesa = await _outrosMovimentosRepository.ObterMovimentosDespesaCompetencia(competencia);
            return listaOutrosMovimentosDespesa.Sum(m=>m.Valor);
        } 
        public async Task<decimal> GerarReceita(string competencia)
        {
            var listaAlunosReceita = await _movimentoAlunoRepository.ObterMovimentosReceitaCompetencia(competencia);
            decimal alunosReceita = listaAlunosReceita.Sum(v => v.ValorPago);

            var listaProfissionalReceita = await _movimentoProfissionalRepository.ObterMovimentosReceitaCompetencia(competencia);
            decimal profissionaisReceita = listaProfissionalReceita.Sum(v => v.ValorPago);

            var listaOutrosMovimentos = await _outrosMovimentosRepository.ObterMovimentosReceitaCompetencia(competencia);
            decimal outrosmovimentosReceita = listaOutrosMovimentos.Sum(v => v.Valor);

            return alunosReceita + profissionaisReceita + outrosmovimentosReceita;
        }

        public Task<Caixa> ObterValoresFinaisCaixa(Guid Id)
        {
             throw new NotImplementedException();
        }

        public async Task FecharCaixa(Guid Id)
        {
            var caixa = await _entidadeRepository.ObterCaixaPorId(Id);
            caixa.Situacao = 2;
            await _entidadeRepository.Atualizar(caixa);
        }

        public async Task Reprocessar(Guid Id)
        {
            var caixa = await _entidadeRepository.ObterCaixaPorId(Id);
            caixa.TotalDespesa = await GerarDespesa(caixa.Competencia);
            caixa.TotalReceita = await GerarReceita(caixa.Competencia);
            caixa.TotalFinal = caixa.TotalReceita - caixa.TotalDespesa;
            caixa.Situacao = 1;
            caixa.Status = DefinirStatus(caixa.TotalFinal);
            await _entidadeRepository.Atualizar(caixa);            
        }

        private string DefinirStatus(decimal TotalFinal) 
        {
            if (TotalFinal >= 0) return "Positivo";
            else return "Negativo";
        }            
        public void Dispose()
        {
            _entidadeRepository?.Dispose();
            _movimentoAlunoRepository?.Dispose();
            _movimentoProfissionalRepository?.Dispose();
            _outrosMovimentosRepository?.Dispose();
        }

       
    }
}
