using CityEvents.Service.DTO;
using CityEvents.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEvents.Service.Interface
{
    public interface IEventReservationService
    {
        Task<bool> AdicionarReserva(EventReservationDto reserva);
        Task<IEnumerable<EventReservationDto>> ConsultaReserva(string nome, string tituloEvento);
        Task<bool> DeletaReserva(int id);
        Task<bool> EditarQuantidadeReserva(int id, int quantidade);
    }
}
