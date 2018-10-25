using Day1Grades.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Graders.Utilities
{
    public class GradePrinter
    {
        private GradeRecord grades;
        public GradePrinter(GradeRecord grades)
        {
            this.grades = grades;
        }

        public void PrintGrades()
        {
            foreach(IndividualGrade grade in grades.Grades)
            {

                Console.WriteLine("Name: {0} is Grade: {1} "
                    , grade.Name, grade.Grade);

            }
            Console.WriteLine("Highest Grade: {0} ", grades.MaxGrade);
            Console.WriteLine("Lowest Grade: {0}", grades.MinGrade);
            Console.WriteLine("Average Grade: {0}", grades.AverageGrade);
            Console.ReadLine();
        }
    }
}
