using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoFluxoFinanceiro.Dados.Mappings
{
    class EspecialidadeMapping : IEntityTypeConfiguration<Especialidades>
    {

        public void Configure(EntityTypeBuilder<Especialidades> builder)
        {
            builder.HasKey(p => p.Id);           

            builder.ToTable("Especialidades");

        }

    }
}
