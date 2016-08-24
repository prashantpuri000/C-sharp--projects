using AIRLINE_RESERVATION_SYSTEM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRLINE_RESERVATION_SYSTEM
{
    static class ARSDatabase
    {
        public static List<Customer> customers = new List<Customer>();
        public static List<Administrator> Admins = new List<Administrator>();
        public static List<Flight> Flights = new List<Flight>();
        public static List<Package> Pakcages = new List<Package>();
        public static List<Hotel> Hotel = new List<Hotel>();
        public static List<FlightBooked> BookedFlights = new List<FlightBooked>();
        public static List<PackageBooked> BookedPackagese = new List<PackageBooked>();
        public static List<HotelBooked> BookedHotels = new List<HotelBooked>();
    }
    class Program
    {

        private static void InitData()
        {
            ARSDatabase.Admins.Add(new Administrator()
            {
                Email = "admin",
                Id = 1,
                Name = "Administrator",
                Password = "123",
            });
        }
        static void Main(string[] args)
        {
            InitData();
            object UserLogged = null;
            bool isRunning = true;
            Console.WriteLine("--------------------------- AIRLINE RESERVATION SYSTEM -----------------------");
            do
            {
                int menu = GuessMenu();
                switch (menu)
                {
                    case 1:
                        {
                            Customer cus = new Customer();
                            Console.WriteLine("-----LOGIN-----");
                            Console.Write("Email   : ");
                            cus.Email = Console.ReadLine();
                            Console.Write("Password: ");
                            cus.Password = Console.ReadLine();
                            UserLogged = cus.Login(cus.Email, cus.Password);
                            if (UserLogged == null)
                            {
                                Console.WriteLine("Log in fail!");
                            }

                            do
                            {
                                menu = CustommerMenu();
                                switch (menu)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("-----BOOKED FLIGHTS-----");
                                            Console.WriteLine("{0,5}|{1,12}|{2,15}|{3,30}", "No", "Flight ID", "Source", "Destination");
                                            Console.WriteLine("------------------------------------------------------------------------");
                                            var booked = ARSDatabase.BookedFlights.Where(s => s.UserID.Equals(cus.Email, StringComparison.CurrentCultureIgnoreCase)).Select(s => s).ToList();
                                            for (int i = 0; i < booked.Count(); i++)
                                            {
                                                Flight f = ARSDatabase.Flights.Where(s => s.FlightNumber.Equals(booked[i].FlightID, StringComparison.CurrentCultureIgnoreCase)).Select(s => s).FirstOrDefault();
                                                if (f != null)
                                                {
                                                    Console.WriteLine("{0,5}|{1,12}|{2,15}|{3,30}", i + 1, f.FlightNumber, f.Destination, f.Source);
                                                    Console.WriteLine("------------------------------------------------------------------------");
                                                }
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("-----BOOKED PACKAGESE-----");
                                            Console.WriteLine("{0,5}|{1,15}|{2,15}|{3,15}", "No", "Package ID", "Flight ID", "Location");
                                            Console.WriteLine("------------------------------------------------------------------------");
                                            var booked = ARSDatabase.BookedPackagese.Where(s => s.UserID.Equals(cus.Email, StringComparison.CurrentCultureIgnoreCase)).Select(s => s).ToList();
                                            for (int i = 0; i < booked.Count(); i++)
                                            {
                                                Package p = ARSDatabase.Pakcages.Where(s => s.PackageId.Equals(booked[i].PackageID, StringComparison.CurrentCultureIgnoreCase)).Select(s => s).FirstOrDefault();
                                                Console.WriteLine("{0,5}|{1,15}|{2,15}|{3,15}", i + 1, p.PackageId, p.FlightId, p.Location);
                                                Console.WriteLine("------------------------------------------------------------------------");
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("-----BOOKED HOTELS-----");
                                            Console.WriteLine("{0,5}|{1,15}|{2,50}", "No", "Name", "Location");
                                            Console.WriteLine("------------------------------------------------------------------------");
                                            var booked = ARSDatabase.BookedHotels.Where(s => s.UserID.Equals(cus.Email, StringComparison.CurrentCultureIgnoreCase)).Select(s => s).ToList();
                                            for (int i = 0; i < booked.Count(); i++)
                                            {
                                                Hotel h = ARSDatabase.Hotel.Where(s => s.Id.Equals(booked[i].HotelID, StringComparison.CurrentCultureIgnoreCase)).Select(s => s).FirstOrDefault();
                                                Console.WriteLine("{0,5}|{1,15}|{2,50}", i + 1, h.Name, h.Location);
                                                Console.WriteLine("------------------------------------------------------------------------");
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("-----SEARCH FLIGHTS-----");
                                            Console.WriteLine("Notice: Leave empty to find all");
                                            Console.Write("Flight ID:");
                                            string fId = Console.ReadLine();
                                            Console.Write("Source:");
                                            string source = Console.ReadLine();
                                            Console.Write("Destination:");
                                            string dest = Console.ReadLine();

                                            var flightResult = ARSDatabase.Flights.Where(s => s.FlightNumber == fId || string.IsNullOrEmpty(fId))
                                                .Where(s => s.Source.Contains(source) || string.IsNullOrEmpty(source))
                                                .Where(s => s.Destination.Contains(dest)).Select(s => s).ToList();

                                            Console.WriteLine("-----FLIGHTS SEARCH RESULT-----");
                                            Console.WriteLine("{0,5}|{1,12}|{2,15}|{3,30}", "No", "Flight ID", "Source", "Destination");
                                            Console.WriteLine("------------------------------------------------------------------------");

                                            for (int i = 0; i < flightResult.Count(); i++)
                                            {
                                                Flight f = flightResult[i];
                                                Console.WriteLine("{0,5}|{1,12}|{2,15}|{3,30}", i + 1, f.FlightNumber, f.Destination, f.Source);
                                                Console.WriteLine("------------------------------------------------------------------------");
                                            }
                                            break;

                                        }
                                    case 5:
                                        {
                                            Console.WriteLine("-----SEARCH PACKAGESE-----");
                                            Console.WriteLine("Notice: Leave empty to find all");
                                            Console.Write("Package ID:");
                                            string pID = Console.ReadLine();
                                            Console.Write("Flight ID :");
                                            string fID = Console.ReadLine();
                                            Console.Write("Location  :");
                                            string location = Console.ReadLine();

                                            var Result = ARSDatabase.Pakcages.Where(s => s.FlightId == fID || string.IsNullOrEmpty(fID))
                                                .Where(s => s.PackageId.Contains(pID) || string.IsNullOrEmpty(pID))
                                                .Where(s => s.Location.Contains(location)).Select(s => s).ToList();

                                            Console.WriteLine("-----PACKAGESE SEARCH RESULT-----");
                                            Console.WriteLine("{0,5}|{1,15}|{2,15}|{3,15}", "No", "Package ID", "Flight ID", "Location");
                                            Console.WriteLine("------------------------------------------------------------------------");

                                            for (int i = 0; i < Result.Count(); i++)
                                            {
                                                Package p = Result[i];
                                                Console.WriteLine("{0,5}|{1,15}|{2,15}|{3,15}", i + 1, p.PackageId, p.FlightId, p.Location);
                                                Console.WriteLine("------------------------------------------------------------------------");
                                            }
                                            break;
                                        }
                                    case 6:
                                        {
                                            Console.WriteLine("-----SEARCH HOTELS-----");
                                            Console.WriteLine("Notice: Leave empty to find all");
                                            Console.Write("Hotel name:");
                                            string name = Console.ReadLine();
                                            Console.Write("Location  :");
                                            string location = Console.ReadLine();
                                            var Result = ARSDatabase.Hotel.Where(s => s.Name.Contains(name) || string.IsNullOrEmpty(name))
                                                .Where(s => s.Location.Contains(location) || string.IsNullOrEmpty(name)).Select(s => s).ToList();

                                            Console.WriteLine("-----HOTELS SEARCH RESULT-----");
                                            Console.WriteLine("{0,5}|{1,15}|{2,50}", "No", "Name", "Location");
                                            Console.WriteLine("------------------------------------------------------------------------");

                                            for (int i = 0; i < Result.Count(); i++)
                                            {
                                                Hotel h = Result[i];
                                                Console.WriteLine("{0,5}|{1,15}|{2,50}", i + 1, h.Name, h.Location);
                                                Console.WriteLine("------------------------------------------------------------------------");
                                            }
                                            break;
                                        }
                                    case 7:
                                        {
                                            Console.WriteLine("-----BOOK FLIGHT-----");
                                            Console.WriteLine("Notice: You can search flight before booking!");
                                            Console.Write("Flight ID: ");
                                            string flight = Console.ReadLine();

                                            var flightFind = ARSDatabase.Flights.Where(s => s.FlightNumber.Equals(flight, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                                            if (flightFind == null)
                                            {
                                                Console.WriteLine("Flight not existed! You can search flight before booking");
                                                break;
                                            }
                                            Console.Write("Seat: ");
                                            string seat = Console.ReadLine();
                                            FlightBooked booked = new FlightBooked()
                                            {
                                                FlightID = flight.ToUpper(),
                                                ID = new Random(10000).Next().ToString(),
                                                Seat = seat,
                                                UserID = cus.Email
                                            };
                                            ARSDatabase.BookedFlights.Add(booked);
                                            Console.WriteLine("Flight was booked! Thanks for chose us.");
                                            break;
                                        }
                                    case 8:
                                        {
                                            Console.WriteLine("-----BOOK PACKAGE-----");
                                            Console.WriteLine("Notice: You can search flight before booking!");
                                            Console.Write("Flight ID: ");
                                            string flight = Console.ReadLine();

                                            var flightFind = ARSDatabase.Flights.Where(s => s.FlightNumber.Equals(flight, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                                            if (flightFind == null)
                                            {
                                                Console.WriteLine("Flight not existed! You can search flight before booking");
                                                break;
                                            }
                                            PackageBooked booked = new PackageBooked()
                                            {
                                                ID = new Random(10000).Next().ToString(),
                                                FlightID = flight.ToUpper(),
                                                UserID = cus.Email
                                            };
                                            ARSDatabase.BookedPackagese.Add(booked);
                                            Console.WriteLine("Package was booked! Thanks for chose us.");
                                            break;
                                        }
                                    case 9:
                                        {
                                            Console.WriteLine("-----BOOK HOTEL-----");
                                            Console.WriteLine("Notice: You can search hotel before booking!");
                                            Console.Write("Hotel ID: ");
                                            string id = Console.ReadLine();

                                            var hotel = ARSDatabase.Hotel.Where(s => s.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                                            if (hotel == null)
                                            {
                                                Console.WriteLine("Hotel not existed! You can search hotel before booking");
                                                break;
                                            }
                                            Console.Write("From date (dd/mm/yyyy): ");
                                            string from = Console.ReadLine();
                                            Console.Write("To date (dd/mm/yyyy): ");
                                            string to = Console.ReadLine();
                                            HotelBooked booked = new HotelBooked()
                                            {
                                                ID = new Random(10000).Next().ToString(),
                                                HotelID = id.ToUpper(),
                                                UserID = cus.Email,
                                                FromDate = from,
                                                Todate = to
                                            };
                                            ARSDatabase.BookedHotels.Add(booked);
                                            Console.WriteLine("Hotel was booked! Thanks for chose us.");
                                            break;
                                        }
                                }
                            } while (menu != 10);

                            break;
                        }
                    case 2:
                        {
                            Customer cus = new Customer();
                            Console.WriteLine("-----REGISTER-----");
                            Console.Write("Email   : ");
                            cus.Email = Console.ReadLine();
                            Console.Write("Password: ");
                            cus.Password = Console.ReadLine();
                            Console.Write("Name    : ");
                            cus.Name = Console.ReadLine();
                            Console.Write("SSN: ");
                            cus.SSN = Console.ReadLine();
                            Console.Write("Address: ");
                            cus.Address = Console.ReadLine();
                            Console.Write("Phone: ");
                            cus.Phone = Console.ReadLine();
                            ARSDatabase.customers.Add(cus);
                            Console.WriteLine("Add customer sucessful!");

                            break;
                        }
                    case 3:
                        {
                            Administrator admin = new Administrator();
                            Console.WriteLine("-----ADMIN LOGIN-----");
                            Console.Write("Email   : ");
                            admin.Email = Console.ReadLine();
                            Console.Write("Password: ");
                            admin.Password = Console.ReadLine();
                            UserLogged = admin.Login(admin.Email, admin.Password);
                            if (UserLogged == null)
                            {
                                Console.WriteLine("Log in fail!");
                                break;
                            }

                            do
                            {
                                menu = AdminMenu();
                                switch (menu)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("-----FLIGHT LIST-----");
                                            Console.WriteLine("{0,5}|{1,12}|{2,15}|{3,30}", "No", "Flight ID", "Source", "Destination");
                                            Console.WriteLine("------------------------------------------------------------------------");
                                            for (int i = 0; i < ARSDatabase.Flights.Count; i++)
                                            {
                                                Flight f = ARSDatabase.Flights[i];
                                                Console.WriteLine("{0,5}|{1,12}|{2,15}|{3,30}", i + 1, f.FlightNumber, f.Destination, f.Source);
                                                Console.WriteLine("------------------------------------------------------------------------");
                                            }
                                            break;
                                        }

                                    case 2:
                                        {
                                            Flight flight = new Flight();
                                            Console.WriteLine("-----ADD FLIGHT-----");
                                            Console.Write("Flight number: ");
                                            flight.FlightNumber = Console.ReadLine();
                                            Console.Write("Flight Source: ");
                                            flight.Source = Console.ReadLine();
                                            Console.Write("Destination: ");
                                            flight.Destination = Console.ReadLine();

                                            ARSDatabase.Flights.Add(flight);
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("-----DELETE FLIGHT-----");
                                            Console.Write("Flight number: ");
                                            string flightNumber = Console.ReadLine();
                                            var flight = ARSDatabase.Flights.Where(s => s.FlightNumber.Equals(flightNumber, StringComparison.CurrentCultureIgnoreCase)).SingleOrDefault();
                                            if (flight == null)
                                            {
                                                Console.WriteLine("Flight not existed!");
                                            }
                                            else
                                            {
                                                ARSDatabase.Flights.Remove(flight);
                                                Console.WriteLine("Flight deleted successful!");
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("-----PACKAGESE LIST-----");
                                            Console.WriteLine("{0,5}|{1,15}|{2,15}|{3,15}", "No", "Package ID", "Flight ID", "Location");
                                            Console.WriteLine("------------------------------------------------------------------------");
                                            for (int i = 0; i < ARSDatabase.Pakcages.Count; i++)
                                            {
                                                Package p = ARSDatabase.Pakcages[i];
                                                Console.WriteLine("{0,5}|{1,15}|{2,15}|{3,15}", i + 1, p.PackageId, p.FlightId, p.Location);
                                                Console.WriteLine("------------------------------------------------------------------------");

                                            }
                                            break;
                                        }
                                    case 5:
                                        {
                                            Package package = new Package();
                                            Console.WriteLine("-----ADD PACKAGE-----");
                                            Console.Write("Flight number: ");
                                            package.FlightId = Console.ReadLine();
                                            var flight = ARSDatabase.Flights.Where(s => s.FlightNumber.Equals(package.FlightId, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                                            if (flight == null)
                                            {
                                                Console.WriteLine("Flight not existed!");
                                                break;
                                            }
                                            Console.Write("Location: ");
                                            package.Location = Console.ReadLine();
                                            Console.Write("PackageId: ");
                                            package.PackageId = Console.ReadLine();

                                            ARSDatabase.Pakcages.Add(package);
                                            break;
                                        }
                                    case 6:
                                        {
                                            Console.WriteLine("-----DELETE PACKAGE-----");
                                            Console.Write("package ID: ");
                                            string packageId = Console.ReadLine();
                                            var package = ARSDatabase.Pakcages.Where(s => s.PackageId.Equals(packageId, StringComparison.CurrentCultureIgnoreCase)).SingleOrDefault();
                                            if (package == null)
                                            {
                                                Console.WriteLine("Package not existed!");
                                            }
                                            else
                                            {
                                                ARSDatabase.Pakcages.Remove(package);
                                                Console.WriteLine("Package deleted successful!");
                                            }
                                            break;
                                        }
                                    case 7:
                                        {
                                            Console.WriteLine("-----HOTELS LIST-----");
                                            Console.WriteLine("{0,5}|{1,15}|{2,50}", "No", "Name", "Location");
                                            Console.WriteLine("------------------------------------------------------------------------");
                                            for (int i = 0; i < ARSDatabase.Hotel.Count; i++)
                                            {
                                                Hotel h = ARSDatabase.Hotel[i];
                                                Console.WriteLine("{0,5}|{1,15}|{2,50}", i + 1, h.Name, h.Location);
                                                Console.WriteLine("------------------------------------------------------------------------");

                                            }
                                            break;
                                        }
                                    case 8:
                                        {
                                            Hotel hotel = new Hotel();
                                            Console.WriteLine("-----ADD HOTEL-----");
                                            Console.Write("Hotel Id: ");
                                            hotel.Id = Console.ReadLine();
                                            Console.Write("Name: ");
                                            hotel.Name = Console.ReadLine();
                                            Console.Write("Location: ");
                                            hotel.Location = Console.ReadLine();

                                            ARSDatabase.Hotel.Add(hotel);
                                            break;
                                        }
                                    case 9:
                                        {
                                            Console.WriteLine("-----DELETE HOTEL-----");
                                            Console.Write("Hotel ID: ");
                                            string hotelId = Console.ReadLine();
                                            var hotel = ARSDatabase.Hotel.Where(s => s.Id.Equals(hotelId, StringComparison.CurrentCultureIgnoreCase)).SingleOrDefault();
                                            if (hotel == null)
                                            {
                                                Console.WriteLine("Hotel not existed!");
                                            }
                                            else
                                            {
                                                ARSDatabase.Hotel.Remove(hotel);
                                                Console.WriteLine("Hotel deleted successful!");
                                            }
                                            break;
                                        }
                                }
                            } while (menu != 10);
                            break;
                        }
                    case 4:
                        {
                            isRunning = false;
                            break;
                        }
                }
            } while (isRunning);
            Console.WriteLine("have nice day!");
        }

        public static int GuessMenu()
        {
            int Menu_chose = 0;
            Console.WriteLine("-----MENU-----");
            Console.WriteLine("1: Log in");
            Console.WriteLine("2: Register");
            Console.WriteLine("3: Admin login");
            Console.WriteLine("4: Program Exit");

            do
            {
                char input = Console.ReadLine()[0];

                if (!Char.IsDigit(input))
                {
                    continue;
                }
                Menu_chose = int.Parse(input.ToString());

            } while (Menu_chose <= 0 || Menu_chose > 4);
            return Menu_chose;
        }

        public static int CustommerMenu()
        {
            int Menu_chose = 0;
            Console.WriteLine("-----MENU-----");
            Console.WriteLine("1: Booked flights");
            Console.WriteLine("2: Booked packagese");
            Console.WriteLine("3: Booked hotels");
            Console.WriteLine("4: Search flight");
            Console.WriteLine("5: Seach package");
            Console.WriteLine("6: Seach hotel");
            Console.WriteLine("7: Book flight");
            Console.WriteLine("8: Book package");
            Console.WriteLine("9: Book hotel");
            Console.WriteLine("10: Sigout");

            do
            {
                string input = Console.ReadLine();

                for (int i = 0; i < input.Length; i++)
                {
                    if (!Char.IsDigit(input[i]))
                    {
                        continue;
                    }
                }

                Menu_chose = int.Parse(input.ToString());

            } while (Menu_chose <= 0 || Menu_chose > 10);
            return Menu_chose;
        }

        public static int AdminMenu()
        {
            int Menu_chose = 0;
            Console.WriteLine("-----MENU-----");
            Console.WriteLine("1: Flights list");
            Console.WriteLine("2: Add flight");
            Console.WriteLine("3: Delete flight");
            Console.WriteLine("4: Package list");
            Console.WriteLine("5: Add palkage");
            Console.WriteLine("6: Delete palkage");
            Console.WriteLine("7: Hotel list");
            Console.WriteLine("8: Add Hotel");
            Console.WriteLine("9: Delete Hotel");
            Console.WriteLine("10: Sigout");

            do
            {
                string input = Console.ReadLine();

                for (int i = 0; i < input.Length; i++)
                {
                    if (!Char.IsDigit(input[i]))
                    {
                        continue;
                    }
                }

                Menu_chose = int.Parse(input.ToString());

            } while (Menu_chose <= 0 || Menu_chose > 10);
            return Menu_chose;
        }

        public static string Message(int messageCode)
        {
            switch (messageCode)
            {
                case 1: return "Success!";
                case 10: return "login fail!";
            }

            return "No message!";
        }

        public static void MessageShow(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
