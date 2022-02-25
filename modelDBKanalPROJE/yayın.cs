using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modelDBKanalPROJE
{
    public partial class yayın : Form
    {
        public yayın()
        {
            InitializeComponent();
        }
        Model1kanalContainer baglanti = new Model1kanalContainer();

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.yayinSet.ToList();
        }
        public void Goruntule()
        {
            dataGridView1.DataSource = baglanti.yayinSet.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            yayin ekle = new yayin();

            ekle.yayinadi = textBox1.Text;
            ekle.yayıntarih = dateTimePicker1.Value;
            ekle.reyting = Convert.ToInt32(textBox4.Text);
            baglanti.yayinSet.Add(ekle);
            baglanti.SaveChanges();
            Goruntule();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            int No = Convert.ToInt32(textBox2.Tag);
            yayin yenile = baglanti.yayinSet.SingleOrDefault(z => z.Id == No);
            yenile.yayinadi = textBox2.Text;
            yenile.yayıntarih = dateTimePicker1.Value;
            yenile.reyting = Convert.ToInt32(textBox4.Text);
            baglanti.SaveChanges();
            Goruntule();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox2.Tag = satir.Cells["Id"].Value.ToString();
            textBox2.Text = satir.Cells["yayinadi"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["yayıntarih"].Value.ToString();
           textBox4.Text = satir.Cells["reyting"].Value.ToString(); 

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int No = Convert.ToInt32(textBox2.Tag);
            yayin sil = baglanti.yayinSet.SingleOrDefault(x => x.Id == No);
            baglanti.yayinSet.Remove(sil);
            baglanti.SaveChanges();
            Goruntule();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.yayinSet.Where(a =>
           a.yayinadi.ToLower().Contains(textBox2.Text) || a.yayinadi.ToUpper().Contains(textBox2.Text)).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Hide();
        }
    }
}
