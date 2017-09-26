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
    public partial class AdminControl : Form
    {
        string connectionString;

        SqlConnection connection;


        public AdminControl()
        {
            InitializeComponent();
        }

        private void BtnAdminLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login =new Login();
            login.ShowDialog();
        }

        private void AdminControl_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["TRF.Properties.Settings.TRFMembersConnectionString"].ConnectionString;

            ListMembers();
            
            
        }
        private void ListMembers()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Members", connection))
            {
                DataTable MemberTable = new DataTable();
                adapter.Fill(MemberTable);

                LstAdminMembers.DisplayMember = "FirstName";
                LstAdminMembers.ValueMember = "Id";
                LstAdminMembers.DataSource = MemberTable;

                


            }
            
            
        }

        private void LstAdminMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtAdminMemberFirstName.Text = LstAdminMembers.
        }
    }
}
