using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace TRF
{
    public partial class MemberControl : Form
    {
        //Deklarerar en connectionstring som används för uppkoppling mot databas
        public string connectionString = ConfigurationManager.ConnectionStrings["TRF.Properties.Settings.TRFMembersConnectionString"].ConnectionString;
        //Deklarerar en variabel som kan hålla medlemens Id
        public int Id;
        //En metod som kan ta emot medlemens id från andra klasser.
        public void MemberId(object id)
        {
            //Omvandlar Id objektet till en int
            Id = int.Parse(id.ToString());
        }

        public MemberControl()
        {
            InitializeComponent();
        }
        //Avslutar applikationen om fönstret stängs
        private void MemberControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //När fönstret laddas
        private void MemberControl_Load(object sender, EventArgs e)
        {
            //Kör metod för att lista medlemmens tigrar.
            ListTigers();
        }
        //När en tiger markeras i listan(även när det först laddas)
        private void LstMemberTigers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Kör metod för att visa info om vald tiger.
            ShowTigerInfo();
        }

        //Metod för att lista tigrarna
        private void ListTigers()
        {
            //Jag börjar med att deklarera min sql-query i en variabel
            //Översätter man queryn så står det i stort sätt: VÄLJ alla(rader) från Tigers(tabellen med alla tigrar)
            //där variabeln Member är lika med kolumnen OwnerId:s värde.
            string query = "SELECT * FROM Tigers WHERE @Member=OwnerId";
            //för att kunna använda sig av variablar i sql kommandot så räcker det inte med en adapter utan vi måste använda oss av sqlcommand
            //som vi sen använder i vår adapter
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {

                //Värdet är den samma som Id på medlemmen och eftersom databasen är uppbyggd så att OwnerId är samma som Id på ägaren,
                //Kan man på detta sätt sålla så att man bara får fram de tigrar som ägs av den markerade medlemmen.
                
                command.Parameters.AddWithValue("@Member", Id);

                //Här händer samma sak som när medlemmarna listas, dock med andra värden.
                DataTable Tigertable = new DataTable();
                adapter.Fill(Tigertable);

                LstMemberTigers.DisplayMember = "TigerName";
                LstMemberTigers.ValueMember = "Id";
                LstMemberTigers.DataSource = Tigertable;

            }
        }

        //Visar vald tigers information
        private void ShowTigerInfo()
        {
            //Samma procedur som för att lista tigrarna:
            string query = "SELECT * FROM Tigers WHERE @Member=OwnerId";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@Member", Id);

                //Ett datatable fylls
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                //Tigerns id tar fram markerat index
                int TigerId = LstMemberTigers.SelectedIndex;
                //På så sätt så hittar vi rätt vald tiger i tabellen med index
                DataRow datarow = datatable.Rows[TigerId];
                //Här väljs vilka kolumner som ska visas i respektive fält
                TxtMemberTigerName.Text = datarow[2].ToString();
                TxtMemberTigerAge.Text = datarow[3].ToString();
                TxtMemberTigerSpecies.Text = datarow[4].ToString();
            }
        }

        //Uppdaterar informationen om vald tiger
        private void BtnUpdateTiger_Click(object sender, EventArgs e)
        {
            //En query som uppdaterar informationen i de valda kolumnerna med de inmatade variablarna.
            string query = "UPDATE Tigers SET TigerName = @TigerName, TigerAge = @TigerAge, Species = @Species WHERE Id = @TigerId";

            //Öpnar kommunikation med databas
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                //Öppnar uppkoppling
                connection.Open();

                //Specificerar parametrar.
                command.Parameters.AddWithValue("@TigerName", TxtMemberTigerName.Text);
                command.Parameters.AddWithValue("@TigerAge", TxtMemberTigerAge.Text);
                command.Parameters.AddWithValue("@Species", TxtMemberTigerSpecies.Text);
                command.Parameters.AddWithValue("@TigerId", LstMemberTigers.SelectedValue);

                //Skickar parametrar till SQL kommando
                command.ExecuteScalar();
                //Listar tigrar igen för att uppdatera lista och därmed också informationen.
                ListTigers();
            }
        }

        //Raderar vald tiger
        private void BtnMemberDeleteTiger_Click(object sender, EventArgs e)
        {
            //skapar en sträng med namn på tigern som är vald
            string tiger = TxtMemberTigerName.Text;
            //Skapar en MessageBox med en sträng som frågar om man är säker, en label som varnar och två alternativ, Yes/No
            var confirm = MessageBox.Show("Du håller på att radera tigern: " + tiger + "\n Är du säker på att du vill fortsätta?", "Varning!", MessageBoxButtons.YesNo);

            //Om man väljer Yes:
            if (confirm == DialogResult.Yes)
            {
                //SQL-query
                string query = "DELETE FROM Tigers WHERE Id = @TigerId";

                //Öppnar en connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    
                    command.Parameters.AddWithValue("@TigerId", LstMemberTigers.SelectedValue);

                    command.ExecuteScalar();

                    //rensar fälten, detta för att dom ska vara tomma om det inte finns några tigrar kvar.
                    TxtMemberTigerAge.Text = "";
                    TxtMemberTigerName.Text = "";
                    TxtMemberTigerSpecies.Text = "";

                    ListTigers();

                }
            }
            
        }

        //Lägger till ny tiger
        private void BtnMemberAddTiger_Click(object sender, EventArgs e)
        {
            //SQL-query
            string query = "INSERT INTO Tigers VALUES (@OwnerId, @Name, @Age, @Species)";

            //Öppnar en connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                //Hämtar inmatad data från fälten och sparar i variablar.
                string name = TxtMemberAddTigerName.Text;
                string species = TxtMemberAddTigerSpecies.Text;
                //Sätter åldern till -1 som utgångsläge då en tiger inte kommer vara -1 år gammal
                int age = -1;
                //Omvandlara inmatad data till en int
                int.TryParse(TxtMemberAddTigerAge.Text, out age);
                //Om det inte går att omvandla data så betyder det att något annat än en siffra är inmatad
                if (!int.TryParse(TxtMemberAddTigerAge.Text, out age))
                {
                    //Varning
                    MessageBox.Show("Åldern måste vara en siffra!");
                }
                //Om något av fälten är tomma
                else if (name == "" || species == "" || age == -1)
                {
                    //Varning
                    MessageBox.Show("Alla fält måste vara ifyllda!");
                }
                //Om allt är som det ska
                else
                {
                    //Parametrar skickas till SQL-kommando
                    command.Parameters.AddWithValue("@OwnerId", Id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Age", age);
                    command.Parameters.AddWithValue("@Species", species);

                    command.ExecuteScalar();

                    //Tigrar listas igen för att uppdatera i realtid
                    ListTigers();
                    //Alla fält sätts till blankt för att tömma dom.
                    TxtMemberAddTigerSpecies.Text = "";
                    TxtMemberAddTigerAge.Text = "";
                    TxtMemberAddTigerName.Text = "";
                }
            }
        }
        //Metod för att logga ut.
        private void BtnMemberLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void WikiLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://sv.wikipedia.org/wiki/Tiger");
        }
    }
}
