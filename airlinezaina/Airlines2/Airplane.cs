using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline2
{
    public class Airplane
    {
        public static int a = 0;
        public  int id { get; set; }
        public int amountOfSeats { get; set; }
       public Flight flight { get; set; }
        public Airline airline { get; set; }

        public Airplane()
        {
            id = a;
            a++;
            amountOfSeats = 0;
        }
        public Airplane(int amountOfSeats ,Airline airline)
        {
            this.id = a;
            a++;
            this.amountOfSeats = amountOfSeats;

            this.airline = airline;
        }
        public void AddFlight(Flight flight)
        {
            this.flight = flight;
        }
        public static Airplane Copy(Airplane airplane)
        {
            Airplane r = new Airplane(airplane.amountOfSeats, airplane.airline);
            r.flight = airplane.flight;
            r.id = airplane.id;
            return r;
        }
        public override string ToString()
        {
            return id.ToString();
        }
    }
}
