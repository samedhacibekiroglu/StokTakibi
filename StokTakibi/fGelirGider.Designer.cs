
namespace StokTakibi
{
    partial class fGelirGider
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOdemeTuru = new System.Windows.Forms.ComboBox();
            this.lGelirGider = new StokTakibi.lStandart();
            this.lStandart2 = new StokTakibi.lStandart();
            this.tNakit = new StokTakibi.tNumaric();
            this.tKart = new StokTakibi.tNumaric();
            this.lStandart3 = new StokTakibi.lStandart();
            this.lStandart4 = new StokTakibi.lStandart();
            this.tAçıklama = new StokTakibi.tStandart();
            this.lStandart5 = new StokTakibi.lStandart();
            this.dtTarih = new System.Windows.Forms.DateTimePicker();
            this.lStandart6 = new StokTakibi.lStandart();
            this.bEkle = new StokTakibi.bStandart();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // cmbOdemeTuru
            // 
            this.cmbOdemeTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOdemeTuru.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbOdemeTuru.FormattingEnabled = true;
            this.cmbOdemeTuru.Items.AddRange(new object[] {
            "NAKİT\t",
            "KART",
            "KART-NAKİT"});
            this.cmbOdemeTuru.Location = new System.Drawing.Point(25, 81);
            this.cmbOdemeTuru.Name = "cmbOdemeTuru";
            this.cmbOdemeTuru.Size = new System.Drawing.Size(214, 28);
            this.cmbOdemeTuru.TabIndex = 1;
            this.cmbOdemeTuru.SelectedIndexChanged += new System.EventHandler(this.cmbOdemeTuru_SelectedIndexChanged);
            // 
            // lGelirGider
            // 
            this.lGelirGider.AutoSize = true;
            this.lGelirGider.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lGelirGider.ForeColor = System.Drawing.Color.DarkCyan;
            this.lGelirGider.Location = new System.Drawing.Point(21, 15);
            this.lGelirGider.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lGelirGider.Name = "lGelirGider";
            this.lGelirGider.Size = new System.Drawing.Size(116, 20);
            this.lGelirGider.TabIndex = 2;
            this.lGelirGider.Text = "GELİR GİDER";
            // 
            // lStandart2
            // 
            this.lStandart2.AutoSize = true;
            this.lStandart2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lStandart2.ForeColor = System.Drawing.Color.DarkCyan;
            this.lStandart2.Location = new System.Drawing.Point(25, 48);
            this.lStandart2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lStandart2.Name = "lStandart2";
            this.lStandart2.Size = new System.Drawing.Size(97, 20);
            this.lStandart2.TabIndex = 3;
            this.lStandart2.Text = "Ödeme Türü";
            // 
            // tNakit
            // 
            this.tNakit.BackColor = System.Drawing.Color.White;
            this.tNakit.Enabled = false;
            this.tNakit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tNakit.Location = new System.Drawing.Point(25, 162);
            this.tNakit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tNakit.Name = "tNakit";
            this.tNakit.Size = new System.Drawing.Size(102, 26);
            this.tNakit.TabIndex = 4;
            this.tNakit.Text = "0";
            this.tNakit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tKart
            // 
            this.tKart.BackColor = System.Drawing.Color.White;
            this.tKart.Enabled = false;
            this.tKart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tKart.Location = new System.Drawing.Point(142, 162);
            this.tKart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tKart.Name = "tKart";
            this.tKart.Size = new System.Drawing.Size(97, 26);
            this.tKart.TabIndex = 5;
            this.tKart.Text = "0";
            this.tKart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lStandart3
            // 
            this.lStandart3.AutoSize = true;
            this.lStandart3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lStandart3.ForeColor = System.Drawing.Color.DarkCyan;
            this.lStandart3.Location = new System.Drawing.Point(25, 128);
            this.lStandart3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lStandart3.Name = "lStandart3";
            this.lStandart3.Size = new System.Drawing.Size(45, 20);
            this.lStandart3.TabIndex = 6;
            this.lStandart3.Text = "Nakit";
            // 
            // lStandart4
            // 
            this.lStandart4.AutoSize = true;
            this.lStandart4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lStandart4.ForeColor = System.Drawing.Color.DarkCyan;
            this.lStandart4.Location = new System.Drawing.Point(138, 128);
            this.lStandart4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lStandart4.Name = "lStandart4";
            this.lStandart4.Size = new System.Drawing.Size(38, 20);
            this.lStandart4.TabIndex = 7;
            this.lStandart4.Text = "Kart";
            // 
            // tAçıklama
            // 
            this.tAçıklama.BackColor = System.Drawing.Color.White;
            this.tAçıklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tAçıklama.Location = new System.Drawing.Point(25, 225);
            this.tAçıklama.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tAçıklama.Multiline = true;
            this.tAçıklama.Name = "tAçıklama";
            this.tAçıklama.Size = new System.Drawing.Size(214, 99);
            this.tAçıklama.TabIndex = 8;
            // 
            // lStandart5
            // 
            this.lStandart5.AutoSize = true;
            this.lStandart5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lStandart5.ForeColor = System.Drawing.Color.DarkCyan;
            this.lStandart5.Location = new System.Drawing.Point(21, 202);
            this.lStandart5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lStandart5.Name = "lStandart5";
            this.lStandart5.Size = new System.Drawing.Size(73, 20);
            this.lStandart5.TabIndex = 9;
            this.lStandart5.Text = "Açıklama";
            // 
            // dtTarih
            // 
            this.dtTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtTarih.Location = new System.Drawing.Point(25, 362);
            this.dtTarih.Name = "dtTarih";
            this.dtTarih.Size = new System.Drawing.Size(214, 26);
            this.dtTarih.TabIndex = 10;
            // 
            // lStandart6
            // 
            this.lStandart6.AutoSize = true;
            this.lStandart6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lStandart6.ForeColor = System.Drawing.Color.DarkCyan;
            this.lStandart6.Location = new System.Drawing.Point(21, 339);
            this.lStandart6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lStandart6.Name = "lStandart6";
            this.lStandart6.Size = new System.Drawing.Size(44, 20);
            this.lStandart6.TabIndex = 11;
            this.lStandart6.Text = "Tarih";
            // 
            // bEkle
            // 
            this.bEkle.BackColor = System.Drawing.Color.Tomato;
            this.bEkle.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.bEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bEkle.ForeColor = System.Drawing.Color.White;
            this.bEkle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bEkle.Location = new System.Drawing.Point(136, 401);
            this.bEkle.Margin = new System.Windows.Forms.Padding(1);
            this.bEkle.Name = "bEkle";
            this.bEkle.Size = new System.Drawing.Size(101, 54);
            this.bEkle.TabIndex = 12;
            this.bEkle.Text = "Ekle";
            this.bEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bEkle.UseVisualStyleBackColor = false;
            this.bEkle.Click += new System.EventHandler(this.bEkle_Click);
            // 
            // fGelirGider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(330, 463);
            this.Controls.Add(this.bEkle);
            this.Controls.Add(this.lStandart6);
            this.Controls.Add(this.dtTarih);
            this.Controls.Add(this.lStandart5);
            this.Controls.Add(this.tAçıklama);
            this.Controls.Add(this.lStandart4);
            this.Controls.Add(this.lStandart3);
            this.Controls.Add(this.tKart);
            this.Controls.Add(this.tNakit);
            this.Controls.Add(this.lStandart2);
            this.Controls.Add(this.lGelirGider);
            this.Controls.Add(this.cmbOdemeTuru);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "fGelirGider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GELİR-GİDER İŞLEMLERİ";
            this.Load += new System.EventHandler(this.fGelirGider_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbOdemeTuru;
        private lStandart lGelirGider;
        private lStandart lStandart2;
        private tNumaric tNakit;
        private tNumaric tKart;
        private lStandart lStandart3;
        private lStandart lStandart4;
        private tStandart tAçıklama;
        private lStandart lStandart5;
        private System.Windows.Forms.DateTimePicker dtTarih;
        private lStandart lStandart6;
        private bStandart bEkle;
    }
}