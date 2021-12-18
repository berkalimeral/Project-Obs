﻿using System;
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
    public partial class Form4 : Form
    {
        public int student_id;
        public Form4(int student_id)
        {
            this.student_id = student_id;
            InitializeComponent();
        }
        public Form4()
        {
          
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-E35HS2M;Initial Catalog=obs;Integrated Security=True");
        SqlCommand command;
        SqlDataReader dataReader;

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dersKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Ders Ekleme Sayfası Açılacak
            OgrenciDersEkleme ogrenciDersEkleme = new OgrenciDersEkleme(student_id);
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
            listofGrades listofGrades = new listofGrades(student_id);
            this.Hide();
            listofGrades.Show();
            listofGrades.Location = this.Location;
        }

        private void devamsızlıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            attendance attendance = new attendance(student_id);
            
            this.Hide();
            attendance.Show();
            attendance.Location = this.Location;
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            studentInformation studentInformation = new studentInformation(student_id);
            this.Hide();
            studentInformation.Show();
            studentInformation.Location = this.Location;
        }
        string imagePath;
        private void Form4_Load(object sender, EventArgs e)
        {
            connection.Open();
            command = new SqlCommand("SELECT name, surname,imagePath FROM student WHERE student_id = @id", connection);
            command.Parameters.AddWithValue("@id", student_id);
            dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
                label1.Text = "HELLO, " +dataReader["name"]+" "+dataReader["surname"];
                imagePath = dataReader["imagePath"].ToString();
            }
            pictureBox1.ImageLocation = imagePath;
            connection.Close();
        }
    }
}
