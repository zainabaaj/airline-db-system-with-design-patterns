using Airline2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines2
{
    // in population class all data of all classes are saved and are saved and bound
     class Population
    {
        public List<Airline> airlines { get; set; }
        public List<Airport> airports { get; set; }  
        public List<Airplane> airplanes { get; set; }  
        public List<Ticket> tickets { get; set; }
        public List<Customer> customers { get; set; }
        public List<AirlineEmployee> airlineEmployees { get; set; }
        public List<BookingAgent> bookingagents { get; set; }
        public List<Flight> flights { get; set; }

        private static Population _instance;

        public static Population Instance
        {

            get
            {
                // singleton pattern used for creating only one instance of a class
                if (_instance == null)
                {
                    _instance = new Population();
                    // once the insatce is created all the intial object will be creates with it 
                    _instance.CreatePopulation();

                }
                
                return _instance;
            }


        }
        public void CreatePopulation()
        {
            #region customer
            Customer ahmad = new Customer("Ahmet Baaj", "ahmadbaaj@gmail.com", "0535417086", "A905123", new DateTime(2018, 01, 01), "Syria", new DateTime(2005, 10, 13));
            Customer zaina = new Customer("Zaina Baaj", "zainabaaj@gmail.com", "0535417085", "A905122", new DateTime(2018, 01, 01), "Syria", new DateTime(1995, 10, 13));
            customers = new List<Customer>();
            customers.Add(ahmad);
            customers.Add(zaina);
            #endregion

            #region booking agent
            BookingAgent yalovatravel = new BookingAgent("Yalova Travel Agency");
            BookingAgent bursatravel = new BookingAgent("Bursa Travel Agency");
            bookingagents = new List<BookingAgent>();
            bookingagents.Add(yalovatravel);
            bookingagents.Add(bursatravel);
            #endregion

          

            #region airline
            airlines = new List<Airline>();
            Airline THY = new Airline("THY");
            Airline Pegasus = new Airline("Pegasus");
            Airline Sunexpress = new Airline("Sun Express");
            airlines.Add(THY);
            airlines.Add(Pegasus);
            airlines.Add(Sunexpress);
            airlines.Remove(Pegasus);
            airlines.Add(Pegasus);
            #endregion
            #region airplanes
            airplanes = new List<Airplane>();
            Airplane thy_boeing01 = new Airplane(270, airlines[0]);
            Airplane sunexpress_boeing01 = new Airplane(270, airlines[2]);
            airplanes.Add(thy_boeing01);
            airplanes.Add(sunexpress_boeing01);
            //binding the airplane with its airline
            thy_boeing01.airline.AddAirplane(thy_boeing01);
            sunexpress_boeing01.airline.AddAirplane(sunexpress_boeing01);
            #endregion
            #region airline employee
            airlineEmployees = new List<AirlineEmployee>();
            AirlineEmployee leonardo = new AirlineEmployee("Leonardo", "De caprio",airlines[0]);
            AirlineEmployee tom = new AirlineEmployee("Tom", "Hanks",airlines[2]);
            airlineEmployees.Add(leonardo);
            airlineEmployees.Add(tom);
            //binding airline with employee
            leonardo.airline.AddAirlineEmployee(leonardo);
            tom.airline.AddAirlineEmployee(tom);

            #endregion
            #region airport
            airports = new List<Airport>();
            Airport ataturk = new Airport("Atatürk", "İstanbul");
            Airport sabiha = new Airport("Sabiha Gökçen", "İstanbul");
            Airport erhac = new Airport("Erhaç", "Malatya");
            airports.Add(ataturk);
            airports.Add(sabiha);
            airports.Add(erhac);
            #endregion

            
            #region flights
            flights = new List<Flight>();
            List<Airport> a1 = new List<Airport>();
            a1.Add(ataturk);
            a1.Add(erhac);
            List<Airport> a2 = new List<Airport>();
            a2.Add(ataturk);
            a2.Add(sabiha);
            Flight f1 = new Flight(new DateTime(2017, 06, 06, 06, 00, 00), new DateTime(2017, 06, 06, 08, 00, 00), 150,THY,thy_boeing01, a1 );
            Flight f2 = new Flight(new DateTime(2017, 06, 06, 06, 00, 00), new DateTime(2017, 06, 06, 08, 00, 00), 150,Sunexpress,sunexpress_boeing01, a2);
            f1.airline.AddFlight(f1);
            f2.airline.AddFlight(f2);
            f1.airplane.AddFlight(f1);
            f2.airplane.AddFlight(f2);
            //binding airports with flights
            f1.airports[0].AddFlight(f1);
            f1.airports[1].AddFlight(f1);
            f2.airports[0].AddFlight(f2);
            f2.airports[1].AddFlight(f2);


            flights.Add(f1);
            flights.Add(f2);
            
            #endregion

            #region tickets
            tickets = new List<Ticket>();
            Ticket ahmad_sunexress = new Ticket(ahmad, yalovatravel, f2, Sunexpress);
            // binding the ticket with its airline , flight , booking agent and customer
            ahmad_sunexress.airline.AddTicket(ahmad_sunexress);
            ahmad_sunexress.flight.AddTickets(ahmad_sunexress);
            ahmad_sunexress.bookingAgent.Addticket(ahmad_sunexress);
            ahmad_sunexress.customer.AddTicket(ahmad_sunexress);
            tickets.Add(ahmad_sunexress);
            #endregion




        }
    }
}
