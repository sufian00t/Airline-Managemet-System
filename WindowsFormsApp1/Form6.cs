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
    public partial class Add_Flight : Form
    {
        public Add_Flight()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-H5LD2MF;Initial Catalog=Airline management System;Integrated Security=True");
        private void Populate()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string query = "select * from Flight;";
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 ff = new Form5();
            ff.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 ff = new Form4();
            ff.Show();
            this.Hide();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox5.Text == "" || textBox3.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || textBox6.Text=="")
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
                    string query = "insert into Flight values(@FlightCode , @Source , @Destination , @Date , @Seats)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@FlightCode", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Source", comboBox1.SelectedItem);
                    cmd.Parameters.AddWithValue("@Destination", comboBox2.SelectedItem);
                    cmd.Parameters.AddWithValue("@Date", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Seats", textBox5.Text);
                    int check = cmd.ExecuteNonQuery();
                    if (check > 0)
                    {
                        MessageBox.Show("Flight Added Successfully");
                        Populate();
                    }
                    else
                    {
                        MessageBox.Show("Something Erorr Occured,Please Try again");

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

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox5.Text == "" || textBox3.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || textBox6.Text == "")
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
                    string query = "update Flight set FlightCode = @FlightCode , Source = @Source , Destination = @Destination , Date = @Date , Seats = @Seats where FlightCode = @FlightCode";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@FlightCode", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Source", comboBox1.SelectedItem);
                    cmd.Parameters.AddWithValue("@Destination", comboBox2.SelectedItem);
                    cmd.Parameters.AddWithValue("@Date", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Seats", textBox5.Text);
                    int check = cmd.ExecuteNonQuery();
                    if (check > 0)
                    {
                        MessageBox.Show("Flight Updated Successfully");
                        Populate();
                    }
                    else
                    {
                        MessageBox.Show("Something Erorr Occured,Please Try again");

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

        private void button_WOC3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox5.Text == "" || textBox3.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || textBox6.Text == "")
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
                    string query = "delete from Flight where FlightCode = @FlightCode";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@FlightCode", textBox1.Text);
                    int check = cmd.ExecuteNonQuery();
                    if (check > 0)
                    {
                        MessageBox.Show("Flight deleted Successfully");
                        Populate();
                    }
                    else
                    {
                        MessageBox.Show("Something Erorr Occured,Please Try again");

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

        private void button_WOC4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox5.Text = "";
            textBox3.Text = "";
            comboBox2.SelectedItem = null;
            comboBox1.SelectedItem = null;
            textBox6.Text = "";
        }
    }
}
