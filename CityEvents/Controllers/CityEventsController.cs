using CityEvents.Service.DTO;
using CityEvents.Service.Entity;
using CityEvents.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CityEvents.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CityEventsController : ControllerBase
    {
        private ICityEventService _cityEventService { get; set; }
        
        public CityEventsController(ICityEventService cityEventService) 
        {
            _cityEventService = cityEventService;
        }

        [HttpGet("ConsultaPorPrecoEData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CityEventDto> GetConsultaPorPrecoData(decimal precoMin, decimal precoMax, DateTime data)
        {
            return Ok(_cityEventService.ConsultaPorPrecoEData(precoMin, precoMax, data));
        }

        [HttpGet("ConsultaPorLocalEData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CityEventDto> GetConsultaPorLocalEData(string local, DateTime data)
        {
            return Ok(_cityEventService.ConsultaPorLocalEData(local, data));
        }

        [HttpGet("ConsultaPorTitulo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CityEventDto> GetConsultaPorTitulo(string titulo)
        {
            return Ok(_cityEventService.ConsultarPorTitulo(titulo));
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CityEventDto>> Inserir(CityEventDto entity)
        {
            if (!await _cityEventService.AdicionarEvento(entity))
            {
                return BadRequest();
            }
            return Ok(entity);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CityEventDto>> EditarEvento(CityEventDto entity, int id)
        {
            if (!await _cityEventService.EditarEvento(entity, id))
            {
                return BadRequest();
            }
            return Ok(entity);
        }
        [Authorize(Roles = "admin")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Deletar([FromQuery]int id) 
        { 

            if(!await _cityEventService.DeletarOuInativarEvento(id))
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}