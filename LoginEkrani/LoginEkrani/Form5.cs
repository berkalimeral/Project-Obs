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
    public partial class Form5 : Form
    {

        public int id;
        public Form5(int id)
        {
            this.id = id;
            InitializeComponent();
        }
        public Form5()
        {
            
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-E35HS2M;Initial Catalog=obs;Integrated Security=True");
        SqlCommand command;
        SqlDataReader dataReader;

        private void devamsızlıkToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application is developed by Alperen Sarıerikli and Berk Ali Meral.");
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

        private void görüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevamsizlikSayfasi devamsizlik = new DevamsizlikSayfasi(id);
            devamsizlik.Show();
            devamsizlik.Location = this.Location;
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void studentStaticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentStatic student = new StudentStatic();
            student.Show();

        }
        string imagePath;
        private void Form5_Load(object sender, EventArgs e)
        {
            connection.Open();
            command = new SqlCommand("SELECT name, surname,imagePath FROM academist WHERE id = @id",connection);
            command.Parameters.AddWithValue("@id",id);
            dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
                label1.Text = "WELCOME "+dataReader["name"]+" "+dataReader["surname"];
                imagePath = dataReader["imagePath"].ToString();
            }
            pictureBox1.ImageLocation = imagePath;
            connection.Close();

        }
    }
}
