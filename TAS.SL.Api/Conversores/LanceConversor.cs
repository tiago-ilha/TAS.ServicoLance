using AutoMapper;
using TAS.SL.Api.ViewModels;
using TAS.SL.Dominio;
using TAS.SL.Dominio.DTO;

namespace TAS.SL.Api.Conversores
{
    public class LanceConversor : Profile
    {
        public LanceConversor()
        {
            CreateMap<Lance, ListarLancesDTO>();
            CreateMap<Lance, DetalheLanceDTO>();
        }
    }
}
