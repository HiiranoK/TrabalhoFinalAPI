using CityEvents.Filter;
using CityEvents.Infra.Data.Repository;
using CityEvents.Service.DTO;
using CityEvents.Service.Entity;
using CityEvents.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [TypeFilter(typeof(ExcecaoGeralFilter))]
        public async Task<ActionResult<IEnumerable<CityEventDto>>> GetConsultaPorPrecoData([FromQuery] decimal precoMin, decimal precoMax, DateTime data)
        {
            var resposta = await _cityEventService.ConsultaPorPrecoEData(precoMin, precoMax, data);
            if (!resposta.Any())
            {
                return NotFound();
            }
            return Ok(resposta);
        }

        [HttpGet("ConsultaPorLocalEData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [TypeFilter(typeof(ExcecaoGeralFilter))]
        public async Task<ActionResult<IEnumerable<CityEventDto>>> GetConsultaPorLocalEData([FromQuery] string local, DateTime data)
        {
            var resposta = await _cityEventService.ConsultaPorLocalEData(local, data);
            if (!resposta.Any())
            {
                return NotFound();
            }
            return Ok(resposta);
        }

        [HttpGet("ConsultaPorTitulo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [TypeFilter(typeof(ExcecaoGeralFilter))]
        public async Task<ActionResult<IEnumerable<CityEventDto>>> GetConsultaPorTitulo([FromQuery] string titulo)
        {
            var resposta = await _cityEventService.ConsultarPorTitulo(titulo);
            if (!resposta.Any())
            {
                return NotFound();
            }
            return Ok(resposta);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [TypeFilter(typeof(ExcecaoGeralFilter))]
        public async Task<ActionResult<CityEventDto>>Inserir(CityEventDto entity)
        {
            if (!await _cityEventService.AdicionarEvento(entity))
            {
                return BadRequest();
            }
            return Ok(entity);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [TypeFilter(typeof(ExcecaoGeralFilter))]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [TypeFilter(typeof(ExcecaoGeralFilter))]
        public async Task<IActionResult>Deletar([FromQuery]int id) 
        { 

            if(!await _cityEventService.DeletarOuInativarEvento(id))
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}