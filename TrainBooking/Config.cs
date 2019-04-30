using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainBooking
{
    class Config
    {
        SqlConnection sqlconnection = new SqlConnection(@"Data Source=DESKTOP-8T8V4OU;Initial Catalog=TrainBooking;Integrated Security=True");
        SqlCommand sqlcommand = new SqlCommand();

        public SqlConnection getSqlConnection { get; set; }
        public SqlCommand getSqlCommand { get; set; }

        public String getNewGuid() {
            return Guid.NewGuid().ToString().Replace("-", String.Empty);
        }

        public void execQuery(String query)
        {
            sqlconnection.Open();
            sqlcommand.Connection = sqlconnection;
            sqlcommand.CommandText = query;
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
        }


        public void closeAndOpen(Form oldForm, Form newType)
        {
            oldForm.Hide();
            var newform = newType;
            newform.Closed += (s, args) => oldForm.Close();
            newform.StartPosition = FormStartPosition.Manual;
            newform.Location = oldForm.Location;
            newform.Show();
        }

    }
}
