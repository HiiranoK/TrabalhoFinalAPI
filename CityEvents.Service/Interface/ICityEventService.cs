using CityEvents.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEvents.Service.Interface
{
    public interface ICityEventService
    {
        void AdicionarEvento(CityEventsEntity evento);

        void EditarEvento(CityEventsEntity evento, int id);

        void ExcluirEvento(int id);

        void ConsultaPorTitulo(string titulo);

        void ConsultaPorLocalEData(string local, DateTime data);

        void ConsultaPorPrecoEData(double precoMin, double precoMax, DateTime data);
    }
}
