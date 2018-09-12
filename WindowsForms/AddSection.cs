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
    public partial class AddSection : Form
    {
        CourseManager courseManager ;
        public AddSection(CourseManager courseManager)
        {
            this.courseManager = courseManager;
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // This is the test box of the section Id
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // this is the text box for the section name
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // This is the text box for the maximum number of students in the section
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // This is the text box for keeping the semester period for the section

        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool close = false;

            try
            {
                // On clicking this button the section will be added to the course selected from the courseList 
                // Overhere I am creating an object of the section and then I am using that to add the section into the selected course
                Section section = new Section(); // I think over here I can use the second constructor so that I can simply add course that the user high lights so that it can be added easily
                section.SectionId = textBox1.Text;
                section.Name = textBox2.Text;
                section.MaxNumberOfStudents = Convert.ToInt32(textBox3.Text);
                //  section.Semester = SemesterPeriod(textBox4.Text);  // For this I have to provide the dropdown list for the user to select from
                if (radioButton1.Checked)
                {
                    section.Semester = SemesterPeriod.FALL;
                }
                else if (radioButton2.Checked)
                {
                    section.Semester = SemesterPeriod.WINTER;
                }
                else if(radioButton3.Checked)
                {
                    section.Semester = SemesterPeriod.SUMMER;
                }
                else
                {
                    MessageBox.Show("Please select a semester Period ");
                }
            
                
               try
               {
                    courseManager.Courses[courseListBox.SelectedIndex].AddSection(section);
                    close = true;
               }
                catch
               {
                    
                    MessageBox.Show("Please select a course for section to be added. ");
                    
               }
               
            }
            catch
            {
                MessageBox.Show("Please check the data and try again !");
            }
            if(close)
            {
                this.Close();
            }
           


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // This is the radio button of the Winter semester
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            // This is the radio button for the Summer semester
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // This is the radio button for keeping the fall semester
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AddSection_Load(object sender, EventArgs e)
        {
            // Here when the form is loaded the file will be loaded
            //as well and after that when i will make any changes I will save those changes using the file
           foreach(Course crs in courseManager.Courses)
           {
                courseListBox.Items.Add(crs.CourseCode);
           }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void courseListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This list box will display all the courses list
            
        }
    }
}
