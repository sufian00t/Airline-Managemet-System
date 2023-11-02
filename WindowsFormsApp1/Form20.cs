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
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            Form24 ff = new Form24();
            ff.Show();
            this.Hide();

        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            Form11 ff = new Form11();
            ff.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form18 ff = new Form18();
            ff.Show();
            this.Hide();
        }
    }
}
