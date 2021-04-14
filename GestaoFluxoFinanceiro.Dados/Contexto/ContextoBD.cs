using GestaoFluxoFinanceiro.Negocio;
using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Data.Contexto
{
    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions options): base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Alunos> Alunos { get; set; }
        public DbSet<Profissional> profissionais { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<EnderecoProfissional> EnderecoProf { get; set; }
        public DbSet<Caixa> Caixa { get; set; }
        public DbSet<MovimentoAluno> MovimentoAluno { get; set; }
        public DbSet<MovimentoProfissional> MovimentoProfissional { get; set; }
        public DbSet<MovimentosOutros> OutrosMovimentos { get; set; }
        public DbSet<ContratoFinanceiroAluno> contratoFinanceiroAluno { get; set; }
        public DbSet<ContratoFinanceiroProfissional> contratoFinanceiroProfissional { get; set; }
        public DbSet<Especialidades> especialidade { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");           

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextoBD).Assembly);          

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;                    
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;                    
                }
            }           

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
