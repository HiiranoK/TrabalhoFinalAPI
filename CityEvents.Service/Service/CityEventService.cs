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
    public class CityEventService : ICityEventService
    {
        private  ICityEventRepository _repository;
        private  IMapper _mapper;

        public CityEventService(ICityEventRepository rep,IMapper mapper) 
        {
            _repository = rep;
            _mapper = mapper;
        }

        public async Task<bool> AdicionarEvento(CityEventDto evento)
        {
           CityEventEntity entidade = _mapper.Map<CityEventEntity>(evento);
           return await _repository.AdicionarEvento(entidade);
        }

        public async Task<IEnumerable<CityEventDto>>ConsultaPorLocalEData(string local, DateTime data)
        {
            IEnumerable<CityEventEntity> entidade = await _repository.ConsultaPorLocalEData(local, data);
            if (entidade == null)
            {
                return null;
            }

            IEnumerable<CityEventDto> eventoDto = _mapper.Map<IEnumerable<CityEventDto>>(entidade);
            return eventoDto;
        }

        public async Task<IEnumerable<CityEventDto>> ConsultaPorPrecoEData(decimal precoMin, decimal precoMax, DateTime data)
        {
            IEnumerable<CityEventEntity> entidade = await _repository.ConsultaPorPrecoEData(precoMin,precoMax,data);
            if (entidade == null)
            {
                return null;
            }
            IEnumerable<CityEventDto> eventoDto = _mapper.Map<IEnumerable<CityEventDto>>(entidade);
            return eventoDto;
        }

        public async Task<IEnumerable<CityEventDto>> ConsultarPorTitulo(string titulo)
        {

            IEnumerable<CityEventEntity> entidade = await _repository.ConsultaPorTitulo(titulo);
            if(entidade == null)
            {
                return null;
            }
            IEnumerable<CityEventDto> eventoDto = _mapper.Map<IEnumerable<CityEventDto>>(entidade);
            return eventoDto;
        }

        public async Task<bool> DeletarOuInativarEvento(int id)
        {
            bool quantidadeReserva = await _repository.ConsultaReservasNoEvento(id);
            
            if(quantidadeReserva != false)
            {
                return await _repository.ExcluirEvento(id);
            }
            return await _repository.InativarEvento(id);
        }

        public async Task<bool> EditarEvento(CityEventDto evento, int id)
        {
            CityEventEntity entidade = _mapper.Map<CityEventEntity>(evento);
            return await _repository.EditarEvento(entidade,id);
        }
    }
}
