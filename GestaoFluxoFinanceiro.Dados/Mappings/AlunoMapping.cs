using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GestaoFluxoFinanceiro.Dados.Mappings
{
    public class AlunosMapping : IEntityTypeConfiguration<Alunos>
    {
        public void Configure(EntityTypeBuilder<Alunos> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Matricula).IsRequired();

            builder.Property(p => p.CPF)
               .IsRequired()
               .HasColumnType("varchar(11)");

            builder.HasOne(a => a.ContratoFinanceiroAluno).WithOne(c => c.aluno)
                .HasForeignKey<ContratoFinanceiroAluno>(c => c.AlunoId);

            builder.HasOne(f => f.Endereco)
              .WithOne(e => e.Aluno).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(a => a.MovimentoAluno).WithOne(a => a.Aluno).HasForeignKey(a => a.AlunoId);

            builder.ToTable("Alunos");
        }
    }
}
