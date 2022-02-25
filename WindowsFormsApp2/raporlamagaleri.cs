using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class raporlamagaleri : Form
    {
        public raporlamagaleri()
        {
            InitializeComponent();
        }
        GalericiEntities3 islem = new GalericiEntities3();
        private void button1_Click(object sender, EventArgs e)
        {
            var sonuc = from arac in islem.Araclars
                        orderby arac.AracModel descending
                        select arac;
            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sonuc = from d in islem.Araclars
                        group d by d.AracMarka into Grup
                        select new
                        {
                            AraçFiyattoplam = Grup.Sum(p => p.AracFiyat * p.AracAdet),
                            aracmarka = Grup.Key

                        };


            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sonuc = from arac in islem.Araclars
                        orderby arac.AracYıl ascending
                        select arac;
            dataGridView1.DataSource = sonuc.ToList();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            var sonuc = from sube in islem.Subelers
                        join Araclar in islem.Araclars on sube.SubeNo
                        equals Araclar.SubeNo
                        select new
                        {
                            sube.Musteriler,
                            sube.MusteriNo,
                            sube.SubeNo,
                            Araclar.AracPaket,
                            Araclar.AracRenk
                        };
            dataGridView1.DataSource = sonuc.ToList();
        }
        //        var sonuc = from urun in islem.Urunlers
        //                    join kategori in islem.Kategorilers on urun.KategoriID
        //                    equals kategori.KategoriID
        //                    join tedarikci in islem.Tedarikcilers on urun.TedarikciID
        //equals tedarikci.TedarikciID
        //                    select new
        //                    {
        //                        urun.UrunAdi,
        //                        urun.BirimdekiMiktar,
        //                        kategori.KategoriAdi,
        //                        kategori.KategoriID,
        //                        urun.UrunID,
        //                        urun.TedarikciID,
        //                        tedarikci.Telefon
        //                    };
        //        dataGridView1.DataSource = sonuc.ToList();
        private void button5_Click(object sender, EventArgs e)
        {
            var sonuc = from arac in islem.Araclars
                        join sube in islem.Subelers on arac.SubeNo
                        equals sube.SubeNo
                        join musteri in islem.Musterilers on sube.MusteriNo
                        equals musteri.MusteriNo
                        select new
                        {arac.AracYıl,
                        arac.AracNo,
                        sube.MusteriNo,
                        sube.SubeCalısanSayisi,
                        musteri.MusteriYas,
                        musteri.MusteriBakiye
                        };
            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var sonuc = from d in islem.Musterilers
                        group d by d.MusteriYas into Grup
                        select new
                        {
                            macbakiye= Grup.Max(p => p.MusteriBakiye),
                            musteriyas = Grup.Key
                        };

            dataGridView1.DataSource = sonuc.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        //var sonuc = from detay in islem.Satis_Detaylaris
        //            group detay by detay.Satislar.SatisTarihi.Value.Year into Grup
        //            select new
        //            {
        //                Gelir = Grup.Sum(Satis => Satis.Miktar * Satis.BirimFiyati),
        //                Yil = Grup.Key
        //            };
        //dataGridView1.DataSource = sonuc.ToList();
    }
}
