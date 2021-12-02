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
    }
}
