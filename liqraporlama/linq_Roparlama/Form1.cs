using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linq_Roparlama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sonuc = from urun in islem.Urunlers
                        join tedarikci in islem.Tedarikcilers on urun.TedarikciID
                        equals tedarikci.TedarikciID
                        select new
                        {
                            urun.UrunAdi,
                            urun.BirimFiyati,
                            urun.HedefStokDuzeyi,
                            tedarikci.SirketAdi,
                            tedarikci.Sehir,
                            tedarikci.Telefon
                        };
            dataGridView1.DataSource = sonuc.ToList();
        }
        NorthwindEntities islem = new NorthwindEntities();
        private void button3_Click(object sender, EventArgs e)
        {
            var sonuc = from urun in islem.Urunlers
                        orderby urun.BirimFiyati
                        select urun;
            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var sonuc = from urun in islem.Urunlers
                        orderby urun.UrunAdi descending
                        select urun;
            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var sonuc = from urun in islem.Urunlers
                        orderby urun.UrunAdi ascending
                        select urun;
            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var sonuc = from urun in islem.Urunlers
                        join kategori in islem.Kategorilers on urun.KategoriID
                        equals kategori.KategoriID
                        select new
                        {urun.UrunAdi,
                        urun.YeniSatis,
                        urun.HedefStokDuzeyi,
                        kategori.KategoriAdi,
                        kategori.Tanimi
                        };
            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var sonuc = from urun in islem.Urunlers
                        join kategori in islem.Kategorilers on urun.KategoriID
                        equals kategori.KategoriID join tedarikci in islem.Tedarikcilers on urun.TedarikciID
                        equals tedarikci.TedarikciID
                        select new
                        {
                            urun.UrunAdi,
                            urun.BirimdekiMiktar,                        
                            kategori.KategoriAdi,
                            kategori.KategoriID,
                            urun.UrunID,
                            urun.TedarikciID,
                            tedarikci.Telefon
                        };
            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sonuc = from personel in islem.Personellers
                        join satis in islem.Satislars on
                        personel.PersonelID equals satis.PersonelID
                        group satis by personel.Adi into grup
                        select new
                        {
                            personelAdi = grup.Key,
                            toplamsatis = grup.Count()
                        };
            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var sonuc = from detay in islem.Satis_Detaylaris
                        group detay by detay.Satislar.SatisTarihi.Value.Year into Grup
                        select new
                        {
                            Gelir =Grup.Sum(Satis => Satis.Miktar*Satis.BirimFiyati),
                            Yil =Grup.Key
                        };
            dataGridView1.DataSource = sonuc.ToList();
        }
    }
}
