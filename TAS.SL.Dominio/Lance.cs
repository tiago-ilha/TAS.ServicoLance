using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using TAS.SL.Dominio.Eventos;

namespace TAS.SL.Dominio
{
    public class Lance : Entidade
    {
        public Lance(Guid idAnuncio, decimal valor)
        {
            IdLance = Guid.NewGuid();
            IdAnuncio = idAnuncio;
            Valor = valor;
        }

        public Guid IdAnuncio { get; set; }
        public Guid IdLance { get; set; }
        public decimal Valor { get; set; }
        public bool Fechado { get; set; }

        public void Aprovar()
        {
            Fechado = true;

            AdicionarEvento(new AprovarLance(IdAnuncio));
        }
    }
}
