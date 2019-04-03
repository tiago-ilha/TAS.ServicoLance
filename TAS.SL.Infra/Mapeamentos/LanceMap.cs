using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TAS.SL.Dominio;

namespace TAS.SL.Infra.Mapeamentos
{
    public class LanceMap : IEntityTypeConfiguration<Lance>
    {
        public void Configure(EntityTypeBuilder<Lance> builder)
        {
            builder.HasKey(x => new { x.IdAnuncio, x.IdLance });
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.Fechado);
        }
    }
}
