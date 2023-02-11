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
        void IncluiReserva(EventReservationEntity reserva);

        void EditarQuantidadeReserva(int id, int quantidade);

        void DeletaReserva(int id);

        void ConsultaReserva(string nome, string tituloEvento);
    }
}
