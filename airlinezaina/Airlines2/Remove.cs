using Airline2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines2
{
    // the delete button
    class SetClassRemove
    {
        public void SetStrategyForm( object y)
        {
            string x = y.GetType().Name;

            if (x == "Airline")  AirlineRemove(y);
            else
           if (x == "Airplane") AirplaneRemove(y);
            else
           if (x == "Booking Agent")  BookingAgentRemove(y);
            else
           if (x == "Airline Employee")  AirlineEmployeeRemove(y);
            else
           if (x == "Airport")  AirportRemove(y);
            else
           if (x == "Flight")  FlightRemove(y);
            else
           if (x == "Customer")  CustomerRemove(y);
            else
           if (x == "Ticket") TicketRemove(y);
        }

        private void FlightRemove(object x)
        {
            Population.Instance.flights.Remove((Flight)x);
        }

        private void AirlineRemove(object x)
        {
            Population.Instance.airlines.Remove((Airline)x);

        }

        private void CustomerRemove(object x)
        {
            Population.Instance.customers.Remove((Customer)x);
        }

        private void AirportRemove(object x)
        {
            Population.Instance.airports.Remove((Airport)x);
        }

        private void AirlineEmployeeRemove(object x)
        {
            Population.Instance.airlineEmployees.Remove((AirlineEmployee)x);
        }

        private void BookingAgentRemove(object x)
        {
            Population.Instance.bookingagents.Remove((BookingAgent)x);
        }

        private void AirplaneRemove(object x)
        {
            Population.Instance.airplanes.Remove((Airplane)x);
        }

        private void TicketRemove(object x)
        {
            Population.Instance.tickets.Remove((Ticket)x);
        }
    }
}
