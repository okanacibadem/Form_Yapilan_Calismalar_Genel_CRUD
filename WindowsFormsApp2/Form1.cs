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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            araclarForm git = new araclarForm();
            git.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MusterilerForm git = new MusterilerForm();
            git.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Subelerform git = new Subelerform();
            git.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            raporlamagaleri git = new raporlamagaleri();
            git.Show();
            this.Hide();
        }
    }
}
