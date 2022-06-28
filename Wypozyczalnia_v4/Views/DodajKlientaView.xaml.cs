using System.Windows;
using System.Windows.Controls;
using Wypozyczalnia_v4.DbCon;
using System.Data.SqlClient;
using System.Data;

namespace Wypozyczalnia_v4.Views
{
    /// <summary>
    /// Interaction logic for DodajKlientaVIew.xaml
    /// </summary>
    public partial class DodajKlientaVIew : UserControl
    {
        string connectionString = @"Data Source=DESKTOP-QR4BK4H;Initial Catalog=Wypozyczalnia;Integrated Security=True";

        public DodajKlientaVIew()
        {
            InitializeComponent();

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from Klienci", connection);
            connection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();

            KlienciDataGrid.DataContext = dt;
        }
        private void ButtonDodajKlienta_Click(object sender, RoutedEventArgs e)
        {

            using (WypozyczalniaContext db = new WypozyczalniaContext(connectionString))
            {
                db.Add(new Klient { Imie = BoxImie.Text, Nazwisko = BoxNazwisko.Text, PESEL = BoxPesel.Text, Email = BoxEmail.Text, Telefon = BoxTelefon.Text });
                db.SaveChanges();

            }
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from Klienci", connection);
            connection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();

            KlienciDataGrid.DataContext = dt;
        }

        private void ButtonUsunKlienta_Click(object sender, RoutedEventArgs e)
        {

            using (WypozyczalniaContext db = new WypozyczalniaContext(connectionString))
            {
                db.Remove(new Klient {Id = BoxID.Text });
                db.SaveChanges();

            }
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from Klienci", connection);
            connection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();

            KlienciDataGrid.DataContext = dt;
        }
    }   
}
