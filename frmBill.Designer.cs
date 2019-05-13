namespace Lokanta_Otomasyonu
{
    partial class frmBill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbIndirim = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkIndirim = new System.Windows.Forms.CheckBox();
            this.lvUrunler = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rbNakit = new System.Windows.Forms.RadioButton();
            this.rbKrediKarti = new System.Windows.Forms.RadioButton();
            this.rbTicket = new System.Windows.Forms.RadioButton();
            this.lblIndirim = new System.Windows.Forms.Label();
            this.lblKdv = new System.Windows.Forms.Label();
            this.lblToplamTutar = new System.Windows.Forms.Label();
            this.lblOdenecek = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGeriDon = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIndirimTutari = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblAdisyonId = new System.Windows.Forms.Label();
            this.gbIndirim.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbIndirim
            // 
            this.gbIndirim.Controls.Add(this.txtIndirimTutari);
            this.gbIndirim.Controls.Add(this.label9);
            this.gbIndirim.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbIndirim.Location = new System.Drawing.Point(1036, 88);
            this.gbIndirim.Name = "gbIndirim";
            this.gbIndirim.Size = new System.Drawing.Size(238, 132);
            this.gbIndirim.TabIndex = 0;
            this.gbIndirim.TabStop = false;
            this.gbIndirim.Text = "Özel Aktivite";
            this.gbIndirim.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkIndirim);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(652, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Özel İndirim";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lblOdenecek);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lblKdv);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lblToplamTutar);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblIndirim);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(652, 194);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(378, 225);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ödeme Bilgileri";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbTicket);
            this.groupBox4.Controls.Add(this.rbKrediKarti);
            this.groupBox4.Controls.Add(this.rbNakit);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox4.Location = new System.Drawing.Point(1036, 232);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(238, 187);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ödeme Türü";
            // 
            // chkIndirim
            // 
            this.chkIndirim.AutoSize = true;
            this.chkIndirim.Location = new System.Drawing.Point(28, 43);
            this.chkIndirim.Name = "chkIndirim";
            this.chkIndirim.Size = new System.Drawing.Size(202, 33);
            this.chkIndirim.TabIndex = 0;
            this.chkIndirim.Text = "İndirim Uygula";
            this.chkIndirim.UseVisualStyleBackColor = true;
            this.chkIndirim.CheckedChanged += new System.EventHandler(this.chkIndirim_CheckedChanged);
            // 
            // lvUrunler
            // 
            this.lvUrunler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvUrunler.FullRowSelect = true;
            this.lvUrunler.GridLines = true;
            this.lvUrunler.Location = new System.Drawing.Point(31, 65);
            this.lvUrunler.Name = "lvUrunler";
            this.lvUrunler.Size = new System.Drawing.Size(355, 282);
            this.lvUrunler.TabIndex = 1;
            this.lvUrunler.UseCompatibleStateImageBehavior = false;
            this.lvUrunler.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Urun Adı";
            this.columnHeader1.Width = 87;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Adet";
            this.columnHeader2.Width = 82;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "UrunId";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Fiyat";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "SatisId";
            // 
            // rbNakit
            // 
            this.rbNakit.AutoSize = true;
            this.rbNakit.Location = new System.Drawing.Point(33, 43);
            this.rbNakit.Name = "rbNakit";
            this.rbNakit.Size = new System.Drawing.Size(94, 33);
            this.rbNakit.TabIndex = 0;
            this.rbNakit.TabStop = true;
            this.rbNakit.Text = "Nakit";
            this.rbNakit.UseVisualStyleBackColor = true;
            // 
            // rbKrediKarti
            // 
            this.rbKrediKarti.AutoSize = true;
            this.rbKrediKarti.Location = new System.Drawing.Point(33, 82);
            this.rbKrediKarti.Name = "rbKrediKarti";
            this.rbKrediKarti.Size = new System.Drawing.Size(158, 33);
            this.rbKrediKarti.TabIndex = 0;
            this.rbKrediKarti.TabStop = true;
            this.rbKrediKarti.Text = "Kredi Kartı";
            this.rbKrediKarti.UseVisualStyleBackColor = true;
            // 
            // rbTicket
            // 
            this.rbTicket.AutoSize = true;
            this.rbTicket.Location = new System.Drawing.Point(33, 121);
            this.rbTicket.Name = "rbTicket";
            this.rbTicket.Size = new System.Drawing.Size(106, 33);
            this.rbTicket.TabIndex = 0;
            this.rbTicket.TabStop = true;
            this.rbTicket.Text = "Ticket";
            this.rbTicket.UseVisualStyleBackColor = true;
            // 
            // lblIndirim
            // 
            this.lblIndirim.AutoSize = true;
            this.lblIndirim.Location = new System.Drawing.Point(203, 43);
            this.lblIndirim.Name = "lblIndirim";
            this.lblIndirim.Size = new System.Drawing.Size(27, 29);
            this.lblIndirim.TabIndex = 0;
            this.lblIndirim.Text = "0";
            this.lblIndirim.TextChanged += new System.EventHandler(this.lblIndirim_TextChanged);
            // 
            // lblKdv
            // 
            this.lblKdv.AutoSize = true;
            this.lblKdv.Location = new System.Drawing.Point(203, 86);
            this.lblKdv.Name = "lblKdv";
            this.lblKdv.Size = new System.Drawing.Size(27, 29);
            this.lblKdv.TabIndex = 0;
            this.lblKdv.Text = "0";
            // 
            // lblToplamTutar
            // 
            this.lblToplamTutar.AutoSize = true;
            this.lblToplamTutar.Location = new System.Drawing.Point(203, 134);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new System.Drawing.Size(27, 29);
            this.lblToplamTutar.TabIndex = 0;
            this.lblToplamTutar.Text = "0";
            // 
            // lblOdenecek
            // 
            this.lblOdenecek.AutoSize = true;
            this.lblOdenecek.Location = new System.Drawing.Point(203, 177);
            this.lblOdenecek.Name = "lblOdenecek";
            this.lblOdenecek.Size = new System.Drawing.Size(27, 29);
            this.lblOdenecek.TabIndex = 0;
            this.lblOdenecek.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "İndirim";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fiyat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ara Toplam";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "KDV";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 29);
            this.label5.TabIndex = 0;
            this.label5.Text = "TL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(286, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 29);
            this.label6.TabIndex = 0;
            this.label6.Text = "TL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(286, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "TL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(286, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 29);
            this.label8.TabIndex = 0;
            this.label8.Text = "TL";
            // 
            // btnGeriDon
            // 
            this.btnGeriDon.Location = new System.Drawing.Point(44, 376);
            this.btnGeriDon.Name = "btnGeriDon";
            this.btnGeriDon.Size = new System.Drawing.Size(75, 43);
            this.btnGeriDon.TabIndex = 2;
            this.btnGeriDon.Text = "Geri Dön";
            this.btnGeriDon.UseVisualStyleBackColor = true;
            this.btnGeriDon.Click += new System.EventHandler(this.btnGeriDon_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(142, 376);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(75, 43);
            this.btnCikis.TabIndex = 2;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(826, 436);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 55);
            this.button3.TabIndex = 2;
            this.button3.Text = "Hesap Özeti";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(907, 436);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 55);
            this.button4.TabIndex = 2;
            this.button4.Text = "Hesap Kapat";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(28, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(183, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "İndirim Tutarı Giriniz";
            // 
            // txtIndirimTutari
            // 
            this.txtIndirimTutari.Location = new System.Drawing.Point(32, 67);
            this.txtIndirimTutari.Name = "txtIndirimTutari";
            this.txtIndirimTutari.Size = new System.Drawing.Size(179, 34);
            this.txtIndirimTutari.TabIndex = 1;
            this.txtIndirimTutari.TextChanged += new System.EventHandler(this.txtIndirimTutari_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Siparişler";
            // 
            // lblAdisyonId
            // 
            this.lblAdisyonId.AutoSize = true;
            this.lblAdisyonId.Location = new System.Drawing.Point(123, 45);
            this.lblAdisyonId.Name = "lblAdisyonId";
            this.lblAdisyonId.Size = new System.Drawing.Size(19, 17);
            this.lblAdisyonId.TabIndex = 0;
            this.lblAdisyonId.Text = "Id";
            // 
            // frmBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1348, 519);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnGeriDon);
            this.Controls.Add(this.lvUrunler);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbIndirim);
            this.Controls.Add(this.lblAdisyonId);
            this.Controls.Add(this.label10);
            this.Name = "frmBill";
            this.Text = "frmBill";
            this.Load += new System.EventHandler(this.frmBill_Load);
            this.gbIndirim.ResumeLayout(false);
            this.gbIndirim.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbIndirim;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkIndirim;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblOdenecek;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblKdv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblToplamTutar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblIndirim;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbTicket;
        private System.Windows.Forms.RadioButton rbKrediKarti;
        private System.Windows.Forms.RadioButton rbNakit;
        private System.Windows.Forms.ListView lvUrunler;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnGeriDon;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtIndirimTutari;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblAdisyonId;
    }
}