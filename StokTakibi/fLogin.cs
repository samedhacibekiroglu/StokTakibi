﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakibi
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void bGiris_Click(object sender, EventArgs e)
        {
            GirisYap();
        }

        private void GirisYap()
        {
            if (tKullaniciAdi.Text != "" && tSifre.Text != "")
            {
                try
                {
                    using (var db = new BarkodDbEntities())
                    {
                        if (db.Kullanici.Any())
                        {
                            var bak = db.Kullanici.Where(X => X.KullaniciAd == tKullaniciAdi.Text && X.Sifre == tSifre.Text).FirstOrDefault();
                            if (bak != null)
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                fBaslangic f = new fBaslangic();
                                f.bSatisIslemi.Enabled = (bool)bak.Satis;
                                f.bGenelRapor.Enabled = (bool)bak.Rapor;
                                f.bStok.Enabled = (bool)bak.Stok;
                                f.bUrunGiris.Enabled = (bool)bak.UrunGiris;
                                f.bAyarlar.Enabled = (bool)bak.Ayarlar;
                                f.bFıyatGuncelle.Enabled = (bool)bak.FiyatGuncelle;
                                f.bYedekleme.Enabled = (bool)bak.Yedekleme;
                                f.lKullanici.Text = bak.AdSoyad;
                                var isyeri = db.Sabit.FirstOrDefault();
                              //  f.label1.Text = isyeri.Unvan;
                                f.Show();
                                this.Hide();
                                Cursor.Current = Cursors.Default;
                            }
                            else
                            {
                                MessageBox.Show("Hatalı Giriş...");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void fLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                GirisYap();
            }
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
