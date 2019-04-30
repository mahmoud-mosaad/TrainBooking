using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainBooking
{
    public partial class AddTrain : Form
    {

        Config config = new Config();

        public AddTrain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            config.closeAndOpen(this, new MainForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Add Train


            if (numericUpDown1.Value != 0)
            {

                string temp = "insert into Train values (";
                String uuid = config.getNewGuid();

                temp = temp + "'" + uuid + "'" + ", ";

                if (!textBox3.Text.Equals(""))
                    temp = temp + "'" + textBox3.Text + "'" + ", ";
                else
                    temp = temp + "NULL , ";

                temp = temp + numericUpDown1.Value.ToString() + ")";
                config.execQuery(temp);

                MessageBox.Show("Successfully insetred");

            }
            else
            {
                MessageBox.Show("Enter #Seats");
            }
        }
    }
}
