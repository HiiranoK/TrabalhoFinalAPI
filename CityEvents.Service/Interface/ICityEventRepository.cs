using CityEvents.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEvents.Service.Interface
{
    public interface ICityEventRepository
    {
        Task<bool> AdicionarEvento(CityEventEntity evento);

        Task<bool> EditarEvento(CityEventEntity evento, int id);

        Task<bool> ExcluirEvento(int id);

        Task<bool> InativarEvento(int id);

        Task<List<CityEventEntity>> ConsultaPorTitulo(string titulo);

        Task<IEnumerable<CityEventEntity>> ConsultaPorLocalEData(string local, DateTime data);

        Task<List<CityEventEntity>> ConsultaPorPrecoEData(decimal precoMin, decimal precoMax, DateTime data);
        Task<bool> ConsultaReservasNoEvento(int idEvento);
    }
}
