using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainBooking
{
    public partial class AddTrip : Form
    {

        Config config = new Config();

        public AddTrip()
        {
            InitializeComponent();
            List<string> list = getTrains();
            domainUpDown2.Items.Clear();
            domainUpDown2.Items.AddRange(list);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            config.closeAndOpen(this, new MainForm());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Add Trip


            if (numericUpDown2.Value != 0 && !domainUpDown2.Text.Equals("Select Train") && 
                !textBox4.Text.Equals("") && !textBox5.Text.Equals("") && !textBox6.Text.Equals(""))
            {

                string temp = "insert into Trip values (";
                String uuid = config.getNewGuid();

                temp = temp + "'" + uuid + "'" + ", ";

                temp = temp + "'" + textBox5.Text + "', ";

                temp = temp + "'" + textBox4.Text + "', ";
                
                temp = temp + numericUpDown2.Value.ToString() + ", ";

                temp = temp + "'" + textBox6.Text + "', ";

                temp = temp + "'" 
                        +((numericUpDown1.Value < 10) ? "0" + numericUpDown1.Value.ToString() : numericUpDown1.Value.ToString())
                        + ":" + ((numericUpDown3.Value < 10) ? "0" + numericUpDown3.Value.ToString() : numericUpDown3.Value.ToString())
                        + "', ";

                temp = temp + "'" + domainUpDown2.Text + "')";
                
                config.execQuery(temp);

                MessageBox.Show("Successfully insetred");

            }
            else
            {
                MessageBox.Show("Enter all informations");
            }
        }

        public List<string> getTrains()
        {
            List<string> list = new List<string>();

            SqlConnection sqlconnection = new SqlConnection(@"Data Source=DESKTOP-8T8V4OU;Initial Catalog=TrainBooking;Integrated Security=True");

            sqlconnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT Id FROM Train", sqlconnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader["Id"].ToString());
            }
            sqlconnection.Close();

            return list;
        }
    }
}
