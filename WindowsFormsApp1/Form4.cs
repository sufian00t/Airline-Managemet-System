using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 ff = new Form5();
            ff.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Flight management
           // Form6 ff = new Form6();
            //ff.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form12 ff = new Form12();
            ff.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 ff = new Form3();
            ff.Show();
            this.Hide();
        }
    }
}
