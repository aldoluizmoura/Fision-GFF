using GestaoFluxoFinanceiro.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Negocio.Interfaces
{
    public interface IAlunoRepository : IRepository<Alunos>
    {
        Task<Alunos> ObterAlunoPorId(Guid Id);
        Task<IEnumerable<Alunos>> ObterTodosAlunos();
        Task<IEnumerable<Alunos>> ObterTodosAlunosAtivos();
        Task<Alunos> ObterEnderecoAluno(Guid id);        
        string ObterUltimaMatricula();

    }
}
