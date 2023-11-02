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
    public partial class Form5 : Form
    {
        public Form5()
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
            string query = "select * from Employee;";
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
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            //Addinfo
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.SelectedItem == null || textBox6.Text == "")
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
                    string query = "insert into Employee values(@Name , @Phone , @Address , @Role , @Employeeid)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Phone", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Role", comboBox1.SelectedItem);
                    cmd.Parameters.AddWithValue("@Employeeid", textBox6.Text);
                    int check = cmd.ExecuteNonQuery();
                    if (check > 0)
                    {
                        MessageBox.Show("Employee Added Successfully");
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
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ||  comboBox1.SelectedItem== null || textBox6.Text == "")
            {
                MessageBox.Show("Please fillup required feilds");
            }
            else
            {
                try
                {
                    if(con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    con.Open();
                    string query = "update Employee set Name = @Name ,Phone = @Phone ,Address = @Address ,Role = @Role ,Employeeid = @Employeeid where Employeeid = @Employeeid and Role = @Role";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Phone", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Role", comboBox1.SelectedItem);
                    cmd.Parameters.AddWithValue("@Employeeid", textBox6.Text);
                    int check = cmd.ExecuteNonQuery();
                    if (check > 0)
                    {
                        MessageBox.Show("Employee Updated Successfully");
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
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.SelectedItem == null || textBox6.Text == "")
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
                    string query = "delete from Employee where Employeeid = @Employeeid";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Employeeid", textBox6.Text);
                    int check = cmd.ExecuteNonQuery();
                    if (check > 0)
                    {
                        MessageBox.Show("Employee Deleted Successfully");
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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedItem = null;
            textBox6.Text = "";

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

        private void button3_Click(object sender, EventArgs e)
        {
            //Form6 ff = new Form6();
            //ff.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form12 ff = new Form12();
            ff.Show();
            this.Hide();
        }
    }
}
