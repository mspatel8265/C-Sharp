using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollegeConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeConsole.Tests
{
    [TestClass()]
    public class CourseTests
    {
        // Things to be tested are:
        // Adding valid section
        // Adding invalid seection
        // Adding valid section already assigned to some other course
        // Trying to change the number of evaluations for the course that has section assigned
        // trying to change the number of evaluations for the course that do not have section assigned to it

        [TestMethod()]
        public void AddSectionTest_AddingInvalidSection_ThrowException()
        {
            // This method for checking the exception when an empty section is assigned to the course

            // Arrange
            // Create a Course
            Course testCourse = new Course();

            // Populating the course values
            testCourse.CourseCode = "Comp1";
            testCourse.Description = "Software Engineering Methodologies";
            testCourse.NoOfEvaluations = 5;

            // Create a section and populating with values
            Section testSection = new Section();
            //testSection.Name = null;
            //testSection.SectionId = null;

            // Act
            // Trying to add the section to the course

            try
            {
                testCourse.AddSection(testSection);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Section is not valid ");
                return;
            }

            //Assert
            Assert.Fail("No Exception was thrown");
        }

        [TestMethod]
        public void TryingToChangeNoOfEvaluations_AlreadyAssignedSection_CorrectCourseINfo()
        {
            // This method is to check if the section is already assigned to the course then the number of evaluations cannot be changed
            // Arrange

            // Create course
            Course testCourse1 = new Course();

            // Populating the course values
            testCourse1.CourseCode = "Comp2";
            testCourse1.Description = "Introduction to database concepts";
            testCourse1.NoOfEvaluations = 5;

            Section testSection1 = new Section()
            {
                Name = "Section-2",
                SectionId = "W002"
            };

            // Act
            // Trying to add the section to the course

            try
            {
                testCourse1.AddSection(testSection1);
                testCourse1.NoOfEvaluations = 10;
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Section is already assigned. Number of evaluations cannot be changed anymore!! ");  // <-- I have a question for here that should I check here for the validation of the section information as well
                return;
            }

            // Assert
            Assert.Fail("No Exception was thrown");

        }


        [TestMethod]
        public void AddSection_ScetionAlreadyAssigned_ThrowAnException()
        {
            // This method checks if I have already assigned a section to one course and if try to add it again to some another course it should throw an exception

            // Arrange
            // Creating two courses
            Course testCourse2 = new Course() { Name = "Comp3", CourseCode = "123" };
            Course testCourse3 = new Course() { Name = "Comp4", CourseCode = "234" };


            // Creating one section to assign twice

            Section testSection2 = new Section()
            {
                Name = "Section-3",
                SectionId = "W003"
            };


            try
            {
                testCourse2.AddSection(testSection2);
                testCourse3.AddSection(testSection2);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Section is already assigned to " + testSection2.ACourse.Name + " course. ");
                return;
            }

            // Assert 
            Assert.Fail("No Exception was thrown");

        }

        [TestMethod]
        public void ChangeNumberOfEvaluations_SectionNotAssigned_NoException()
        {
            // Arrange
            // Create a valid course and then try to change the number of evaluations the section is not assigned yet
            Course testCourse4 = new Course()
            {
                Name = "Comp5",
                CourseCode = "101",
                NoOfEvaluations = 5
            };

            int ExpectedNoOfevaluations = 10;

            // Act 
            // I will try to change the numberOfEvalautions without adding any sections to it 

            testCourse4.NoOfEvaluations = 10;

            // Assert
            Assert.AreEqual(ExpectedNoOfevaluations, testCourse4.NoOfEvaluations);

        }

    }
}