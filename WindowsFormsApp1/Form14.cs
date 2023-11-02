using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-H5LD2MF;Initial Catalog=Airline management System;Integrated Security=True");
        private void Form14_Load(object sender, EventArgs e)
        {
           
        }
        string pat = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
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
            if (Regex.IsMatch(textBox2.Text, pat)==false)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Please give correct E-mail Sequence");

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

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                errorProvider4.SetError(this.comboBox2, "Please Select an item");
                comboBox2.Focus();
            }
            else errorProvider4.Clear();

        }

        private void comboBox3_Leave(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == null)
            {
                errorProvider5.SetError(this.comboBox3, "Please Select an item");
                comboBox3.Focus();
            }
            else errorProvider5.Clear();

        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox6.Text))
            {
                errorProvider6.SetError(this.textBox6, "Please fill the information");
                textBox6.Focus();
            }
            else errorProvider6.Clear();

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null || textBox6.Text == "")
            {
                MessageBox.Show("Please fillup required feilds");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into Passengerinfor values(@Name , @Email , @Passport , @Nationality , @Gender , @PassCode)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Passport", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Nationality", comboBox2.SelectedItem);
                    cmd.Parameters.AddWithValue("@Gender", comboBox3.SelectedItem);
                    cmd.Parameters.AddWithValue("@PassCode", textBox6.Text);
                    int check = cmd.ExecuteNonQuery();
                    if (check > 0)
                    {
                        MessageBox.Show("Account Created Successfully");
                        Form1 ff = new Form1();
                        ff.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Something Erorr Occured,Please Try again");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox6.Text = "";
                        comboBox2.SelectedItem = null ;
                        comboBox3.SelectedItem = null;

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
