using System;
using System.Collections.Generic;
namespace CollegeConsole
{
    [Serializable]
    public class Student : Person
    {
        public List<Section> sections = new List<Section>();

        public List<Section> Sections
        {
            get { return sections; }
            set { sections = value; }
        }

        public string PrintTranscript()
        {
            string result = "";
            int i = 0;

            foreach (Section printSection in Sections)
            {
                if (this.RegistrationNumber == printSection.Enrollments[i].Student.RegistrationNumber)
                {
                    result += printSection.ACourse.CourseCode + "  " + printSection.Enrollments[i].AFinalGrade + "\n";
                }

            }

            return result;
        }


        public override string ToString()
        {
            return base.ToString();
        }

        //public int FindPosition()
        //{
        //    int j = 0;
        //    int i = 0;

        //    foreach(Section printSection in Sections)
        //    {

        //    }

        //    return j;
        //}
    }
}