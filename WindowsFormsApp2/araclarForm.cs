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
    public partial class araclarForm : Form
    {
        public araclarForm()
        {
            InitializeComponent();
        }
        GalericiEntities3 baglanti = new GalericiEntities3();
        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.Araclars.ToList();
        }
        public void Goruntule()
        {
            dataGridView1.DataSource = baglanti.Araclars.ToList();

        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Araclar ekle = new Araclar();           
            ekle.AracFiyat = Convert.ToInt32(textBox2fiyat.Text);
            ekle.AracAdet =Convert.ToInt32( textBox3det.Text);
            ekle.AracMarka = textBox4mark.Text;
            ekle.AracModel = Convert.ToInt32(textBox5model.Text);
            ekle.AracYıl = Convert.ToInt32(textBox6yıl.Text);
            ekle.AracOzellik = textBox7özellik.Text;
            ekle.AracMotor = textBox8motor.Text;
            ekle.AracPaket = textBox9paket.Text;
            ekle.AracRenk = textBox10renk.Text;
            ekle.SubeNo = Convert.ToInt32(textBox11subeno.Text);
        
            baglanti.Araclars.Add(ekle);
            baglanti.SaveChanges();
            Goruntule();

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {

            int No = Convert.ToInt32(textBox2fiyat.Tag);
            Araclar yenile = baglanti.Araclars.SingleOrDefault(z => z.AracNo == No);
            yenile.AracFiyat = Convert.ToInt32(textBox2fiyat.Text);
            yenile.AracAdet = Convert.ToInt32(textBox3det.Text);
            yenile.AracMarka = textBox4mark.Text;
            yenile.AracModel = Convert.ToInt32(textBox5model.Text);
            yenile.AracYıl = Convert.ToInt32(textBox6yıl.Text);
            yenile.AracOzellik = textBox7özellik.Text;
            yenile.AracMotor = textBox8motor.Text;
            yenile.AracPaket = textBox9paket.Text;
            yenile.AracRenk = textBox10renk.Text;
            baglanti.SaveChanges();
            Goruntule();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
           textBox2fiyat.Tag = satir.Cells["AracNo"].Value.ToString();
            textBox2fiyat.Text = satir.Cells["AracFiyat"].Value.ToString();
            textBox3det.Text = satir.Cells["AracAdet"].Value.ToString();
            textBox4mark.Text = satir.Cells["AracMarka"].Value.ToString();
            textBox5model.Text = satir.Cells["AracModel"].Value.ToString();
           textBox6yıl.Text = satir.Cells["AracYıl"].Value.ToString();
            textBox7özellik.Text = satir.Cells["AracOzellik"].Value.ToString();
           textBox8motor.Text = satir.Cells["AracMotor"].Value.ToString();
            textBox9paket.Text = satir.Cells["AracPaket"].Value.ToString();
           textBox10renk.Text = satir.Cells["AracRenk"].Value.ToString();
            textBox11subeno.Text = satir.Cells["SubeNo"].Value.ToString();
   
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int No = Convert.ToInt32(textBox2fiyat.Tag);
            Araclar sil = baglanti.Araclars.SingleOrDefault(x => x.AracNo == No);
            baglanti.Araclars.Remove(sil);
            baglanti.SaveChanges();
            Goruntule();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.Araclars.Where(a =>
            a.AracMarka.ToLower().Contains(textBox4mark.Text) || a.AracMarka.ToUpper().Contains(textBox4mark.Text)).ToList();   
            
            
            ;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
