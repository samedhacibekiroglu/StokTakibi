using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StokTakibi
{
    public partial class fSatis : Form
    {
        public fSatis()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        BarkodDbEntities db = new BarkodDbEntities();
        private void tbarkod_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.Enter)
            {
                string barkod = tbarkod.Text.Trim();
                if (barkod.Length <= 2)
                {
                    tmiktar.Text = barkod;
                    tbarkod.Clear();
                    tbarkod.Focus();
                }

                else
                {

                    if (db.Urun.Any(a => a.Barkod == barkod))
                    {
                        var urun = db.Urun.Where(a => a.Barkod == barkod).FirstOrDefault();
                        UrunGetirListeye(urun, barkod, Convert.ToDouble(tmiktar.Text));


                    }
                    else
                    {
                        int onek = Convert.ToInt32(barkod.Substring(0, 2));
                        if (db.Terazi.Any(async => async.TeraziOnEk == onek))
                        {
                            string teraziurunno = barkod.Substring(2, 5);
                            if (db.Urun.Any(a => a.Barkod == teraziurunno))
                            {
                                var urunterazi = db.Urun.Where(a => a.Barkod == teraziurunno).FirstOrDefault();
                                double miktarkg = Convert.ToDouble(barkod.Substring(7, 5)) / 1000;
                                UrunGetirListeye(urunterazi, teraziurunno, miktarkg);
                            }
                            else
                            {
                                Console.Beep(900, 2000);
                                MessageBox.Show("KĞ Ürün Ekleme Sayfası");


                            }

                        }
                        else
                        {
                            Console.Beep(900, 2000);
                            fUrunGiris f = new fUrunGiris();
                            f.tBarkod.Text = barkod;
                            f.ShowDialog();
                        }

                    }
                }
                gridsatislistesi.ClearSelection();
                GenelToplam();



            }
        }

        private void UrunGetirListeye(Urun urun, string barkod, double miktar)
        {
            int satirsayisi = gridsatislistesi.Rows.Count;
            // double miktar = Convert.ToDouble(tmiktar.Text);
            bool eklenmismi = false;
            if (satirsayisi > 0)
            {
                for (int i = 0; i < satirsayisi; i++)
                {
                    if (gridsatislistesi.Rows[i].Cells["Barkod"].Value.ToString() == barkod)
                    {
                        gridsatislistesi.Rows[i].Cells["Miktar"].Value = miktar + Convert.ToDouble(gridsatislistesi.Rows[i].Cells["Miktar"].Value);
                        gridsatislistesi.Rows[i].Cells["Toplam"].Value = Math.Round(Convert.ToDouble(gridsatislistesi.Rows[i].Cells["Miktar"].Value) * Convert.ToDouble(gridsatislistesi.Rows[i].Cells["Fiyat"].Value), 2);
                        eklenmismi = true;
                    }
                }
            }

            if (!eklenmismi)
            {
                gridsatislistesi.Rows.Add();
                gridsatislistesi.Rows[satirsayisi].Cells["Barkod"].Value = barkod;
                gridsatislistesi.Rows[satirsayisi].Cells["UrunAdi"].Value = urun.UrunAd;
                gridsatislistesi.Rows[satirsayisi].Cells["UrunGrup"].Value = urun.UrunGrup;
                gridsatislistesi.Rows[satirsayisi].Cells["Birim"].Value = urun.Birim;
                gridsatislistesi.Rows[satirsayisi].Cells["Fiyat"].Value = urun.SatisFiyat;
                gridsatislistesi.Rows[satirsayisi].Cells["Miktar"].Value = miktar;
                gridsatislistesi.Rows[satirsayisi].Cells["Toplam"].Value = Math.Round(miktar * (double)urun.SatisFiyat, 2);
                gridsatislistesi.Rows[satirsayisi].Cells["AlisFiyat"].Value = urun.AlisFiyat;
                gridsatislistesi.Rows[satirsayisi].Cells["KdvTutari"].Value = urun.KdvTutari;


            }



        }
        private void GenelToplam()
        {
            double toplam = 0;
            for (int i = 0; i < gridsatislistesi.Rows.Count; i++)
            {
                toplam += Convert.ToDouble(gridsatislistesi.Rows[i].Cells["Toplam"].Value);

            }
            tgeneltoplam.Text = toplam.ToString("C2");
            tmiktar.Text = "1";
            tbarkod.Clear();
            tbarkod.Focus();

        }
        private void HizliButonDoldur()
        {
            var hizliurun = db.HizliUrun.ToList();
            foreach (var item in hizliurun)
            {
                Button bh = this.Controls.Find("bH" + item.Id, true).FirstOrDefault() as Button;
                if (bh != null)
                {
                    double fiyat = Islemler.DoubleYap(item.Fiyat.ToString());

                    bh.Text = item.UrunAd + "\n" + fiyat.ToString("C2");
                }
            }
        }
        private void HizliButonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int butonid = Convert.ToInt16(b.Name.ToString().Substring(2, b.Name.Length - 2));

            if (b.Text.ToString().StartsWith("-"))
            {
                fHizliButonUrunEkle f = new fHizliButonUrunEkle();
                f.lButonId.Text = butonid.ToString();
                f.ShowDialog();
            }
            else
            {
                var urunbarkod = db.HizliUrun.Where(a => a.Id == butonid).Select(a => a.Barkod).FirstOrDefault();
                var urun = db.Urun.Where(a => a.Barkod == urunbarkod).FirstOrDefault();
                UrunGetirListeye(urun, urunbarkod, Convert.ToDouble(tmiktar.Text));
                GenelToplam();
            }
        }
        private void gridsatislistesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                gridsatislistesi.Rows.Remove(gridsatislistesi.CurrentRow);
                gridsatislistesi.ClearSelection();
                GenelToplam();
                tbarkod.Focus();

            }
        }
        private void Sil_Click(object sender, EventArgs e)
        {
            int butonid = Convert.ToInt16(sender.ToString().Substring(19, sender.ToString().Length - 19));
            var guncelle = db.HizliUrun.Find(butonid);
            guncelle.Barkod = "-";
            guncelle.UrunAd = "-";
            guncelle.Fiyat = 0;
            db.SaveChanges();
            double fiyat = 0;
            Button b = this.Controls.Find("bh" + butonid, true).FirstOrDefault() as Button;
            b.Text = "-" + "\n" + fiyat.ToString("C2");
        }
        private void fSatis_Load(object sender, EventArgs e)
        {
            HizliButonDoldur();
            b5.Text = 5.ToString("C2");
            b10.Text = 10.ToString("C2");
            b20.Text = 20.ToString("C2");
            b50.Text = 50.ToString("C2");
            b100.Text = 100.ToString("C2");
            b200.Text = 200.ToString("C2");
            using (var db=new BarkodDbEntities())
            {
                var sabit = db.Sabit.FirstOrDefault();
                chYazdirmaDurumu.Checked = Convert.ToBoolean(sabit.Yazici);

            }

        }
        private void bNx_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == ",")
            {
                int virgul = tNumarator.Text.Count(x => x == ',');
                if (virgul < 1)
                {
                    tNumarator.Text += b.Text;

                }


            }
            else if (b.Text == "<")
            {
                if (tNumarator.Text.Length > 0)
                {
                    tNumarator.Text = tNumarator.Text.Substring(0, tNumarator.Text.Length - 1);

                }
            }
            else
            {
                tNumarator.Text += b.Text;
            }
        }

        private void bH_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button b = (Button)sender;
                if (!b.Text.StartsWith("-"))
                {
                    int butonid = Convert.ToInt16(b.Name.ToString().Substring(2, b.Name.Length - 2));
                    ContextMenuStrip s = new ContextMenuStrip();
                    ToolStripMenuItem sil = new ToolStripMenuItem();
                    sil.Text = "Temizle - Buton No:" + butonid.ToString();
                    sil.Click += Sil_Click;
                    s.Items.Add(sil);
                    this.ContextMenuStrip = s;

                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bAdet_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text != "")
            {
                tmiktar.Text = tNumarator.Text;
                tNumarator.Clear();
                tbarkod.Clear();
                tbarkod.Focus();
            }
        }

        private void bOdenen_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text != "")
            {
                double sonuc = Islemler.DoubleYap(tNumarator.Text) - Islemler.DoubleYap(tgeneltoplam.Text);
                tParaUstu.Text = sonuc.ToString("C2");
                todenen.Text = Islemler.DoubleYap(tNumarator.Text).ToString("C2");
                tNumarator.Clear();
                tbarkod.Focus();

            }
        }

        private void tbarkod_TextChanged(object sender, EventArgs e)
        {
        }
        private void ParaUstuhesapla_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            double sonuc = Islemler.DoubleYap(b.Text) - Islemler.DoubleYap(tgeneltoplam.Text);
            todenen.Text = Islemler.DoubleYap(b.Text).ToString("C2");
            tParaUstu.Text = sonuc.ToString("C2");
        }
        private void bBarkod_Click(object sender, EventArgs e)
        {

            if (tNumarator.Text != "")
            {
                if (db.Urun.Any(a => a.Barkod == tNumarator.Text))
                {
                    var urun = db.Urun.Where(a => a.Barkod == tNumarator.Text).FirstOrDefault();
                    UrunGetirListeye(urun, tNumarator.Text, Convert.ToDouble(tmiktar.Text));
                    tNumarator.Clear();
                    tbarkod.Focus();
                }
                else
                {
                    MessageBox.Show("dsv");
                }
            }

        }

        private void bDigerUrun_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text != "")
            {
                int satirsayisi = gridsatislistesi.Rows.Count;
                gridsatislistesi.Rows.Add();
                gridsatislistesi.Rows[satirsayisi].Cells["Barkod"].Value = "1111111111116";
                gridsatislistesi.Rows[satirsayisi].Cells["UrunAdi"].Value = "Barkodsuz Ürün";
                gridsatislistesi.Rows[satirsayisi].Cells["UrunGrup"].Value = "Barkodsuz Ürün";
                gridsatislistesi.Rows[satirsayisi].Cells["Birim"].Value = "Adet";
                gridsatislistesi.Rows[satirsayisi].Cells["Miktar"].Value = 1;
                gridsatislistesi.Rows[satirsayisi].Cells["AlisFiyati"].Value = 0;
                gridsatislistesi.Rows[satirsayisi].Cells["Fiyat"].Value = Convert.ToDouble(tNumarator.Text);
                gridsatislistesi.Rows[satirsayisi].Cells["KdvTutari"].Value = 0;
                gridsatislistesi.Rows[satirsayisi].Cells["Toplam"].Value = Convert.ToDouble(tNumarator.Text);
                tNumarator.Text = "";
                GenelToplam();
                tbarkod.Focus();

            }
        }

        private void bİade_Click(object sender, EventArgs e)
        {

        }

        private void bIade_Click(object sender, EventArgs e)
        {
            if (chSatisIadeIslemi.Checked)
            {
                chSatisIadeIslemi.Checked = false;
                chSatisIadeIslemi.Text = "Satış Yapılıyor";

            }
            else
            {

                chSatisIadeIslemi.Checked = true;
                chSatisIadeIslemi.Text = "İade Yapılıyor";
            }
        }

        private void bTemizle_Click(object sender, EventArgs e)
        {
            temizle();

        }
        public void SatisYap(string odemesekli)
        {
            int satirsayisi = gridsatislistesi.Rows.Count;
            bool satisiade = chSatisIadeIslemi.Checked;
            double alisfiyattoplam = 0;
            if (satirsayisi > 0)
            {
                int? islemno = db.Islem.First().IslemNo;
                Satis satis = new Satis();
                for (int i = 0; i < satirsayisi; i++)
                {
                    satis.IslemNo = islemno;
                    satis.UrunAd = gridsatislistesi.Rows[i].Cells["UrunAdi"].Value.ToString();
                    satis.UrunGrup = gridsatislistesi.Rows[i].Cells["UrunGrup"].Value.ToString();
                    satis.Barkod = gridsatislistesi.Rows[i].Cells["Barkod"].Value.ToString();
                    satis.Birim = gridsatislistesi.Rows[i].Cells["Birim"].Value.ToString();
                    satis.AlisFiyat = Islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["AlisFiyat"].Value.ToString());
                    satis.SatisFiyat = Islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["Fiyat"].Value.ToString());
                    satis.Miktar = Islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["Miktar"].Value.ToString());
                    satis.Toplam = Islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["Toplam"].Value.ToString());
                    satis.KdvTutari = Islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["KdvTutari"].Value.ToString());
                    satis.OdemeSekli = odemesekli;
                    satis.Iade = satisiade;
                    satis.Tarih = DateTime.Now;
                    satis.Kullanici = lKullanici.Text;
                    db.Satis.Add(satis);
                    db.SaveChanges();

                    if (!satisiade)
                    {
                        Islemler.StokAzalt(gridsatislistesi.Rows[i].Cells["Barkod"].Value.ToString(), Islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["Miktar"].Value.ToString()));

                    }
                    else
                    {
                        Islemler.StokArtir(gridsatislistesi.Rows[i].Cells["Barkod"].Value.ToString(), Islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["Miktar"].Value.ToString()));
                    }
                    alisfiyattoplam += Islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["AlisFiyat"].Value.ToString()) * Islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["Miktar"].Value.ToString());

                }
                IslemOzet io = new IslemOzet();
                io.IslemNo = islemno;
                io.Iade = satisiade;
                io.AlisFiyatToplam = alisfiyattoplam;
                io.Gelir = false;
                io.Gider = false;

                if (!satisiade)
                {


                    io.Aciklama = odemesekli + " Satış";
                }

                else
                {

                    io.Aciklama = "İade İşlemi (" + odemesekli + ")";

                }
                io.OdemeSekli = odemesekli;
                io.Kullanici = lKullanici.Text;
                io.Tarih = DateTime.Now;

                switch (odemesekli)
                {
                    case "Nakit":

                        io.Nakit = Islemler.DoubleYap(tgeneltoplam.Text);
                        io.Kart = 0; break;
                    case "Kart":
                        io.Nakit = 0;
                        io.Kart = Islemler.DoubleYap(tgeneltoplam.Text); break;

                    case "Kart-Nakit":
                        io.Nakit = Islemler.DoubleYap(lNakit.Text);
                        io.Kart = Islemler.DoubleYap(lKart.Text); break;

                }
                db.IslemOzet.Add(io);
                db.SaveChanges();

                var islemnoartir = db.Islem.First();
                islemnoartir.IslemNo += 1;
                db.SaveChanges();
                if (chYazdirmaDurumu.Checked)
                {
                    // Yazdır....
                    Yazdir yazdir = new Yazdir(islemno);
                    yazdir.IslemNo = islemno;
                    yazdir.YazdirmayaBasla();
                }
                MessageBox.Show("Yazdırma İşlemi Yap");
                temizle();


            }
        }
        private void temizle()
        {
            tmiktar.Text = "1";
            todenen.Clear();
            tParaUstu.Clear();
            tbarkod.Clear();
            tgeneltoplam.Text = 0.ToString("C2");
            chSatisIadeIslemi.Checked = false;
            tNumarator.Clear();
            gridsatislistesi.Rows.Clear();
            tbarkod.Clear();
            tbarkod.Focus();

        }



        private void bnakit_Click(object sender, EventArgs e)
        {
            SatisYap("Nakit");

        }

        private void bkart_Click(object sender, EventArgs e)
        {
            SatisYap("Kart");
        }

        private void bkartnakit_Click(object sender, EventArgs e)
        {
            fNakitKart f = new fNakitKart();
            f.ShowDialog();
        }

        private void tbarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

        private void tmiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

        private void fSatis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                SatisYap("Nakit");
            if (e.KeyCode == Keys.F2)
                SatisYap("Kart");
            if (e.KeyCode == Keys.F3)
            {
                fNakitKart f = new fNakitKart();
                f.ShowDialog();
            }
        }

        private void bIslemBeklet_Click(object sender, EventArgs e)
        {
            if (bIslemBeklet.Text == "İşlem Beklet")
            {
                Bekle();
                bIslemBeklet.BackColor = System.Drawing.Color.OrangeRed;
                bIslemBeklet.Text = "İşlem Bekliyor.";
                gridsatislistesi.Rows.Clear();
            }
            else
            {
                BeklemedenCik();
                bIslemBeklet.BackColor = System.Drawing.Color.DimGray;
                bIslemBeklet.Text = "İşlem Beklet";
                gridBekle.Rows.Clear();
            }
        }

        private void Bekle()
        {
            int satir = gridsatislistesi.Rows.Count;
            int sutun = gridsatislistesi.Columns.Count;
            if (satir > 0)
            {
                for (int i = 0; i < satir; i++)
                {
                    gridBekle.Rows.Add();
                    
                    for (int j = 0; j < sutun - 1; j++)
                    {
                        gridBekle.Rows[i].Cells[j].Value = gridsatislistesi.Rows[i].Cells[j].Value;
                    }
                }
            }
        }
        
        private void BeklemedenCik()
        {
            int satir = gridBekle.Rows.Count;
            int sutun = gridBekle.Columns.Count;
            if (satir > 0)
            {
                for (int i = 0; i < satir; i++)
                {
                    gridsatislistesi.Rows.Add();

                    for (int j = 0; j < sutun - 1; j++)
                    {
                        gridsatislistesi.Rows[i].Cells[j].Value = gridBekle.Rows[i].Cells[j].Value;
                    }
                }
            }
        }

        private void chSatisIadeIslemi_CheckedChanged(object sender, EventArgs e)
        {
            if (chSatisIadeIslemi.Checked)
            {
                chSatisIadeIslemi.Text = "İade Yapılıyor";
            }
            else
            {
                chSatisIadeIslemi.Text = "Satış Yapılıyor";
            }
        }

        public void label3_Click(object sender, EventArgs e)
        {

        }

    }
}





















































