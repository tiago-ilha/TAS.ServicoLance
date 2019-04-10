using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
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
            modelBuilder.Ignore<Entidade>();

            modelBuilder.ApplyConfiguration(new LanceMap());
        }

        public override int SaveChanges() {

            var entidadeAlteradas = ChangeTracker.Entries()
                                        .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

            foreach (var entry in entidadeAlteradas)
            {
                var entidade = entry.Entity as Lance;

                if (entidade.EventosDeDominio != null && entidade.EventosDeDominio.Count > 0)
                    DisparadorDeEventos.ObterDominioEventos(entidade);
            }

           return base.SaveChanges();
        }
    }
}
