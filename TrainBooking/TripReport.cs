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
    public partial class TripReport : Form
    {

        Config config = new Config();

        public TripReport()
        {
            InitializeComponent();
        }

        private void TripReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'TrainBookingDataSet.Trip' table. You can move, or remove it, as needed.
            this.TripTableAdapter.FillJoinQuery(this.TrainBookingDataSet.Trip);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            config.closeAndOpen(this, new MainForm());
        }
    }
}
