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
    public partial class AdminAddMember : Form
    {
        public AdminAddMember()
        {

            InitializeComponent();
        }

        private void BtnAdminRegister_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TRF.Properties.Settings.TRFMembersConnectionString"].ConnectionString;
            string query = "INSERT INTO Members VALUES (@FirstName, @LastName, @Address, @Email, @UserName, @Password)";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                string FName = TxtAdminAddFirstName.Text;
                string LName = TxtAdminAddLastName.Text;
                string Addr = TxtAdminAddAddress.Text;
                string Email = TxtAdminAddEmail.Text;
                string UName = TxtAdminAddUserName.Text;
                string Pass = TxtAdminAddPass.Text;
                
                if (FName == "" || LName == "" || Addr == "" || Email == "" || UName == "" || Pass == "")
                {
                    MessageBox.Show("Alla fält måste fyllas i!");
                }
                else
                {
                    command.Parameters.AddWithValue("@FirstName", FName);
                    command.Parameters.AddWithValue("@LastName", LName);
                    command.Parameters.AddWithValue("@Address", Addr);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@UserName", UName);
                    command.Parameters.AddWithValue("@Password", Pass);

                    command.ExecuteScalar();

                    this.Hide();
                    AdminControl admin = new AdminControl();
                    admin.ShowDialog();
                }
            }
        }
    }
}
