using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline2
{
    public class Ticket
    {
        public static int a =0 ;

        public  int id { get; set; }
        public Airline airline { get; set; }
        public Customer customer { get; set; }
        public BookingAgent bookingAgent { get; set; }
        public Flight flight { get; set; }
   
        public Ticket()
        {
            id = a;
            a++;
            airline = new Airline();
            customer = new Customer();
            bookingAgent = new BookingAgent();
            flight = new Flight();

        }
        
        public Ticket(Customer customer, BookingAgent bookingAgent ,
            Flight flight, Airline airline)
        {
            this.id = a;
            a++;
            this.customer = customer;
            this.bookingAgent= bookingAgent;
            this.flight = flight;
            this.airline = airline;
        }

        public static Ticket Copy(Ticket t)
        {
           Ticket r=  new Ticket(t.customer, t.bookingAgent, t.flight, t.airline);
            r.id = t.id;

            return r;

        }
    }
}
