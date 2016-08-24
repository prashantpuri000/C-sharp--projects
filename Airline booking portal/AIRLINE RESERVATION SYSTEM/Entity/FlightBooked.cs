using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRLINE_RESERVATION_SYSTEM.Entity
{
    public class FlightBooked
    {
        private string _ID;
        public string ID {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _UserID;
        public string UserID {
            get { return _UserID;}
            set { _UserID = value; }
        }

        private string _FlightID;
        public string FlightID {
            get { return _FlightID; }
            set { _FlightID = value; }
        }

        private string _Seat;
        public string Seat {
            get { return _Seat; }
            set { _Seat = value; }
        }
    }
}
