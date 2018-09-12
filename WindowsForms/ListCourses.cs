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

    public partial class ListCourses : Form
    {

        CourseManager courseManager ;

        public ListCourses(CourseManager courseManager)
        {
           this.courseManager = courseManager;
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Add("CourseOneInfo");
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            // listBox1.Items.Add("CourseOneInfo");
            foreach (Section sec in courseManager.Courses[listBox1.SelectedIndex].Sections)
            {
                listBox2.Items.Add(sec.SectionId);
            }
        }

        private void onClickShowItems(object sender, EventArgs e)
        {
            this.Close();
        }


        public void ListOfCoursesAdded(Course course)
        {
            

        }

        private void ListCourses_Load(object sender, EventArgs e)
        {
            foreach(Course crs in courseManager.Courses)
            {
                listBox1.Items.Add(crs.CourseCode);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadCourse_Click(object sender, EventArgs e)
        {
            courseManager.LoadSchool("user.dat");
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (Course crs in courseManager.Courses)
            {
               listBox1.Items.Add(crs.CourseCode);
            }

                MessageBox.Show("The Courses have been loaded !");
            
        }

        private void saveCourse_Click(object sender, EventArgs e)
        {
            if(courseManager.Courses.Count == 0)
            {
                MessageBox.Show("The courseManager is Empty ! ");

            }
            else
            {
                courseManager.SaveSchoolInfo();
                MessageBox.Show("The Courses have been Saved !");
            }
            
        }
    }
}
