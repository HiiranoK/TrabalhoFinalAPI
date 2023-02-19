using AutoMapper;
using CityEvents.Service.DTO;
using CityEvents.Service.Entity;
using CityEvents.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEvents.Service.Service
{
    public class EventReservationService : IEventReservationService
    {
        private IEventReservationRepository _repository;
        private IMapper _mapper;

        public EventReservationService(IEventReservationRepository rep, IMapper mapper) 
        {
            _repository = rep;
            _mapper = mapper;
        }

        public async Task<bool> AdicionarReserva(EventReservationDto reserva)
        {
            bool  status = await _repository.ValidaStatusEvento(reserva.IdEvent);
            if(status)
            {
                EventReservationEntity entidade = _mapper.Map<EventReservationEntity>(reserva);
                return await _repository.AdicionarReserva(entidade);
            }
            return false;
        }

        public async Task<IEnumerable<EventReservationDto>> ConsultaReserva(string nome, string tituloEvento)
        {
            IEnumerable<EventReservationEntity> entidade = await _repository.ConsultaReserva(nome, tituloEvento);
            if(entidade == null)
            {
                return null;
            }
            IEnumerable<EventReservationDto> reservaDto = _mapper.Map<IEnumerable<EventReservationDto>>(entidade);
            return reservaDto;
        }

        public async Task<bool> DeletaReserva(int id)
        {
            return await _repository.DeletaReserva(id);
        }

        public async Task<bool> EditarQuantidadeReserva(int id, int quantidade)
        {
            return await _repository.EditarQuantidadeReserva(id, quantidade);
        }
    }
}
