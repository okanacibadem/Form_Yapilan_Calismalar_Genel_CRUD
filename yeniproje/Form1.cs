using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yeniproje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Personel> liste = new List<Personel>()
            {
                new Personel() {Ad="Nimet",Yas=23},
                new Personel() {Ad="MUHAMMED",Yas=22},
                 new Personel() {Ad="Büşra",Yas=20},
                  new Personel() {Ad="Ayşe",Yas=21},
            };


            //Şartı sağlayanı getiriyor
            //dataGridView1.DataSource = liste.Where(x => x.Ad == "Nimet").ToList();
            //---------------------


            //dataGridView1.DataSource = liste.Where(x => x.Ad == "Muhammed").Select(x => x.Yas);
            //---------------------


            //Yasa göre sıralayıp getiriyor
            //dataGridView1.DataSource = liste.OrderBy(x => x.Yas).ToList();
            //---------------------


            //ilk iki satırı getiriyor
            //dataGridView1.DataSource = liste.OrderBy(x => x.Yas).Skip(2).ToList();
            //---------------------

            //
            //dataGridView1.DataSource = liste.Where(x => x.Ad.Contains("A")).Take(2).ToList();
            //dataGridView1.DataSource = liste.Where(x => x.Ad.Contains("a")).ToList();

            //textBox1.Text = liste.Any(x => x.Ad == "Ayşe").ToString();
            //textBox1.Text = liste.FirstOrDefault(p => p.Yas == 23).Ad;

            //dataGridView1.DataSource = liste.Where(p => p.Ad.Contains("e")).ToList();

            //dataGridView1.DataSource = liste.Where(p => p.Ad.StartsWith("M")).ToList();

            //textBox1.Text = liste.Sum(p => p.Yas).ToString();


            textBox1.Text = liste.Find(p => p.Yas == 21).Ad.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] numara = { 1, 3, 5, 7, 9 };

            //singleordefault: Eğer dizi içinden sadece bir tane sayı seçmek istiyorsak ve seciö
            //şartımız sağlamıyorsa bu durumda int tipinin varsayılan değeri olan 0 (sıfır)
            //döndürülsün istiyorsak singleordefault secimi kullanmalıyız.

            int a = numara.SingleOrDefault(n => n.Equals(9));
            textBox1.Text = a.ToString();

            if (a.ToString()=="0")
            {
                MessageBox.Show("böyle bir kişi bulunamadı ");
            }
            else
            {
                MessageBox.Show("Bulundu");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //single : eğer seciminiz sonucunda sadece bir tane elemam geleceği garanti ise , bu durumda single secimini kullanabiliriz.
            //eğer şatımızı sağlayan hiçbir eleman dönmezse veya şartımızı sağlayan birden fazla eleman dönerse , bu iki durumda istisnalar fırlatışacak ve hata ile karşilaşmoi olucaz
            int[] sayılar = { 1, 3, 5, 7, 9, 11 };

            try
            {
                int a = sayılar.Single(n => n.Equals(11));
                textBox1.Text = a.ToString();
            }
            catch 
            {
                MessageBox.Show("hata yakalandı cnm");
                throw;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] sayilar = { 1, 3, 5, 7, 9, 13 };

            int sayi = 0;
            //sayi = sayilar.FirstOrDefault(n => n > 9);
            //sayi = sayilar.FirstOrDefault(n => n == 3);
            //sayi = sayilar.FirstOrDefault(n => n > 4);
            // 4 den nütük ilk elemanı getirir.
            //sayi = sayilar.First(n => n == 5);
            //sayi = sayilar.First(n => n>2);
            //sayi = sayilar.First(n => n > 13);

            textBox1.Text = sayi.ToString();

        }
    }
}
