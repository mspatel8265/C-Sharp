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
    public partial class AddCourse : Form
    {

        //CourseManager courseManager = new CourseManager();
       // Form1 Form = new Form1();
        
        CourseManager courseManager ;
        public AddCourse(CourseManager courseManager)
        {
            this.courseManager = courseManager;
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // This text box is for the Course Name 
           // string crsNm = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // this text box is for keeping the course code
           // string crsCd = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // This text box is for keeping the number of evaluations in the course
           // int noOfEval = Convert.ToInt32(textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // this text box is for keeping the course description of the course
           // string crsDescription = "" ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // This button is the add button in the AddCourse form
           try
           {
                
            string crsNm = textBox1.Text;
            string crsCd = textBox2.Text;
            int noOfEval = Convert.ToInt32(textBox3.Text);
            string crsDescription = textBox4.Text;

                

          
                Course aCourse = new Course();
                aCourse.Name = crsNm;
                aCourse.CourseCode = crsCd;
                aCourse.NoOfEvaluations = noOfEval;
                aCourse.Description = crsDescription;
                
                // Here I am collecting the data and passing the values into a method to add the course object that is created here
               
                courseManager.AddCourse(aCourse);
                
                this.Close();

           }
            catch(Exception ex)
           {
                MessageBox.Show("Entered data is not in the correct format !");
           }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
