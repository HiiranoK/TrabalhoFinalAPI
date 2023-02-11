using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEvents.Service.Entity
{
    public class EventReservationEntity
    {
        // talvez tenha que trocar pra long
        public int IdReservation { get; set; }
        public int IdEvent { get; set; }
        public string PersonName { get; set; }
        public int Quantity { get; set; }

    }
}
