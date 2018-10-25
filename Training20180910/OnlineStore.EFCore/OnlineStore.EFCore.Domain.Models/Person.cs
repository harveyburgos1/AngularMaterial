using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineStore.EFCore.Domain.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public Guid PersonID { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public int Age
        {
            get
            {
                var age = DateTime.Today.Year - Birthday.Date.Year;
                if (Birthday.Date > DateTime.Today.Date)
                {
                    return age - 1;
                }
                return age;
                //else if(Birthday.Date <= DateTime.Today.Date)
                //{
                //    return age;
                //}
            }
        }

        public byte[] Photo{ get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string RelationshipStatus { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Religion { get; set; }

        [Required]
        public string Street { get; set; }

        public string Barangay { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int PostalCode { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longtitude { get; set; }
    }


}
