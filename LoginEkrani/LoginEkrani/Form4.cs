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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dersKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Ders Ekleme Sayfası Açılacak
            OgrenciDersEkleme ogrenciDersEkleme = new OgrenciDersEkleme();
            this.Hide();
            ogrenciDersEkleme.Show();
            ogrenciDersEkleme.Location = this.Location;
            
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application is developed by Alperen Sarıerikli and Berk Ali Meral.");
        }

        private void notlarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listofGrades listofGrades = new listofGrades();
            this.Hide();
            listofGrades.Show();
            listofGrades.Location = this.Location;
        }

        private void devamsızlıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            attendance attendance = new attendance();
            
            this.Hide();
            attendance.Show();
            attendance.Location = this.Location;
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
