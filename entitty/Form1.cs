using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entitty
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rakamlar = new[] { 1, 6, 2, 8, 9, 3, 7, 5, 4 };
            foreach (var item in rakamlar)
            {
                listBox1.Items.Add("Tüm Değerler : " + item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var liste = new[] { 1, 6, 2, 8, 9, 3, 7, 5, 4 };
            var tekler = liste.Where(sayi => sayi % 2 == 1);
            foreach (var tekSayi in tekler)
            {
                listBox1.Items.Add("Tek Değerler : " + tekSayi);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var liste = new int[] { 1, 3, 33, 44, 56, 101 };

            var tekler =
                from sayi in liste
                where sayi % 2 == 1
                select sayi;

            foreach (var tekSayi in tekler)
            {
                listBox1.Items.Add("tek sayilar : " + tekSayi);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var rakamlar = new[] { 1, 6, 2, 8, 9, 3, 7, 5, 4 };
            var küçüğebüyükten = from rkm in rakamlar orderby rkm ascending select rkm;
            Console.WriteLine("Küçüğe Büyükten  sayılar ");
            Console.WriteLine("-----------------------");
            foreach (var item in küçüğebüyükten)
            {
                listBox1.Items.Add("küçükten büyüğe sayilar :" + item);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var rakamlar = new[] { 1, 6, 2, 8, 9, 3, 7, 5, 4 };
            var büyüktenküçüğe = from rkm in rakamlar orderby rkm descending select rkm;
            Console.WriteLine("Büyükten küçüğe sayılar ");
            Console.WriteLine("-----------------------");
            foreach (var item in büyüktenküçüğe)
            {
                listBox1.Items.Add("küçükten büyüğe sayilar :" + item);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
