using System;
using System.Collections.Generic;
using System.Text;

namespace TAS.SL.Dominio
{
    public interface ILanceRepositorio
    {
        IEnumerable<Lance> ListarLances(Guid idAnuncio);
        Lance ObterLancePorIdAnuncio(Guid idAnuncio);
        Lance ObterLancePorIdLance(Guid idLance);
        void Salvar(Lance lance);
        void Atualizar(Lance lance);
    }
}
