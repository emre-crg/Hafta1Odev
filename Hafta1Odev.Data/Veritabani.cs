using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta1Odev.Data
{
    public class Veritabani
    {
        SqlConnection Conn;
        public Veritabani()
        {
            Conn = new SqlConnection(@"Data Source=DESKTOP-F0CFL0E;Initial Catalog=HbUrun;Integrated Security=True");
        }

        public List<UrunModel> TumUrunler()

        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Urunler", Conn);

            SqlDataReader dr = cmd.ExecuteReader();


            List<UrunModel> urunler = new List<UrunModel>();
            while (dr.Read())
            {
                UrunModel urun = new UrunModel();
                urun.Id = Convert.ToInt32(dr[0]);
                urun.UrunAdi = dr["UrunAdi"].ToString();
                urun.Renk = dr.GetString(2); 
                urun.Fiyat = dr.GetDecimal(3);

                urunler.Add(urun);

            }

            Conn.Close();

            return urunler;
        }

        public UrunModel UrunAra(int id)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Urunler WHERE Id=@ID", Conn);

            cmd.Parameters.AddWithValue("@ID", id);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            UrunModel urun = new UrunModel();
            urun.Id = -1;

            if (dr.HasRows) 
            {
                urun.Id = Convert.ToInt32(dr[0]);
                urun.UrunAdi = dr["UrunAdi"].ToString();
                urun.Renk = dr.GetString(2); 
                urun.Fiyat = dr.GetDecimal(3); 

            }
            Conn.Close();

            return urun;
        }

        public void UrunEkle(UrunModel urun)
        {
            Conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Urunler VALUES(@UrunAdi,@Renk,@Fiyat)", Conn);

            cmd.Parameters.AddWithValue("@UrunAdi", urun.UrunAdi);
            cmd.Parameters.AddWithValue("@Renk", urun.Renk);
            cmd.Parameters.AddWithValue("@Fiyat", urun.Fiyat);

            cmd.ExecuteNonQuery();
            Conn.Close();
        }

        public void UrunSil(int id)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Urunler WHERE Id=@ID", Conn);

            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();

            Conn.Close();

        }

        public void UrunDüzenle(int id, UrunModel urun)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Urunler SET UrunAdi=@UrunAdi, Renk=@Renk, Fiyat=@Fiyat WHERE Id=@ID", Conn);

            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@UrunAdi", urun.UrunAdi);
            cmd.Parameters.AddWithValue("@Renk", urun.Renk);
            cmd.Parameters.AddWithValue("@Fiyat", urun.Fiyat);

            cmd.ExecuteNonQuery();

            Conn.Close();

        }
    }
}
