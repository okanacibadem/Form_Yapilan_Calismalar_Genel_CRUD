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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
       GalericiEntities3 baglanti = new GalericiEntities3();
        private bool girisyap(string ad,string sifre)
        {

            GalericiEntities3 baglanti = new GalericiEntities3();
            var sorgu = from p in baglanti.kullanıcılar
                        where p.kullanıcıAd == ad
                        && p.şifre == sifre
                        select p;
            if (sorgu.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglanti.kullanıcılar.ToList();
            comboBox1.ValueMember = "kullanıcıNO";

            label3.Visible = false;
            label4.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (girisyap(textBox1.Text,textBox2.Text))
            {
                Form1 git = new Form1();
                git.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            kullanıcılar ekle = new kullanıcılar();
            ekle.kullanıcıAd =textBox3.Text;
            ekle.şifre= textBox4.Text;
      
            baglanti.kullanıcılar.Add(ekle);
            baglanti.SaveChanges();
            MessageBox.Show("kullanıcı eklendi :");

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label3.Visible = true;
            label4.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            button2.Visible = true;
        }
    }
}
