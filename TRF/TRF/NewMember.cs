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
using System.IO;

namespace TRF
{
    public partial class NewMember : Form
    {
        public NewMember()
        {
            InitializeComponent();
        }

        private void BtnNewAbort_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void NewMember_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BtnNewAdd_Click(object sender, EventArgs e)
        {
            //Här deklarerar jag en variabel för connectionstring som kan ses som en address till databasen.
            string connectionString = ConfigurationManager.ConnectionStrings["TRF.Properties.Settings.TRFMembersConnectionString"].ConnectionString;
            //Jag börjar med att deklarera min sql-query i en variabel då den är lite längre.
            //Översätter man queryn så står det i stort sätt: Lägg till i tabellen Members med värdena (variablar) i den ordning man deklarerat dom
            string query = "INSERT INTO Members VALUES (@FirstName, @LastName, @Address, @Email, @UserName, @Password)";

            //Här skapas en ny instans av en sql uppkoppling med hjälp av connectionstringen jag deklarerade tidigare.
            using (SqlConnection connection = new SqlConnection(connectionString))
            //Här skapas en ny instans av en sql data adapter där som tar hand om kommunikationen med databasen.
            //Detta görs med att först mata in ett command till databasen med hjälp av en SQL query, och även vilken uppkoppling som ska användas.
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                //Eftersom man ska intoducera data till databasen så måste man öppna kopplingen manuellt.
                connection.Open();

                //Deklarerar ett antal variabler med den inmatade informationen om den nya medlemen.
                string FName = TxtNewFirstName.Text;
                string LName = TxtNewLastName.Text;
                string Addr = TxtNewAddress.Text;
                string Email = TxtNewEmail.Text;
                string UName = TxtNewUseName.Text;
                string Pass = TxtNewPass.Text;

                //En if-sats som ska utesluta att något av fälten är tomt.
                if (FName == "" || LName == "" || Addr == "" || Email == "" || UName == "" || Pass == "")
                {
                    //Om något av fälten är tomt så kommer en varning visas.
                    MessageBox.Show("Alla fält måste fyllas i!");
                }
                //Om alla fälten är ifyllda
                else
                {

                    //Skickas variablarna in i sql kommandot.
                    command.Parameters.AddWithValue("@FirstName", FName);
                    command.Parameters.AddWithValue("@LastName", LName);
                    command.Parameters.AddWithValue("@Address", Addr);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@UserName", UName);
                    command.Parameters.AddWithValue("@Password", Pass);

                    command.ExecuteScalar();

                    //Skapar en ny streamwriter, denna class skapar en ny textfil på din dator.
                    TextWriter txt = new StreamWriter("InloggningsuppgifterTRF.txt");

                    //Här fyller jag textfilen med innehåll
                    txt.WriteLine("Ditt Användarnamn: " + UName);
                    txt.WriteLine("Ditt lösen: " + Pass);
                    //Här stänger jag skapandet av textfilen och den sparas med innehåll på datorn.
                    txt.Close();

                    MessageBox.Show("Medlem registrerad! \n Du kan nu logga in. \n En textfil har också sparats på din dator med inloggningsuppgifterna!");


                    //När allt är klart så döljs fönstret
                    this.Hide();
                    //En ny instans av AdminControl skapas
                    Login login = new Login();
                    //Detta fönster visas
                    login.ShowDialog();
                }
            }
        }

        private void WikiLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://sv.wikipedia.org/wiki/Tiger");
        }
    }
}
