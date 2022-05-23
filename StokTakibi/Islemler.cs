using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StokTakibi
{
    class Islemler
    {
        public static object StokHareket { get; private set; }

        public static double DoubleYap(string deger)
        {
            double sonuc;
            double.TryParse(deger, NumberStyles.Currency, CultureInfo.CurrentUICulture.NumberFormat, out sonuc);
            return Math.Round(sonuc, 2);
        }

        public static void StokAzalt(String barkod, double miktar)
        {
            if (barkod != "1111111111116")
            {
                using (var db = new BarkodDbEntities())
                {
                    var urunbilgi = db.Urun.SingleOrDefault(x => x.Barkod == barkod);
                    urunbilgi.Miktar = urunbilgi.Miktar - miktar;
                    db.SaveChanges();
                }
            }            
        }

        public static void StokArtir(String barkod, double miktar)
        {

            if (barkod != "1111111111116")
            {
                using (var db = new BarkodDbEntities())
                {
                    var urunbilgi = db.Urun.SingleOrDefault(x => x.Barkod == barkod);
                    urunbilgi.Miktar += miktar;
                    db.SaveChanges();
                }
            }            
        }

        public static void GridDuzenle(DataGridView dgv)
        {
            if (dgv.Columns.Count > 0)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    switch (dgv.Columns[i].HeaderText)
                    {
                        case "Id":
                            dgv.Columns[i].HeaderText = "Numara"; break;
                        case "IslemNo":
                            dgv.Columns[i].HeaderText = "İşlem No"; break;
                        case "UrunId":
                            dgv.Columns[i].HeaderText = "Ürün Numarası"; break;
                        case "UrunAd":
                            dgv.Columns[i].HeaderText = "Ürün Adı"; break;
                        case "Aciklama":
                            dgv.Columns[i].HeaderText = "Açıklama"; break;
                        case "UrunGrub":
                            dgv.Columns[i].HeaderText = "Ürün Grubu"; break;
                        case "AlisFiyat":
                            dgv.Columns[i].HeaderText = "Alış Fiyatı"; break;
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; break;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "AlisFiyatFiyatToplam":
                            dgv.Columns[i].HeaderText = "Alış Fiyat Toplam"; break;
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; break;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;

                        case "SatisFiyat":
                            dgv.Columns[i].HeaderText = "Şatış Fiyatı"; break;
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; break;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "KdvOrani":
                            dgv.Columns[i].HeaderText = "Kdv Oranı"; break;
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "Birim":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "Miktar":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "OdemeSekli":
                            dgv.Columns[i].HeaderText = "Ödeme Şekli"; break;
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "Kart":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; break;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "Nakit":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; break;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "Gelir":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; break;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "Gider":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; break;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "Kullanici":
                            dgv.Columns[i].HeaderText = "Kullanıcı"; break;
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "KdvTutari":
                            dgv.Columns[i].HeaderText = "Kdv Tutarı"; break;
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; break;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "Toplam":
                            dgv.Columns[i].HeaderText = "Toplam"; break;
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; break;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;

                    }
                }
            }
        }

        internal static void StokHareket1(string text1, string v1, double v2, string text2, string text3)
        {
            throw new NotImplementedException();
        }

        internal static void StokHareket1()
        {
            throw new NotImplementedException();
        }
      
        public static void StokHareket1(string barkod, string urunad, string birim, double miktar, string urungrup, string kullanici)
        {
            using (var db = new BarkodDbEntities())
            {
                StokHareket sh = new StokHareket();
                sh.Barkod = barkod;
                sh.UrunAd = urunad;
                sh.Birim = birim;
                sh.Miktar = miktar;
                sh.UrunGrup = urungrup;
                sh.Kullanici = kullanici;
                sh.Tarih = DateTime.Now;
                db.StokHareket.Add(sh);
                db.SaveChanges();
            }
        }

        public static int KartKomisyon()
        {
            int sonuc = 0;
            using (var db = new BarkodDbEntities())
            {
                if (db.Sabit.Any())
                {
                    sonuc = Convert.ToInt16(db.Sabit.First().KartKomisyon);
                }
                else
                {
                    sonuc = 0;
                }
            }
            return sonuc;
        }

        public static void SabitVarsayilan()
        {
            using (var db = new BarkodDbEntities())
            {
                if (!db.Sabit.Any())
                {
                    Sabit s = new Sabit();
                    s.KartKomisyon = 0;
                    s.Yazici = false;
                    s.AdSoyad = "admin";
                    s.Adres = "admin";
                    s.Unvan = "admin";
                    s.Telefon = "admin";
                    s.Eposta = "admin";
                    db.Sabit.Add(s);
                    db.SaveChanges();
                }
                
            }
        }

        public static void Backup()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Veri yedek dosyası|0.bak";
            save.FileName = "Barkodlu_Satis_Programi_" + DateTime.Now.ToShortDateString();
            if (save.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (File.Exists(save.FileName))
                    {
                        File.Delete(save.FileName);
                    }
                    var dbHedef = save.FileName;
                    //string dbKaynak = Application.StartupPath + @"\BarkodDb.mdf";
                    using (var db=new BarkodDbEntities())
                    {
                        string dbKaynak = db.Database.Connection.Database;
                        var cmd = @"BACKUP DATABASE[" + dbKaynak + "] TO DISK='" + dbHedef + "'";
                        db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, cmd);
                    }
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Yedekleme tamamlanmıştır");
                }
                catch (Exception ex )
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
