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
    public partial class attendance : Form
    {
        public attendance()
        {
            InitializeComponent();
        }

        private void devamsızlıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already here.");
        }

        private void notlarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listofGrades listofGrades = new listofGrades();
            this.Hide();
            listofGrades.Show();
            listofGrades.Location = this.Location;
        }

        private void dersKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciDersEkleme ogrenciDersEkleme = new OgrenciDersEkleme();
            ogrenciDersEkleme.Show();
            this.Hide();
            ogrenciDersEkleme.Location = this.Location;
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

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application is developed by Alperen Sarıerikli and Berk Ali Meral.");
        }

        /* public void listele()
        {
            listView1.Items.Clear();
            connection.Open();
            command = new SqlCommand("select course_id, course_name, attendance from student_course sc inner join student s on sc.student_number=s.student_id  where id=@id ", connection);
            command.Parameters.AddWithValue("@id",ogrenci_id);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["course_id"].ToString();
                item.SubItems.Add(reader["course_name"].ToString());
                item.SubItems.Add(reader["attendance"].ToString());
                
                

                listView1.Items.Add(item);
            }
            connection.Close();
        }*/

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void attendance_Load(object sender, EventArgs e)
        {
            //listele();
        }
    }
}
