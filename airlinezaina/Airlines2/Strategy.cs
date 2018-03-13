using Airline2;
using Airlines2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airlines2
{
    // this class will create the form needed for each class when ____ ADD BUTTON _____ is clicked 
    // the difference between strategy and factory in this example is that in factory method all we need is to list objects
    // but in strategy pattern in this example we are creating different forms and different methods for each class
    // start with create class form then ticketform,airlineform .. etc.

    abstract class Strategy
    {
        //method for the buttons , comboboxes , text boxes and lables needed
       public abstract List<Control> SelectFrom();
        
    }
    class TicketForm : Strategy
    {

   
        List<Control> controls = new List<Control>();

        public override List<Control> SelectFrom()
        {// giving the  lables names of the properties of ticket class
            ArrayList classlist = new ArrayList() {  "Customer","Booking_Agent", "flight", "Airline" };
            int txtno = 4;
            int pointX = 150;
            int pointxlbl = 30;
            int pointylbl = 42;
            int pointY = 40;
            for (int i = 0; i < txtno; i++)
            {
                // the customers are defined in the customer class , 
                //thats why we need to call them from the data base then we have the ticket
                ComboBox cb = new ComboBox();

                cb.Name = classlist[i].ToString();
                cb.Location = new Point(pointX, pointY);
                // bring objects from population
                if (i == 0) cb.Items.AddRange(Population.Instance.customers.ToArray());
                else if (i == 1) cb.Items.AddRange(Population.Instance.bookingagents.ToArray());
                else if (i == 2)
                {
                    // flights can have different airlines but not all airlines have the same flight .
                    //so when ever the flight is selected we need to bring the right airlines with 
                    //flight_selectedIndexChanged method that will call flightAirline method

                    cb.Items.AddRange(Population.Instance.flights.ToArray());
                    cb.SelectedIndexChanged += new System.EventHandler(this.flight_selectedIndexChanged);
                }
                else if (i == 3) cb.Items.AddRange(Population.Instance.airlines.ToArray());

                controls.Add(cb);
                pointY += 20;
            }
           

            for (int i = 0; i < txtno; i++)
            {
                Label l = new Label();
                l.Text = classlist[i].ToString();
                l.Location = new Point(pointxlbl, pointylbl);
                controls.Add(l);
                pointylbl += 21;

            }

    
            Button b = new Button();
            b.Name = "ticket";
            b.Location = new Point(85, pointylbl + 40);
            b.Text = "save";
            b.Click += save;
            controls.Add(b);

            return controls;
        }
        // showing airlines according to the flight selected
        public void FlightAirline(Flight flight)
        {
            for (int x = 0; x < ((ComboBox)controls[3]).Items.Count; x++)
            {
                if (flight.airline != (Airline)(((ComboBox)controls[3]).Items[x]) )
            {
                    ((ComboBox)controls[3]).Items.Remove((((ComboBox)controls[3]).Items[x]));
            }
                
            }
        }
        // knowing what flight was selected so we can define the airlines
        public void flight_selectedIndexChanged(object sender, EventArgs e)
        {
            FlightAirline((Flight)(((ComboBox)sender).SelectedItem));
        }
        
        // adding the new object to population and binding it with other classes objects
        public void save(object sender, EventArgs e)
        {

            Ticket ticket = new Ticket(((Customer)(((ComboBox)controls[0]).SelectedItem)),
                ((BookingAgent)(((ComboBox)controls[1]).SelectedItem)),
                ((Flight)(((ComboBox)controls[2]).SelectedItem)),
                ((Airline)(((ComboBox)controls[3]).SelectedItem))
                );
           
            Population.Instance.tickets.Add(ticket);
            ticket.customer.AddTicket(ticket);
            ticket.bookingAgent.Addticket(ticket);
            ticket.flight.AddTickets(ticket);
            ticket.airline.AddTicket(ticket);
            
            ((Form)((Button)sender).Parent).Close();
        }



    }
    class AirportForm : Strategy
    {
        List<Control> controls = new List<Control>();
        public override List<Control> SelectFrom()
        {
          ArrayList classlist = new ArrayList() { "name","city"};
            int txtno = 2;
            int pointX = 150;
            int pointxlbl = 30;
            int pointylbl = 40;
            int pointY = 40;
            for (int i = 0; i < txtno; i++)
            {
                TextBox a = new TextBox();
               
                a.Name = classlist[i].ToString();
                a.Location = new Point(pointX, pointY);
                controls.Add(a);
                pointY += 20;
            }
            for (int i = 0; i < txtno; i++)
            {
                Label a = new Label();
                a.Text = classlist[i].ToString();
                a.Location = new Point(pointxlbl, pointylbl);
                controls.Add(a);
                pointylbl += 21;
                
            }

            Button b = new Button();
            b.Name = "airport";
            b.Location = new Point(85, pointylbl + 40);
            b.Text = "save";
            b.Click += save;
            controls.Add(b);
            
            return controls;
        }
        public void save(object sender, EventArgs e)
        {
            
            Airport airport = new Airport(controls[0].Text.ToString(), controls[1].Text.ToString());
            Population.Instance.airports.Add(airport);
            ((Form)((Button)sender).Parent).Close();

        }

        


    }
    class AirlineForm : Strategy
    {
        List<Control> controls = new List<Control>();
        public override List<Control> SelectFrom()
        {

            ArrayList classlist = new ArrayList() { "name" };//, "employees", "airplanes", "tickets", "flights" };
            int pointX = 150;
            int pointxlbl = 30;
            int pointylbl = 40;
            int pointY = 40;

            TextBox a = new TextBox();
            a.Location = new Point(pointX, pointY);
            controls.Add(a);
            pointY += 20;
        
            Label l = new Label();
            l.Text = classlist[0].ToString();
            l.Location = new Point(pointxlbl, pointylbl);
            controls.Add(l);
            pointylbl += 21;

            Button b = new Button();
            b.Name = "airline";
            b.Location = new Point(85, pointylbl + 40);
            b.Text = "save";
            b.Click += save;
            controls.Add(b);

            return controls;
        }
        public void save(object sender, EventArgs e)
        {
            Airline airline = new Airline(controls[0].Text);
            Population.Instance.airlines.Add(airline);
            ((Form)((Button)sender).Parent).Close();
        }
    }


    class BookingAgentForm : Strategy
    {
        List<Control> controls = new List<Control>();
        public override List<Control> SelectFrom()
        {
            ArrayList classlist = new ArrayList() { "name"};
            int pointX = 150;
            int pointxlbl = 30;
            int pointY = 40;
         
            TextBox a = new TextBox();

            a.Name = classlist[0].ToString();
            a.Location = new Point(pointX, pointY);
            controls.Add(a);
          
            Label l = new Label();
            l.Text = classlist[0].ToString();
            l.Location = new Point(pointxlbl, pointY);
            controls.Add(l);

            Button b = new Button();
            b.Name = "bookingAgent";
            b.Location = new Point(85, pointY + 40);
            b.Text = "save";
            b.Click += save;
            controls.Add(b);

            return controls;
        }
        public void save(object sender, EventArgs e)
        {

            BookingAgent bookingAgent = new BookingAgent(controls[0].Text.ToString());
            Population.Instance.bookingagents.Add(bookingAgent);
            ((Form)((Button)sender).Parent).Close();
        }




    }

    class AirplaneForm : Strategy
    {
        List<Control> controls = new List<Control>();
        public override List<Control> SelectFrom()
        {
            ArrayList classlist = new ArrayList() { "amount of seats","airline" };
            int txtno = 2;
            int pointX = 150;
            int pointxlbl = 30;
            int pointylbl = 40;
            int pointY = 40;

            TextBox a = new TextBox();

            a.Name = classlist[0].ToString();
            a.Location = new Point(pointX, pointY);
            controls.Add(a);
            ComboBox cb = new ComboBox();

            cb.Name = classlist[1].ToString();
            cb.Location = new Point(pointX, pointY + 20);
            cb.Items.AddRange(Population.Instance.airlines.ToArray());
            controls.Add(cb);

            for (int i = 0; i < txtno; i++)
            {
                Label l = new Label();
                l.Text = classlist[i].ToString();
                l.Location = new Point(pointxlbl, pointylbl);
                controls.Add(l);
                pointylbl += 21;

            }
            

            Button b = new Button();
            b.Name = "airplane";
            b.Location = new Point(85, pointylbl + 40);
            b.Text = "save";
            b.Click += save;
            controls.Add(b);

            return controls;
        }
        public void save(object sender, EventArgs e)
        {

            Airplane airplane = new Airplane(Convert.ToInt32( controls[0].Text), ((Airline)(((ComboBox)controls[1]).SelectedItem)));
            airplane.airline.AddAirplane(airplane);
            Population.Instance.airplanes.Add(airplane);
            ((Form)((Button)sender).Parent).Close();
        }
    }
    class AirlineEmployeeForm : Strategy
    {
        List<Control> controls = new List<Control>();
        public override List<Control> SelectFrom()
        {
            ArrayList classlist = new ArrayList() { "first_name", "last_name","airline" };
            int txtno = 3;
            int pointX = 150;
            int pointxlbl = 30;
            int pointylbl = 40;
            int pointY = 40;
            // Controls.Clear();
            for (int i = 0; i < txtno; i++)
            {
                if (i == 2)
                {
                    ComboBox cb = new ComboBox();

                    cb.Name = classlist[2].ToString();
                    cb.Location = new Point(pointX, pointY );
                    cb.Items.AddRange(Population.Instance.airlines.ToArray());
                    controls.Add(cb);
                }
                else
                {
                    TextBox a = new TextBox();

                    a.Name = classlist[i].ToString();
                    a.Location = new Point(pointX, pointY);
                    controls.Add(a);
                    pointY += 20;
                }
            }
            for (int i = 0; i < txtno; i++)
            {
                Label a = new Label();
                a.Text = classlist[i].ToString();
                a.Location = new Point(pointxlbl, pointylbl);
                controls.Add(a);
                pointylbl += 21;

            }

            Button b = new Button();
            b.Name = "airlineEmployee";
            b.Location = new Point(85, pointylbl + 40);
            b.Text = "save";
            b.Click += save;
            controls.Add(b);

            return controls;
        }
        public void save(object sender, EventArgs e)
        {

            AirlineEmployee airlineEmployee = new AirlineEmployee(controls[0].Text.ToString(), controls[1].Text.ToString(), ((Airline)(((ComboBox)controls[2]).SelectedItem)));
            Population.Instance.airlineEmployees.Add(airlineEmployee);
            Population.Instance.airlines[Population.Instance.airlines.IndexOf(airlineEmployee.airline)].AddAirlineEmployee(airlineEmployee);
            ((Form)((Button)sender).Parent).Close();
        }
    }
    class CustomerForm : Strategy
    {
        List<Control> controls = new List<Control>();
        public override List<Control> SelectFrom()
        {

            ArrayList classlist = new ArrayList() { "name", "email","phone_number","passport_number","passport_expiration","passport_country","date_of_birth" };
            int txtno = 7;
            int pointX = 150;
            int pointxlbl = 30;
            int pointylbl = 40;
            int pointY = 40;
            for (int i = 0; i < txtno; i++)
            {
                if (i == 4 || i == 6)
                {
                    DateTimePicker dtp = new DateTimePicker();
                    dtp.Name = classlist[i].ToString();
                    dtp.Location = new Point(pointX, pointY);
                    controls.Add(dtp);
                    pointY += 20;
                }
                else
                {

                    TextBox a = new TextBox();

                    a.Name = classlist[i].ToString();
                    a.Location = new Point(pointX, pointY);
                    controls.Add(a);
                    pointY += 20;
                }
            }
            for (int i = 0; i < txtno; i++)
            {
                Label a = new Label();
                a.Text = classlist[i].ToString();
                a.Location = new Point(pointxlbl, pointylbl);
                controls.Add(a);
                pointylbl += 21;

            }

            Button b = new Button();
            b.Name = "customer";
            b.Location = new Point(85, pointylbl + 40);
            b.Text = "save";
            b.Click += save;
            controls.Add(b);

            return controls;
        }
        public void save(object sender, EventArgs e)
        {
            Customer customer = new Customer(controls[0].Text.ToString(), controls[1].Text.ToString(),
                controls[2].Text.ToString(), controls[3].Text.ToString(),
               ( (DateTimePicker) controls[4]).Value.Date, controls[5].Text.ToString(),
                ((DateTimePicker)controls[6]).Value.Date
                );
            Population.Instance.customers.Add(customer);
            ((Form)((Button)sender).Parent).Close();
        }
    }
    class FlightForm : Strategy
    {
        List<Control> controls = new List<Control>();
        public override List<Control> SelectFrom()
        {

            ArrayList classlist = new ArrayList() { "From", "Departure_time", "To", "Arrival_time","Airline","Airplane", "Price"};
            int txtno = 7;
            int pointX = 150;
            int pointxlbl = 30;
            int pointylbl = 40;
            int pointY = 40;
            for (int i = 0; i < txtno; i++)
            {
                if(i == 0 || i == 2 || i ==4 || i == 5)
                {
                    ComboBox cb = new ComboBox();
                    cb.Location = new Point(pointX, pointY);
                    if (i == 0 || i == 2) cb.Items.AddRange(Population.Instance.airports.ToArray());
                    else if (i == 4)
                    { cb.Items.AddRange(Population.Instance.airlines.ToArray());
                        cb.SelectedIndexChanged += new System.EventHandler(this.Airline_SelectedIndexChanged);

                    }
                    controls.Add(cb);
                    pointY += 20;

                }
                
                else if (i == 1 || i == 3)
                {
                    DateTimePicker dtp = new DateTimePicker();
                    dtp.Name = classlist[i].ToString();
                    dtp.Location = new Point(pointX, pointY);
                    controls.Add(dtp);
                    pointY += 20;
                }
                else
                {

                    TextBox a = new TextBox();

                    a.Name = classlist[i].ToString();
                    a.Location = new Point(pointX, pointY);
                    controls.Add(a);
                    pointY += 20;
                }
            }
            for (int i = 0; i < txtno; i++)
            {
                Label a = new Label();
                a.Text = classlist[i].ToString();
                a.Location = new Point(pointxlbl, pointylbl);
                controls.Add(a);
                pointylbl += 21;

            }

            Button b = new Button();
            b.Name = "flight";
            b.Location = new Point(85, pointylbl + 40);
            b.Text = "save";
            b.Click += save;
            controls.Add(b);

            return controls;
        }
        private void Airline_SelectedIndexChanged(object sender, EventArgs e)
        {
            AirlineAirplane((Airline)(((ComboBox)sender).SelectedItem));
        }
        private void AirlineAirplane(Airline airline)
        {
            ((ComboBox)controls[5]).Items.Clear();
            ((ComboBox)controls[5]).Items.AddRange(airline.airplanes.ToArray());
        }
        public void save(object sender, EventArgs e)
        {
            List<Airport> list = new List<Airport>();
            list.Add(((Airport)(((ComboBox)controls[0]).SelectedItem)));
            list.Add(((Airport)(((ComboBox)controls[2]).SelectedItem)));

            Flight flight = new Flight(((DateTimePicker)controls[1]).Value,((DateTimePicker)controls[3]).Value,
                Convert.ToDouble(controls[6].Text),
                ((Airline)(((ComboBox)controls[4]).SelectedItem)), ((Airplane)(((ComboBox)controls[5]).SelectedItem)),
                list
                );
            flight.airline.AddFlight(flight);
            Population.Instance.flights.Add(flight);
            ((Form)((Button)sender).Parent).Close();
        }
    }
    class CreateClassForm
    {
        // list of controls that will be created according to the class selected
        public List<Control> _list = new List<Control>();
        private Strategy _strategy;
       
        public void SetStrategyForm(string x)
        {

            if (x == "Airline") this._strategy = new AirlineForm();
            else
           if (x == "Airplane") this._strategy = new AirplaneForm();
            else
           if (x == "Booking Agent") this._strategy = new BookingAgentForm();
            else
           if (x == "Airline Employee") this._strategy = new AirlineEmployeeForm();
            else
           if (x == "Airport") this._strategy = new AirportForm();
            else
           if (x == "Flight") this._strategy = new FlightForm();
            else
           if (x == "Customer") this._strategy = new CustomerForm();
            else
           if (x == "Ticket") this._strategy = new TicketForm();
            _list = _strategy.SelectFrom();
        }
      //  public object getobject() =>  _strategy.GetType().Name;




    }

   
}
