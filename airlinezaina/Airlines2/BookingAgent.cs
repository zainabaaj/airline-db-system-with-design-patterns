using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline2
{
    public class BookingAgent
    {
        public static int a=0;
        public int id { get;  set; }
        public string name { get; set; }
        public Ticket ticket { get; set; }
        public BookingAgent()
        {
            id = a;
            a++;
            name = "null";
            ticket = new Ticket();
        }
        public BookingAgent(string name)
        {
            this.id = a;
            a++;
            this.name = name;
        }
        public void Addticket(Ticket ticket)
        {
            this.ticket = ticket;
        }
        public override string ToString()
        {
            return name; 
        }

        public static BookingAgent Copy(BookingAgent b)
        {
            BookingAgent r = new BookingAgent(b.name);
            r.id = b.id;
            return r;
        }

    }
}
