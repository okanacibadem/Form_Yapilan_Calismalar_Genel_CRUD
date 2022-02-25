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
    public partial class MusterilerForm : Form
    {
        public MusterilerForm()
        {
            InitializeComponent();
        }
        GalericiEntities3 baglanti = new GalericiEntities3();

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.Musterilers.ToList();
        }
        public void Goruntule()
        {
            dataGridView1.DataSource = baglanti.Musterilers.ToList();

        }
        private void btnEkle_Click(object sender, EventArgs e)
        {

            Musteriler ekle = new Musteriler();
            ekle.MusteriNo = Convert.ToInt32(textBox1.Text);
            ekle.MusteriAdSoyad = textBox2.Text;
            ekle.MusteriYas = textBox3.Text;
            ekle.MusteriBakiye = textBox4.Text;    


            baglanti.Musterilers.Add(ekle);
            baglanti.SaveChanges();
            Goruntule();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            int No = Convert.ToInt32(textBox2.Tag);
           Musteriler yenile = baglanti.Musterilers.SingleOrDefault(z => z.MusteriNo == No);
            yenile.MusteriAdSoyad = textBox2.Text;
            yenile.MusteriYas = textBox3.Text;
            yenile.MusteriBakiye = textBox4.Text;     
            baglanti.SaveChanges();
            Goruntule();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox2.Tag = satir.Cells["MusteriNo"].Value.ToString();
            textBox2.Text = satir.Cells["MusteriAdSoyad"].Value.ToString();
            textBox3.Text = satir.Cells["MusteriYas"].Value.ToString();
            textBox4.Text = satir.Cells["MusteriBakiye"].Value.ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int No = Convert.ToInt32(textBox2.Tag);
            Musteriler sil = baglanti.Musterilers.SingleOrDefault(x => x.MusteriNo == No);
            baglanti.Musterilers.Remove(sil);
            baglanti.SaveChanges();
            Goruntule();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.Musterilers.Where(a =>
         a.MusteriAdSoyad.ToLower().Contains(textBox2.Text) ||
         a.MusteriAdSoyad.ToUpper().Contains(textBox2.Text)).ToList();

        }
    }
}
