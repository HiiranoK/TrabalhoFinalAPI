using CityEvents.Service.DTO;
using CityEvents.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEvents.Service.Interface
{
    public interface IEventReservationRepository
    {
        Task<bool> AdicionarReserva(EventReservationEntity reserva);
        Task<IEnumerable<EventReservationEntity>> ConsultaReserva(string nome, string tituloEvento);
        Task<bool> DeletaReserva(int id);
        Task<bool> EditarQuantidadeReserva(int id, int quantidade);

        Task<bool> ValidaStatusEvento(int idEvento);
     }
}
