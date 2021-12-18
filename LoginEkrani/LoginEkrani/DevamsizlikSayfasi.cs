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
    public partial class DevamsizlikSayfasi : Form
    {
        public int id;
        public DevamsizlikSayfasi(int id)
        {
            this.id = id;
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-E35HS2M;Initial Catalog=obs;Integrated Security=True");
        SqlCommand command;
        SqlDataReader reader;

        public void listele()
        {
            listView1.Items.Clear();
            connection.Open();
            command = new SqlCommand("SELECT name, course_number, student_number, absance FROM student_course sc join student s on sc.student_number = s.student_id", connection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["student_number"].ToString();
                item.SubItems.Add(reader["name"].ToString());
                item.SubItems.Add(reader["course_number"].ToString());
                item.SubItems.Add(reader["absance"].ToString());

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
            ders_ekle_sayfasi ders_Ekle = new ders_ekle_sayfasi(id);
            ders_Ekle.Show();
            this.Hide();
            ders_Ekle.Location = this.Location;
        }

        private void dersleriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DersIslemleri dersIslemleri = new DersIslemleri(id);
            dersIslemleri.Show();
            this.Hide();
            dersIslemleri.Location = this.Location;
        }

        private void notEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNotePage addNote = new AddNotePage(id);
            addNote.Show();
            addNote.Location = this.Location;
            this.Hide();
        }

        private void notlarıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListNotesPage listNotes = new ListNotesPage(id);
            listNotes.Show();
            listNotes.Location = this.Location;
            this.Hide();
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(id);
            form5.Show();
            this.Hide();
            form5.Location = this.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            command = new SqlCommand("update student_course set absance= absance+1 where student_number=@student_number and course_number=@course_id", connection);
            command.Parameters.AddWithValue("@student_number",textBox1.Text);
            command.Parameters.AddWithValue("@course_id", textBox3.Text);
            command.ExecuteNonQuery();

            MessageBox.Show("Absence Updated Successfully!");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            connection.Close();
            listele();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DevamsizlikSayfasi_Load(object sender, EventArgs e)
        {
            listele();

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
        }
    }
}
