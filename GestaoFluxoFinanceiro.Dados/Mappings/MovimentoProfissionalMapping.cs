using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoFluxoFinanceiro.Dados.Mappings
{
    public class MovimentoProfissionalMapping : IEntityTypeConfiguration<MovimentoProfissional>
    {
        public void Configure(EntityTypeBuilder<MovimentoProfissional> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(c => c.Observacao).HasColumnType("varchar(300)");

            builder.ToTable("MovimentoProfissional");
        }
    }
}
