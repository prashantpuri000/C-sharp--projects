using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRLINE_RESERVATION_SYSTEM.Entity
{
    public class Package
    {
        private string _PackageId;
        public string PackageId
        {
            get { return _PackageId; }
            set { _PackageId = value; }
        }
        private string _FlightId;
        public string FlightId
        {
            get { return _FlightId; }
            set { _FlightId = value; }

        }

        private string _Location;
        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }
    }
}
