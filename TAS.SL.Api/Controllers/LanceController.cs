using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using TAS.SL.Api.ViewModels;
using TAS.SL.Dominio;
using TAS.SL.Dominio.DTO;

namespace TAS.SL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanceController : ControllerBase
    {
        private readonly ILanceRepositorio _repositorio;
        private readonly IMapper _mapper;

        public LanceController(ILanceRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        // GET: api/Lance
        [HttpGet("{idAnuncio}")]
        public IActionResult ListarLances(Guid idAnuncio)
        {
            var lances = _mapper.Map<IEnumerable<ListarLancesDTO>>(_repositorio.ListarLances(idAnuncio));

            if (lances == null || lances.Count() == 0)
                return NoContent();

            return Ok(lances);
        }

        //POST: api/Lance
        [HttpPost]
        public IActionResult Cadastrar([FromBody] RegistrarLanceViewModel viewModel)
        {
            if(viewModel.Invalid)
                return BadRequest(RetornoAcao(viewModel.Valid, "Não foi possível completar operação.", viewModel.Notifications));

            var lance = new Lance(viewModel.IdAnuncio, viewModel.Valor);

            _repositorio.Salvar(lance);

            var url = Url.Action(nameof(ListarLances), new { idAnuncio = lance.IdAnuncio });

            return Created(url, RetornoAcao(lance.Valid, "Operação foi realizado com sucesso."));
        }

        [HttpPut("{idLance}")]
        public IActionResult AprovarLance(Guid idLance)
        {
            var lance = _repositorio.ObterLancePorIdLance(idLance);

            if (lance == null)
                return BadRequest(RetornoAcao(false, "Não foi possível completar operação."));

            lance.Aprovar();

            _repositorio.Atualizar(lance);

            return Ok(RetornoAcao(lance.Valid, "Operação foi realizado com sucesso."));
        }


        #region Métodos compartilhados

        private object RetornoAcao(bool estaValido, string mensagem, IReadOnlyCollection<Notification> erros = null)
        {
            return new
            {
                EstaValid = estaValido,
                Mensagem = mensagem,
                Erros = erros != null && erros.Count > 0 ? erros : new List<Notification>()
            };
        }

        #endregion
    }
}
