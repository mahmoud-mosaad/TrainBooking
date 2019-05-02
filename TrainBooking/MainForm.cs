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
    public partial class MainForm : Form
    {

        Config config = new Config();

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            config.closeAndOpen(this, new UserSignupForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            config.closeAndOpen(this, new UserUpdateForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            config.closeAndOpen(this, new AddTrain());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            config.closeAndOpen(this, new UpdateTrain());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            config.closeAndOpen(this, new AddTrip());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            config.closeAndOpen(this, new UpdateTrip());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            config.closeAndOpen(this, new BookTrip());
        }
        

        private void button9_Click(object sender, EventArgs e)
        {
            config.closeAndOpen(this, new CancelTrip());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            config.closeAndOpen(this, new TripReport());
        }
    }
}
