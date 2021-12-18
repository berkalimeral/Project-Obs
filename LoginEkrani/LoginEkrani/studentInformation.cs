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
    public partial class studentInformation : Form
    {

        public int student_id;
        public studentInformation(int student_id)
        {
            this.student_id = student_id;
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-E35HS2M;Initial Catalog=obs;Integrated Security=True");
        SqlCommand command;
        SqlDataReader dataReader;

        private void dersKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciDersEkleme ogrenciDersEkleme = new OgrenciDersEkleme(student_id);
            
            this.Hide();
            ogrenciDersEkleme.Show();
            ogrenciDersEkleme.Location = this.Location;
        }

        private void notlarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listofGrades listofGrades = new listofGrades(student_id);
            this.Hide();
            listofGrades.Show();
            listofGrades.Location = this.Location;
        }

        private void devamsızlıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            attendance attendance = new attendance(student_id);
            this.Hide();
            attendance.Show();
            attendance.Location = this.Location;
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(student_id);
            this.Hide();
            form4.Show();
            form4.Location = this.Location;
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application is developed by Alperen Sarıerikli and Berk Ali Meral.");
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        string imagepath;
        private void studentInformation_Load(object sender, EventArgs e)
        {
            connection.Open();
            command = new SqlCommand("SELECT student_id, name, surname,imagePath FROM student WHERE student_id = @id",connection);
            command.Parameters.AddWithValue("@id", student_id);
            dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
                textBox1.Text = ""+dataReader["student_id"];
                textBox2.Text = "" + dataReader["name"];
                textBox3.Text = "" + dataReader["surname"];
                pictureBox1.ImageLocation = dataReader["imagepath"].ToString();
            }
            connection.Close();
            connection.Open();

            
            command = new SqlCommand("SELECT (SUM(grade_final)/count(student_number))*0.6 FROM student_course WHERE student_number=@student_id", connection);
            command.Parameters.AddWithValue("@student_id",student_id);
            int finalort =Convert.ToInt32( command.ExecuteScalar());
            command = new SqlCommand("SELECT (SUM(grade_midterm)/count(student_number))*0.4 FROM student_course WHERE student_number=@student_id", connection);
            command.Parameters.AddWithValue("@student_id", student_id);
            int midtermort = Convert.ToInt32(command.ExecuteScalar());

            textBox4.Text = midtermort.ToString() + finalort.ToString();
            

            connection.Close();
        }
    }
}
