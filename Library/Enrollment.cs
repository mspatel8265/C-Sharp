using System;
using System.Collections.Generic;
namespace CollegeConsole
{
    [Serializable]
    public class Enrollment
    {
        Student student;   // <-- It was of type Person before I converted it to be of type Student now 
        Section section;
        FinalGrade aFinalGrade = new FinalGrade();
        //int numberOfEvaluations;
        List<Evaluation> evaluations;//Evaluation[] evaluations;  <-- I have to replace this with a collection

        //Properties

        public Student Student
        {
            get { return student; }
            set { student = value; }
        }

        public Section Section
        {
            get { return section; }
            set { section = value; }
        }

        public FinalGrade AFinalGrade
        {
            get { return aFinalGrade; }
            set { aFinalGrade = value; }
        }

        public List<Evaluation> Evaluations   // I am not sure if it is correct or not !
        {
            get { return evaluations; }
            set { evaluations = value; }
        }

        /*
        public int NumberOfEvaluations
        {
            get { return numberOfEvaluations; }
        }
        */

        // Default Constructor

        /*
         
         public Enrollment()
        {
            Student = null;
            Section = null;
            AFinalGrade = FinalGrade.Aplus;
        } 
        
        */

        // Specified constructor
        public Enrollment(Section section, Student student, int evaluations) // Put something for the number of course evaluations  -- I changed here as well and kept it to be of type Student instead of Person earlier
        {
            Section = section;
            Student = student;
            // numberOfEvaluations = evaluations;
            Evaluations = new List<Evaluation>();// Evaluations = new Evaluation[numberOfEvaluations];
        }


        // Methods

        // Method to calculate the final Grade 

        public FinalGrade CalculateFinalGrade(double fMarks)
        {


            if (fMarks >= 90)
                AFinalGrade = FinalGrade.Aplus;

            else if (fMarks >= 80)
                AFinalGrade = FinalGrade.A;

            else if (fMarks >= 75)
                AFinalGrade = FinalGrade.Bplus;

            else if (fMarks >= 70)
                AFinalGrade = FinalGrade.B;

            else if (fMarks >= 65)
                AFinalGrade = FinalGrade.Cplus;

            else if (fMarks >= 60)
                AFinalGrade = FinalGrade.C;

            else if (fMarks >= 55)
                AFinalGrade = FinalGrade.Dplus;

            else if (fMarks >= 50)
                AFinalGrade = FinalGrade.D;

            else AFinalGrade = FinalGrade.F;

            return AFinalGrade;
        }


        public override string ToString()
        {
            return string.Format("\n {0}", Student.Name);
        }
    }
}
