using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1.Entity;
using ClassLibrary1.Facade;





namespace KatmanlıMimari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }    
        public void Goruntule()
        {
            dataGridView1.DataSource = Üretimler.Listele();
        }
     
        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Üretimler.Listele();

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Uretim uekle = new Uretim();
            uekle.UAdi = textBox2.Text;
            uekle.USehir = textBox3.Text;
            uekle.UMiktar = Convert.ToInt32(textBox4.Text);
            if (Üretimler.Ekle(uekle))
            {

            }
            Goruntule();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox2.Text = satir.Cells["AracId"].Value.ToString();
            textBox2.Text = satir.Cells["AracTuru"].Value.ToString();
            textBox3.Text = satir.Cells["USehir"].Value.ToString();
            textBox4.Text = satir.Cells["UMiktar"].Value.ToString();
            
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {

        }
    }
}
