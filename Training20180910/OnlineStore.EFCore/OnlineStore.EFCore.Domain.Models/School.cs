using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineStore.EFCore.Domain.Models
{
    [Table("School")]
    public class School
    {
        [Key]
        public Guid SchoolID { get; set; }

        [Required]
        public string SchoolName { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
