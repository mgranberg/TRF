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
        public string connectionString;

        public AdminControl()
        {
            InitializeComponent();

        }

        private void BtnAdminLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
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
                TxtAdminMemberId.Text = datarow[0].ToString();
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

        private void BtnAdminEditMember_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Members SET FirstName = @FirstName, LastName = @LastName, Address = @Address, Email = @Email, UserName = @UserName"
                + ", Password = @Password WHERE Id = @Member";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@Member", LstAdminMembers.SelectedValue);
                command.Parameters.AddWithValue("@FirstName", TxtAdminMemberFirstName.Text);
                command.Parameters.AddWithValue("@LastName", TxtAdminMemberLastName.Text);
                command.Parameters.AddWithValue("@Address", TxtAdminMemberAddress.Text);
                command.Parameters.AddWithValue("@Email", TxtAdminMemberEmail.Text);
                command.Parameters.AddWithValue("@UserName", TxtAdminMemberUserName.Text);
                command.Parameters.AddWithValue("@Password", TxtAdminMemberPass.Text);

                command.ExecuteScalar();
            }

            ListMembers();
        }

        private void BtnAdminEditTiger_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Tigers SET TigerName = @TigerName, TigerAge = @TigerAge, Species = @Species"
                + " WHERE Id = @Tiger";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@Tiger", LstAdminTigers.SelectedValue);
                command.Parameters.AddWithValue("@TigerName", TxtAdminTigerName.Text);
                command.Parameters.AddWithValue("@TigerAge", TxtAdminTigerAge.Text);
                command.Parameters.AddWithValue("@Species", TxtAdminTigerSpecies.Text);

                command.ExecuteScalar();
            }

            ListTigers();
        }

        private void BtnAdminAddMember_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminAddMember add = new AdminAddMember();
            add.ShowDialog();
        }

        private void BtnAdminAddTiger_Click(object sender, EventArgs e)
        {

            this.Hide();
            AdminAddTiger addT = new AdminAddTiger(LstAdminMembers.SelectedValue);
            addT.ShowDialog();
            addT.GetOwner(LstAdminMembers.SelectedValue);
        }

        private void BtnAdminRemoveMember_Click(object sender, EventArgs e)
        {
            string medlem = TxtAdminMemberFirstName.Text.ToString() + " " + TxtAdminMemberLastName.Text.ToString();
            var confirm = MessageBox.Show("Du håller på att radera medlemmen: " + medlem + "\n Är du säker på att du vill fortsätta?", "Varning!", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                string query = "DELETE FROM Members"
                    + " WHERE Id = @Member";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@Member", LstAdminMembers.SelectedValue);

                    command.ExecuteScalar();
                    ListMembers();
                }
            }
        }

        private void BtnAdminRemoveTiger_Click(object sender, EventArgs e)
        {
            string tiger = TxtAdminTigerName.Text.ToString();
            var confirm = MessageBox.Show("Du håller på att radera Tigern: " + tiger + "\n Är du säker på att du vill fortsätta?", "Varning!", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                string query = "DELETE FROM Tigers"
                    + " WHERE Id = @Tiger";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@Tiger", LstAdminTigers.SelectedValue);

                    command.ExecuteScalar();
                    ListTigers();
                }
            }
        }
    }
}

