using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary1.Entity;

namespace ClassLibrary1.Facade
{
   public class Üretimler
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("listeleUretim", Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public static bool Sil(Uretim usil)
        {
            SqlCommand sil = new SqlCommand("UretimSil", Tools.Baglanti);
            sil.CommandType = CommandType.StoredProcedure;
            sil.Parameters.AddWithValue("UNo", usil.UNo);
            return Tools.ExecuteNonQuery(sil);
        }

        public static bool Ekle(Uretim uekle)
        {
            SqlCommand ekle = new SqlCommand("ekleUretim", Tools.Baglanti);
            ekle.CommandType = CommandType.StoredProcedure;
            ekle.Parameters.AddWithValue("UAdi", uekle.UNo);
            ekle.Parameters.AddWithValue("USehir", uekle.USehir);
            ekle.Parameters.AddWithValue("UMiktar", uekle.UMiktar);
            return Tools.ExecuteNonQuery(ekle);
        }
        public static bool Yenile(Uretim güncelle)
        {
            SqlCommand güncelleKOMUT = new SqlCommand("güncelleUretim", Tools.Baglanti);
            güncelleKOMUT.CommandType = CommandType.StoredProcedure;
            güncelleKOMUT.Parameters.AddWithValue("UNo", güncelle.UNo);
            güncelleKOMUT.Parameters.AddWithValue("UAdi", güncelle.UAdi);
            güncelleKOMUT.Parameters.AddWithValue("USehir", güncelle.USehir);
            güncelleKOMUT.Parameters.AddWithValue("UMiktar", güncelle.UMiktar);
            return Tools.ExecuteNonQuery(güncelleKOMUT);
        }

    }
}
