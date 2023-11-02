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
    public partial class Form15 : Form
    {
        public static Form15 Instance;
        public Form15()
        {
            InitializeComponent();
            Instance = this;
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-H5LD2MF;Initial Catalog=Airline management System;Integrated Security=True");

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            Form10 ff = new Form10();
            ff.Show();
            this.Hide();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "delete from Ticket where Passport = @Passport";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Passport", Form10.Instance.textBox1.Text);
                int check = cmd.ExecuteNonQuery();
                if (check > 0)
                {
                    MessageBox.Show("Ticket Cancelled");
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

    }
    }

