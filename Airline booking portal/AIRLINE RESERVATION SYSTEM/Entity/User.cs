using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRLINE_RESERVATION_SYSTEM.Entity
{
    public class User
    {
        private int _Id = 0;
        public int Id {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _Email;
        public string Email {
            get { return _Email; }
            set { _Email = value; }
        }
        private string _Name;
        public string Name {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Password;
        public string Password {
            get { return _Password; }
            set { _Password = value; }
        }

        public virtual User Login(string email, string password) {
            return null;
        }

    }
}
