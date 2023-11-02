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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-H5LD2MF;Initial Catalog=Airline management System;Integrated Security=True");
        private void Populate()
        {
            con.Open();
            string query = "select Name , E-Mail , Passport , Nationality , Gender from Passengerinfor";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form18 ff = new Form18();
            ff.Show();
            this.Hide();
        }

        private void button_WOC4_Click(object sender, EventArgs e)
        {
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

        private void button_WOC2_Click(object sender, EventArgs e)
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

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedItem = "";
            comboBox2.SelectedItem = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form25 ff = new Form25();
            ff.Show();
            this.Hide();
        }
    }
}
