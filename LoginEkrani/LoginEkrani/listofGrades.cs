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
    public partial class listofGrades : Form
    {
        public listofGrades()
        {
            InitializeComponent();
        }

        private void notlarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already here.");

        }

        private void dersKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciDersEkleme ogrenciDersEkleme = new OgrenciDersEkleme();
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
            studentInformation studentInformation = new studentInformation();
            this.Hide();
            studentInformation.Show();
            studentInformation.Location = this.Location;
        }
    }
}
