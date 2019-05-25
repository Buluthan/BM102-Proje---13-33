using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;


namespace lokanta
{
    public partial class frmRaporlar : Form
    {
        private void frmRaporlar_Load(object sender, EventArgs e)
        {

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinizde Emin Misiniz?", "Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }

        private void Istatistik(string gfName, int KatId, Color renk)
        {
            chRapor.Palette = ChartColorPalette.None;
            chRapor.Series[0].EmptyPointStyle.Color = Color.Transparent;
            chRapor.Series[0].Color = renk;
            cUrunler u = new cUrunler();
            lvIstatistik.Items.Clear();
            u.urunleriListeleIstatistiklereGoreUrunId(lvIstatistik, dtBaslangic, dtBitis, KatId);//KatId : kategori id si anayemeklerin
            gbİstatistik.Text = gfName;

            if (lvIstatistik.Items.Count > 0)
            {
                chRapor.Series["Satislar"].Points.Clear();

                for (int i = 0; i < lvIstatistik.Items.Count; i++)
                {
                    chRapor.Series["Satislar"].Points.AddXY(lvIstatistik.Items[i].SubItems[0].Text, lvIstatistik.Items[i].SubItems[1].Text);
                }
            }
            else
            {
                MessageBox.Show("Gösterilecek istatistik yok, başka bir zaman dilimi seçiniz");
            }
        }

        private void btnAnaYemek1_Click(object sender, EventArgs e)
        {
            Istatistik("Anayemek Grafiği", 1, Color.Red);
        }

        private void btnCorba2_Click(object sender, EventArgs e)
        {
            Istatistik("Çorba Grafiği", 2, Color.Yellow);
        }

        private void btnSalata3_Click(object sender, EventArgs e)
        {
            Istatistik("Salata Grafiği", 3, Color.Green);
        }

        private void btnİcecek4_Click(object sender, EventArgs e)
        {
            Istatistik("İçecek Grafiği", 4, Color.Orange);
        }

        private void btnTatlilar5_Click(object sender, EventArgs e)
        {
            Istatistik("Tatlı Grafiği", 5, Color.Blue);
        }

        private void btnKahvalti6_Click(object sender, EventArgs e)
        {
            Istatistik("Kahvaltı Grafiği", 6, Color.LightBlue);
        }

        private void btnFirin7_Click(object sender, EventArgs e)
        {
            Istatistik("Fırın Grafiği", 7, Color.DarkViolet);
        }

        private void btnBalik8_Click(object sender, EventArgs e)
        {
            Istatistik("Balık Grafiği", 8, Color.Goldenrod);
        }

        private void btnZRaporu_Click(object sender, EventArgs e)
        {
            chRapor.Palette = ChartColorPalette.None;
            chRapor.Series[0].EmptyPointStyle.Color = Color.Transparent;
            chRapor.Series[0].Color = Color.GreenYellow;
            cUrunler u = new cUrunler();
            lvIstatistik.Items.Clear();
            u.urunleriListeleIstatistiklereGore(lvIstatistik, dtBaslangic, dtBitis);
            gbİstatistik.Text = "TÜM ÜRÜNLER ";

            if (lvIstatistik.Items.Count > 0)
            {
                chRapor.Series["Satislar"].Points.Clear();

                for (int i = 0; i < lvIstatistik.Items.Count; i++)
                {
                    chRapor.Series["Satislar"].Points.AddXY(lvIstatistik.Items[i].SubItems[0].Text, lvIstatistik.Items[i].SubItems[1].Text);
                }
            }
            else
            {
                MessageBox.Show("Gösterilecek istatistik yok, başka bir zaman dilimi seçiniz");
            }
        }
    }
}
