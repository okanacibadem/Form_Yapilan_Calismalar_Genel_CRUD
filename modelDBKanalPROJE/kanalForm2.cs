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
    public partial class kanalForm2 : Form
    {
        public kanalForm2()
        {
            InitializeComponent();
        }
        Model1kanalContainer baglanti = new Model1kanalContainer();
        public void Goruntule()
        {
            dataGridView1.DataSource = baglanti.kanalSet.ToList();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
           kanal ekle = new kanal();

            ekle.kanaladi = textBox2.Text;
            ekle.ciro = Convert.ToInt32(textBox5.Text);
            ekle.adres = textBox3.Text;
            ekle.reyting = Convert.ToInt32(textBox4.Text); 
            ekle.yayinId= Convert.ToInt32(textBox6.Text);
            baglanti.kanalSet.Add(ekle);
            baglanti.SaveChanges();
            Goruntule();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["Kanalno"].Value.ToString();
            textBox1.Text = satir.Cells["Kanalno"].Value.ToString();
            textBox2.Text = satir.Cells["kanaladi"].Value.ToString();
            textBox5.Text = satir.Cells["ciro"].Value.ToString();
            textBox3.Text = satir.Cells["adres"].Value.ToString();
            textBox4.Text = satir.Cells["reyting"].Value.ToString();
            textBox6.Text = satir.Cells["yayinId"].Value.ToString();
        }
        private void btnYenile_Click(object sender, EventArgs e)
        {
            int No = Convert.ToInt32(textBox1.Tag);
            kanal yenile = baglanti.kanalSet.SingleOrDefault(z => z.KanaIno== No);
            yenile.kanaladi = textBox2.Text;
            yenile.ciro = Convert.ToInt32(textBox5.Text);
            yenile.reyting = Convert.ToInt32(textBox4.Text);
            yenile.yayinId = Convert.ToInt32(textBox6.Text);
            baglanti.SaveChanges();
            Goruntule();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.kanalSet.ToList();
        }

       
    }
}
