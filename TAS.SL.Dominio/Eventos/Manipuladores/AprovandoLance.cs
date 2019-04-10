using EasyNetQ;

namespace TAS.SL.Dominio.Eventos.Manipuladores
{
    public class AprovandoLance : IManipularDeEvento<AprovarLance>
    {
        public void Executar(AprovarLance evento)
        {
            using (var bus = RabbitHutch.CreateBus("host=127.0.0.1"))
            {
                bus.Publish(new AprovarLance(evento.idAnuncio));
            }
        }
    }
}