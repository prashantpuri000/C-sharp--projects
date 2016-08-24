using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRLINE_RESERVATION_SYSTEM.Entity
{
    public class Customer : User
    {
        private string _SSN;
        public string SSN
        {
            get
            {
                return _SSN;
            }
            set
            {
                _SSN = value;
            }
        }

        private string _Address;
        public string Address {
            get { return _Address; }
            set { _Address = value; }
        }

        private string _Phone;
        public string Phone {
            get { return _Phone; }
            set { _Phone = value; }
        }

        public override User Login(string email, string password)
        {
            return ARSDatabase.customers.Where(s => s.Password == password && s.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        }
        public bool Register(Customer cus)
        {
            return true;
        }

        public List<Flight> SearchFlights(string source, string destination)
        {
            return null;
        }

        public Flight BookFlight(Flight flight)
        {
            return null;
        }

        public List<Package> SearchPackages(int flightNumber, int packageID)
        {
            return null;
        }

        public Package BookPackage(Package package)
        {
            return null;
        }

        public List<Hotel> SearchHotels(int flightNumber, int packageID)
        {
            return null;
        }

        public Hotel BookHotelRoom(Hotel package)
        {
            return null;
        }

    }
}
