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
    public partial class UserUpdateForm : Form
    {

        Config config = new Config();
        string joinQuery = "SELECT Usr.Id, Usr.Name, Usr.Email, Usr.RoleTitle AS RoleTitle from Usr";

        public UserUpdateForm()
        {
            InitializeComponent();
        }

        private void UserUpdateForm_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection(@"Data Source=DESKTOP-8T8V4OU;Initial Catalog=TrainBooking;Integrated Security=True");
            SqlDataAdapter s = new SqlDataAdapter(joinQuery, sqlconnection);
            DataTable dt = new DataTable();
            s.Fill(dt);
            dataGridView1.DataSource = dt;
            //this.usrTableAdapter.Fill(this.trainBookingDataSet.Usr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            config.closeAndOpen(this, new MainForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //dataGridView1.EndEdit();
            //this.usrTableAdapter.Update(this.trainBookingDataSet.Usr);
            
            // update user
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals(""))
            {

                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                string temp = "update Usr set Name = ";

                temp = temp + "'" + textBox2.Text + "'";

                temp = temp + " , Email = ";

                temp = temp + "'" + textBox1.Text + "'";

                temp = temp + " where  Id = '" + id + "'";
                
                config.execQuery(temp);
                MessageBox.Show("Successfully updated");

            }
            else
            {
                MessageBox.Show("Enter Your mail and the new name");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            string tmp = "delete from BookSeat where UsrId = ";

            tmp = tmp + "'" + id + "'";

            config.execQuery(tmp);

            string temp = "delete from Usr where Id = ";

            temp = temp + "'" + id + "'";
            
            config.execQuery(temp);
            this.usrTableAdapter.Fill(this.trainBookingDataSet.Usr);
            MessageBox.Show("Successfully deleted");
        }
    }
}
