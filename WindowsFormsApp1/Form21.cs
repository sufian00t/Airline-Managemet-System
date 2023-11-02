using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-H5LD2MF;Initial Catalog=Airline management System;Integrated Security=True");
        private void Populate()
        {
            con.Open();
            string query = "select * from Pilot";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thankyou for Your Query , Authority will response via your Mail");
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            Populate();
        }
    }
}
