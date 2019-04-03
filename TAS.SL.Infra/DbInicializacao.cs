using System;
using System.Collections.Generic;
using TAS.SL.Dominio;
using TAS.SL.Infra.Config;

namespace TAS.SL.Infra
{
    public class DbInicializacao
    {
        public static void Popular(ServicoLanceContexto context)
        {
            var idAnuncio = Guid.Parse("63D7D8F5-0FAD-4F68-B459-D99786710A65");

            var listaDeAnuncios = new List<Lance>
                {
                    new Lance(idAnuncio, 1000M),
                };

            context.Lances.AddRange(listaDeAnuncios);
            context.SaveChanges();
        }
    }
}
