using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia_v4.DbCon
{
    class WypozyczalniaContext : DbContext
    {
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<PracownicyC> Pracownicy { get; set; }
        public DbSet<ButyC> Buty { get; set; }
        public DbSet<KaskiC> Kaski { get; set; }
        public DbSet<KijkiC> Kijki { get; set; }
        public DbSet<NartyC> Narty { get; set; }
        public DbSet<WypożyczoneC> Wypożyczone { get; set; }
        public DbSet<ZestawC> Zestaw { get; set; }
        public DbSet<StatusyC> Statusy { get; set; }

        public string ConnectionString { get; }

        public WypozyczalniaContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(this.ConnectionString);
        }
    }


    public class Klient
    {
        public string Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string PESEL { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
    }

    public class PracownicyC
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Telefon { get; set; }
    }

    public class ButyC
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int Rozmiar { get; set; }
        public int StatusID { get; set; }
        public decimal Cena { get; set; }
    }

    public class KaskiC
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Rozmiar { get; set; }
        public int StatusID { get; set; }
        public decimal Cena { get; set; }
    }

    public class KijkiC
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int Długość { get; set; }
        public int StatusID { get; set; }
        public decimal Cena { get; set; }
    }

    public class NartyC
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int Długość { get; set; }
        public int StatusID { get; set; }
        public decimal Cena { get; set; }
    }

    public class StatusyC
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
    }

    public class WypożyczoneC
    {
        public int Id { get; set; }
        public int KlienicID { get; set; }
        public int ZestawID { get; set; }
        public DateTime Wypożyczenia { get; set; }
        public DateTime DataOddania { get; set; }
        public int PracownikID { get; set; }
        public decimal KworaDoZapłaty { get; set; }
    }

    public class ZestawC
    {
        public string Id { get; set; }
        public string NartyID { get; set; }
        public string ButyID { get; set; }
        public string KaskiID { get; set; }
        public string KijkiID { get; set; }
        public string CenaZestawu { get; set; }
    }
}

