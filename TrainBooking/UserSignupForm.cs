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
    public partial class UserSignupForm : Form
    {

        Config config = new Config();

        public UserSignupForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // signup


            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals("") && !domainUpDown1.Text.Equals("Select Role"))
            {

                string temp = "insert into Usr values (";

                String uuid = config.getNewGuid();

                temp = temp + "'" + uuid + "'" + ", ";

                temp = temp + "'" + textBox2.Text + "'" + ", ";

                temp = temp + "'" + textBox1.Text + "'" + ", ";

                if (domainUpDown1.Text.Equals("Admin"))
                    temp += "'admin') ";
                else
                    temp += "'customer') ";
                
                config.execQuery(temp);

                MessageBox.Show("Successfully insetred");

            }
            else
            {
                MessageBox.Show("Enter All User information");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            config.closeAndOpen(this, new MainForm());
        }
    }
}
