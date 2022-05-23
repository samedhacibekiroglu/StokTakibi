using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StokTakibi
{
    public partial class fHizliButonUrunEkle : Form
    {
        public fHizliButonUrunEkle()
        {
            InitializeComponent();
        }
        BarkodDbEntities db = new BarkodDbEntities();
        private void turunara_TextChanged(object sender, EventArgs e)
        {
            if (turunara.Text != "")
            {
                string urunad = turunara.Text;
                var urunler = db.Urun.Where(a => a.UrunAd.Contains(urunad)).ToList();
                gridurunler.DataSource = urunler;
                Islemler.GridDuzenle(gridurunler);
            }
        }

        private void gridurunler_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridurunler.Rows.Count > 0)
            {
                string barkod = gridurunler.CurrentRow.Cells["Barkod"].Value.ToString();
                string urunad = gridurunler.CurrentRow.Cells["UrunAd"].Value.ToString();
                double fiyat = Convert.ToDouble(gridurunler.CurrentRow.Cells["SatisFiyat"].Value.ToString());
                int id = Convert.ToInt16(lButonId.Text);
                var guncellenecek = db.HizliUrun.Find(id);
                guncellenecek.Barkod = barkod;
                guncellenecek.UrunAd = urunad;
                guncellenecek.Fiyat = fiyat;
                db.SaveChanges();
                MessageBox.Show("Buton Tanımlanmıştır");
                fSatis f = (fSatis)Application.OpenForms["fSatis"];
                if (f != null)
                {
                    Button b = f.Controls.Find("bH" + id, true).FirstOrDefault() as Button;
                    b.Text = urunad + "\n" + fiyat.ToString("C2");
                }

            }
        }

        private void chTumu_CheckedChanged(object sender, EventArgs e)
        {
            if (chTumu.Checked)
            {
                gridurunler.DataSource = db.Urun.ToList();
                gridurunler.Columns["AlisFiyat"].Visible = false;
                gridurunler.Columns["SatisFiyat"].Visible = false;
                gridurunler.Columns["KdvOrani"].Visible = false;
                gridurunler.Columns["KdvTutari"].Visible = false;
                gridurunler.Columns["Miktar"].Visible = false;
                
                Islemler.GridDuzenle(gridurunler);
            }
            else
            {
                gridurunler.DataSource = null;

            }
        }

        private void fHizliButonUrunEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
