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
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Members", connection))
            {
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                
                LstAdminMembers.DisplayMember = "FirstName";
                LstAdminMembers.ValueMember = "Id";
                LstAdminMembers.DataSource = datatable;

            }
        }

        private void ShowMemberInfo(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Members", connection))
            {
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);

                DataRow datarow = datatable.Rows[Id];
                TxtAdminMemberFirstName.Text = datarow[1].ToString();
                TxtAdminMemberLastName.Text = datarow[2].ToString();
                TxtAdminMemberAddress.Text = datarow[3].ToString();
                TxtAdminMemberEmail.Text = datarow[4].ToString();
                TxtAdminMemberUserName.Text = datarow[5].ToString();
                TxtAdminMemberPass.Text = datarow[6].ToString();

            }
        }

        private void ShowTigerInfo(int Id)
        {
            string query = "SELECT * FROM Tigers WHERE @Member=OwnerId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@Member", LstAdminMembers.SelectedValue);


                DataTable datatable = new DataTable();
                adapter.Fill(datatable);

                DataRow datarow = datatable.Rows[Id];
                TxtAdminTigerName.Text = datarow[2].ToString();
                TxtAdminTigerAge.Text = datarow[3].ToString();
                TxtAdminTigerSpecies.Text = datarow[4].ToString();

            }
        }

        private void ListTigers()
        {
            string query = "SELECT * FROM Tigers WHERE @Member=OwnerId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@Member", LstAdminMembers.SelectedValue);

                //connection.Open();
                
                DataTable Tigertable = new DataTable();
                adapter.Fill(Tigertable);

                LstAdminTigers.DisplayMember = "TigerName";
                LstAdminTigers.ValueMember = "Id";
                LstAdminTigers.DataSource = Tigertable;

            }
        }

        private void LstAdminMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int MemberId = LstAdminMembers.SelectedIndex;
            ShowMemberInfo(MemberId);
            ListTigers();

        }

        

        private void LstAdminTigers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TigerId = LstAdminTigers.SelectedIndex;
            ShowTigerInfo(TigerId);
        }

        private void AdminControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
