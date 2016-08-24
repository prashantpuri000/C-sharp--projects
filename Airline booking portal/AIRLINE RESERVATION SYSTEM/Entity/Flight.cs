using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRLINE_RESERVATION_SYSTEM.Entity
{
    public class Flight
    {
        private string _FlightNumber;
        public string FlightNumber 
        { 
            get 
            { 
                return _FlightNumber; 
            }
            set
            {
                _FlightNumber = value;
            }
        }

        private string _Source;
        public string Source
        {
            get
            {
                return _Source;
            }
            set
            {
                _Source = value;
            }
        }

        private string _Destination;
        public string  Destination 
        {
            get
            {
                return _Destination;
            } 
            set
            {
                _Destination = value;
            }
        }
    }
}
