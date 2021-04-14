using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestaoFluxoFinanceiro.Aplicacao.Data
{
    public class AppContexto : IdentityDbContext<IdentityUser>
    {
        private readonly DbContextOptions _options;
        public AppContexto(DbContextOptions<AppContexto> options)
            : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
