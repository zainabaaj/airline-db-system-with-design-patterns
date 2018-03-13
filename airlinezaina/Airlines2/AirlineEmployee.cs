using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline2
{
    public class AirlineEmployee
    {
        public static int a = 0;
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Airline airline { get; set; }
      
        public AirlineEmployee()
        {
            id = a;
            a++;
            firstName = "null";
            lastName = "null";
            Airline airline = new Airline();
        }
        public AirlineEmployee(string firstName, string lastName,Airline airline)
        {
            this.id = a;
            a++;
           
            this.firstName = firstName;
            this.lastName = lastName;
            this.airline = airline;
        }
        public static AirlineEmployee Copy(AirlineEmployee airlineEmployee)
        {
            AirlineEmployee r = new AirlineEmployee(airlineEmployee.firstName,airlineEmployee.lastName,airlineEmployee.airline);
            r.id = airlineEmployee.id;

            return r;
            
        }

    }
}
