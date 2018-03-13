using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline2
{
    public class Customer
    {
        public static int a = 0;
        public int id { get;  set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string passportNumber { get; set; }
        public DateTime passportExpiration { get; set; }
        public string passportCountry { get; set; }
        public DateTime dateOfBirth { get; set; }
        public Ticket ticket { get; set; }
        public Customer()
        {
            id = a;
            a++;
            name = "null";
            email = "null";
            phoneNumber = "null";
            passportNumber = "null";
            passportExpiration = DateTime.Now;
            passportCountry = "null";
            dateOfBirth = DateTime.Now;
            ticket = new Ticket();
            
        }
        public Customer( string name, string email, string phoneNumber,string passportNumber, DateTime passportExpiration, string passportCountry, DateTime dateOfBirth  )
        {
            this.id = a;
            a++;
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.passportNumber = passportNumber;
            this.passportExpiration = passportExpiration;
            this.passportCountry = passportCountry;
            this.dateOfBirth = dateOfBirth;
        }
        public void AddTicket(Ticket ticket)
        {
            this.ticket = ticket;
        }

        public override string ToString()
        {
            return name;
        }

        public static Customer Copy(Customer c)
        {
            Customer r = new Customer(c.name, c.email, c.phoneNumber, c.passportNumber, c.passportExpiration, c.passportCountry, c.dateOfBirth);
            r.id = c.id;
            return r;
        }
    }
}
