using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollegeConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeConsole.Tests
{

    // Things to be tested are:
    // Trying to add student to the section that is not assigned to the course -- passed
    // Trying to add the student to the section that is already full -- passed
    // I do not know if I should have a method for DefineEvaluations()
    // Trying to add marks for the student that is not there in the section
    // Trying to add marks that are greater than the maxPoints

    [TestClass()]
    public class SectionTests
    {
        [TestMethod()]
        public void AddStudent_SectionNotAssignedToCourse_Exception()
        {
            // Arrange
            // Creating a section and a student to add in the section
            Section testSection1 = new Section()
            {
                Name = "Section-1",
                SectionId = "1234"
            };

            Student testStudent1 = new Student()
            {
                Name = "Bob",
                DOB = new DateTime(1998, 8, 29)
            };

            // Act
            // Try to add student to the section 
            try
            {
                testSection1.AddStudent(testStudent1);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Student can only be assigned to the section that is assigned to the course .");
                return;
            }

            //
            Assert.Fail("No exception was thrown");
        }



        [TestMethod()]

        public void AddStudent_SectionIsFull_ThrowAnEception()
        {
            // Arrange
            // Creating a course and adding the section to it so that I Do not get an exception for that
            Course course = new Course() { Name = "Comp01", CourseCode = "0101" };

            // Creating a section and a student to add in the section
            Section testSection2 = new Section(course, 1, SemesterPeriod.WINTER)
            {
                Name = "Section-1",
                SectionId = "1234",
            };

            Student testStudent1 = new Student()
            {
                Name = "Bob",
                DOB = new DateTime(1998, 8, 29)
            };

            Student testStudent2 = new Student()
            {
                Name = "Ann"
            };

            // Act
            // Try to add student to the section 
            try
            {
                testSection2.AddStudent(testStudent1);
                testSection2.AddStudent(testStudent2);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Student cannot be added. Section is full. ");
                return;
            }

            //
            Assert.Fail("No exception was thrown");
        }

        [TestMethod()]
        public void AddStudentMark_StudentNotInSection_ThrowAnException()
        {
            // Arrange 
            // Creating a new Course and adding a section 
            // The maximum number of students will be 2
            // Will try to add marks for the student that is not there in the section
            Course course = new Course()
            {
                CourseCode = "123456",
                Name = "Comp02"
            };

            Section section = new Section(course, 2, SemesterPeriod.WINTER)
            {
                Name = "Sec1",
                SectionId = "002"
            };

            // Creating two students to be added in the section and the third student for checking the exceptions
            Student testStudent1 = new Student() { Name = "Happy" };
            Student testStudent2 = new Student() { Name = "Joy" };
            Student testStudent3 = new Student() { Name = "Frank" };

            // Act
            // trying to add students to the section and then calculate the marks for the student
            try
            {
                section.AddStudent(testStudent1);
                section.AddStudent(testStudent2);
                section.AddStudentMark(1, testStudent3, 40);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Student " + testStudent3.Name + " does not exists");
            }


        }


        [TestMethod()]
        public void AddStudentMark_PointsGreaterThanMaxPoints_ThrowAnException()
        {
            // Arrange 
            // Creating a new Course and adding a section 
            // The maximum number of students will be 2
            // Will try to add marks for the student that is not there in the section
            Course course = new Course()
            {
                CourseCode = "123456",
                Name = "Comp02"
            };

            Section section = new Section(course, 2, SemesterPeriod.WINTER)
            {
                Name = "Sec1",
                SectionId = "002"
            };

            // Creating two students to be added in the section and the third student for checking the exceptions
            Student testStudent1 = new Student() { Name = "Happy" };
            Student testStudent2 = new Student() { Name = "Joy" };

            // Act
            // trying to add students to the section and then calculate the marks for the student
            try
            {

                // Adding students to the section
                section.AddStudent(testStudent1);
                section.AddStudent(testStudent2);

                // Defining evaluation to check for the condition
                section.DefineEvaluation(1, EvaluationType.TEST, 100, 0.50);
                section.DefineEvaluation(2, EvaluationType.LAB, 80, 0.3);

                // Adding marks for the student
                section.AddStudentMark(1, testStudent1, 90);
                section.AddStudentMark(2, testStudent2, 90);

            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Points are greater than the maximum points.");
                return;
            }
            Assert.Fail("No exceptionwas thrown ");

        }






    }
}