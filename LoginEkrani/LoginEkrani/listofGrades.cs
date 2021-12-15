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
    public partial class listofGrades : Form
    {

        public int student_id;
        public listofGrades(int student_id)
        {
            this.student_id = student_id;
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-E35HS2M;Initial Catalog=obs;Integrated Security=True");
        SqlCommand command;

        private void notlarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already here.");

        }

        private void dersKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciDersEkleme ogrenciDersEkleme = new OgrenciDersEkleme(student_id);
            ogrenciDersEkleme.Show();
            this.Hide();
            ogrenciDersEkleme.Location = this.Location;
        }

        private void devamsızlıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            attendance attendance= new attendance();
            attendance.Show();
            this.Hide();
            attendance.Location = this.Location;
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 anaSayfa = new Form4();
            this.Hide();
            anaSayfa.Show();
            anaSayfa.Location = this.Location;
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            studentInformation studentInformation = new studentInformation(student_id);
            this.Hide();
            studentInformation.Show();
            studentInformation.Location = this.Location;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            



        }
       /* public void listele()
        {
            listView1.Items.Clear();
            connection.Open();
            command = new SqlCommand("select course_id, course_name, grade_midterm, grade_final from student_course sc inner join student s on sc.student_number=s.student_id  where id=@id ", connection);
            command.Parameters.AddWithValue("@id",ogrenci_id);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["course_id"].ToString();
                item.SubItems.Add(reader["course_name"].ToString());
                item.SubItems.Add(reader["grade_midterm"].ToString());
                item.SubItems.Add(reader["grade_final"].ToString());
                

                listView1.Items.Add(item);
            }
            connection.Close();
        }*/

        private void listofGrades_Load(object sender, EventArgs e)
        {
           //listele();
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application is developed by Alperen Sarıerikli and Berk Ali Meral.");
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
