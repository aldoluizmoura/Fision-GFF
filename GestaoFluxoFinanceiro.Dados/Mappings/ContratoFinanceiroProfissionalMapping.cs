using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoFluxoFinanceiro.Dados.Mappings
{
    class ContratoFinanceiroProfissionalMapping : IEntityTypeConfiguration<ContratoFinanceiroProfissional>
    {
        public void Configure(EntityTypeBuilder<ContratoFinanceiroProfissional> builder)
        {
            builder.HasKey(p => p.Id);           

            builder.ToTable("ContratoFinanceiroProfissional");
        }
    }
}
