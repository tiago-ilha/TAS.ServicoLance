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
            var idAnuncio = Guid.Parse("218edfce-4b13-41a7-a682-41b4a9260a32");

            var listaDeAnuncios = new List<Lance>
                {
                    new Lance(idAnuncio, 1000M),
                };

            context.Lances.AddRange(listaDeAnuncios);
            context.SaveChanges();
        }
    }
}
