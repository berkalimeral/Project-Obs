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
    public partial class OgrenciDersEkleme : Form
    {

        public int student_id;
        public OgrenciDersEkleme(int student_id)
        {
            this.student_id = student_id;
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-E35HS2M;Initial Catalog=obs;Integrated Security=True");
        SqlCommand command;
        SqlDataReader reader;
        SqlDataReader dataReader;
        public void listele()
        {
            listView1.Items.Clear();
            connection.Open();
            command = new SqlCommand("select distinct c.course_id, c.course_code, c.course_name, a.id, a.name ,c.class_capacity from coursee c join academist a on c.academist_id=a.id", connection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["course_id"].ToString();
                item.SubItems.Add(reader["course_code"].ToString());
                item.SubItems.Add(reader["course_name"].ToString());
                item.SubItems.Add(reader["id"].ToString());
                item.SubItems.Add(reader["name"].ToString());
                item.SubItems.Add(reader["class_capacity"].ToString());

                listView1.Items.Add(item);
            }
            connection.Close();
        }

        private void dersKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already here.");
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            attendance.Show();
            this.Hide();
            attendance.Location = this.Location;
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

        private void OgrenciDersEkleme_Load(object sender, EventArgs e)
        {
            listele();
            connection.Open();
            command = new SqlCommand("SELECT name, surname FROM student WHERE student_id = @id", connection);
            command.Parameters.AddWithValue("@id", student_id);
            dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
                label1.Text =dataReader["name"] + " " + dataReader["surname"];
            }
            connection.Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            command = new SqlCommand("insert into student_course (student_number,absance,grade_midterm,course_number,grade_final,academist_id) values('" + student_id + "','" + 0 + "','" + null + "','"+ listView1.SelectedItems[0].SubItems[0].Text +"','"+null+"','"+ listView1.SelectedItems[0].SubItems[3].Text+"')", connection);
            command.ExecuteNonQuery();

            MessageBox.Show("Course Registration is Successfully Completed");

            connection.Close();
        }   

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            label2.Text = "Selected Course: "+listView1.SelectedItems[0].SubItems[2].Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            listView1.SelectedItems.Clear();
        }
    }
}
