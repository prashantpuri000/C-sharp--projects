using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRLINE_RESERVATION_SYSTEM.Entity
{
    public class Administrator:User
    {
        public override User Login(string email, string password)
        {
            return ARSDatabase.Admins.Where(s => s.Password == password && s.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        }
        public Flight AddFlight(Flight flight) {
            return null;
        }

        public bool DeleteFlight(int flightNumber)
        {
            return true;
        }

        public Package AddPackage(Package package)
        {
            return null;
        }

        public bool DeletePackage(int packageId)
        {
            return true;
        }

        public Hotel AddHotel(Hotel hotel)
        {
            return null;
        }

        public bool DeleteHotel(int hotelId)
        {
            return true;
        }

    }
}
