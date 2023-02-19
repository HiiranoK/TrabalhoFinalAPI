using CityEvents.Service.DTO;
using CityEvents.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CityEvents.Service.Interface
{
    public interface ICityEventService
    {
        Task<bool> AdicionarEvento(CityEventDto evento);
        Task<IEnumerable<CityEventDto>> ConsultaPorLocalEData(string local, DateTime data);
        Task<IEnumerable<CityEventDto>> ConsultaPorPrecoEData(decimal precoMin, decimal precoMax, DateTime data);
        Task<IEnumerable<CityEventDto>> ConsultarPorTitulo(string titulo);
        Task<bool> EditarEvento(CityEventDto evento,int id);
        Task<bool> DeletarOuInativarEvento(int id);
    }
}
