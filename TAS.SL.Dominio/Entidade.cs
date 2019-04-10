using System.Collections.Generic;
using Flunt.Notifications;

namespace TAS.SL.Dominio
{
    public abstract class Entidade : Notifiable
    {
        private List<IEventoDeDominio> _eventosDeDominio;
        public List<IEventoDeDominio> EventosDeDominio => _eventosDeDominio;

        public void AdicionarEvento(IEventoDeDominio eventItem)
        {
            _eventosDeDominio = _eventosDeDominio ?? new List<IEventoDeDominio>();
            _eventosDeDominio.Add(eventItem);
        }

        public void RemoverEvento(IEventoDeDominio eventItem)
        {
            _eventosDeDominio?.Remove(eventItem);
        }
    }
}