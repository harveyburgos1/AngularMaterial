using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineStore.EFCore.Domain.Models
{

    [Table("Employee")]
    public class Employee
    {
        [Key] 
        public Guid EmployeeID { get; set; }

        [MaxLength(60)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(60)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(60)]
        public string Title { get; set; }

        [MaxLength(60)]
        public string TitleOfCourtesy { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime? HireDate { get; set; }

        [MaxLength(100)]
        [Required]
        public string Address { get; set; }

        [MaxLength(100)]
        [Required]
        public string City { get; set; }

        [MaxLength(100)]
        public string Region { get; set; }

        [MaxLength(15)]
        public string PostalCode { get; set; }

        [MaxLength(100)]
        [Required]
        public string Country { get; set; }


        [MaxLength(15)]
        public string HomePhone { get; set; }

        [MaxLength(15)]
        public string Extension { get; set; }

        public byte[] Photo { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }


        public Guid ReportsTo { get; set; }




    }
}
