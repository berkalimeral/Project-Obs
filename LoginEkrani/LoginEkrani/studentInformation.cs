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
    public partial class studentInformation : Form
    {

        public int student_id;
        public studentInformation(int student_id)
        {
            this.student_id = student_id;
            InitializeComponent();
        }

        private void dersKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciDersEkleme ogrenciDersEkleme = new OgrenciDersEkleme(student_id);
            
            this.Hide();
            ogrenciDersEkleme.Show();
            ogrenciDersEkleme.Location = this.Location;
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
            this.Hide();
            attendance.Show();
            attendance.Location = this.Location;
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.Show();
            form4.Location = this.Location;
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application is developed by Alperen Sarıerikli and Berk Ali Meral.");
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void studentInformation_Load(object sender, EventArgs e)
        {

        }
    }
}
