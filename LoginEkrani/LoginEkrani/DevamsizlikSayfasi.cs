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
    public partial class DevamsizlikSayfasi : Form
    {
        public int id;
        public DevamsizlikSayfasi(int id)
        {
            this.id = id;
            InitializeComponent();
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
    }
}
