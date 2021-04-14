using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoFluxoFinanceiro.Dados.Mappings
{
    public class CaixaMapping : IEntityTypeConfiguration<Caixa>
    {
        public void Configure(EntityTypeBuilder<Caixa> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(c => c.Competencia).HasColumnType("varchar(9)");
            builder.ToTable("Caixa");
        }
    }
}
