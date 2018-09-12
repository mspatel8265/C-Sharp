using System;
using CollegeConsole;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeConsole
{
    [Serializable]
    public class Course
    {
        string courseCode;      // It says in the assignment requirements that it should be uniq, so are we going to check that using the condition for that ?
        string name;
        string description;
        int noOfEvaluations;  // <-- I will use count for this and will not use this anymore
        Section aSection;
        List<Section> sections; //  <-- I will convert it into the collections 
        //int noOfSections;
        bool canUpdate = true;

        //Properties
        public string CourseCode
        {
            get { return courseCode; }
            set { courseCode = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }

        }

        public Section ASection
        {
            get { return aSection; }
            set { aSection = value; }
        }

        public List<Section> Sections
        {
            get { return sections; }
            set { sections = value; }

        }

        public int NoOfEvaluations
        {
            get { return noOfEvaluations; }
            set
            {
                if (canUpdate == true)   // This is to keep the check on whether the section is assigned or not ? If the section is assigned it will be false, so the number of evaluations cannot be changed
                    noOfEvaluations = value;
                else
                    throw new Exception("Section is already assigned. Number of evaluations cannot be changed anymore!! ");
            }
        }


        public Course()
        {
            CourseCode = null;
            Name = null;
            Description = null;
            NoOfEvaluations = 0;
            Sections = new List<Section>();
            // NumberOfSections = 0;
            // ASection.Name = "";

        }

        public Course(string courseCode, string name)
        {
            CourseCode = courseCode;
            Name = name;
            Description = null;
            NoOfEvaluations = 0;
            Sections = new List<Section>();
            //ASection = new Section();
        }


        public void AddSection(SemesterPeriod semesterPeriod, string sectionId, string sectionName)          // Add creating a new section I have to add it to the course !!
        {
            // This will take the section information and it is mandatory to take the information for this specific method
            Section newSection = new Section(this, 30, semesterPeriod);  //public Section(Course aCourse, int MaxNumberOfStudents, SemesterPeriod semester)

        
            {
                Sections.Add(newSection);     // This is to add the section in this course
                canUpdate = false;            // This is to make sure that once the section is assigned number of evaluations for it cannot be changed
            }

        }


        // Add section method that takes only one parameter

        public void AddSection(Section aSection)                                                              // This checks if the section is full it will show a message the section is full 
        {

            // for (int i = 0; i < noOfSections; i++) // <--- I have commented this out because it is showing me an error for the varibale " i " that it is out of the scope or something like that and I think that it is showing me so because it is in the if statement loop --- it could be so but again i am not sure for that though
            // I think this is what he said while explaining that point
            // This statement will check first that if the section information is null it will throw an error of section being invalid

            if (aSection.SectionId == null || aSection.Name == null)
            {
                throw new Exception("Section is not valid ");
            }

            else if (aSection.ACourse != null) //(Sections.Contains(aSection))
            {
                
                throw new Exception("Section is already assigned to " + aSection.ACourse.Name + " course. ");
            }

            else
            {

                Sections.Add(aSection);
                aSection.ACourse = this;
                canUpdate = false;  // Again this is to keep check that the section is added, so the numberOfEvaluations cannot be changed anymore


            }
        }


        // GetInfo method


        public override string ToString()
        {
            string result;
            result = "\nCourse code: " + CourseCode + "\tCourse name: " + Name + "\tCourse description: " + Description + "\tNumber Of Evaluations: " + NoOfEvaluations + "\tNumber Of Sections: " + Sections.Count;

            // Hey I am not sure how to manage with this and that is the reason why I do not like null thing because it keeps on giving the null reference to me if it is not assigneed why does it not just print it living that to be blank instead of giving null reference error !!!!!!
            for (int i = 0; i < Sections.Count; i++)
            {

                result = result + "\n\t" + Sections[i].ACourse.Name + ": " + Sections[i].Name;
            }

            return result;
        }


    }
}
