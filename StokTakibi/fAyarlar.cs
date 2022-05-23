using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakibi
{
    public partial class fAyarlar : Form
    {
        public fAyarlar()
        {
            InitializeComponent();
        }
        private void Temizle()
        {
            tAdSoyad.Clear();
            tTelefon.Clear();
            tEposta.Clear();
            tKullanıcı.Clear();
            tSifre.Clear();
            tTekrar.Clear();
            chSatisEkranı.Checked = false;
            chRapor.Checked = false;
            chStok.Checked = false;
            chUrunGiris.Checked = false;
            chYedekleme.Checked = false;
            chUrunGiris.Checked = false;
            chFiyatGuncelle.Checked = false;
            
        }
        private void bKaydet_Click(object sender, EventArgs e)
        {
            if (bKaydet.Text == "Kaydet")
            {
                if (tAdSoyad.Text != "" && tTelefon.Text != "" && tKullanıcı.Text != "" && tSifre.Text != "" && tTekrar.Text != "")
                {
                    if (tSifre.Text == tTekrar.Text)
                    {
                        try
                        {
                            using (var db = new BarkodDbEntities())
                            {
                                if (!db.Kullanici.Any(x => x.KullaniciAd == tKullanıcı.Text))
                                {
                                    Kullanici k = new Kullanici();
                                    k.AdSoyad = tAdSoyad.Text;
                                    k.Telefon = tTelefon.Text;
                                    k.EPosta = tEposta.Text;
                                    k.KullaniciAd = tKullanıcı.Text.Trim();
                                    k.Sifre = tSifre.Text;
                                    k.Satis = chSatisEkranı.Checked;
                                    k.Rapor = chRapor.Checked;
                                    k.Stok = chStok.Checked;
                                    k.UrunGiris = chUrunGiris.Checked;
                                    k.Ayarlar = chAyarlar.Checked;
                                    k.FiyatGuncelle = chFiyatGuncelle.Checked;
                                    k.Yedekleme = chYedekleme.Checked;
                                    db.Kullanici.Add(k);
                                    db.SaveChanges();
                                    Doldur();

                                }
                                else
                                {
                                    MessageBox.Show("Bu kullanıcı zaten kayıtlı");
                                }
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Hata oluştu");
                            throw;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler uyuşmuyor");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen zorunlu alanları dolrudunuz" + "\nAd Soyad \nTelefon\nKullanıcı Adı\nŞifre\nŞifre Tekrar");
                }
            }
            else if (bKaydet.Text == "Düzenle/Kaydet")
            {
                if (tAdSoyad.Text != "" && tTelefon.Text != "" && tKullanıcı.Text != "" && tSifre.Text != "" && tTekrar.Text != "")
                {
                    if (tSifre.Text == tTekrar.Text)
                    {
                        int id = Convert.ToInt32(lKullaniciId.Text);
                        using (var db = new BarkodDbEntities())
                        {
                            var guncelle = db.Kullanici.Where(x => x.Id == id).FirstOrDefault();
                            guncelle.AdSoyad = tAdSoyad.Text;
                            guncelle.AdSoyad = tAdSoyad.Text;
                            guncelle.Telefon = tTelefon.Text;
                            guncelle.EPosta = tEposta.Text;
                            guncelle.KullaniciAd = tKullanıcı.Text.Trim();
                            guncelle.Sifre = tSifre.Text;
                            guncelle.Satis = chSatisEkranı.Checked;
                            guncelle.Rapor = chRapor.Checked;
                            guncelle.Stok = chStok.Checked;
                            guncelle.UrunGiris = chUrunGiris.Checked;
                            guncelle.Ayarlar = chAyarlar.Checked;
                            guncelle.FiyatGuncelle = chFiyatGuncelle.Checked;
                            guncelle.Yedekleme = chYedekleme.Checked;
                            db.SaveChanges();
                            MessageBox.Show("Güncelleme yapılmıştır");
                            bKaydet.Text = "Kaydet";
                            Temizle();
                            Doldur();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler uyuşmuyoor");
                    }

                }
                else
                {
                    MessageBox.Show("Lütfen zorunlu alanları dolrudunuz" + "\nAd Soyad \nTelefon\nKullanıcı Adı\nŞifre\nŞifre Tekrar");
                }
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridListeKullanici.Rows.Count>0)
            {
                int id = Convert.ToInt32(gridListeKullanici.CurrentRow.Cells["ıd"].Value.ToString());
                lKullaniciId.Text = id.ToString();
                using(var db=new BarkodDbEntities())
                {
                    var getir = db.Kullanici.Where(x => x.Id == id).FirstOrDefault();
                    tAdSoyad.Text = getir.AdSoyad;
                    tTelefon.Text = getir.Telefon;
                    tEposta.Text = getir.EPosta;
                    tKullanıcı.Text = getir.KullaniciAd;
                    tSifre.Text = getir.Sifre;
                    tTekrar.Text = getir.Sifre;
                    chSatisEkranı.Checked = (bool)getir.Satis;
                    chRapor.Checked = (bool)getir.Rapor;
                    chFiyatGuncelle.Checked = (bool)getir.FiyatGuncelle;
                    chStok.Checked = (bool)getir.Stok;
                    chAyarlar.Checked = (bool)getir.Ayarlar;
                    chYedekleme.Checked = (bool)getir.Yedekleme;
                    chUrunGiris.Checked = (bool)getir.UrunGiris;
                    bKaydet.Text = "Düzenle/Kaydet";
                    Doldur();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı seçiniz");
            }
        }

        private void fAyarlar_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Doldur();
            
            Cursor.Current = Cursors.Default;
        }
        private void Doldur()
        {
            using (var db = new BarkodDbEntities())
            {
                if (db.Kullanici.Any())
                {
                    gridListeKullanici.DataSource = db.Kullanici.Select(x => new { x.Id, x.AdSoyad, x.KullaniciAd, x.Telefon }).ToList();
                }
                Islemler.SabitVarsayilan();
                var yazici = db.Sabit.FirstOrDefault();
                chYazmaDurumu.Checked = (bool)yazici.Yazici;
                var sabitler = db.Sabit.FirstOrDefault();
                tKartKomisyon.Text = sabitler.KartKomisyon.ToString();
                var terazionek = db.Terazi.ToList();
                cmbTeraziOnEk.DisplayMember = "TeraziOnEk";
                cmbTeraziOnEk.ValueMember = "Id";
                cmbTeraziOnEk.DataSource = terazionek;


                tIsyeriAdSoyad.Text = sabitler.AdSoyad;
                tIsyeriUnvan.Text = sabitler.Unvan;
                tIsyeriAdres.Text = sabitler.Adres;
                tIsyeriTelefon.Text = sabitler.Telefon;
                tIsyeriEposta.Text = sabitler.Eposta;
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chYazmaDurumu_CheckedChanged(object sender, EventArgs e)
        { 
           using (var db = new BarkodDbEntities())
           {
            if (chYazmaDurumu.Checked)
            {
               
                    Islemler.SabitVarsayilan();
                    var ayarla = db.Sabit.FirstOrDefault();
                    ayarla.Yazici = true;
                    db.SaveChanges();
                    chYazmaDurumu.Text = "Yazma Durumu Aktif";

            }
            else
            {
                    Islemler.SabitVarsayilan();
                    var ayarla = db.Sabit.FirstOrDefault();
                    ayarla.Yazici = false;
                    db.SaveChanges();
                    chYazmaDurumu.Text = "Yazma Durumu Pasif";
            }
              
           }
        }

        private void bKartKomisyonAyarla_Click(object sender, EventArgs e)
        {
            if (tKartKomisyon.Text != "")
            {
                 using (var db = new BarkodDbEntities())
                 {
                    var sabit = db.Sabit.FirstOrDefault();
                    sabit.KartKomisyon = Convert.ToInt16(tKartKomisyon.Text);
                    db.SaveChanges();
                    MessageBox.Show("Kart komisyon ayarlandı");
                 }

            }
            else
            {
                    MessageBox.Show("Kart komisyon bilgisi giriniz");
            }
        }

        private void bTeraziÖnEkKaydet_Click(object sender, EventArgs e)
        {
            if (tTeraziOnEk.Text!="")
            {
                int onek = Convert.ToInt16(tTeraziOnEk.Text);
                using (var db =new BarkodDbEntities())
                {
                    if (db.Terazi.Any(x=> x.TeraziOnEk==onek))
                    {
                        MessageBox.Show(onek.ToString()+"ön eki zaten kayıtlı");
                    }
                    else
                    {
                        Terazi t = new Terazi();
                        t.TeraziOnEk = onek;
                        db.Terazi.Add(t);
                        db.SaveChanges();
                        MessageBox.Show("Bilgiler kaydedilmiştir");
                        cmbTeraziOnEk.DisplayMember = "TerzaiOnEK";
                        cmbTeraziOnEk.ValueMember = "Id";
                        cmbTeraziOnEk.DataSource = db.Terazi.ToList();
                        tTeraziOnEk.Clear();

                    }
                }
            }
            else
            {
                MessageBox.Show("Terazi önek bilgisini giriniz");
            }
        }

        private void bTeraziOnEkSil_Click(object sender, EventArgs e)
        {
            if (cmbTeraziOnEk.Text!="")
            {
                int onekid = Convert.ToInt16(cmbTeraziOnEk.SelectedValue);
                DialogResult onay = MessageBox.Show(cmbTeraziOnEk.Text+"öneki silmek istiyor musunuz?","Terazi Önek Silme İşleml",MessageBoxButtons.YesNo);
                if (onay==DialogResult.Yes)
                {
                    using (var db =new BarkodDbEntities())
                    {
                        var onek = db.Terazi.Find(onekid);
                        db.Terazi.Remove(onek);
                        db.SaveChanges();
                        cmbTeraziOnEk.DisplayMember = "TerzaiOnEK";
                        cmbTeraziOnEk.ValueMember = "Id";
                        cmbTeraziOnEk.DataSource = db.Terazi.ToList();
                        tTeraziOnEk.Clear();
                        MessageBox.Show("Önek silinmiştir");
                    }
                }
            }
            else
            {
                MessageBox.Show("önek seçiniz");
            }
        }

        private void bIsyeriKaydet_Click(object sender, EventArgs e)
        {
            if (tIsyeriAdSoyad.Text!="" && tIsyeriUnvan.Text!="" && tIsyeriAdres.Text!="" && tIsyeriTelefon.Text!="")
            {
                using (var db=new BarkodDbEntities())
                {
                    var isyeri = db.Sabit.FirstOrDefault();
                    isyeri.AdSoyad = tIsyeriAdSoyad.Text;
                    isyeri.Unvan = tIsyeriUnvan.Text;
                    isyeri.Adres = tIsyeriAdres.Text;
                    isyeri.Telefon = tIsyeriTelefon.Text;
                    isyeri.Eposta = tIsyeriEposta.Text;
                    db.SaveChanges();
                    MessageBox.Show("İşyeri bilgileri kaydedilmiştir");
                    var yeni = db.Sabit.FirstOrDefault();
                    tIsyeriAdSoyad.Text = yeni.AdSoyad;
                    tIsyeriUnvan.Text = yeni.Unvan;
                    tIsyeriAdres.Text = yeni.Adres;
                    tIsyeriTelefon.Text = yeni.Telefon;
                    tIsyeriEposta.Text = yeni.Eposta;
                }
            }
        }

        private void bYedektenYükle_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\ProgramRestore.exe");
            Application.Exit();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void lKullaniciId_Click(object sender, EventArgs e)
        {

        }

        private void tKullanıcı_TextChanged(object sender, EventArgs e)
        {

        }

        private void lStandart7_Click(object sender, EventArgs e)
        {

        }

        private void chYedekleme_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chFiyatGuncelle_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chStok_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chAyarlar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chUrunGiris_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chRapor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lStandart2_Click(object sender, EventArgs e)
        {

        }

        private void chSatisEkranı_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bIptal_Click(object sender, EventArgs e)
        {

        }

        private void tTekrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void lStandart6_Click(object sender, EventArgs e)
        {

        }

        private void tTelefon_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void tSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void lStandart5_Click(object sender, EventArgs e)
        {

        }

        private void tEposta_TextChanged(object sender, EventArgs e)
        {

        }

        private void lStandart4_Click(object sender, EventArgs e)
        {

        }

        private void tAdSoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void lStandart3_Click(object sender, EventArgs e)
        {

        }

        private void AD_Click(object sender, EventArgs e)
        {

        }

        private void lStandart1_Click(object sender, EventArgs e)
        {

        }

        private void gridListeKullanici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void lStandart17_Click(object sender, EventArgs e)
        {

        }

        private void lStandart10_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tTeraziOnEk_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbTeraziOnEk_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lStandart9_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tKartKomisyon_TextChanged(object sender, EventArgs e)
        {

        }

        private void lStandart8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void lStandart16_Click(object sender, EventArgs e)
        {

        }

        private void tIsyeriAdres_TextChanged(object sender, EventArgs e)
        {

        }

        private void lStandart11_Click(object sender, EventArgs e)
        {

        }

        private void tIsyeriUnvan_TextChanged(object sender, EventArgs e)
        {

        }

        private void lStandart15_Click(object sender, EventArgs e)
        {

        }

        private void tIsyeriTelefon_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void tIsyeriEposta_TextChanged(object sender, EventArgs e)
        {

        }

        private void lStandart12_Click(object sender, EventArgs e)
        {

        }

        private void tIsyeriAdSoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void lStandart13_Click(object sender, EventArgs e)
        {

        }

        private void lStandart14_Click(object sender, EventArgs e)
        {

        }

        private void bStandart1_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\ProgramRestore.exe");
            Application.Exit();
        }

        private void lStandart18_Click(object sender, EventArgs e)
        {

        }
    }
}
