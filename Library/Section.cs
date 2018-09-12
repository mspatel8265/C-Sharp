using System;
using System.Collections.Generic;
using System.Linq;
namespace CollegeConsole
{
    [Serializable]
    public class Section
    {
        string sectionId;
        string name;
        SemesterPeriod semester = new SemesterPeriod();
        Teacher faculty;   // <-- Change this to of type Teacher
        Course aCourse;
        Enrollment enrollment;
        int maxNumberofEnrollments;
        int counter = 0; // this is useful to me in calculating the evaluations


        List<Enrollment> enrollments;//Enrollment[] enrollments;  <-- I have to change this into oen type of collection
                                     // List<Evaluation> evaluations;//Evaluation[] anEvaluation = new Evaluation[20];  <-- I have to change this as well into a type of collections

        // Properties
        public string SectionId
        {
            get { return sectionId; }
            set { sectionId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int MaxNumberOfStudents  // this is the maximum number of enrollments !! <-- I guess I will still need this because I will take this number from the user to make sure that I no more than max. students are added into the list
        {
            get { return maxNumberofEnrollments; }
            set { maxNumberofEnrollments = value; }
        }

        public SemesterPeriod Semester
        {
            get { return semester; }
            set { semester = value; }
        }

        public Teacher Faculty
        {
            get { return faculty; }
            set
            {
                faculty = value;
                faculty.Sections.Add(this);
            }
        }

        public Course ACourse
        {
            get { return aCourse; }
            set { aCourse = value; }
        }

        public Enrollment Enrollment
        {
            get { return enrollment; }
            set { enrollment = value; }
        }

        public List<Enrollment> Enrollments
        {
            get { return enrollments; }
            set { enrollments = value; }
        }

        public Section()
        {
            enrollments = new List<Enrollment>(); //enrollments = new Enrollment[NumberOfEnrollments];
            SectionId = null;
            Name = null;
            MaxNumberOfStudents = 40;  // I need this because in one of the sections in professor's output it shows 40 and if I donot do this way it is showing me "0"
            Semester = SemesterPeriod.WINTER;
            Faculty = new Teacher();
            Faculty.Sections.Add(this);
        }

        public Section(Course course, int maxNoOfStudents, SemesterPeriod semester) // course name
        {
            enrollments = new List<Enrollment>();
            ACourse = course;
            MaxNumberOfStudents = maxNoOfStudents;
            Semester = semester;
            SectionId = null;
            Name = null;
            Faculty = new Teacher();
            Faculty.Sections.Add(this);

        }


        public void AddStudent(Student aStudent)    // AddStudent will add a student by adding an enrolment to the section
        {
            // A student is added to a section and so to the course by adding the enrollment to both of them respectively 
            // This will take the enrollment information


            // If the course code of the enrollment being added to the section should be assigned to the course otherwise it will be null and thus exception will be thrown

            if (this.ACourse == null)
            {
                throw new Exception("Student can only be assigned to the section that is assigned to the course .");
            }

            // Else it will check if the current number of students in the enrollment has reached it's limit that is the maximum number of students

            else
              if (Enrollments.Count == this.MaxNumberOfStudents)
            {

                throw new Exception("Student cannot be added. Section is full. ");

            }

            // The student that is the enrollment will be added is the current number of enrollements for that specific section has not reached the maximum number
            else
            {
                Enrollment enrol = new Enrollment(this, aStudent, 20);
                Enrollments.Add(enrol);
                aStudent.Sections.Add(this);
            }

        }

        // Over here it is giving me index out of range exception when I try to Insert Evaluation object

        public void DefineEvaluation(int orderNumber, EvaluationType evalType, double maxPoint, double evalWeight)
        {

            // This will take the evaluation information - specifically the weightage, max points and the evaluation type to calculate the marks for the student

            Evaluation eval = new Evaluation(evalWeight, maxPoint, evalType);   //  public Evaluation(double evaluationWeight, int maxPoints, TypeOfEvaluation typeOfEvaluation)

            // This one is for adding the evaluation type in the evaluations array !
            // Overhere I cannot use for loop anymore - I have to use foreach loop 
            foreach (Enrollment checkEnrol in Enrollments)
            {
                checkEnrol.Evaluations.Add(eval);
                // Enrollment.Section = this;    // Well this is to specifically say that this enrollment is for this particular section -- I don't know if it is correct or not 
            }

        }


        public void AddStudentMark(int orderNumber, Student aStudent, double points)
        {
            /*
             * I don not know I am facing some strange problem here ! When I want to add marks to the student the functionality is working 
             * correctly ...I mean logic wise but the problem that I am facing is when I add marks for one particular studentit is changing 
             * the marks for all the students in the collection
             * So I am actually adding he marks of all the students into another object and then I am adding that particular object; This 
             * is kind of like similar problem that I was facing in the quiz while assigning the values but it was array and this is list, 
             * So I will not only will have to insert but if I insert the I will have to use remove at as well 
             * 
             */


            int j = 0;
            bool answer = DoesStudentExists(aStudent, ref j);
            int index = orderNumber - 1;
            double maxpoint, weightage;
            EvaluationType etype;

            if (answer)
            {
                if (Enrollments[j].Evaluations[index].MaxPoints >= points)
                {
                    maxpoint = Enrollments[j].Evaluations[index].MaxPoints;
                    weightage = Enrollments[j].Evaluations[index].EvaluationWeight;
                    etype = Enrollments[j].Evaluations[index].ATypeOfEvaluation;

                    Evaluation addEval = new Evaluation(weightage, maxpoint, etype) { Points = points };
                    Enrollments[j].Evaluations.Insert(index, addEval);
                    Enrollments[j].Evaluations.RemoveAt(orderNumber);

                }
                else throw new Exception("Points are greater than the maximum points.");
            }
            else
                throw new Exception("Student " + aStudent.Name + " does not exists");
        }

        public string GetEvaluationsInfo()
        {

            string result = "\t\t";  // This is for keeping the space for the name of the student as the first field
            string subResult = "\n";

            for (counter = 0; counter < Enrollments[0].Evaluations.Count; counter++)
            {
                result = result + counter + "." + Enrollments[counter].Evaluations[counter].ATypeOfEvaluation + "[" + Enrollments[counter].Evaluations[counter].MaxPoints + "]" + "\t";

            }

            String finalResult = " ";

            foreach (Enrollment printEnrol in Enrollments)
            {

                subResult = "\n" + printEnrol.Student.Name;


                // I can create a counter here
                for (int i = 0; i < printEnrol.Evaluations.Count; i++)
                {
                    subResult += "\t\t" + printEnrol.Evaluations[i].Points + "/" + (printEnrol.Evaluations[i].Points / printEnrol.Evaluations[i].MaxPoints) * printEnrol.Evaluations[i].EvaluationWeight * 100 + " ";
                }

                finalResult += subResult;
            }

            result = result + finalResult;

            return result;
        }


        public string FinalMarksInfo()
        {
            // This loop is for assigning the final grade 

            foreach (Enrollment calcEnrol in Enrollments)
            {
                double finalMark = 0;

                foreach (Evaluation calcEval in calcEnrol.Evaluations)
                {
                    finalMark += (calcEval.Points / calcEval.MaxPoints) * calcEval.EvaluationWeight * 100;
                }

                calcEnrol.AFinalGrade = calcEnrol.CalculateFinalGrade(finalMark);
            }

            // This loop is for printing the result in the required format
            string result = "";

            for (int i = 0; i < Enrollments.Count; i++)
            {
                result = result + Enrollments[i].Student.Name + "\t" + Enrollments[i].AFinalGrade + "\n";

            }
            return result;
        }

        public override string ToString()
        {
            string result = "\nSection id: " + SectionId + "\t\tName: " + Name + "\t\tMax no of students: " + MaxNumberOfStudents + "\t\tSemester: " + Semester + "\nFaculty : " + Faculty.Name + "\nNo of students: " + Enrollments.Count;
            string resPart2 = "\n\t";

            foreach (Enrollment printEnrol in Enrollments)
            {
                resPart2 += printEnrol;
            }

            return result + resPart2;
        }

        // My methods

        public bool DoesStudentExists(Student aStudent, ref int j)
        {
            bool exists = false;

            for (int i = 0; i < Enrollments.Count; i++)
            {
                if (Enrollments[i].Student.RegistrationNumber == aStudent.RegistrationNumber)
                {
                    j = i;
                    exists = true;
                    i = Enrollments.Count;
                }

            }
            return exists;
        }


    }
}