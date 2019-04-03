using System;
using System.Collections.Generic;
using System.Linq;
using TAS.SL.Dominio;
using TAS.SL.Infra.Config;
using Microsoft.EntityFrameworkCore;

namespace TAS.SL.Infra
{
    public class LanceRepositorio : ILanceRepositorio
    {
        private ServicoLanceContexto _contexto;

        public LanceRepositorio(ServicoLanceContexto contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Lance> ListarLances(Guid idAnuncio)
        {
            return _contexto.Lances.AsNoTracking().Where(x => x.IdAnuncio == idAnuncio);
        }

        public Lance ObterLancePorIdAnuncio(Guid idAnuncio)
        {
            return _contexto.Lances.Where(x => x.IdAnuncio == idAnuncio).SingleOrDefault();
        }

        public Lance ObterLancePorIdLance(Guid idLance)
        {
            return _contexto.Lances.Where(x => x.IdLance == idLance).SingleOrDefault();
        }

        public void Salvar(Lance lance)
        {
            _contexto.Lances.Add(lance);
            _contexto.SaveChanges();
        }

        public void Atualizar(Lance lance)
        {
            _contexto.Entry(lance).State = EntityState.Modified;
            _contexto.SaveChanges();
        }
    }
}
