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
        bool AdicionarReserva(EventReservationEntity reserva, int idEvento);

        bool EditarQuantidadeReserva(int id, int quantidade);

        bool DeletaReserva(int id);

        void ConsultaReserva(string nome, string tituloEvento);
    }
}
