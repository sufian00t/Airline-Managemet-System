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
    public partial class Form24 : Form
    {
        public Form24()
        {
            InitializeComponent();
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            Form20 ff = new Form20();
            ff.Show();
            this.Hide();
        }
    }
}
