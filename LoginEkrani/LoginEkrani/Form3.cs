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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-E35HS2M;Initial Catalog=obs;Integrated Security=True");
        SqlCommand command;
        SqlDataReader dataReader;
        
        
            public int id;
        
         public int listele()
        {
            id = (int)(dataReader["student_id"]);
            return id;
        }
       
        
        public void button1_Click(object sender, EventArgs e)
        {

            connection.Open();
            command = new SqlCommand("SELECT student_id, password  FROM student WHERE student_id = @username AND password = @password", connection);
            command.Parameters.AddWithValue("@username", textBox1.Text);
            command.Parameters.AddWithValue("@password", textBox2.Text);
            dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
                Form4 form4 = new Form4(listele());
                form4.Show();
                this.Hide();
                form4.Location = this.Location;
            }
            else
            {
                MessageBox.Show("Username or Password Incorrect!");
            }
            connection.Close();


        }
        
        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
