using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoFluxoFinanceiro.Dados.Mappings
{
    public class ProfissionaisMapping : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Matricula).IsRequired();


            builder.HasOne(a => a.ContratoFinanceiroProfissional).WithOne(c => c.Profissionais)
               .HasForeignKey<ContratoFinanceiroProfissional>(c => c.ProfissionalId);

            builder.HasOne(e => e.Endereco).WithOne(e => e.profissionais);

            builder.HasMany(p => p.MovimentoProfissional).WithOne(p => p.Profissionais).HasForeignKey(p =>p.ProfissionalId);

            builder.ToTable("Profissional");
        }
    }
}
