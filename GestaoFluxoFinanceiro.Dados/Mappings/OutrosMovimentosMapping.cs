using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoFluxoFinanceiro.Dados.Mappings
{
    public class MovimentosOutrosMapping : IEntityTypeConfiguration<MovimentosOutros>
    {
        public void Configure(EntityTypeBuilder<MovimentosOutros> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(c => c.Descricao).HasColumnType("varchar(300)");
            builder.ToTable("MovimentosOutros");
        }
    }
}