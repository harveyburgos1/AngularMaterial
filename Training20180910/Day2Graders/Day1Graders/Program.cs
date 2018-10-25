using Day1Graders.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Graders
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Method1
            //List<decimal> grades = new List<decimal>();
            //Random randomizer = new Random();

            //for (int i = 1; i <= 8; i += 1)
            //{
            //    decimal grade = randomizer.Next(75, 100);
            //    grades.Add(grade);
            //    Console.WriteLine("Grade {0}: {1} ",
            //        i, grade);
            //}

            //Console.WriteLine("Highest Grade: {0} ", grades.Max());
            //Console.WriteLine("Lowest Grade: {0}", grades.Min());
            //Console.WriteLine("Average Grade: {0}", grades.Average());
            //Console.ReadLine();
            #endregion

            GradeGenerator generator = new GradeGenerator();
            GradeRecord grades = generator.GenerateGrades();
            GradePrinter printer = new GradePrinter(grades);

            printer.PrintGrades();
            Console.ReadLine();


          
        }
    }
}
