namespace TAS.SL.Dominio
{
    public interface IManipularDeEvento<TEvento> where TEvento : IEventoDeDominio
    {
         void Executar(TEvento evento);
    }
}