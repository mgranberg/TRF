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
    //Allt är likadant som AddMember, Undatagen är kommenterade.
    public partial class AdminAddTiger : Form
    {
        public AdminAddTiger(object value)
        {
            InitializeComponent();
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
                //Omvandlar inmatad ålder till int
                int.TryParse(TxtAdminAddTigerAge.Text, out Age);
                string Species = TxtAdminAddSpecies.Text;
                int OwnerId = 0;
                //Omvandlar inmatad OwnerId till int
                int.TryParse(TxtAdminAddOwnerId.Text, out OwnerId);

                //Om något av fälten är tomma:
                if (Name == "" || Species == "" || Age == 0 || OwnerId == 0)
                {
                    //Varning
                    MessageBox.Show("Alla fält måste fyllas i!");
                }
                //Om det inte går att omvandla åler och OwnerId till int
                else if(!int.TryParse(TxtAdminAddTigerAge.Text, out Age) || !int.TryParse(TxtAdminAddOwnerId.Text, out OwnerId))
                {
                    //Varning
                    MessageBox.Show("Du måste mata in ett tal som ålder!");
                }
                //Om allt är som det ska.
                else
                {
                    //Lägger till värderna i query
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Age", Age);
                    command.Parameters.AddWithValue("@Species", Species);
                    command.Parameters.AddWithValue("@OwnerId", OwnerId);

                    command.ExecuteScalar();

                    //Döljer och visar admin control igen.
                    this.Hide();
                    AdminControl newadmin = new AdminControl();
                    newadmin.ShowDialog();
                }
            }
        }
        //Avlutar applikationen när fönstret stängs.
        private void AdminAddTiger_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void WikiLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://sv.wikipedia.org/wiki/Tiger");
        }
    }
}
