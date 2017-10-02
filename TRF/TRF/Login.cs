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

//Inkluderat Sql och system.configuration då jag behöver ha kontakt med min databas

namespace TRF
{
    public partial class Login : Form
    {
        //Här deklarerar jag en variabel för connectionstring som kan ses som en address till databasen.
        public string connectionString = ConfigurationManager.ConnectionStrings["TRF.Properties.Settings.TRFMembersConnectionString"].ConnectionString;

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
                //Denna query söker efter medlemar som matchar det inmatade användarnamnet. LOWER() betyder att versaler inte kommer påverka
                string query = "SELECT * FROM Members WHERE LOWER(UserName) = LOWER(@UserName)";

                //Här skapas en uppkoppling mot databasen med hjälp av connectionsträngen som skapades tidigare.
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    //Här matar vi in data i variabeln för sql queryn
                    command.Parameters.AddWithValue("@UserName", TxtLoginUserName.Text);
                    //Skapar ett nytt datatable
                    DataTable dt = new DataTable();
                    //Adaptern fyller datatablet med den hämtade datan
                    adapter.Fill(dt);
                    
                    //Om det fanns en användare med samma UserName så körs detta kodblock (Vilket betyder att det finns en rad i tabellen (Användaren man matchat med) )
                    if(dt.Rows.Count == 1)
                    {
                        //Skapar en datarow med den första raden (Borde också vara den enda)
                        DataRow dr = dt.Rows[0];

                        //När man hittat en användare så kollar man om lösenordet stämmer med kolumn nr 6 vilket motsvarar Pass. Här letar man efter en exakt matchning
                        if (dr[6].ToString() == TxtLoginPass.Text)
                        {
                            //Om allt stämmer så loggas man in
                            MessageBox.Show("Du har loggat in som " + TxtLoginUserName.Text);
                            this.Hide();
                            MemberControl mc = new MemberControl();
                            mc.MemberId(dr[0]);
                            mc.ShowDialog();
                            
                        }
                        //Om lösenordet är fel
                        else
                        {
                            //Varning!
                            MessageBox.Show("Felaktigt lösenord!");
                        }
                    }
                    //Om mot all förmodan sökningen skulle resultera i fler rader.
                    //Alltså fler användare med samma användarnamn.
                    //Detta ska inte gå att skapa men någon som har tillgång till databasen skulle kunna lägga till det manuellt
                    //Detta är bara en extra säkerhetsåtgärd
                    else if(dt.Rows.Count > 1)
                    {
                        //Varning!, kontakta admin då denna kan radera eller ändra användarnamn
                        MessageBox.Show("Det har blivit något fel och det finns fler användare med det användarnamnet. Kontakta adminitratören för hjälp!");
                    }
                    //Om användarnamnet inte hittas
                    else
                    {
                        //Varning
                        MessageBox.Show("Användarnamnet finns inte!");
                    }
                }
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void WikiLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://sv.wikipedia.org/wiki/Tiger");
        }
    }
}
