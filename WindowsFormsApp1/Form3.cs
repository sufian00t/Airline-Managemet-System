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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-H5LD2MF;Initial Catalog=Airline management System;Integrated Security=True");
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form18 ff = new Form18();
            ff.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

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

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider2.SetError(this.textBox2, "Please fill the information");
                textBox2.Focus();
            }
            else errorProvider2.Clear();

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please fillup required feilds");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "select * from AdminLogin where UserId = @UserId and Passcode = @Passcode";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserId", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Passcode", textBox2.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        MessageBox.Show("Login Successful");
                        Form4 ff = new Form4();
                        ff.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No Account found in such Information");
                        textBox1.Clear();
                        textBox2.Clear();

                    }


                    con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
