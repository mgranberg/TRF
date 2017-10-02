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
    public partial class AdminControl : Form
    {
        //Här deklarerar jag en variabel för connectionstring som kan ses som en address till databasen.
        public string connectionString = ConfigurationManager.ConnectionStrings["TRF.Properties.Settings.TRFMembersConnectionString"].ConnectionString;

        public AdminControl()
        {
            InitializeComponent();
        }
        
        //Klick-event för att logga ut ur admin-läget.
        private void BtnAdminLogout_Click(object sender, EventArgs e)
        {
            //Detta gömmer det öppna fönstret.
            this.Hide();
            //Detta skapar en ny instans av inloggnings-fönstret.
            Login login = new Login();
            //Detta visar det nya fönstret.
            login.ShowDialog();
        }
        
        private void AdminControl_Load(object sender, EventArgs e)
        {
            //Denna metod körs när fönstret laddas, den listar upp alla medlemar i listboxen.
            ListMembers();
        }

        private void ListMembers()
        {
            //Denna metod listar medlemarna i listboxen.
            //Jag använder ett using statement för att koppla upp mig mot databasen för att då öppnas och stängs uppkopplingen automatiskt.

            //Här skapas en ny instans av en sql uppkoppling med hjälp av connectionstringen jag deklarerade tidigare.
            using (SqlConnection connection = new SqlConnection(connectionString))
            //Här skapas en ny instans av en sql data adapter där som tar hand om kommunikationen med databasen.
            //Detta görs med att först mata in ett command till databasen med hjälp av en SQL query, och även vilken uppkoppling som ska användas.
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Members", connection))
            {
                //Här skapas ett nytt datatable vilket är en lokal tabell.
                DataTable datatable = new DataTable();
                //här fyller jag tabellen med det som hämtats med adaptern.
                adapter.Fill(datatable);

                //Här väljer jag ut min listbox och deklarerar lite egenskaper för hur/vilken data som ska visas.
                LstAdminMembers.DisplayMember = "FirstName";
                LstAdminMembers.ValueMember = "Id";
                LstAdminMembers.DataSource = datatable;
            }
        }

        private void ListTigers()
        {
            //Här händer i stort sätt samma sak som när medlemsinfon hämtas dock med ett undantag.

            //Jag börjar med att deklarera min sql-query i en variabel då den är lite längre.
            //Översätter man queryn så står det i stort sätt: VÄLJ alla(rader) från Tigers(tabellen med alla tigrar)
            //där variabeln Member är lika med kolumnen OwnerId:s värde.
            string query = "SELECT * FROM Tigers WHERE @Member=OwnerId";
            //för att kunna använda sig av variablar i sql kommandot så räcker det inte med en adapter utan vi måste använda oss av sqlcommand
            //som vi sen användet i vår adapter
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                //Här deklareras vad variabeln Member ska vara, detta hämtas då från värdet av den valda medlemmen i den listan.
                //Värdet är den samma som Id på medlemmen och eftersom databasen är uppbyggd så att OwnerId är samma som Id på ägaren,
                //Kan man på detta sätt sålla så att man bara får fram de tigrar som ägs av den markerade medlemmen.
                command.Parameters.AddWithValue("@Member", LstAdminMembers.SelectedValue);
                
                //Här händer samma sak som när medlemmarna listas, dock med andra värden.
                DataTable Tigertable = new DataTable();
                adapter.Fill(Tigertable);

                LstAdminTigers.DisplayMember = "TigerName";
                LstAdminTigers.ValueMember = "Id";
                LstAdminTigers.DataSource = Tigertable;

            }
        }

        private void ShowMemberInfo(int Id)
        {
            //Denna metod fyller informationsfälten för den valda medlemmen.

            //Precis samma sak som när medlemslistan fylls så öppnas här en connection till databasen.
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Members", connection))
            {
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);

                //Här skapas en datarow vilket är en rad i tabellen, vilken rad bestäms av variabeln "Id" som har skickats med när metoden kallades.
                //då denna variabel bestämmer rad i tabellen bestämmer den alltså vilken användares info som ska visas, och vi vill ju att rätt info ska visas.
                DataRow datarow = datatable.Rows[Id];

                /*Här fyller jag de olika textfälten på sidan med respektive information 
                genom att deklarera vilken kolumn som innehåller rätt info och sen omvandlar jag detta till en sträng*/
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
            //Samma procedur som för att lista tigrarna:
            string query = "SELECT * FROM Tigers WHERE @Member=OwnerId";

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@Member", LstAdminMembers.SelectedValue);

                //Nedanstående är precis samma som för medlemsinfon, dock med andra fält.
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);

                DataRow datarow = datatable.Rows[Id];

                TxtAdminTigerName.Text = datarow[2].ToString();
                TxtAdminTigerAge.Text = datarow[3].ToString();
                TxtAdminTigerSpecies.Text = datarow[4].ToString();
            }
        }
        
        //Denna metod körs när valet i medlemslistan ändras, När den fylls och när man markerar en ny medlem.
        private void LstAdminMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Först sparas en variabel med medlemsid genom att spara indexet på den valda medlemen.
            //Anledningen till att jag inte tar selected value är att jag vill ha en int och indexen har ändå samma värde. 
            int MemberId = LstAdminMembers.SelectedIndex;
            //Här kallas metoden för att visa info om den valda medlemmen och Id:t skickas med så att rätt info visas.
            ShowMemberInfo(MemberId);
            //Här kallas metoden för att lista medlemmens tigrar.
            ListTigers();

        }
        
        //Samma sak här som för medlemslistan men med tigerlistan.
        private void LstAdminTigers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TigerId = LstAdminTigers.SelectedIndex;
            ShowTigerInfo(TigerId);
        }

        //denna metod har jag lagt till för att programmet ska avslutas helt när man stänger det då det annars kör en process i bakgrunden
        //Detta händer för att formuläret stängs men applikationen avslutas inte.
        private void AdminControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Denna metod körs när man klickar på uppdatera info för medlemmen.
        private void BtnAdminEditMember_Click(object sender, EventArgs e)
        {
            //En variabel för sql-query där man uppdaterar databasen med det olika variablerna
            //men ändast de rader där Id stämmer med den valda medlemmen, alltså ändrar man bara den medlemmen man valt.
            string query = "UPDATE Members SET FirstName = @FirstName, LastName = @LastName, Address = @Address, Email = @Email, UserName = @UserName"
                + ", Password = @Password WHERE Id = @Member";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                //När man vill ändra eller lägga till data i databasen måste man öppna kopplingen själv.
                connection.Open();

                //Här matas värdet in i variablarna till sql-queryn
                command.Parameters.AddWithValue("@Member", LstAdminMembers.SelectedValue);
                command.Parameters.AddWithValue("@FirstName", TxtAdminMemberFirstName.Text);
                command.Parameters.AddWithValue("@LastName", TxtAdminMemberLastName.Text);
                command.Parameters.AddWithValue("@Address", TxtAdminMemberAddress.Text);
                command.Parameters.AddWithValue("@Email", TxtAdminMemberEmail.Text);
                command.Parameters.AddWithValue("@UserName", TxtAdminMemberUserName.Text);
                command.Parameters.AddWithValue("@Password", TxtAdminMemberPass.Text);

                //Detta kommando verkställer ändringarna.
                command.ExecuteScalar();
            }
            //efter ändringar gjorts så listas medlemarna på nytt så att listan uppdateras  och då även informationsfälten.
            ListMembers();
        }

        //Denna metod gör exakt samma sak för tigrarna.
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

        //Denna metod kallas när man klickar på lägg till medlem
        private void BtnAdminAddMember_Click(object sender, EventArgs e)
        {
            //Gömmer nuvaranade fönster
            this.Hide();
            //Skapar en ny instans av AddMember form.
            AdminAddMember add = new AdminAddMember();
            //visar detta fönster.
            add.ShowDialog();
        }

        //samma sak som lägg till medlem.
        private void BtnAdminAddTiger_Click(object sender, EventArgs e)
        {

            this.Hide();
            //en ny instans av AddTiger skapas med medskickad information om vald medlem.
            AdminAddTiger addT = new AdminAddTiger(LstAdminMembers.SelectedValue);
            addT.ShowDialog();
        }

        //Denna metod körs när man klickar på radera ta bort användare
        private void BtnAdminRemoveMember_Click(object sender, EventArgs e)
        {
            //skapar en sträng med för och efternamn på medlemen som är vald
            string medlem = TxtAdminMemberFirstName.Text.ToString() + " " + TxtAdminMemberLastName.Text.ToString();
            //Skapar en MessageBox med en sträng som frågar om man är säker, en label som varnar och två alternativ, Yes/No
            var confirm = MessageBox.Show("Du håller på att radera medlemmen: " + medlem + "\n Är du säker på att du vill fortsätta?", "Varning!", MessageBoxButtons.YesNo);

            //Om man väljer Yes:
            if (confirm == DialogResult.Yes)
            {
                //Query som raderar en rad från databasen där Id stämmer med vald medlem
                string query = "DELETE FROM Members"
                    + " WHERE Id = @Member";

                //Allt detta är som vanligt
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //Även här måste vi öppna kopplingen manuellt då vi ska påverka databasen.
                    connection.Open();

                    command.Parameters.AddWithValue("@Member", LstAdminMembers.SelectedValue);

                    command.ExecuteScalar();
                    //Åter igen listar vi medlemarna för att uppdatera listan.
                    ListMembers();
                }
            }
            //Om man väljer No så händer inget och dialog-rutan stängs igen.
        }

        //Precis samma som för att radera en medlem men såklart med andra variabler.
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

        private void WikiLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://sv.wikipedia.org/wiki/Tiger");
        }
    }
}

