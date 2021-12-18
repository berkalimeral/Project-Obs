using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginEkrani
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-E35HS2M;Initial Catalog=obs;Integrated Security=True");
        SqlCommand command;
        SqlDataReader dataReader;

        public int id;

        public int listele()
        {
            id = (int)(dataReader["id"]);
            return id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            command = new SqlCommand("SELECT username, password, id FROM academist WHERE username = @username AND password = @password", connection);
            command.Parameters.AddWithValue("@username",textBox1.Text);
            command.Parameters.AddWithValue("@password",textBox2.Text);
            dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
                Form5 academist_page = new Form5(listele());
                academist_page.Show();
                this.Hide();
                academist_page.Location = this.Location;
            }
            else
            {
                MessageBox.Show("Username or Password Incorrect!");
            }
            connection.Close();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
