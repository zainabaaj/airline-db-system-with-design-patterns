using Airline2;
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
    // update button
    // also using strategy method and similar to add button it will show a form that has the object information 
    //need to be changed .
    // save button will delete the old object and create a new one 
    
    //  the old object will be saved and sent to form1 for command pattern
    abstract class UpdateStrategy
    {
        // for the old object to send it to form1
        public object oldObject;
        // to make changes on the object in population class
        public object o { get; set; }
        public abstract List<Control> SelectFrom(object o );

    }
    class UpdateTicket : UpdateStrategy
    {


        List<Control> controls = new List<Control>();

        public override List<Control> SelectFrom(object o )
        {
            this.o = o;
            ArrayList classlist = new ArrayList() { "Customer", "Booking_Agent", "flight", "Airline" };
            int txtno = 4;
            int pointX = 150;
            int pointxlbl = 30;
            int pointylbl = 42;
            int pointY = 40;
            for (int i = 0; i < txtno; i++)
            {
                ComboBox cb = new ComboBox();

                cb.Name = classlist[i].ToString();
                cb.Location = new Point(pointX, pointY);
                if (i == 0)
                {
                    cb.Items.AddRange(Population.Instance.customers.ToArray());
                    cb.SelectedItem = ((Ticket)o).customer;
                }
                else if (i == 1)
                {
                    cb.Items.AddRange(Population.Instance.bookingagents.ToArray());
                    cb.SelectedItem = ((Ticket)o).bookingAgent;

                }
                else if (i == 2)
                {
                    cb.Items.AddRange(Population.Instance.flights.ToArray());
                    cb.SelectedItem = ((Ticket)o).flight;
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
            b.Text = "Update";
            b.Click += save;
            controls.Add(b);

            return controls;
        }
        private void FlightAirline(Flight flight)
        {
            for (int x = 0; x < ((ComboBox)controls[3]).Items.Count; x++)
            {
                if (flight.airline != (Airline)(((ComboBox)controls[3]).Items[x]))
                {
                    ((ComboBox)controls[3]).Items.Remove((((ComboBox)controls[3]).Items[x]));
                }

            }
        }
        private void flight_selectedIndexChanged(object sender, EventArgs e)
        {
            FlightAirline((Flight)(((ComboBox)sender).SelectedItem));
        }
        private void save(object sender, EventArgs e)
        {
            Ticket oldticket = Ticket.Copy((Ticket)o);
            oldObject = oldticket;
           
             ((Ticket)o).customer = ((Customer)(((ComboBox)controls[0]).SelectedItem));
            ((Ticket)o).bookingAgent = ((BookingAgent)(((ComboBox)controls[1]).SelectedItem));
            ((Ticket)o).flight = ((Flight)(((ComboBox)controls[2]).SelectedItem));
            ((Ticket)o).airline = ((Airline)(((ComboBox)controls[3]).SelectedItem));

            ((Form)((Button)sender).Parent).Close();

        }



    }
    class UpdateAirport : UpdateStrategy
    {
        List<Control> controls = new List<Control>();
        public override List<Control> SelectFrom(object o)
        {
            this.o = o;

            ArrayList classlist = new ArrayList() { "name", "city" };
            int txtno = 2;
            int pointX = 150;
            int pointxlbl = 30;
            int pointylbl = 40;
            int pointY = 40;
            for (int i = 0; i < txtno; i++)
            {
                TextBox a = new TextBox();

                a.Name = classlist[i].ToString();
               if(i==0) a.Text = ((Airport)o).name;
               else a.Text = ((Airport)o).city;
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
                pointylbl += 20;

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
            Airport oldticket = Airport.Copy((Airport)o);
            oldObject = oldticket;

            ((Airport)o).name = ((TextBox)controls[0]).Text;
            ((Airport)o).city = ((TextBox)controls[1]).Text;

            ((Form)((Button)sender).Parent).Close();
        }




    }
    class UpdateAirline : UpdateStrategy
    {
        List<Control> controls = new List<Control>();
        public override List<Control> SelectFrom(object o)
        {
            this.o = o;
            ArrayList classlist = new ArrayList() { "name" };
            int txtno = 5;
            int pointX = 150;
            int pointxlbl = 30;
            int pointylbl = 40;
            int pointY = 40;
            
            TextBox a = new TextBox();

            a.Location = new Point(pointX, pointY);
            a.Text = ((Airline)o).name;
            controls.Add(a);
            pointY += 20;

            Label l = new Label();
            l.Text = classlist[0].ToString();
            l.Location = new Point(pointxlbl, pointylbl);
            controls.Add(l);
            pointylbl += 20;


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
            Airline oldticket = Airline.Copy((Airline)o);
            oldObject = oldticket;

            ((Airline)o).name = controls[0].Text;
            ((Form)((Button)sender).Parent).Close();
        }
    }


    class UpdateBookingAgent : UpdateStrategy
    {
        List<Control> controls = new List<Control>();
        public override List<Control> SelectFrom(object o)
        {
            this.o = o;
            ArrayList classlist = new ArrayList() { "name" };
            int pointX = 150;
            int pointxlbl = 30;
            int pointY = 40;

            TextBox a = new TextBox();

            a.Name = classlist[0].ToString();
            a.Text = ((BookingAgent)o).name;
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
            BookingAgent oldticket = BookingAgent.Copy((BookingAgent)o);
            oldObject = oldticket;
            ((BookingAgent)o).name= controls[0].Text.ToString();
            ((Form)((Button)sender).Parent).Close();
        }




    }

    class UpdateAirplane : UpdateStrategy
    {
        List<Control> controls = new List<Control>();
        public override List<Control> SelectFrom(object o)
        {
            this.o = o;
            ArrayList classlist = new ArrayList() { "amount of seats", "airline" };
            int txtno = 2;
            int pointX = 150;
            int pointxlbl = 30;
            int pointylbl = 40;
            int pointY = 40;

            TextBox a = new TextBox();

            a.Name = classlist[0].ToString();
            a.Text = ((Airplane)o).amountOfSeats.ToString();
            a.Location = new Point(pointX, pointY);
            controls.Add(a);
            ComboBox cb = new ComboBox();

            cb.Name = classlist[1].ToString();
            cb.SelectedItem = ((Airplane)o).airline;
            cb.Location = new Point(pointX, pointY + 20);
            cb.Items.AddRange(Population.Instance.airlines.ToArray());
            controls.Add(cb);

            for (int i = 0; i < txtno; i++)
            {
                Label l = new Label();
                l.Text = classlist[i].ToString();
                l.Location = new Point(pointxlbl, pointylbl);
                controls.Add(l);
                pointylbl += 20;

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
            Airplane oldticket = Airplane.Copy((Airplane)o);
            oldticket.id = ((Airplane)o).id;
            oldObject = oldticket;
            ((Airplane)o).amountOfSeats = int.Parse(controls[0].Text);
            ((Airplane)o).airline = (Airline)(((ComboBox)(controls[1])).SelectedItem);

            ((Form)((Button)sender).Parent).Close();
        }
    }
    class UpdateAirlineEmployee : UpdateStrategy
    {
        List<Control> controls = new List<Control>();
        public override List<Control> SelectFrom(object o)
        {
            this.o = o;
            ArrayList classlist = new ArrayList() { "first_name", "last_name", "airline" };
            int txtno = 3;
            int pointX = 150;
            int pointxlbl = 30;
            int pointylbl = 40;
            int pointY = 40;
            for (int i = 0; i < txtno; i++)
            {
                if (i == 2)
                {
                    ComboBox cb = new ComboBox();

                    cb.Name = classlist[2].ToString();
                    cb.SelectedItem = ((AirlineEmployee)o).airline;
                    cb.Location = new Point(pointX, pointY);
                    cb.Items.AddRange(Population.Instance.airlines.ToArray());
                    controls.Add(cb);
                }
                else
                {
                    TextBox a = new TextBox();

                    a.Name = classlist[i].ToString();
                    if (i == 0) a.Text = ((AirlineEmployee)o).firstName;
                    else if (i == 1) a.Text = ((AirlineEmployee)o).lastName;
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
                pointylbl += 20;

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
            AirlineEmployee oldticket = AirlineEmployee.Copy((AirlineEmployee)o);
            oldObject = oldticket;
            ((AirlineEmployee)o).firstName = controls[0].Text;
            ((AirlineEmployee)o).lastName = controls[1].Text;
            ((AirlineEmployee)o).airline = (Airline)(((ComboBox)(controls[2])).SelectedItem);
            ((Form)((Button)sender).Parent).Close();
        }
    }
    class UpdateCustomer : UpdateStrategy
    {
        List<Control> controls = new List<Control>();
        public override List<Control> SelectFrom(object o)
        {
            this.o = o;
            ArrayList classlist = new ArrayList() { "name", "email", "phone_number", "passport_number", "passport_expiration", "passport_country", "date_of_birth" };
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
                   if(i==4)  dtp.Value = ((Customer)o).passportExpiration;
                    else dtp.Value = ((Customer)o).dateOfBirth;
                    dtp.Location = new Point(pointX, pointY);
                    controls.Add(dtp);
                    pointY += 20;
                }
                else
                {

                    TextBox a = new TextBox();

                    a.Name = classlist[i].ToString();
                    if (i == 0) a.Text = ((Customer)o).name;
                    else if (i == 1) a.Text = ((Customer)o).email;
                    else if (i == 2) a.Text = ((Customer)o).phoneNumber;
                    else if (i == 3) a.Text = ((Customer)o).passportNumber;
                    else if (i == 5) a.Text = ((Customer)o).passportCountry;
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
                pointylbl += 20;

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
            Customer oldticket = Customer.Copy((Customer)o);
            oldObject = oldticket;
            ((Customer)o).name = controls[0].Text;
            ((Customer)o).email = controls[1].Text;
            ((Customer)o).phoneNumber = controls[2].Text;
            ((Customer)o).passportNumber = controls[3].Text;
            ((Customer)o).passportExpiration = (DateTime)(((DateTimePicker)(controls[4])).Value);
            ((Customer)o).passportNumber = controls[5].Text;
            ((Customer)o).passportExpiration = (DateTime)(((DateTimePicker)(controls[6])).Value);
            ((Form)((Button)sender).Parent).Close();
        }
    }
    class UpdateFlight : UpdateStrategy
    {
        List<Control> controls = new List<Control>();
        public override List<Control> SelectFrom(object o)
        {
            this.o = o;
            ArrayList classlist = new ArrayList() { "From", "Departure_time", "To", "Arrival_time", "Airline", "Airplane", "Price" };
            int txtno = 7;
            int pointX = 150;
            int pointxlbl = 30;
            int pointylbl = 40;
            int pointY = 40;
            for (int i = 0; i < txtno; i++)
            {
                if (i == 0 || i == 2 || i == 4 || i == 5)
                {
                    ComboBox cb = new ComboBox();
                    cb.Location = new Point(pointX, pointY);
                    if (i == 0)
                    {
                        cb.Items.AddRange(Population.Instance.airports.ToArray());
                        cb.SelectedItem = ((Flight)o).airports[0];
                    }
                    else if (i == 2)
                    {
                        cb.Items.AddRange(Population.Instance.airports.ToArray());
                        cb.SelectedItem = ((Flight)o).airports[1];
                    }
                    else if (i == 4)
                    {
                        cb.Items.AddRange(Population.Instance.airlines.ToArray());
                        cb.SelectedItem = ((Flight)o).airline;
                    }
                    else if (i == 5)
                    {
                        cb.Items.AddRange(Population.Instance.airplanes.ToArray());
                        cb.SelectedItem = ((Flight)o).airplane;
                    }
                    controls.Add(cb);
                    pointY += 20;

                }

                else if (i == 1 || i == 3)
                {
                    DateTimePicker dtp = new DateTimePicker();
                    dtp.Name = classlist[i].ToString();
                    if (i == 1) dtp.Value = ((Flight)o).departureTime;
                    if (i == 3) dtp.Value = ((Flight)o).arrivalTime;
                    dtp.Location = new Point(pointX, pointY);
                    controls.Add(dtp);
                    pointY += 20;
                }
                else
                {

                    TextBox a = new TextBox();

                    a.Name = classlist[i].ToString();
                    a.Text = ((Flight)o).price.ToString();
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
                pointylbl += 20;

            }

            Button b = new Button();
            b.Name = "flight";
            b.Location = new Point(85, pointylbl + 40);
            b.Text = "save";
            b.Click += save;
            controls.Add(b);

            return controls;
        }
        public void save(object sender, EventArgs e)
        {
            Flight oldticket = Flight.Copy((Flight)o);
            oldObject = oldticket;
            ((Flight)o).airports[0] = (Airport)((ComboBox)controls[0]).SelectedItem;
            ((Flight)o).departureTime = (DateTime)(((DateTimePicker)(controls[1])).Value);
            ((Flight)o).airports[1] = (Airport)((ComboBox)controls[2]).SelectedItem;
            ((Flight)o).arrivalTime = (DateTime)(((DateTimePicker)(controls[3])).Value);
            ((Flight)o).airline = (Airline)((ComboBox)controls[4]).SelectedItem;
            ((Flight)o).airplane = (Airplane)((ComboBox)controls[5]).SelectedItem;
            ((Flight)o).price = double.Parse(controls[6].Text);
            ((Form)((Button)sender).Parent).Close();
        }
    }
    class UpdateClassForm
    {
        public List<Control> _list = new List<Control>();
        private UpdateStrategy _UpdateStrategy;

        public void SetUpdateStrategyForm(object o)
        {

            string x = o.GetType().Name;
            if (x == "Airline") this._UpdateStrategy = new UpdateAirline();
            else
           if (x == "Airplane") this._UpdateStrategy = new UpdateAirplane();
            else
           if (x == "BookingAgent") this._UpdateStrategy = new UpdateBookingAgent();
            else
           if (x == "AirlineEmployee") this._UpdateStrategy = new UpdateAirlineEmployee();
            else
           if (x == "Airport") this._UpdateStrategy = new UpdateAirport();
            else
           if (x == "Flight") this._UpdateStrategy = new UpdateFlight();
            else
           if (x == "Customer") this._UpdateStrategy = new UpdateCustomer();
            else
           if (x == "Ticket") this._UpdateStrategy = new UpdateTicket();
            _list = _UpdateStrategy.SelectFrom(o);
        }
        // to get the old object 
        public object getobject() => _UpdateStrategy.oldObject;



    }
}
