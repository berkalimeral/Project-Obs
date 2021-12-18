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
    public partial class ders_ekle_sayfasi : Form
    {
        public int id;
        public ders_ekle_sayfasi(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-E35HS2M;Initial Catalog=obs;Integrated Security=True");
        SqlCommand command;

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            command = new SqlCommand("INSERT INTO coursee (course_code, course_name, class_capacity) VALUES ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "')", connection);
            command.ExecuteNonQuery();
            connection.Close();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            

            MessageBox.Show("New Course Saved!.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DersIslemleri dersIslemleri = new DersIslemleri(id);
            dersIslemleri.Show();
            this.Hide();
            dersIslemleri.Location = this.Location;
        }

        private void ders_ekle_sayfasi_Load(object sender, EventArgs e)
        {

        }
    }
}
