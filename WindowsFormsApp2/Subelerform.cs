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
    public partial class Subelerform : Form
    {
        public Subelerform()
        {
            InitializeComponent();
        }
        GalericiEntities3 baglanti = new GalericiEntities3();
        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.Subelers.ToList();
        }
        public void Goruntule()
        {
            dataGridView1.DataSource = baglanti.Subelers.ToList();

        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            int No = Convert.ToInt32(textBox2.Tag);
            Subeler sil = baglanti.Subelers.SingleOrDefault(x => x.SubeNo == No);
            baglanti.Subelers.Remove(sil);
            baglanti.SaveChanges();
            Goruntule();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            Subeler ekle = new Subeler();
            ekle.SubeNo = Convert.ToInt32(textBox1.Text);
            ekle.SubeAdi = textBox2.Text;
            ekle.SubeCalısanSayisi = Convert.ToInt32(textBox3.Text);
            ekle.SubeCiro = Convert.ToInt32(textBox4.Text);
            ekle.SubeCiro = Convert.ToInt32(textBox4.Text); 
            baglanti.Subelers.Add(ekle);
            baglanti.SaveChanges();
            Goruntule();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            int No = Convert.ToInt32(textBox2.Tag);
            Subeler yenile = baglanti.Subelers.SingleOrDefault(z => z.MusteriNo == No);
            yenile.SubeAdi = textBox2.Text;
            yenile.SubeCalısanSayisi =Convert.ToInt32( textBox3.Text);
            yenile.SubeCiro = Convert.ToInt32(textBox4.Text);
            baglanti.SaveChanges();
            Goruntule();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox2.Tag = satir.Cells["SubeNo"].Value.ToString();
            textBox2.Text = satir.Cells["SubeAdi"].Value.ToString();
            textBox3.Text = satir.Cells["SubeCalısanSayisi"].Value.ToString();
            textBox4.Text = satir.Cells["SubeCiro"].Value.ToString();
            textBox5.Text = satir.Cells["MusteriNo"].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.Subelers.Where(a =>
           a.SubeAdi.ToLower().Contains(textBox2.Text) || a.SubeAdi.ToUpper().Contains(textBox2.Text)).ToList();
     

        }
    }
}
