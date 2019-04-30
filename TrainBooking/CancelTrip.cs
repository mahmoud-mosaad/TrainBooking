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
    public partial class CancelTrip : Form
    {

        Config config = new Config();

        public CancelTrip()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            config.closeAndOpen(this, new MainForm());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string b = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            

            string tmp = "delete from BookSeat where TripId = '" + b + "'and UsrId = '" + a + "'";
            config.execQuery(tmp);


            MessageBox.Show("BookedTrip deleted Successfully");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //
            if (!textBox1.Text.Equals("")) {
                string tmp = "select BookSeat.* from BookSeat, Usr where Usr.Id = BookSeat.UsrId and Email = '" + textBox1.Text + "'";

                SqlConnection sqlconnection = new SqlConnection(@"Data Source=DESKTOP-8T8V4OU;Initial Catalog=TrainBooking;Integrated Security=True");
                SqlDataAdapter s = new SqlDataAdapter(tmp, sqlconnection);
                DataTable dt = new DataTable();
                s.Fill(dt);
                dataGridView1.DataSource = dt;

            }else
            {
                MessageBox.Show("Enter Your Mail");
            }
        }
    }
}
