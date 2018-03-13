using Airline2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airlines2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // creating an instance for command pattern
        User user ;
        // creating an instance for factory pattern
        Iproduct listim;
        // to save the selected class name from the combobox
        String className;

        private void addBtn_Click(object sender, EventArgs e)
        {

            // making sure a class's been selected
            if (classcb.SelectedIndex == -1) return;
            // using strategy class 
            CreateClassForm strategy = new CreateClassForm();
            strategy.SetStrategyForm(classcb.SelectedItem.ToString());
            Add addform = new Add();
            // getting the list of controls created
            addform.Controls.AddRange(strategy._list.ToArray());
            addform.ShowDialog();
            // after adding the object the list will be refreshed 
            var factory = new Factory() as Ifactory;
            listim = factory.Getproduct(classcb.SelectedItem.ToString());
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(listim.list);
            
        }

        private void classcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // listing objects with factory class 
            var factory = new Factory() as Ifactory;
            var listim = factory.Getproduct(classcb.SelectedItem.ToString());
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(listim.list);
            // user for a command is created
            user = new User();
        }

        public void deleteBtn_Click(object sender, EventArgs e)
        {
            // making sure a class's been selected
            if (classcb.SelectedIndex == -1) return;
            //making sure something is selected to be deleted
            if (((ListView)groupBox1.Controls[0]).SelectedItems.Count ==0) return;
            if (listim.list.SelectedItems != null)
            {
                var o =((ListView)groupBox1.Controls[0]).SelectedItems[0].Tag;
                SetClassRemove setclass = new SetClassRemove();
                setclass.SetStrategyForm(o);
                var factory = new Factory() as Ifactory;
                var listim = factory.Getproduct(classcb.SelectedItem.ToString());
                groupBox1.Controls.Clear();
                groupBox1.Controls.Add(listim.list);
            }

        }

        public void updateBtn_Click(object sender, EventArgs e)
        {
            if (classcb.SelectedIndex ==-1) return;
            className = classcb.SelectedItem.ToString();
            if (((ListView)groupBox1.Controls[0]).SelectedItems.Count != 0)
            {
                var o = ((ListView)groupBox1.Controls[0]).SelectedItems[0].Tag;
                UpdateClassForm strategy = new UpdateClassForm();
                strategy.SetUpdateStrategyForm(o);
                Add addform = new Add();
                addform.Controls.AddRange(strategy._list.ToArray());
                addform.ShowDialog();
               object oldObject = strategy.getobject();
                // telling the command there is an object's been updated
                user.Compute(oldObject, o);
                var factory = new Factory() as Ifactory;
                listim = factory.Getproduct(className);
                groupBox1.Controls.Clear();
                groupBox1.Controls.Add(listim.list);
            }
            
        }

        // key listener for ctrl+z and ctrl+y
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Y && e.Modifiers == Keys.Control) || (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control))
            {
                if (e.KeyCode == Keys.Y && e.Modifiers == Keys.Control)
                {
                    user.Redo();
                }
                else if (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control)
                {
                    user.Undo();
                }
                var factory = new Factory() as Ifactory;
                listim = factory.Getproduct(classcb.SelectedItem.ToString());
                groupBox1.Controls.Clear();
                groupBox1.Controls.Add(listim.list);
            }
        }
    }
}
