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
    public partial class DersIslemleri : Form
    {
        public DersIslemleri()
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
            command = new SqlCommand("SELECT * FROM course", connection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["id"].ToString();
                item.SubItems.Add(reader["course_code"].ToString());
                item.SubItems.Add(reader["course_name"].ToString());
                item.SubItems.Add(reader["class_capacity"].ToString());

                listView1.Items.Add(item);
            }
            connection.Close();
        }

        private void dersEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ders_ekle_sayfasi ders_Ekle = new ders_ekle_sayfasi();
            ders_Ekle.Show();
            this.Hide();
            ders_Ekle.Location = this.Location;
        }

        private void notEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNotePage addNote = new AddNotePage();
            addNote.Show();
            addNote.Location = this.Location;
            this.Hide();
        }

        private void notlarıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListNotesPage listNotes = new ListNotesPage();
            listNotes.Show();
            listNotes.Location = this.Location;
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
            form5.Location = this.Location;
        }

        private void DersIslemleri_Load(object sender, EventArgs e)
        {
            listele();
        }

        int id = 0;
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            command = new SqlCommand("DELETE FROM course WHERE id=(" + id + ")", connection);
            command.ExecuteNonQuery();
            connection.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            command = new SqlCommand("UPDATE course SET course_code='" + textBox1.Text.ToString() + "',course_name='" + textBox2.Text.ToString() + "',class_capacity='" + textBox3.Text.ToString() + "'where id = " + id + "", connection);
            command.ExecuteNonQuery();
            connection.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}
