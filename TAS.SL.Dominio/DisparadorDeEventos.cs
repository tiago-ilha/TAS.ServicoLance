using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TAS.SL.Dominio
{
    public class DisparadorDeEventos
    {
        private static List<Type> _handlers;

        public static void Init()
        {
            _handlers = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.GetInterfaces()
                .Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IManipularDeEvento<>)))
                .ToList();
        }

        public static void ObterDominioEventos<T>(T entidade) where T : Entidade
        {
            foreach (var eventoDeDominio in entidade.EventosDeDominio)
            {
                foreach (var handlerType in _handlers)
                {
                    if (PermiteManipularEvento(handlerType, eventoDeDominio))
                    {
                        dynamic handler = Activator.CreateInstance(handlerType);
                        handler.Executar((dynamic)eventoDeDominio);
                    }
                }
            }
        }

        private static bool PermiteManipularEvento(Type tipoManipulador, IEventoDeDominio eventoDeDominio)
        {
            return tipoManipulador.GetInterfaces()
                .Any(x => x.IsGenericType
                        && x.GetGenericTypeDefinition() == typeof(IManipularDeEvento<>)
                        && x.GenericTypeArguments[0] == eventoDeDominio.GetType());
        }
    }
}