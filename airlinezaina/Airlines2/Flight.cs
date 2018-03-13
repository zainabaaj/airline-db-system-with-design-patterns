using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline2
{
    public class Flight
    {
        public static int a =0;
        public int id { get;  set; }
        public double price { get; set; }
        public DateTime departureTime { get; set; }
        public DateTime arrivalTime { get; set; }
        public List<Ticket> tickets { get; set; }
        public List<Airport> airports { get; set; }
        
        public Airline airline { get; set; }
        
        public Airplane airplane { get; set; }
       

        public Flight()
        {
            id = a;
            a++;
            tickets = new List<Ticket>();
            airports = new List<Airport>();
            departureTime = DateTime.Now;
            arrivalTime = DateTime.Now;
            price = 0;
            airline = new Airline();
            airplane = new Airplane();

        }
        public Flight(DateTime departureTime, DateTime arrivalTime, double price,Airline airline ,Airplane airplane, List<Airport> airports)
        {
            this.id= a;
            a++;
            this.departureTime = departureTime;
            this.arrivalTime = arrivalTime;
            this.airplane = airplane;
            this.airports = new List<Airport>();
            this.airports.AddRange(airports);
            this.price = price;
            this.airline = airline;
            this.tickets = new List<Ticket>();
            

        }
       
         
        public void AddTickets(Ticket ticket)
        {
            tickets.Add(ticket);
        }
         
        public void AddAirports(Airport airport)
        {
            airports.Add(airport);

        }
        public override string ToString()
        {
            return airports[0].ToString() + "-" + airports[1].ToString();
        }

        public static Flight Copy(Flight f)
        {
            Flight r = new Flight(f.departureTime, f.arrivalTime, f.price, f.airline, f.airplane, f.airports);
            r.id = f.id;
            return r;
        }
    }
}
