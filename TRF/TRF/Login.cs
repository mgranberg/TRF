using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Inkluderat Sql och system.configuration då jag behöver ha kontakt med min databas

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
            //Klickar på nu avnändare: Gömmer fönstret och skapar ett nytt och visar detta.
            this.Hide();
            NewMember NM = new NewMember();
            NM.ShowDialog();
        }

        //Klickar på logga in.
        public void BtnLogin_Click(object sender, EventArgs e)
        {
            //En login Metod körs.
            LoginMethod();
        }

        //Login Metoden
        private void LoginMethod()
        {
            //Hämtar användarnamn och lösenord och sparar dom i variablar
            string username = this.TxtLoginUserName.Text;
            string pass = this.TxtLoginPass.Text;

            //Om Användarnamn och lösen är tomma
            if (username == "" && username == "")
            {
                //Varning
                MessageBox.Show("Du måste fylla i båda fälten för att logga in!");
            }
            //Om Användarnamn är tomt
            else if (username == "" && pass != "")
            {
                //Varning
                MessageBox.Show("Du måste mata in ett användarnamn!");
            }
            //Om Lösen är tomt
            else if (pass == "" && username != "")
            {
                //Varning
                MessageBox.Show("Du måste mata in ett lösenord!");
            }
            //Om Användarnamn är admin (versaler är obetydliga då jag använder mig av string.ToLower(); som gör strängen till gemener.
            else if (username.ToLower() == "admin")
            {
                //Om lösen är Admin123 (Exakt matchning viktig)
                if(pass == "Admin123")
                {
                    //Göm detta fönster och skapa AdminControl och öppna det.
                    this.Hide();
                    AdminControl admin = new AdminControl();
                    admin.ShowDialog();
                }
                //Om lösenordet är fel
                else
                {
                    //Varning
                    MessageBox.Show("Du försöker logga in som administratör men har matat in ett felaktigt lösenord.");
                }
            }
            //Om en medlem försöker logga in:
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
