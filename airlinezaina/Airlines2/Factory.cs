using Airline2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airlines2
{
    /*factory pattern is used for indirect accessing to all the classes that have the same purpose of creating a list 
     * factoryclass will decide which class's instance will be added to the listview according to what's been selected from combobox
     *factory -> airlineproduct
     *        -> airplaneproduct
     *        -> ... etc
     */
    public abstract class Iproduct 
    {
        // i product where the list is definded and the instances are created 
        public ListView list = new ListView();
        // this method will define the list items (class object)depending on the class 
        public abstract ListView SelectList();
        public Airline airline;
        public AirlineEmployee airlineEmployee;
        public Airplane airplane;
        public Airport airport;
        public BookingAgent bookingAgent;
        public Customer customer;
        public Flight flight;
        public Ticket ticket;
        public ListView createList()
        {
            ListView listView1 = new ListView();
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new System.Drawing.Point(13, 13);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(235, 210);
            listView1.TabIndex = 0;
            listView1.Sorting = SortOrder.Ascending;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.Details;
            listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            return listView1;
        }
    }
    public class AirlineProduct : Iproduct
    {
           
       public AirlineProduct()
        {
            list = SelectList();
        }
        
        public override ListView SelectList()
        {
            ListView listView1 = new ListView();

            listView1 = createList();
            //take the objects from population class
            var a = Population.Instance.airlines;

            listView1.Columns.Add("id");
            listView1.Columns.Add("name");
            listView1.Columns.Add("employees");
            listView1.Columns.Add("airplanes");
            listView1.Columns.Add("tickets");
            listView1.Columns.Add("flight");
            foreach (var item in a)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = item.id.ToString();
                lvi.SubItems.Add(item.name);
                lvi.SubItems.Add(item.employees.Count.ToString());
                lvi.SubItems.Add(item.airplanes.Count.ToString());
                lvi.SubItems.Add(item.tickets.Count.ToString());
                lvi.SubItems.Add(item.flights.Count.ToString());
                //to save the object type
                lvi.Tag = item;
                listView1.Items.Add(lvi);
            }

            return listView1;
        }
    }
    public class AirlineEmployeeProduct : Iproduct
    {

        public AirlineEmployeeProduct()
        {
            list = SelectList();
        }
        public override ListView SelectList()
        {
            ListView listView1 = new ListView();

            listView1 = createList();
            var a = Population.Instance.airlineEmployees ;

            listView1.Columns.Add("id");
            listView1.Columns.Add("first name");
            listView1.Columns.Add("last name");
            listView1.Columns.Add("airline");

            foreach (var item in a)
            {
                
                ListViewItem lvi = new ListViewItem();

                lvi.Text = item.id.ToString();
                lvi.SubItems.Add(item.firstName);
                lvi.SubItems.Add(item.lastName);
                lvi.SubItems.Add(item.airline.name);
                lvi.Tag = item;
                listView1.Items.Add(lvi);
            }

            return listView1;
        }
    }
    public class AirplaneProduct : Iproduct
    {
        public AirplaneProduct()
        {
            list = SelectList();
        }
        public override ListView SelectList()
        {
            ListView listView1 = new ListView();

            listView1 = createList();
            var a = Population.Instance.airplanes;

            listView1.Columns.Add("id");
            listView1.Columns.Add("amount of seats");
            listView1.Columns.Add("flight");
            listView1.Columns.Add("airline");

            foreach (var item in a)
            {
            

                ListViewItem lvi = new ListViewItem();

                lvi.Text = item.id.ToString();
                lvi.SubItems.Add(item.amountOfSeats.ToString());
                if (item.flight != null) lvi.SubItems.Add(item.flight.ToString());
                else lvi.SubItems.Add("");
                lvi.SubItems.Add(item.airline.name);
                lvi.Tag = item;
                listView1.Items.Add(lvi);
            }

            return listView1;
        }
    }
    public class AirportProduct : Iproduct
    {
        public AirportProduct()
        {
            list = SelectList();
        }
        public override ListView SelectList()
        {
            ListView listView1 = new ListView();

            listView1 = createList();
            var a = Population.Instance.airports;

            listView1.Columns.Add("id");
            listView1.Columns.Add("name");
            listView1.Columns.Add("city");
            listView1.Columns.Add("flight");

            foreach (var item in a)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = item.id.ToString();
                lvi.SubItems.Add(item.name.ToString());
                lvi.SubItems.Add(item.city.ToString());
                if(item.flight != null) lvi.SubItems.Add(item.flight.ToString());
                else lvi.SubItems.Add("");
                
                lvi.Tag = item;

                listView1.Items.Add(lvi);
            }

            return listView1;
        }
    }
    public class BookingAgentProduct : Iproduct
    {
        public BookingAgentProduct()
        {
            list = SelectList();
        }
        public override ListView SelectList()
        {
            ListView listView1 = new ListView();

            listView1 = createList();
            var a = Population.Instance.bookingagents;

            listView1.Columns.Add("id");
            listView1.Columns.Add("name");
            listView1.Columns.Add("ticket");

            foreach (var item in a)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = item.id.ToString();
                lvi.SubItems.Add(item.name.ToString());
                if (item.ticket == null) lvi.SubItems.Add("");
                else lvi.SubItems.Add(item.ticket.id.ToString());
                lvi.Tag = item;
                listView1.Items.Add(lvi);
            }

            return listView1;
        }
    }
    public class CustomerProduct : Iproduct
    {
        public CustomerProduct()
        {
            list = SelectList();
        }
        public override ListView SelectList()
        {
            ListView listView1 = new ListView();

            listView1 = createList();
            var a = Population.Instance.customers;

            listView1.Columns.Add("id");
            listView1.Columns.Add("name");
            listView1.Columns.Add("date of birth");
            listView1.Columns.Add("email");
            listView1.Columns.Add("phone number");
            listView1.Columns.Add("passport number");
            listView1.Columns.Add("passport expiration");
            listView1.Columns.Add("passport country");
            listView1.Columns.Add("ticket");

            foreach (var item in a)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = item.id.ToString();
                lvi.SubItems.Add(item.name);
                lvi.SubItems.Add(item.dateOfBirth.ToString());
                lvi.SubItems.Add(item.email);
                lvi.SubItems.Add(item.phoneNumber);
                lvi.SubItems.Add(item.passportNumber);
                lvi.SubItems.Add(item.passportExpiration.ToString());
                lvi.SubItems.Add(item.passportCountry);
                if(item.ticket == null) { lvi.SubItems.Add(""); }
                else lvi.SubItems.Add(item.ticket.id.ToString());
                lvi.Tag = item;
                listView1.Items.Add(lvi);
            }

            return listView1;
        }
    }
    public class FlightProduct : Iproduct
    {
        public FlightProduct()
        {
            list = SelectList();
        }
        public override ListView SelectList()
        {
            ListView listView1 = new ListView();

            listView1 = createList();
            var a = Population.Instance.flights;

            listView1.Columns.Add("id");
            listView1.Columns.Add("tikcets count");
            listView1.Columns.Add("Airports");
            listView1.Columns.Add("departure time");
            listView1.Columns.Add("Airports");
            listView1.Columns.Add("arrival time");
            listView1.Columns.Add("price");

            foreach (var item in a)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = item.id.ToString();
                lvi.SubItems.Add(item.tickets.Count.ToString());
                lvi.SubItems.Add(item.airports[0].name);
                lvi.SubItems.Add(item.departureTime.ToString());
                lvi.SubItems.Add(item.airports[1].name);
                lvi.SubItems.Add(item.arrivalTime.ToString());
                lvi.SubItems.Add(item.price.ToString());
                lvi.Tag = item;
                listView1.Items.Add(lvi);
            }

            return listView1;
        }
    }
    public class TicketProduct : Iproduct
    {
        public TicketProduct()
        {
            list = SelectList();
        }
        public override ListView SelectList()
        {
            ListView listView1 = new ListView();

            listView1 = createList();
            var a = Population.Instance.tickets;

            listView1.Columns.Add("id");
            listView1.Columns.Add("customer");
            listView1.Columns.Add("booking agent");
            listView1.Columns.Add("flight");

            foreach (var item in a)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = item.id.ToString();
                lvi.SubItems.Add(item.customer.ToString());
                lvi.SubItems.Add(item.bookingAgent.ToString());
                lvi.SubItems.Add(item.flight.ToString());
                lvi.Tag = item;
                listView1.Items.Add(lvi);
            }

            return listView1;
        }
    }
    interface Ifactory
    {
        Iproduct Getproduct(string cb);
    }
    public class Factory : Ifactory
    {
        public Iproduct Getproduct(string cb)
        {
            // selecting the class needed
            if (cb.Contains("Airline Employee")) { return new AirlineEmployeeProduct(); }
            else
            if (cb.Contains("Airline")) { return new AirlineProduct(); }
            else
            if (cb.Contains("Airplane")) { return new AirplaneProduct(); }
            else
            if (cb.Contains("Airport")) { return new AirportProduct(); }
            else
           if (cb.Contains("Booking Agent")) { return new BookingAgentProduct(); }
            else
            if (cb.Contains("Customer")) { return new CustomerProduct(); }
            else
            if (cb.Contains("Flight")) { return new FlightProduct(); }
            else
            if (cb.Contains("Ticket")) { return new TicketProduct(); }
            else return new AirlineProduct();
        }
    }
}
