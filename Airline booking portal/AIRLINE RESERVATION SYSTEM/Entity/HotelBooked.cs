using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRLINE_RESERVATION_SYSTEM.Entity
{
    public class HotelBooked
    {
        private string _ID;
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _UserID;
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        private string _HotelID;
        public string HotelID
        {
            get { return _HotelID; }
            set { _HotelID = value; }
        }
        private string _FromDate;
        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }
        private string _Todate;
        public string Todate
        {
            get { return _Todate; }
            set { _Todate = value; }
        }
    }
}
