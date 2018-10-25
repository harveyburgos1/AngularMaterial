using Day1Grades.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Graders.Utilities
{
    public class GradeRecord
    {
        private List<IndividualGrade> grades;

        public GradeRecord()
        {
            grades = new List<IndividualGrade>();
        }

        public void Add(IndividualGrade grade)
        {
            if (grade == null)
            {
                throw new IndividualGradeNullException();
            }

            if (string.IsNullOrEmpty(grade.Name))
            {
                throw new InvalidNameException();
            }
            if (grade.Grade < 0 || grade.Grade > 100)
            {
                throw new InvalidGradeException(
                    string.Format("Grade {0} is not valid.", grade.Grade));
            }
            grades.Add(grade);
        }

        public decimal MinGrade
        {
            get
            {
                decimal minGrade = 100;
                foreach(var grade in grades)
                {
                    if (grade.Grade < minGrade)
                    {
                        minGrade = grade.Grade;
                    }
                }

                return minGrade;
            }
        }

        public decimal MaxGrade
        {
            get
            {
                decimal maxGrade = 75;
                foreach (var grade in grades)
                {
                    if (grade.Grade > maxGrade)
                    {
                        maxGrade = grade.Grade;
                    }
                }

                return maxGrade;
            }
        }

        public decimal AverageGrade
        {
            get
            {
                decimal totalGrade = 0;
                foreach (var grade in grades)
                {
                   
                    totalGrade += grade.Grade;
                
                }

                return totalGrade/grades.Count;
            }
        }

        public List<IndividualGrade> Grades
        {
            get
            {
                return this.grades.ToList();
            }
        }

    }
}
