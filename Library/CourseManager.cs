using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace CollegeConsole
{
    [Serializable]
    public class CourseManager
    {
        List<Course> courses = new List<Course>(); // Course[] courses = new Course[100];
        int numberOfCourses;

        // Properties

        public List<Course> Courses
        {
            get
            {
                return courses;
            }
            set
            {
                courses = value;
            }

        }

        public int NumberOfCourses
        {
            get { return Courses.Count; }
            set { numberOfCourses = value; }
        }


        // Methods 

        public void AddCourse(Course aCourse)
        {
            Courses.Add(aCourse);
        }

        public void ExportCourses(string fileName, char delimiter)
        {

            FileStream fileOut = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fileOut);
            for (int i = 0; i < Courses.Count; i++)
            {
                Course aCourse = Courses[i];
                writer.WriteLine("{0}{1}{2}{3}{4}{5}{6}", aCourse.CourseCode, delimiter, aCourse.Name, delimiter, aCourse.Description, delimiter, aCourse.NoOfEvaluations);
            }
            writer.Close();
            fileOut.Close();
        }

        public void ImportCourses(string fileName, char delimiter)
        {
            string[] LinesInFile = File.ReadAllLines(fileName);
            FileStream inFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);
            int recordNumber = 0;
            int noOfCoursesAdded = 0;

            foreach (string line in LinesInFile)
            {
                string[] fields = line.Split(delimiter);  // I am not converting only this piece of code into collections
                recordNumber++; // This will keep the number of records for me to print the number in the exceptions
                bool isOkay = false;
                bool courseExists = false;
                bool correctFormat = true;

                try
                {
                    if (fields.Length != 4)
                    {
                        correctFormat = false;
                        throw new Exception("The number of fields are incorrect in record" + recordNumber);
                    }

                    else
                    {
                        string field3 = fields[3];
                        int number;
                        try
                        {
                            isOkay = Int32.TryParse(field3, out number);

                            if (isOkay == false)
                                throw new Exception("Number of evaluations in record " + recordNumber + " is not in correct format");

                            else
                            {
                                foreach (Course course in Courses)
                                    try
                                    {
                                        if (course.CourseCode == fields[0])
                                        {
                                            courseExists = true;
                                            throw new Exception("Course code in record " + recordNumber + " is in use. ");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (courseExists == false && correctFormat == true && isOkay == true)
                {
                    Course aCourse = new Course();
                    aCourse.CourseCode = fields[0];
                    aCourse.Name = fields[1];
                    aCourse.Description = fields[2];
                    aCourse.NoOfEvaluations = Convert.ToInt32(fields[3]);
                    Courses.Add(aCourse);
                    noOfCoursesAdded++;
                }

            }
            reader.Close();
            inFile.Close();
            Console.WriteLine("{0} records processed, {1} courses added", recordNumber, noOfCoursesAdded);
        }


        public void LoadSchool(string fileName)
        {

            FileStream inFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryFormatter bFormater = new BinaryFormatter();
            Courses = (List<Course>)bFormater.Deserialize(inFile);
            int counter = Courses.Count;  // This will tell me that : "Hey ! you have this much courses in total"
            inFile.Close();
        }

        public void SaveSchoolInfo()
        {
            //const string FILENAME = "school.dat";
            BinaryFormatter bFormater = new BinaryFormatter();
            FileStream fileOut = new FileStream("user.dat", FileMode.Create, FileAccess.Write);
            bFormater.Serialize(fileOut, Courses);

            fileOut.Close();

        }


    }
}