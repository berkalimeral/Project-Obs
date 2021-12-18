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
    public partial class StudentStatic : Form
    {
        public StudentStatic()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-E35HS2M;Initial Catalog=obs;Integrated Security=True");
        SqlCommand command;
        SqlDataReader reader;

        

        private void StudentStatic_Load(object sender, EventArgs e)
        {
            connection.Open();
            command = new SqlCommand("SELECT COUNT(student_id) FROM student", connection);

            label2.Text = Convert.ToInt32(command.ExecuteScalar()).ToString();
           
            command = new SqlCommand("SELECT COUNT(male) FROM student WHERE male = 1", connection);

            int male_count = Convert.ToInt32(command.ExecuteScalar());

            command = new SqlCommand("SELECT COUNT(female) FROM student WHERE female = 1", connection);

            int female_count = Convert.ToInt32(command.ExecuteScalar());

            command = new SqlCommand("SELECT COUNT(student_id) FROM student", connection);

            int toplam = Convert.ToInt32(command.ExecuteScalar());

            label4.Text = male_count.ToString();
            label3.Text = female_count.ToString();

            

            connection.Close();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            command = new SqlCommand("SELECT COUNT(student_id) FROM student", connection);

            label2.Text = Convert.ToInt32(command.ExecuteScalar()).ToString();

            command = new SqlCommand("SELECT COUNT(male) FROM student WHERE male = 1", connection);

            int male_count = Convert.ToInt32(command.ExecuteScalar());

            command = new SqlCommand("SELECT COUNT(female) FROM student WHERE female = 1", connection);

            int female_count = Convert.ToInt32(command.ExecuteScalar());

            command = new SqlCommand("SELECT COUNT(student_id) FROM student", connection);

            int toplam = Convert.ToInt32(command.ExecuteScalar());

            label4.Text = male_count.ToString();
            label3.Text = female_count.ToString();
            male_count = (male_count / toplam) * 360;
            female_count = (female_count / toplam) * 360;

            Pen p = new Pen(StudentStatic.DefaultBackColor);
            if (checkBox1.Checked == true)
            {
                p.Color = Color.Black;
                p.Width = 4;
            }
            else
            {
                p.Color = StudentStatic.DefaultBackColor;
                p.Width = 4;
            }

            Graphics g = this.CreateGraphics();

            Rectangle rec = new Rectangle(button1.Location.X + button1.Size.Width + 20, 20, 250, 250);

            Brush b1 = new SolidBrush(Color.Red);
            Brush b2 = new SolidBrush(Color.Blue);

            g.Clear(Form1.DefaultBackColor);


            g.DrawPie(p, rec, 0, male_count);
            g.FillPie(b1, rec, 0, male_count);
            g.DrawPie(p, rec, male_count, female_count);
            g.FillPie(b2, rec, male_count, female_count);

            connection.Close();
        }
    }
}
