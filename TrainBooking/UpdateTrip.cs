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
    public partial class UpdateTrip : Form
    {

        Config config = new Config();


        public UpdateTrip()
        {
            InitializeComponent();
            List<string> list = getTrains();
            domainUpDown2.Items.Clear();
            domainUpDown2.Items.AddRange(list);
        }

        private void UpdateTrip_Load(object sender, EventArgs e)
        {
            this.tripTableAdapter.FillJoinQuery(this.trainBookingDataSet.Trip);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            config.closeAndOpen(this, new MainForm());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Update Trip


            if (numericUpDown2.Value != 0 && !domainUpDown2.Text.Equals("Select Train") &&
                !textBox4.Text.Equals("") && !textBox5.Text.Equals("") && !textBox6.Text.Equals("") &&
                !textBox7.Text.Equals(""))
            {

                string id = dataGridView3.CurrentRow.Cells[0].Value.ToString();

                string temp = "update Trip set Source = ";
                
                temp = temp + "'" + textBox5.Text + "' , Destination =  ";

                temp = temp + "'" + textBox4.Text + "' , AvailableSeats = ";

                temp = temp + numericUpDown2.Value.ToString() + " , Date = ";

                temp = temp + "'" + textBox6.Text + "' , Time = ";

                temp = temp + "'" + textBox7.Text + "' , TrainId = ";

                temp = temp + "'" + domainUpDown2.Text + "'";

                temp = temp + " where Id = '" + id + "'";

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

        private void button3_Click(object sender, EventArgs e)
        {
            string id = dataGridView3.CurrentRow.Cells[0].Value.ToString();

            string tmp = "delete from BookSeat where TripId = ";

            tmp = tmp + "'" + id + "'";

            config.execQuery(tmp);

            string temp = "delete from Trip where Id = ";

            temp = temp + "'" + id + "'";

            config.execQuery(temp);
            this.tripTableAdapter.FillJoinQuery(this.trainBookingDataSet.Trip);
            MessageBox.Show("Successfully deleted");
        }
    }
}
