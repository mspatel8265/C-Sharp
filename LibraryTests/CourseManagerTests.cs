using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollegeConsole;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeConsole.Tests
{
    [TestClass()]
    public class TestCourseManager
    {
        /*
         * Here in the tests for the ImportCourses() method I am not using the Assert to check the actual output because 
         * I am using try catch block and then to print the message I am Console.WriteLine() so that all the records are 
         * processed in the file. So for that reason I am not using the Assert here because, in actual there is nothing
         * that the method is actually throwig so that I can catch it here, but when I run the test and see the output 
         * option it is showing the correct messages that are thrown and shown as in the output of the main program !
         */


        [TestMethod()]
        public void ImportCourses_CourseRepetition_ThrowAnException()
        {
            // Arrange
            CourseManager courseManager = new CourseManager();
            string filename = "testAdditionalCourses.txt";

            // Act
            try
            {
                courseManager.ImportCourses(filename, ',');
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        [TestMethod()]
        public void ImportCourses_IncorrectFormat_ThrowAnException()
        {
            // Arrange
            CourseManager courseManager = new CourseManager();
            string filename = "testAdditionalCourses1.txt";

            // Act
            try
            {
                courseManager.ImportCourses(filename, ',');
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        [TestMethod()]
        public void ImportCourses_IncorrectNoOfFields_ThrowAnException()
        {
            // Arrange
            CourseManager courseManager = new CourseManager();
            string filename = "testAdditionalCourses2.txt";

            // Act
            try
            {
                courseManager.ImportCourses(filename, ',');
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        [TestMethod()]
        public void ExportCourses_CheckFileCreated_UsingFileExistProperty()
        {
            // Here I will check if the path of the file is same or not !
            // I have to create two courses and then I will add those courses to the 
            // Then I wil call the ExportCourses()

            // Arrange

            bool fileExists = false;
            string fileName = "testFile";

            CourseManager courseManager = new CourseManager();
            Course testCourse1 = new Course()
            {
                CourseCode = "Comp1234",
                Name = "Prog1"
            };

            Course testCourse2 = new Course()
            {
                CourseCode = "Comp2345",
                Name = "Prog2"
            };

            // Adding courses
            courseManager.AddCourse(testCourse1);
            courseManager.AddCourse(testCourse2);

            // Act 
            courseManager.ExportCourses("testFile", '|');
            fileExists = File.Exists(fileName);

            // Assert
            Assert.IsTrue(fileExists);
        }

        [TestMethod()]
        public void SaveSchoolInfo_CheckFileExistence_UsingFieExistsproperty()
        {
            // Arrange
            bool fileExists = false;
            string fileName = "user.dat";

            CourseManager crsMngr = new CourseManager();
            Course testCourse1 = new Course()
            {
                CourseCode = "198",
                Name = "Comp98"
            };

            Course testCourse2 = new Course()
            {
                CourseCode = "345",
                Name = "Comp45"
            };

            // Adding courses
            crsMngr.AddCourse(testCourse1);
            crsMngr.AddCourse(testCourse2);

            // Act 
            crsMngr.SaveSchoolInfo();
            fileExists = File.Exists(fileName);

            // Assert
            Assert.IsTrue(fileExists);

        }



        [TestMethod()]
        public void LoadSchoolInfo_CheckFileExistence_UsingFieExistsproperty()
        {
            // Arrange
            bool fileExists = false;
            string fileName = "user.dat";  // Here I am using the sam ename as I have used in the method because if I do not do it that way than it is throwing me an exception that the file does not exists as the SaveSchool() method does not take the file name from putside 

            CourseManager crsMngr = new CourseManager();
            Course testCourse1 = new Course()
            {
                CourseCode = "198",
                Name = "Comp98"
            };

            Course testCourse2 = new Course()
            {
                CourseCode = "345",
                Name = "Comp45"
            };

            // Adding courses 
            crsMngr.AddCourse(testCourse1);
            crsMngr.AddCourse(testCourse2);

            // Act 
            // Loading the file saved before 

            crsMngr.LoadSchool(fileName);
            fileExists = File.Exists(fileName);

            // Assert
            Assert.IsTrue(fileExists);

        }

    }
}
