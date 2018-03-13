using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline2
{
    public class Airport
    {
        public static int a = 0 ;
        public int id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public Flight flight { get; set; }
     
        public Airport()
        {
            id = a;
            a++;
            name = "null";
            city = "null";
            flight = new Flight();
        }
        public Airport(string name, string city )
        {
            this.id = a;
            a++;
            this.name = name;
            this.city = city;
        }
        public void AddFlight( Flight flight)
        {
            this.flight = flight;
        }
        public static Airport Copy(Airport airport)
        {
            Airport r = new Airport(airport.name, airport.city);
            r.id = airport.id;
            r.flight = airport.flight;
            return r;

        }
        public override string ToString()
        {
            return name;
        }
    }
}
