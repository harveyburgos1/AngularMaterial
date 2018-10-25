using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineStore.EFCore.Domain.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public Guid CategoryID { get; set; }

        [MaxLength(100)]
        [Required]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }
    }
}
