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
    public partial class frmMusteriAra : Form
    {
        public frmMusteriAra()
        {
            InitializeComponent();
        }

        private void frmMusteriAra_Load(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.musterileriGetir(lvMusteriler);
        }

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            MusteriEkleme m = new MusteriEkleme();
            cGenel._musteriEkleme = 1;
            m.btnGuncelle.Visible = false;
            m.btnEkle.Visible = true;
            m.Show();

        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {

        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            if (lvMusteriler.SelectedItems.Count > 0)
            {
                MusteriEkleme frm = new MusteriEkleme();
                cGenel._musteriEkleme = 1;
                cGenel._musteriId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);

                frm.btnEkle.Visible = false;
                frm.btnGuncelle.Visible = true;



                this.Close();
                frm.Show();



            }
        }

        private void frmGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }

        private void txtMusteriAd_TextChanged(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.musterigetirAd(lvMusteriler, txtMusteriAd.Text);

        }

        private void txtMusteriSoyad_TextChanged(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.musterigetirSoyad(lvMusteriler, txtMusteriSoyad.Text);
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.musterigetirTlf(lvMusteriler, txtTelefon.Text);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Uyarı!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            { Application.Exit(); }
        }
    }
}
