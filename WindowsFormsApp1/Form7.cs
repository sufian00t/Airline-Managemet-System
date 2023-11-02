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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-H5LD2MF;Initial Catalog=Airline management System;Integrated Security=True");

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
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

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider3.SetError(this.textBox3, "Please fill the information");
                textBox3.Focus();
            }
            else errorProvider3.Clear();

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox4.Text))
            {
                errorProvider4.SetError(this.textBox4, "Please fill the information");
                textBox4.Focus();
            }
            else errorProvider4.Clear();

        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                errorProvider5.SetError(this.comboBox1, "Please Select an item");
                comboBox1.Focus();
            }
            else errorProvider5.Clear();
        }

        private void comboBox5_Leave(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem == null)
            {
                errorProvider6.SetError(this.comboBox5, "Please Select an item");
                comboBox5.Focus();
            }
            else errorProvider6.Clear();

        }

        private void comboBox4_Leave(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem == null)
            {
                errorProvider7.SetError(this.comboBox4, "Please Select an item");
                comboBox4.Focus();
            }
            else errorProvider7.Clear();

        }

        private void comboBox3_Leave(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == null)
            {
                errorProvider8.SetError(this.comboBox3, "Please Select an item");
                comboBox3.Focus();
            }
            else errorProvider8.Clear();

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox3.SelectedItem == null || comboBox5.SelectedItem == null || textBox4.Text == ""|| comboBox1.SelectedItem == null|| comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Please fillup required feilds");
            }
            else
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string query = "insert into Ticket values(@Name , @Passport , @Date ,@Time , @Phone , @Nationality , @Source , @Destination , @Seat , @Amount)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Passport", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Date", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Time", comboBox2.SelectedItem);
                    cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Nationality", comboBox1.SelectedItem);
                    cmd.Parameters.AddWithValue("@Source", comboBox5.SelectedItem);
                    cmd.Parameters.AddWithValue("@Destination", comboBox4.SelectedItem);
                    cmd.Parameters.AddWithValue("@Seat", comboBox3.SelectedItem);
                    if (comboBox3.SelectedIndex == 0)
                    {
                        textBox5.Text = "800000";
                        cmd.Parameters.AddWithValue("@Amount", 80000);

                    }
                    else if (comboBox3.SelectedIndex == 1)
                    {
                        textBox5.Text = "100000";
                        cmd.Parameters.AddWithValue("@Amount", 100000);
                    }
                    else
                    {
                        textBox5.Text = "1200000";
                        cmd.Parameters.AddWithValue("@Amount", 120000);
                    }
                    int check = cmd.ExecuteNonQuery();
                    if (check > 0)
                    {
                        MessageBox.Show("Ticket Booked Successfully");
                        Form22 ff = new Form22();
                        ff.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Something Erorr Occured,Please Try again");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        comboBox1.SelectedItem = null;
                        comboBox3.SelectedItem = null;
                        comboBox4.SelectedItem = null;
                        comboBox5.SelectedItem = null;

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
        }
    }
}
