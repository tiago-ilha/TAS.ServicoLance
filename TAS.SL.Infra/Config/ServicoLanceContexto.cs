using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using TAS.SL.Dominio;
using TAS.SL.Infra.Mapeamentos;

namespace TAS.SL.Infra.Config
{
    public class ServicoLanceContexto : DbContext
    {
        public ServicoLanceContexto(DbContextOptions options) : base(options) { }

        public DbSet<Lance> Lances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfiguration(new LanceMap());
        }
    }
}
