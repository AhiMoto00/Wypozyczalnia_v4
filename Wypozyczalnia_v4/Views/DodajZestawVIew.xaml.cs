using System.Windows;
using System.Windows.Controls;
using Wypozyczalnia_v4.DbCon;
using System.Data.SqlClient;
using System.Data;
namespace Wypozyczalnia_v4.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Page1.xaml
    /// </summary>
    public partial class DodajZestawVIew : UserControl
    {
        string connectionString = @"Data Source=DESKTOP-QR4BK4H;Initial Catalog=Wypozyczalnia;Integrated Security=True";

        public DodajZestawVIew()
        {
            InitializeComponent();

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmdNarty = new SqlCommand("Select * from Narty", connection);
            SqlCommand cmdKijki = new SqlCommand("Select * from Kijki", connection);
            SqlCommand cmdKaski = new SqlCommand("Select * from Kaski", connection);
            SqlCommand cmdButy = new SqlCommand("Select * from Buty", connection);
            connection.Open();
            DataTable dtNarty = new DataTable();
            DataTable dtKijki = new DataTable();
            DataTable dtKaski = new DataTable();
            DataTable dtButy = new DataTable();
            dtNarty.Load(cmdNarty.ExecuteReader());
            dtKijki.Load(cmdKijki.ExecuteReader());
            dtKaski.Load(cmdKaski.ExecuteReader());
            dtButy.Load(cmdButy.ExecuteReader());
            connection.Close();

            DataGridNarty.DataContext = dtNarty;
            DataGridKijki.DataContext = dtKijki;
            DataGridKaski.DataContext = dtKaski;
            DataGridButy.DataContext = dtButy;
        }

        private void ButtonDodajZestaw_Click(object sender, RoutedEventArgs e)
        {

            using (WypozyczalniaContext db = new WypozyczalniaContext(connectionString))
            {
                db.Add(new ZestawC { NartyID = BoxNarty.Text, ButyID = BoxButy.Text, KaskiID = BoxKask.Text, KijkiID = BoxKij.Text});
                db.SaveChanges();
             
            }
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmdZestaw = new SqlCommand("Select * from Zestaw", connection);
            connection.Open();

            DataTable dtZestaw = new DataTable();
            dtZestaw.Load(cmdZestaw.ExecuteReader());
            connection.Close();

            DataGridZestaw.DataContext = dtZestaw;
        }


        private void ButtonUsunZestaw_Click(object sender, RoutedEventArgs e)
        {

            using (WypozyczalniaContext db = new WypozyczalniaContext(connectionString))
            {
                db.Remove(new ZestawC { Id = BoxUsun.Text });
                db.SaveChanges();

            }
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmdZestaw = new SqlCommand("Select * from Zestaw", connection);
            connection.Open();

            DataTable dtZestaw = new DataTable();
            dtZestaw.Load(cmdZestaw.ExecuteReader());
            connection.Close();

            DataGridZestaw.DataContext = dtZestaw;
        }
    }
}
