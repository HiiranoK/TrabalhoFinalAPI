using CityEvents.Service.DTO;
using CityEvents.Service.Entity;
using CityEvents.Service.Interface;
using CityEvents.Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CityEvents.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class EventReservationController : ControllerBase
    {
        private IEventReservationService _eventReservationService { get; set; }

        public EventReservationController(IEventReservationService eventReservationService)
        {
            _eventReservationService = eventReservationService;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async  Task<ActionResult<IEnumerable<EventReservationDto>>> ConsultaReserva(string nome, string tituloEvento)
        {
            return Ok(await _eventReservationService.ConsultaReserva(nome, tituloEvento)); 
        }
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AdicionarReserva(EventReservationDto reserva)
        {
            if(!await _eventReservationService.AdicionarReserva(reserva))
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CityEventDto>> EditarQuantidadeReserva(int id, int quantidade)
        {
            if (!await _eventReservationService.EditarQuantidadeReserva(id,quantidade))
            {
                return BadRequest();
            }
            return Ok();
        }


        [HttpDelete]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Deletar([FromQuery] int id)
        {
            if(!await _eventReservationService.DeletaReserva(id))
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
