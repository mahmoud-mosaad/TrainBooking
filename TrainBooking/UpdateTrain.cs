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
    public partial class UpdateTrain : Form
    {
        Config config = new Config();


        public UpdateTrain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            config.closeAndOpen(this, new MainForm());
        }

        private void button5_Click(object sender, EventArgs e)
        {

            // update Train



            if (numericUpDown1.Value != 0)
            {

                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                string temp = "update Train set NumberOfSeats = ";

                temp = temp + numericUpDown1.Value.ToString();

                temp = temp + " , Name = ";

                if (!textBox3.Text.Equals(""))
                    temp = temp + "'" + textBox3.Text + "'";
                else
                    temp = temp + "NULL ";


                config.execQuery(temp);

                MessageBox.Show("Successfully updated");

            }
            else
            {
                MessageBox.Show("Enter #Seats");
            }
            

        }

        private void UpdateTrain_Load(object sender, EventArgs e)
        {
            this.trainTableAdapter.Fill(this.trainBookingDataSet.Train);

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            string temp = "delete from Train where Id = ";

            temp = temp + "'" + id + "'";

            config.execQuery(temp);
            this.trainTableAdapter.Fill(this.trainBookingDataSet.Train);
            MessageBox.Show("Successfully deleted");
        }
    }
}
