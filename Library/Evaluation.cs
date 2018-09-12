using System;
using System.Collections.Generic;
namespace CollegeConsole
{
    [Serializable]
    public class Evaluation
    {
        double evaluationWeight;
        double maxPoints;
        EvaluationType atypeOfEvaluation = new EvaluationType();
        double points;

        // Properties

        public double EvaluationWeight
        {
            get { return evaluationWeight; }
            set { evaluationWeight = value; }
        }

        public double MaxPoints
        {
            get { return maxPoints; }
            set { maxPoints = value; }
        }

        public double Points
        {
            get { return points; }
            set { points = value; }
        }

        public EvaluationType ATypeOfEvaluation
        {
            get { return atypeOfEvaluation; }
            set { atypeOfEvaluation = value; }
        }


        // default constructor

        public Evaluation()
        {
            EvaluationWeight = 0.0;
            MaxPoints = 0;
            ATypeOfEvaluation = EvaluationType.LAB;
            Points = 0;
        }

        // specified constructor

        public Evaluation(double evaluationWeight, double maxPoints, EvaluationType typeOfEvaluation)
        {
            EvaluationWeight = evaluationWeight;
            MaxPoints = maxPoints;
            ATypeOfEvaluation = typeOfEvaluation;
            Points = 0;
        }

        public string GetInfo()
        {
            return string.Format("\nEvaluation weight: {0} \t\tMax Points: {1} \t\tType Of Evaluation: {2} \t\tPoints: {3]", EvaluationWeight, MaxPoints, ATypeOfEvaluation, Points);
        }
    }
}
