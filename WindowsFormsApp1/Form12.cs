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
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-H5LD2MF;Initial Catalog=Airline management System;Integrated Security=True");
        string pat = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        private void Populate()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string query = "select * from Passengerinfor";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 ff = new Form3();
            ff.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 ff = new Form4();
            ff.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 ff = new Form5();
            ff.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Form6 Unavailable
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void Form12_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox2.SelectedItem = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
           

        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {

        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            //Reset
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedItem = "";
            comboBox2.SelectedItem = "";

        }

        private void button_WOC4_Click(object sender, EventArgs e)
        {
            //Create
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please fillup required feilds");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into Passengerinfor values(@Name , @E-Mail , @Passport , @Nationality , @Gender)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@E-Mail", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Passport", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Nationality", comboBox2.SelectedItem);
                    cmd.Parameters.AddWithValue("@Gender", comboBox1.SelectedItem);
                    int check = cmd.ExecuteNonQuery();
                    if (check > 0)
                    {
                        MessageBox.Show("Passenger Added Successfully");
                        Populate();

                    }
                    else
                    {
                        MessageBox.Show("Something Erorr Occured,Please Try again");

                    }
                    con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please fillup required feilds");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update Passengerinfor set Name = @Name ,E-Mail = @E-Mail ,Passport = @Passport ,Nationality = @Nationality ,Gender = @Gender where Passport = @Passport";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@E-Mail", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Passport", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Nationality", comboBox2.SelectedItem);
                    cmd.Parameters.AddWithValue("@Gender", comboBox1.SelectedItem);
                    int check = cmd.ExecuteNonQuery();
                    if (check > 0)
                    {
                        MessageBox.Show("Passenger Updated Successfully");
                        Populate();

                    }
                    else
                    {
                        MessageBox.Show("Something Erorr Occured,Please Try again");

                    }
                    con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button_WOC2_Click_1(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please fillup required feilds");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete Passengerinfor where Passport = @Passport";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Passport", textBox2.Text);
                    int check = cmd.ExecuteNonQuery();
                    if (check > 0)
                    {
                        MessageBox.Show("Passenger Deleted Successfully");
                        Populate();

                    }
                    else
                    {
                        MessageBox.Show("Something Erorr Occured,Please Try again");

                    }
                    con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox4.Text, pat) == false)
            {
                textBox2.Focus();
                errorProvider1.SetError(this.textBox4, "Please give correct E-mail Sequence");

            }
            else errorProvider1.Clear();
        }
    }
}
