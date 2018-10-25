using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Collections
{
    public class Person
    {
        public int PersonID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age
        {
            get
            {

                return this.BirthDate.GetAge();
            }
        }
    }
}
