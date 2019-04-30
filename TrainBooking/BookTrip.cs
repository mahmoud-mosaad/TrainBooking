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
    public partial class BookTrip : Form
    {

        Config config = new Config();

        public BookTrip()
        {
            InitializeComponent();
        }

        private void AvailableSeatsTrip_Load(object sender, EventArgs e)
        {
            this.tripTableAdapter.FillJoinQuery(this.trainBookingDataSet.Trip);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = true;
            }else
            {
                textBox1.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;
            }
            else
            {
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox3.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                textBox4.Enabled = true;
            }
            else
            {
                textBox4.Enabled = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                numericUpDown1.Enabled = true;
            }
            else
            {
                numericUpDown1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            config.closeAndOpen(this, new MainForm());
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // show available seats
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false)
            {
                MessageBox.Show("Check at least one parameter");
            }
            else
            {
                bool first = true;
                string tmp = "select * from Trip where ";

                if (checkBox1.Checked == true)
                {
                    tmp = tmp + ((first == false) ? " and " : "") + " Date = '" + textBox1.Text + "' ";
                    if (first == true) first = false;
                }
                else if (checkBox2.Checked == true)
                {
                    tmp = tmp + ((first == false) ? " and " : "")
                        + "Time = '"
                        + ((numericUpDown2.Value < 10) ? "0" + numericUpDown2.Value.ToString() : numericUpDown2.Value.ToString())
                        + ":" + ((numericUpDown3.Value < 10) ? "0" + numericUpDown3.Value.ToString() : numericUpDown3.Value.ToString())
                        + "'";
                    if (first == true) first = false;
                }
                else if (checkBox3.Checked == true)
                {
                    tmp = tmp + ((first == false) ? " and " : "") + " Source like '%" + textBox3.Text + "%' ";
                    if (first == true) first = false;
                }
                else if (checkBox4.Checked == true)
                {
                    tmp = tmp + ((first == false) ? " and " : "") + " Destination like '" + textBox4.Text + "' ";
                    if (first == true) first = false;
                }
                else if (checkBox5.Checked == true)
                {
                    tmp = tmp + ((first == false) ? " and " : "") + " availableSeats >= " + numericUpDown1.Value.ToString();
                    if (first == true) first = false;
                }

                SqlConnection sqlconnection = new SqlConnection(@"Data Source=DESKTOP-8T8V4OU;Initial Catalog=TrainBooking;Integrated Security=True");
                SqlDataAdapter s = new SqlDataAdapter(tmp, sqlconnection);
                DataTable dt = new DataTable();
                s.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!textBox2.Text.Equals(""))
            {
                string tripId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string trainId = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                string tmp = "select Name from Usr where Email = '" + textBox1.Text + "'";
                SqlConnection sqlconnection = new SqlConnection(@"Data Source=DESKTOP-8T8V4OU;Initial Catalog=TrainBooking;Integrated Security=True");
                sqlconnection.Open();
                SqlCommand sqlCommand = new SqlCommand(tmp, sqlconnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                string userId = "";
                userId = reader["Id"].ToString();
                sqlconnection.Close();
                string temp = "insert into BookSeat values('" + userId + "', '" + tripId + "')";
                config.execQuery(temp);

                MessageBox.Show("successfully inserted");

            }
            else
            {
                MessageBox.Show("Enter your mail");
            }
        }
    }
}
