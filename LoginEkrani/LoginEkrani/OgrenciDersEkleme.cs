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
    public partial class OgrenciDersEkleme : Form
    {

        public int student_id;
        public OgrenciDersEkleme(int student_id)
        {
            this.student_id = student_id;
            InitializeComponent();
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
            attendance attendance = new attendance();
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

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application is developed by Alperen Sarıerikli and Berk Ali Meral.");
        }

        private void OgrenciDersEkleme_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
