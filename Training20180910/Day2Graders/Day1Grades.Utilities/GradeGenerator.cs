using Day1Grades.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Graders.Utilities
{
    public class GradeGenerator
    {      
        public GradeRecord GenerateGrades()
        {
            GradeRecord grades = new GradeRecord();
            Random randomizer = new Random();

            for (int i = 1; i <= 50; i += 1)
            {
               
                IndividualGrade grade = new IndividualGrade
                {
                    Name = "Any Name" + i.ToString(),
                    Grade = randomizer.Next()
                };
                try
                {
                    grades.Add(grade);
                } 
                catch (InvalidGradeException exc)
                {
                    Console.WriteLine(exc.ToString());
                    grade.Grade = 0;
                    grades.Add(grade);
                }
                catch (InvalidNameException)
                {
                    Console.WriteLine("Name is null");
                }
               
            }
            return grades;
        }
    }
}
