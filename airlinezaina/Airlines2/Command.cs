using Airline2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airlines2
{
    // the command design used for (redo , undo) updates in classes
    //walking through classes :
    // user (receiver , icommand->command)
    // command (receiver -> receiver)
    // receiver( operation)

    /* user instance is intialized in form1 for each update the compute function will be called  
     * otherwize if ctrlz or ctrly is clicked then undo, redo functions will be called
     * in user class the command will be set and a receiver instance will be sent to the command instructor
     */
    /*in command the receiver will be set and the object type and information will be taken 
     *if any redo / undo is done then the receiver operation function will be called
     */
   abstract class ICommand
    {
        public abstract void Execute();
        public abstract void UnExecute();

    }
    class Command : ICommand
    {
        private Receiver receiver;
        object oldObject { get; set; }
        object newObject { get; set; }

        public Command(object oldObject,object newObject, Receiver receiver)
        {
            string oldObjectTypeName = oldObject.GetType().Name;
            string newObjectTypeName = newObject.GetType().Name;
            //check the class of the object
            if (oldObjectTypeName == "Airline")
            {
                // take a copy of the object before and after being updated
                this.oldObject = Airline.Copy((Airline)oldObject);
                this.newObject = Airline.Copy((Airline)newObject);
            }
            else if (oldObjectTypeName == "AirlineEmployee")
            {
                this.oldObject = AirlineEmployee.Copy((AirlineEmployee)oldObject);
                this.newObject = AirlineEmployee.Copy((AirlineEmployee)newObject);
            }
            else if (oldObjectTypeName == "Airplane")
            {
                this.oldObject = Airplane.Copy((Airplane)oldObject);
                this.newObject = Airplane.Copy((Airplane)newObject);
            }
            else if (oldObjectTypeName == "Airport")
            {
                this.oldObject = Airport.Copy((Airport)oldObject);
                this.newObject = Airport.Copy((Airport)newObject);
            }
            else if (oldObjectTypeName == "BookingAgent")
            {
                this.oldObject = BookingAgent.Copy((BookingAgent)oldObject);
                this.newObject = BookingAgent.Copy((BookingAgent)newObject);
            }
            else if (oldObjectTypeName == "Customer")
            {
                this.oldObject = Customer.Copy((Customer)oldObject);
                this.newObject = Customer.Copy((Customer)newObject);
            }
            else if (oldObjectTypeName == "Flight")
            {
                this.oldObject = Flight.Copy((Flight)oldObject);
                this.newObject = Flight.Copy((Flight)newObject);
            }
            else if (oldObjectTypeName == "Ticket")
            {
                this.oldObject = Ticket.Copy((Ticket)oldObject);
                this.newObject = Ticket.Copy((Ticket)newObject);
            }

           
            this.receiver = receiver;
           
        }
        public override void Execute()
        {
            //for redo  replace the new object info with the old one
            receiver.Operation(oldObject,newObject);
        }

        public override void UnExecute()
        {
            // used for undo ..just do the opposite of execute
            receiver.Operation(newObject, oldObject);

        }
    }
     class Receiver
    {
        public void Operation ( object oldObject , object newObject)
        {
            string oldObjectTypeName = oldObject.GetType().Name;
            string newObjectTypeName = newObject.GetType().Name;
            // remove the old instance from population class
            if (oldObjectTypeName == "Airline")
            {
                //take the id of an instance then find it in the population class and delete it 
                ((Airline)newObject).id = ((Airline)oldObject).id;
                Population.Instance.airlines.Remove(Population.Instance.airlines.Find(t => t.id == ((Airline)oldObject).id));
            }
            else if (oldObjectTypeName == "AirlineEmployee")
            {
                ((AirlineEmployee)newObject).id = ((AirlineEmployee)oldObject).id;
                Population.Instance.airlineEmployees.Remove(Population.Instance.airlineEmployees.Find(t => t.id == ((AirlineEmployee)oldObject).id));
            }
            else if (oldObjectTypeName == "Airplane")
            {
                ((Airplane)newObject).id = ((Airplane)oldObject).id;
                Population.Instance.airplanes.Remove(Population.Instance.airplanes.Find(t => t.id == ((Airplane)oldObject).id));
            }
            else if (oldObjectTypeName == "Airport")
            {
                ((Airport)newObject).id = ((Airport)oldObject).id;
                Population.Instance.airports.Remove(Population.Instance.airports.Find(t => t.id == ((Airport)oldObject).id));
            }
            else if (oldObjectTypeName == "BookingAgent")
            {
                ((BookingAgent)newObject).id = ((BookingAgent)oldObject).id;
                Population.Instance.bookingagents.Remove(Population.Instance.bookingagents.Find(t => t.id == ((BookingAgent)oldObject).id));
            }
            else if (oldObjectTypeName == "Customer")
            {
                ((Customer)newObject).id = ((Customer)oldObject).id;
                Population.Instance.customers.Remove(Population.Instance.customers.Find(t => t.id == ((Customer)oldObject).id));
            }
            else if (oldObjectTypeName == "Flight")
            {
                ((Flight)newObject).id = ((Flight)oldObject).id;
                Population.Instance.flights.Remove(Population.Instance.flights.Find(t => t.id == ((Flight)oldObject).id));
            }
            else if (oldObjectTypeName == "Ticket")
            {
                ((Ticket)newObject).id = ((Ticket)oldObject).id;
                Population.Instance.tickets.Remove(Population.Instance.tickets.Find(t => t.id == ((Ticket)oldObject).id));
            }
            // adding the new instance to population class( noticing that it has the same id of the old one

            if (newObjectTypeName == "Airline") Population.Instance.airlines.Add((Airline)newObject);
            else if (newObjectTypeName == "AirlineEmployee") Population.Instance.airlineEmployees.Add((AirlineEmployee)newObject);
            else if (newObjectTypeName == "Airplane") Population.Instance.airplanes.Add((Airplane)newObject);
            else if (newObjectTypeName == "Airport") Population.Instance.airports.Add((Airport)newObject);
            else if (newObjectTypeName == "BookingAgent") Population.Instance.bookingagents.Add((BookingAgent)newObject);
            else if (newObjectTypeName == "Customer") Population.Instance.customers.Add((Customer)newObject);
            else if (newObjectTypeName == "Flight") Population.Instance.flights.Add((Flight)newObject);
            else if (newObjectTypeName == "Ticket") Population.Instance.tickets.Add((Ticket)newObject);


        }
    }
    class User
    {
        private Receiver receiver = new Receiver();
        // the redo undo commands will be hold in a stack when ever a redo is done it will be popped to undo and vise versa
        Stack<ICommand> RedoStack = new Stack<ICommand>();
        Stack<ICommand> UndoStack = new Stack<ICommand>();
        public void Redo()
        {
            if (RedoStack.Count>0)
            {
                // remove the command from redo stack and push it to undo so it can be undone, then call execute
                ICommand cmd = RedoStack.Pop();
                UndoStack.Push(cmd);
                cmd.Execute();

            }


        }
        public void Undo()
        {
            if (UndoStack.Count > 0)
            {
                // remove the command from undo stack so it can be redone and call enexecute
                ICommand cmd = UndoStack.Pop();
                RedoStack.Push(cmd);
                cmd.UnExecute();
            }
            
        }
        
        public void Compute(object oldObject, object newObject)
        {
            // add an update that can be undone
            UndoStack.Push(new Command(oldObject, newObject, receiver));

        }
    }
    
}
