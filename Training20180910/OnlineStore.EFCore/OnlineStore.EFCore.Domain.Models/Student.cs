using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineStore.EFCore.Domain.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public Guid StudentID { get; set; }

       

        public Guid PersonID { get; set; }

        [ForeignKey("PersonID")]
        [Required]
        public Person Person { get; set; }
        [Required]
        public string School { get; set; }


        [Required]
        public DateTime Birthday { get; set; }


        public byte[] Photo { get; set; }
    }
}
