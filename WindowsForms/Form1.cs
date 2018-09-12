using System;
using CollegeConsole;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
       static CourseManager courseManager = new CourseManager();
        AddCourse addCourse = new AddCourse(courseManager);

        public Form1()
        {
            InitializeComponent();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // AddCourse addCourse = new AddCourse(courseManager);
            addCourse.ShowDialog(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddSection addSection = new AddSection(courseManager);
            addSection.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddTeacher addTeacher = new AddTeacher(courseManager);
            addTeacher.ShowDialog();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListCourses listCourses = new ListCourses(courseManager);
            listCourses.ShowDialog();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
