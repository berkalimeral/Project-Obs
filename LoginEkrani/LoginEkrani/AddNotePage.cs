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
    public partial class AddNotePage : Form
    {
        public AddNotePage()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-E35HS2M;Initial Catalog=obs;Integrated Security=True");
        SqlCommand command;
        SqlDataReader reader;
        public void listele()
        {
            listView1.Items.Clear();
            connection.Open();
            command = new SqlCommand("select student_number, name, surname, course_name from student_course sc inner join student s on sc.student_number = s.student_id inner join course c on sc.course_id = c.course_id ", connection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["student_number"].ToString();
                item.SubItems.Add(reader["name"].ToString());
                item.SubItems.Add(reader["surname"].ToString());
                item.SubItems.Add(reader["course_name"].ToString());

                listView1.Items.Add(item);
            }
            connection.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dersEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ders_ekle_sayfasi ders_Ekle = new ders_ekle_sayfasi();
            ders_Ekle.Show();
            this.Hide();
            ders_Ekle.Location = this.Location;
        }

        private void dersleriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DersIslemleri dersIslemleri = new DersIslemleri();
            dersIslemleri.Show();
            this.Hide();
            dersIslemleri.Location = this.Location;
        }

        private void notlarıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListNotesPage listNotes = new ListNotesPage();
            listNotes.Show();
            listNotes.Location = this.Location;
            this.Hide();
        }

        private void görüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevamsizlikSayfasi devamsizlik = new DevamsizlikSayfasi();
            devamsizlik.Show();
            devamsizlik.Location = this.Location;
            this.Hide();
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
            form5.Location = this.Location;
        }

        private void AddNotePage_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            command = new SqlCommand("INSERT INTO student_course (student_number,grade_midterm,grade_final) VALUES ('" + textBox1.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "')", connection);
            command.ExecuteNonQuery();
            connection.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";

            MessageBox.Show("Öğrenci Veri Tabanına Kaydedildi.");
            
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
