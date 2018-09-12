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
    public partial class AddTeacher : Form
    {
        CourseManager courseManager ;
        Section aSection = new Section();

        public AddTeacher(CourseManager courseManager)
        {
            this.courseManager = courseManager;
            InitializeComponent();
        }

        private void AddTeacher_Load(object sender, EventArgs e)
        {
            foreach(Course crs in courseManager.Courses)
            {
                courseCollection.Items.Add(crs.CourseCode);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool close = false;
            try
            {
                string province = textBox5.Text;
                string city = textBox4.Text;
                string street = textBox3.Text;
                Address address = new Address(street, city, province);
                Teacher faculty = new Teacher
                {
                    Name = textBox1.Text,
                    Address = address
                };
                try
                {
                    courseManager.Courses[courseCollection.SelectedIndex].Sections[sectionCollection.SelectedIndex].Faculty = faculty;
                    close = true;
                }
                catch
                {
                    MessageBox.Show("Please select the correct course and the section to add the faculty !");
                }
            }
            catch
            {
                MessageBox.Show("Please check the input data and try again !");
            }
            // here I will assign a faculty to a specific section 
            
            // The main code will go here and at last on click the window will be closed

            if(close)
            {
                this.Close();
            }

           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            // To print the sections of the courses
            sectionCollection.Items.Clear();
           
            foreach (Section sec in courseManager.Courses[courseCollection.SelectedIndex].Sections)
            {
               sectionCollection.Items.Add(sec.SectionId);    
            }
    

        }

        private void CourseCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void sectionCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           // aSection.Faculty.TelephoneNumber = (uint)textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
