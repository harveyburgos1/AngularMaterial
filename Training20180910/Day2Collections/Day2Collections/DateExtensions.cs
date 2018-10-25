using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Collections
{
    public static class DateExtensions
    {
        public static int GetAge(this DateTime birthdate)
        {
            int birthYear = birthdate.Year;
            int birthMonth = birthdate.Month;
            int birthDay = birthdate.Day;

            int age = DateTime.Today.Year - birthYear;
            if (birthMonth > DateTime.Today.Month || 
                (birthMonth == DateTime.Today.Month &&
                birthDay > DateTime.Today.Day))
            {
                age -= 1;
            }

            return age;
        }
    }
}
