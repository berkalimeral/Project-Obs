using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginEkrani
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void devamsızlıkToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application is developed by Alperen Sarıerikli and Berk Ali Meral.");
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

        private void görüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevamsizlikSayfasi devamsizlik = new DevamsizlikSayfasi();
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
    }
}
