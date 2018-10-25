using System;
using System.Collections.Generic;
using System.Text;

namespace Day3Database.Models
{
    public class Applicant
    {
        public Guid ApplicantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
