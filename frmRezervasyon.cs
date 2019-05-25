using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lokanta
{
    public partial class frmRezervasyon : Form
    {
        public frmRezervasyon()
        {
            InitializeComponent();
        }

        private void frmRezervasyon_Load(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.musterileriGetir(lvMusteriler);

            cMasalar masa = new cMasalar();
            masa.MasaKapasitesiveDurumuGetir(cbMasa);

            dtTarih.MinDate = DateTime.Today;
            dtTarih.Format = DateTimePickerFormat.Time;




        }

        private void txtMusteriAd_TextChanged(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.musterigetirAd(lvMusteriler, txtMusteriAd.Text);
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.musterigetirTlf(lvMusteriler, txtMusteriAd.Text);
        }

        private void txtAdres_TextChanged(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.musterigetirAd(lvMusteriler, txtAdres.Text);
        }

        void Temizle()
        {
            txtAdres.Clear();
            txtKisiSayısı.Clear();
            txtMasa.Clear();
            txtTarih.Clear();
            txtAdres.Clear();

        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            cRezervasyon r = new cRezervasyon();

            if (lvMusteriler.SelectedItems.Count > 0)
            {
                bool sonuc = r.RezervasyonAcikmiKontrol(Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text));
                if (!sonuc)
                {
                    if (txtTarih.Text != "")
                    {
                        if (txtKisiSayısı.Text != "")
                        {
                            cMasalar masa = new cMasalar();


                            if (masa.TableGetbyState(Convert.ToInt32(txtMasaNo.Text), 1))
                            {
                                cAdisyon a = new cAdisyon();
                                a.Tarih = Convert.ToDateTime(txtTarih.Text);
                                a.ServisTurNo = 1;
                                a.MasaId = Convert.ToInt32(txtMasaNo.Text);
                                a.PersonelId = cGenel._personelId;

                                r.ClientId = Convert.ToInt32(Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text));
                                r.TableId = Convert.ToInt32(txtMasaNo.Text);
                                r.Date = Convert.ToDateTime(txtTarih.Text);
                                r.CleintCount = Convert.ToInt32(txtKisiSayısı.Text);
                                r.Description = txtAciklama.Text;

                                r.AdditionId = a.RezervasyonAdisyonAc(a);
                                sonuc = r.RezervasyonAc(r);

                                masa.setChangeTableState(txtMasaNo.Text, 3);
                                if (sonuc)
                                {
                                    MessageBox.Show("Rezervasyon Başarıyla Açılmıştır");
                                    Temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Rezervasyon Kayıdı Gerçekleşememiştir. Lütfen Yetkiliyle iletişime geçiniz.");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Rezervasyon Yapılan Masa Şu an Dolu");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen Kişi Sayısı Seçiniz");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen bir tarih seçiniz");

                    }
                }
                else
                {
                    MessageBox.Show("Bu müşteri üzerine açık bir rezervasyon bulunmaktadır.");
                }
            }

        }

        private void dtTarih_MouseEnter(object sender, EventArgs e)
        {
            dtTarih.Width = 200;
        }

        private void dtTarih_Enter(object sender, EventArgs e)
        {
            dtTarih.Width = 200;

        }

        private void dtTarih_MouseLeave(object sender, EventArgs e)
        {
            dtTarih.Width = 23;

        }

        private void dtTarih_ValueChanged(object sender, EventArgs e)
        {
            txtTarih.Text = dtTarih.Value.ToString();

        }

        private void cbKisiSayısı_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKisiSayısı.Text = cbKisiSayısı.SelectedItem.ToString();

        }

        private void cbMasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbKisiSayısı.Enabled = true;
            txtMasa.Text = cbMasa.SelectedItem.ToString();

            cMasalar Kapasitesi = (cMasalar)cbMasa.SelectedItem;
            int kapasite = Kapasitesi.KAPASITE;
            txtMasaNo.Text = Convert.ToString(Kapasitesi.ID);

            cbKisiSayısı.Items.Clear();

            for (int i = 0; i < kapasite; i++)
            {
                cbKisiSayısı.Items.Add(i + 1);

            }

        }

        private void cbMasa_MouseEnter(object sender, EventArgs e)
        {
            cbMasa.Width = 305;
        }

        private void cbMasa_MouseLeave(object sender, EventArgs e)
        {
            cbMasa.Width = 23;
        }

        private void cbKisiSayısı_MouseLeave(object sender, EventArgs e)
        {
            cbKisiSayısı.Width = 23;
        }

        private void cbKisiSayısı_MouseEnter(object sender, EventArgs e)
        {
            cbKisiSayısı.Width = 100;
        }

        private void btnSiparisKontrol_Click(object sender, EventArgs e)
        {

        }

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            MusteriEkleme frm = new MusteriEkleme();
            cGenel._musteriEkleme = 0;

            frm.btnGuncelle.Visible = false;
            frm.btnEkle.Visible = true;

            this.Close();
            frm.Show();

        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            if (lvMusteriler.SelectedItems.Count > 0)
            {
                MusteriEkleme me = new MusteriEkleme();
                cGenel._musteriEkleme = 0;
                cGenel._musteriId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
                me.btnGuncelle.Visible = true;
                me.btnEkle.Visible = false;
                this.Close();
                me.Show();


            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Uyarı!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            { Application.Exit(); }
        }
    }
}
