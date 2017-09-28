using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace TRF
{
    public partial class AdminAddTiger : Form
    {
        public AdminAddTiger(object value)
        {
            InitializeComponent();
        }

        public void GetOwner(object value)
        {
            object owner = value;
        }

        public void BtnAdminAddTiger_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TRF.Properties.Settings.TRFMembersConnectionString"].ConnectionString;
            string query = "INSERT INTO Tigers VALUES (@OwnerId, @Name, @Age, @Species)";

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                string Name = TxtAdminAddTigerName.Text;
                int Age = 0;
                int.TryParse(TxtAdminAddTigerAge.Text, out Age);
                string Species = TxtAdminAddSpecies.Text;
                int OwnerId = 0;
                int.TryParse(TxtAdminAddOwnerId.Text, out OwnerId);

                if (Name == "" || Species == "" || Age == 0 || OwnerId == 0)
                {
                    MessageBox.Show("Alla fält måste fyllas i!");
                }
                else if(!int.TryParse(TxtAdminAddTigerAge.Text, out Age) || !int.TryParse(TxtAdminAddOwnerId.Text, out OwnerId))
                {
                    MessageBox.Show("Du måste mata in ett tal som ålder!");
                }
                else
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Age", Age);
                    command.Parameters.AddWithValue("@Species", Species);
                    command.Parameters.AddWithValue("@OwnerId", OwnerId);

                    command.ExecuteScalar();

                    this.Hide();
                    AdminControl newadmin = new AdminControl();
                    newadmin.ShowDialog();
                }
            }
        }
    }
}
