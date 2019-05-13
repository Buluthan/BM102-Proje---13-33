using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lokanta_Otomasyonu
{
    class cSiparis
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _Id;
        private int _adisyonID;
        private int _urunId;
        private int _adet;
        private int _masaId;
        #endregion


        #region properties
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public int AdisyonID
        {
            get { return _adisyonID; }
            set { _adisyonID = value; }
        }
        public int UrunId
        {
            get { return _urunId; }
            set { _urunId = value; }
        }
        public int Adet
        {
            get { return _adet; }
            set { _adet = value; }
        }
        public int MasaId
        {
            get { return _masaId; }
            set { _masaId = value; }
        }
        #endregion

        //Siparişleri Getir
        public void getByOrder(ListView lv, int AdisyonId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select URUNAD,FIYAT,Satislar.ID,satislar.URUNID,satislar.ADET from satislar Inner Join urunler on Satislar.URUNID=Urunler.ID Where ADISYONID=@AdisyonId", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@AdisyonId", SqlDbType.Int).Value = AdisyonId;
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
                    lv.Items.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNID"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["FIYAT"]) * Convert.ToDecimal(dr["ADET"])));
                    lv.Items[sayac].SubItems.Add(dr["ID"].ToString());

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

        public bool setSaveOrder(cSiparis Bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Satislar(ADISYONID,URUNID,ADET,MASAID,) values(@AdsiyonNo,@UrunId,@Adet,@masaId)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@AdsiyonNo", sqlDbType.Int).Value = Bilgiler.AdisyonID;
                cmd.Parameters.Add("@UrunId", sqlDbType.Int).Value = Bilgiler.UrunId;
                cmd.Parameters.Add("@Adet", sqlDbType.Int).Value = Bilgiler.adet;
                cmd.Parameters.Add("@masaId", sqlDbType.Int).Value = Bilgiler.masaId;
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
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

        public void setDeleteOrder(int satisId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Delete From Satislar Where ID=@SatisID", con);

            cmd.Parameters.Add("@SatisID", sqlDbType.Int).Value = satisId;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }
    }
}
