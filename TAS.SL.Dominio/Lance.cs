using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace TAS.SL.Dominio
{
    public class Lance : Notifiable
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
        }
    }
}
