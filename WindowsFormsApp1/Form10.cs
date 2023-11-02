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
    public partial class Form10 : Form
    {
        public static Form10 Instance;
        public Form10()
        {
            InitializeComponent();
            Instance = this;
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-H5LD2MF;Initial Catalog=Airline management System;Integrated Security=True");
        private void button_WOC2_Click(object sender, EventArgs e)
        {
            Form15 ff = new Form15();
            ff.Show();
            this.Hide();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "update Ticket set Date = @Date , Time = @Time where Passport = @Passport";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Passport", textBox1.Text);
                cmd.Parameters.AddWithValue("@Date", textBox3.Text);
                cmd.Parameters.AddWithValue("@Time", comboBox2.SelectedItem);
                int check = cmd.ExecuteNonQuery();
                if (check > 0)
                {
                    MessageBox.Show("Ticket Re-Scheduled Successfully");
                    Form22 ff = new Form22();
                    ff.Show();
                    this.Hide();

                }

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        
    }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(this.textBox1, "Please fill the information");
                textBox1.Focus();
            }
            else errorProvider1.Clear();
        }
    }
}
