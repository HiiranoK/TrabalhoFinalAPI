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

        public void AdicionarEvento(CityEventsEntity evento)
        {
            throw new NotImplementedException();
        }

        public void ConsultaPorLocalEData(string local, DateTime data)
        {
            throw new NotImplementedException();
        }

        public void ConsultaPorPrecoEData(double precoMin, double precoMax, DateTime data)
        {
            throw new NotImplementedException();
        }

        public void ConsultaPorTitulo(string titulo)
        {
            throw new NotImplementedException();
        }

        public void EditarEvento(CityEventsEntity evento, int id)
        {
            throw new NotImplementedException();
        }

        public void ExcluirEvento(int id)
        {
            throw new NotImplementedException();
        }
    }
}
