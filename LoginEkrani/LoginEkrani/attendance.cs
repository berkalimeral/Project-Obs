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
    public partial class attendance : Form
    {
        public int student_id;
        public attendance(int student_id)
        {
            this.student_id = student_id;
            InitializeComponent();
        }
        public attendance()
        {

            InitializeComponent();
        }


        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-E35HS2M;Initial Catalog=obs;Integrated Security=True");
        SqlCommand command;
        SqlDataReader reader;

        private void devamsızlıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already here.");
        }

        private void notlarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listofGrades listofGrades = new listofGrades(student_id);
            this.Hide();
            listofGrades.Show();
            listofGrades.Location = this.Location;
        }

        private void dersKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciDersEkleme ogrenciDersEkleme = new OgrenciDersEkleme(student_id);
            ogrenciDersEkleme.Show();
            this.Hide();
            ogrenciDersEkleme.Location = this.Location;
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 anaSayfa = new Form4(student_id);
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

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application is developed by Alperen Sarıerikli and Berk Ali Meral.");
        }

       

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void attendance_Load(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            
            
            //listView1.Items.Clear();
            connection.Open();
            command = new SqlCommand("select sc.course_id, absance, course_name from student_course sc join course c on sc.course_id = c.course_id where sc.student_number=@id ", connection);
            command.Parameters.AddWithValue("@id", student_id);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["course_id"].ToString();
                item.SubItems.Add(reader["course_name"].ToString());
                item.SubItems.Add(reader["absance"].ToString());



                listView1.Items.Add(item);

            }
            connection.Close();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
