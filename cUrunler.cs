using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace lokanta
{
    class cUrunler
    {
        cGenel gnl = new cGenel();

        #region MyRegion
        private int _urunid;
        private int _urunturno;
        private string _urunad;
        private decimal _fiyat;
        private string _aciklama;
        #endregion


        #region property
        public int Urunid { get => _urunid; set => _urunid = value; }
        public int Urunturno { get => _urunturno; set => _urunturno = value; }
        public string Urunad { get => _urunad; set => _urunad = value; }
        public decimal Fiyat { get => _fiyat; set => _fiyat = value; }
        public string Aciklama { get => _aciklama; set => _aciklama = value; }
        #endregion

        //ürün adına göre listeleme
        public void urunleriListeleByUrunAdi(ListView lv, string urunadi)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from urunler Where Durum=0 and URUNAD like '%' +@urunAdi+ '%'", con);

            SqlDataReader dr = null;

            cmd.Parameters.Add("@urunAdi", SqlDbType.VarChar).Value = urunadi;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
                    sayac++;
                }
            }

            catch (SqlException ex)
            {
                string hata = ex.Message;
            }

            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();

            }

        }
       
        //Urun Ekle
        public int urunEkle(cUrunler u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into urunler(URUNAD,KATEGORIID,ACIKLAMA,FIYAT) values(@urunAd,@katId,@aciklama,@fiyat)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@urunAd", SqlDbType.VarChar).Value = u._urunad;
                cmd.Parameters.Add("@katId", SqlDbType.Int).Value = u._urunturno;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = u._aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Money).Value = u._fiyat;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return sonuc;
        }
       
        //Urunler ve kategorileri listele
        public void urunleriListele(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select urunler.*,KATEGORIADI from urunler inner join kategoriler on kategoriler.ID=urunler.KATEGORIID Where urunler.Durum=0", con);

            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    
                    sayac++;
                }
            }

            catch (SqlException ex)
            {
                string hata = ex.Message;
            }

            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();

            }

        }

        //Urunleri Güncelle
        public int urunGuncelle(cUrunler u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update urunler set URUNAD=@urunad,KATEGORIID=katID,ACIKLAMA=@aciklama,FIYAT=@fiyat where ID=@urunID ", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@urunAd", SqlDbType.VarChar).Value = u._urunad;
                cmd.Parameters.Add("@katId", SqlDbType.Int).Value = u._urunturno;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = u._aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Money).Value = u._fiyat;
                cmd.Parameters.Add("@urunID", SqlDbType.Int).Value = u._urunid;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return sonuc;
        }

        //Urunleri Sil
        public int urunSil(cUrunler u,int kat)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString); //Durum ->> ID , ID ->> Durum oldu

            string sql = "Update urunler set Durum=1 where";
            if (kat == 0)
                sql += "KATEGORIID=@urunID";
            else
                sql += "ID=@urunID";

            SqlCommand cmd = new SqlCommand(sql, con);
            
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@urunID", SqlDbType.Int).Value = u._urunid;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return sonuc;
        }

        //ürün ID göre listeleme
        public void urunleriListeleByUrunID(ListView lv, int urunId)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select urunler.*,KATEGORIADI from urunler inner join kategoriler on kategoriler.ID=urunler.KATEGORIID Where urunler.Durum=0 and urunler.KATEGORIID=@urunID ", con);

            SqlDataReader dr = null;

            cmd.Parameters.Add("@urunID", SqlDbType.Int).Value = urunId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());                    
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
                    sayac++;
                }
            }

            catch (SqlException ex)
            {
                string hata = ex.Message;
            }

            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();

            }

        }
       
        //2 tarih arası bütün ürünleri getiriyor
        public void urunleriListeleIstatistiklereGore(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT top 10 dbo. urunler.URUNAD ,sum(dbo.satislar.ADET) as adeti FROM dbo.kategoriler INNER JOIN dbo.urunler ON " +
                "dbo.kategoriler.ID = dbo.urunler.KATEGORIID INNER JOIN dbo.satislarO d bo.urunler.ID = dbo.Satislar.URUNID INNER JOIN " +
                "dbo.adisyonlar ON dbo.Satislar.ADISYONID = dbo.adisyonlar.ID WHERE(CONVERT(datetime, TARIH, 104) BETWEEN CONVERT datetime, '01.01.2013', 104) AND " +
                "CONVERT(datetime, '01.01.2015', 104)) group by dbo.urunler.URUNAD order by adeti desc", con);

            SqlDataReader dr = null;

            cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = Baslangic.Value.ToShortDateString();
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis.Value.ToShortDateString();
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());                   
                    sayac++;
                }
            }

            catch (SqlException ex)
            {
                string hata = ex.Message;
            }

            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
                

            }

        }
       
        //belirli kategoriye ait ürünleri listeliyor
        public void urunleriListeleIstatistiklereGoreUrunId(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis, int urunkatId)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT top 10 dbo. urunler.URUNAD ,sum(dbo.satislar.ADET) as adeti FROM dbo.kategoriler INNER JOIN dbo.urunler ON " +
                "dbo.kategoriler.ID = dbo.urunler.KATEGORIID INNER JOIN dbo.satislarO d bo.urunler.ID = dbo.Satislar.URUNID INNER JOIN " +
                "dbo.adisyonlar ON dbo.Satislar.ADISYONID = dbo.adisyonlar.ID WHERE(CONVERT(datetime, TARIH, 104) BETWEEN CONVERT datetime, '01.01.2013', 104) AND " +
                "CONVERT(datetime, '01.01.2015', 104)) and (dbo.urunler.KATEGORIID=@katId) group by dbo.urunler.URUNAD order by adeti desc", con);

            SqlDataReader dr = null;

            cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = Baslangic.Value.ToShortDateString();
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis.Value.ToShortDateString();
            cmd.Parameters.Add("@katId", SqlDbType.Int).Value = urunkatId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());
                    sayac++;
                }
            }

            catch (SqlException ex)
            {
                string hata = ex.Message;
            }

            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();


            }

        }

    }
}
