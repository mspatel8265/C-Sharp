using System;
using System.Collections.Generic;
namespace CollegeConsole
{
    [Serializable]
    public class Teacher : Person
    {
        // Properties
        public List<Section> Sections = new List<Section>();

        public Teacher() : base()
        {

        }

        public Teacher(string name, DateTime dob) : base(name, dob)
        {

        }

        public string SectionsInfo()
        {
            string result = "";

            for (int i = 0; i < Sections.Count; i++)
            {
                result += "\t" + Sections[i].Name + "\n";
            }

            return result;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

}
