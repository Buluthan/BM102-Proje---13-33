using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace lokanta
{
    class cRezervasyon
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _ID;
        private int _TableId;
        private int _ClientId;
        private DateTime _Date;
        private int _CleintCount;
        private string _Description;
        private int _AdditionId;
        #endregion

        #region Properties

        public int TableId
        {
            get { return _TableId; }
            set { _TableId = value; }
        }

        public int ClientId
        {
            get { return _ClientId; }
            set { _ClientId = value; }
        }

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        public int AdditionId
        {
            get { return _AdditionId; }
            set { _AdditionId = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }


        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public int CleintCount
        {
            get { return _CleintCount; }
            set { _CleintCount = value; }
        }

        #endregion

        //MusteriId masa numarasına göre    
        public int getByClientIdFromRezervasyon(int tableId)
        {
            int clientId = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 MUSTERIID from Rezervasyonlar where MASAID=@masaid order by MUSTERIID Desc", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("masaid", SqlDbType.Int).Value = tableId;

                clientId = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            finally
            {
                con.Dispose();
                con.Close();
            }
            return clientId;
        }

        //Hesap kapatırken rezervasyonlu masayı kapattık
        public bool rezervationclose(int adisyonID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Rezervasyonlar set durum =0 where ADISYONID=@adisyonId", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("adisyonId", SqlDbType.Int).Value = adisyonID;
                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            finally
            {
                con.Dispose();
                con.Close();
            }
            return result;

        }

        //Rezervasyonları getir
        public void musteriIdGetirFromRezervasyon(ListView lv)
        {

            lv.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select Rezervasyonlar.MUSTERIID,(AD+SOYAD) as musteri from Rezervasyonlar Inner Join musteriler on Rezervasyonlar.MUSTERIID=musteriler.ID where Rezervasyonlar.Durum=0", conn);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = comm.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["MUSTERIID"].ToString());
                lv.Items[i].SubItems.Add(dr["musteri"].ToString());
                i++;
            }

            dr.Close();
            conn.Dispose();
            conn.Close();

        }

        //Eski Rezervasyonları getir	
        public void eskiRezervasyonlariGetir(ListView lv, int mId)
        {

            lv.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select Rezervasyonlar.MUSTERIID,AD,SOYAD,ADISYONID,TARIH from Rezervasyonlar Inner Join musteriler on Rezervasyonlar.MUSTERIID = musteriler.ID where Rezervasyonlar.MUSTERIID = @mId and Rezervasyonlar.Durum = 0 order by rezervasyonlar.ID Desc ", conn);

            comm.Parameters.Add("mId", SqlDbType.Int).Value = mId;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = comm.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["MUSTERIID"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["TARIH"].ToString());
                lv.Items[i].SubItems.Add(dr["ADISYONID"].ToString());

                i++;
            }

            dr.Close();
            conn.Dispose();
            conn.Close();

        }

        //En Son Rezervasyon Tarihini Getir  //return istiyo SIKINTI VAR    
        public DateTime EnSonRezervasyonTarihi(int mId)
        {
            DateTime tar = new DateTime();
            tar = DateTime.Now;

            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select TARIH from Rezervasyonlar where Rezervasyonlar.MUSTERIID=@mId and Rezervasyonlar.Durum=1 order by rezervasyonlar.ID Desc", conn);

            comm.Parameters.Add("mId", SqlDbType.Int).Value = mId;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            tar = Convert.ToDateTime(comm.ExecuteScalar());

            conn.Dispose();
            conn.Close();

            return tar; //emin değilim ben bi sonradan yazdım

        }

        //Rezervasyon Açık mı kontrolü
        public bool RezervasyonAcikmiKontrol(int mId)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 Rezervasyonlar.ID from Rezervasyonlar where MUSTERIID=@mId and durum=1 order by ID desc", con);
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("mId", SqlDbType.Int).Value = mId;
                result = Convert.ToBoolean(cmd.ExecuteScalar());

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return result;
        }

        //Rezervasyon Aç
        public bool RezervasyonAc(cRezervasyon r)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Rezervasyonlar (MUSTERIID,MASAID,ADISYONID,KISISAYISI,TARIH,ACIKLAMA,DURUM) values (@MUSTERIID,@MASAID,@ADISYONID,@KISISAYISI,@TARIH,@ACIKLAMA,1)", con);

            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("MUSTERIID", SqlDbType.Int).Value = r._ClientId;
                cmd.Parameters.Add("MASAID", SqlDbType.Int).Value = r._TableId;
                cmd.Parameters.Add("ADISYONID", SqlDbType.Int).Value = r._AdditionId;
                cmd.Parameters.Add("KISISAYISI", SqlDbType.Int).Value = r._CleintCount;
                cmd.Parameters.Add("TARIH", SqlDbType.Date).Value = r._Date;
                cmd.Parameters.Add("ACIKLAMA", SqlDbType.VarChar).Value = r._Description;

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());

            }

            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            finally
            {
                con.Dispose();
                con.Close();
            }

            return result;

        }

        //Rezerve Masanın ID'ni getir.
        public int RezerveMasaIdGetir(int mId)
        {
            int sonuc = 0;

            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select Rezervasyonlar.MASAID from Rezervasyonlar INNER JOIN Adisyonlar on Rezervasyonlar.ADISYONID=Adisyonlar.ID where (Rezervasyonlar.Durum=1) and Adisyonlar.Durum=0 and Rezervasyonlar.MUSTERIID=@mId", conn);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            try
            {
                comm.Parameters.Add("mId", SqlDbType.Int).Value = mId;
                sonuc = Convert.ToInt32(comm.ExecuteNonQuery());
            }
            catch (Exception)
            {
                throw;
            }

            conn.Dispose();
            conn.Close();

            return sonuc;

        }


    }
}
