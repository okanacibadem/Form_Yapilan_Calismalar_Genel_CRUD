using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        HoldingEntities2 baglanti = new HoldingEntities2();
        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.Ogrencilers.ToList();

        }
        public void Goruntule()
        {
            dataGridView1.DataSource = baglanti.Ogrencilers.ToList();

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Ogrenciler ekle = new Ogrenciler();
            ekle.AdSoyad = txtadsoyad.Text;
            ekle.TcNO = txttcNo.Text;
            ekle.DogumTarihi = dateTimePicker1.Value.ToString();
            ekle.Telefon = txttelefon.Text;
            ekle.Adres = txtadres.Text;
            ekle.Mail = txtMail.Text;
            baglanti.Ogrencilers.Add(ekle);
            baglanti.SaveChanges();
            Goruntule();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            txtadsoyad.Tag = satir.Cells["OgrenciNo"].Value.ToString();
            txtadsoyad.Text = satir.Cells["AdSoyad"].Value.ToString();
            txttcNo.Text = satir.Cells["TcNO"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["DogumTarihi"].Value.ToString();
            txttelefon.Text = satir.Cells["Telefon"].Value.ToString();
            txtadres.Text = satir.Cells["Adres"].Value.ToString();
            txtMail.Text = satir.Cells["Mail"].Value.ToString();

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            int No = Convert.ToInt32(txtadsoyad.Tag);
            Ogrenciler yenile = baglanti.Ogrencilers.SingleOrDefault(z => z.OgrenciNo == No);
            yenile.AdSoyad = txtadsoyad.Text;
            yenile.TcNO = txttcNo.Text;
            yenile.DogumTarihi = dateTimePicker1.Value.ToString();
            yenile.Telefon = txttelefon.Text;
            yenile.Adres = txtadres.Text;
            yenile.Mail = txtMail.Text;
            baglanti.SaveChanges();
            Goruntule();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int No = Convert.ToInt32(txtadsoyad.Tag);
            Ogrenciler sil = baglanti.Ogrencilers.SingleOrDefault(x => x.OgrenciNo == No);
            baglanti.Ogrencilers.Remove(sil);
            baglanti.SaveChanges();
            Goruntule();
        }

       
    }
}
