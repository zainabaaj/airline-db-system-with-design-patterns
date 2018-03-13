using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline2
{
     /* the classes are designed according to the database datagram
      * connections depends on relationships between tables
      * * one -  one means to create an instance in each table for the other one
      * * one - many meant to create a list in the first one(for many objects from the other table) and an instance in the second one
      * * many - one create an instance in the first one and a list in the second one
      * * many - many create list in each table for the other one ( we dont have this relation in this project)
      */

    public class Airline
    {
        public static int a = 0;
        public  int id { get; set; }
        public string name { get; set; }
        public List<AirlineEmployee> employees { get; set; }
        public List<Airplane> airplanes { get; set; }
        public List<Ticket> tickets { get; set; }
        public List<Flight> flights { get; set; }

        public Airline()
        {
            id = a;
            name = "null";
            a++;
            employees = new List<AirlineEmployee>();
            airplanes = new List<Airplane>();
            tickets = new List<Ticket>();
            flights = new List<Flight>();
        }
        // we only need a name and an id for an airline others will be added after being created in there classes using 
        // adding methods( addairplane, addairlineEmployee... etc)
        public Airline(string name)
        {
            this.id = a;
            a++;
            this.name = name;
            this.employees = new List<AirlineEmployee>();
            this.airplanes = new List<Airplane>();
            tickets = new List<Ticket>();
            flights = new List<Flight>();

        }
        public void AddAirplane(Airplane airplane)
        {
            airplanes.Add(airplane);
        }
        public void AddAirlineEmployee(AirlineEmployee airlineEmployee)
        {
            employees.Add(airlineEmployee);
        }
        public void AddFlight(Flight flight)
        {
            flights.Add(flight);
        }
        
        public void AddTicket(Ticket ticket)
        {
            tickets.Add(ticket);
        }
        // copy method is used for having a copy of an instance to use it in 
        //command class( where we will redo and undo an update for instances)
        public static Airline Copy(Airline airline)
        {
            Airline r = new Airline(airline.name);
            r.id = airline.id;
            r.employees = new List<AirlineEmployee>(airline.employees);
            r.airplanes = new List<Airplane>(airline.airplanes);
            r.flights = new List<Flight>(airline.flights);
            r.tickets = new List<Ticket>(airline.tickets);
            return r;
            
        }
        public override string ToString()
        {
            return name;
        }
    }
}
