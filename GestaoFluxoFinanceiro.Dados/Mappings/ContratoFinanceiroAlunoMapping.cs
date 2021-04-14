using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoFluxoFinanceiro.Dados.Mappings
{
    class ContratoFinanceiroAlunoMapping : IEntityTypeConfiguration<ContratoFinanceiroAluno>
    {
        public void Configure(EntityTypeBuilder<ContratoFinanceiroAluno> builder)
        {
            builder.HasKey(p => p.Id);           

            builder.ToTable("ContratoFinanceiroAluno");
        }
    }
}
