using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRF
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnNewUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewMember NM = new NewMember();
            NM.ShowDialog();
        }

        public void BtnLogin_Click(object sender, EventArgs e)
        {
            LoginMethod();
        }

        private void LoginMethod()
        {
            string username = this.TxtLoginUserName.Text;
            string pass = this.TxtLoginPass.Text;

            if (username == "" && username == "")
            {
                MessageBox.Show("Du måste fylla i båda fälten för att logga in!");
            }
            else if (username == "" && pass != "")
            {
                MessageBox.Show("Du måste mata in ett användarnamn!");
            }
            else if (pass == "" && username != "")
            {
                MessageBox.Show("Du måste mata in ett lösenord!");
            }
            else if (username.ToLower() == "admin" && pass == "Admin123")
            {
                this.Hide();
                AdminControl admin = new AdminControl();
                admin.ShowDialog();
            }
            else
            {
                MessageBox.Show("Du har loggat in som användare!");
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
