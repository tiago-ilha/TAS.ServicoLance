using System;

namespace TAS.SL.Dominio.Eventos
{
    public class AprovarLance : IEventoDeDominio
    {
        public Guid idAnuncio { get; }

        public AprovarLance(Guid idAnuncio)
        {
            this.idAnuncio = idAnuncio;
        }
    }
}