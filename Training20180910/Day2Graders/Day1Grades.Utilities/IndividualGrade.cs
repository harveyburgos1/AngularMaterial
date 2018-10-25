using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Grades.Utilities
{
    public class IndividualGrade
    {
       // public string Name { get; set; }


        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == null || 
                    value == string.Empty )
                {
                    throw new ArgumentNullException("Name is required.");
                }
                name = value;
            }
        }

        private decimal grade;
        public decimal Grade
        {
            get
            {
                return grade;
            }
            set
            {
                grade = value;
            }
        }
    }
}
