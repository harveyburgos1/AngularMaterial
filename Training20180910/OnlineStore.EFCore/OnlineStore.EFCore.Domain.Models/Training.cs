using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineStore.EFCore.Domain.Models
{
    [Table("Training")]
    public class Training
    {
        [Key]
        public Guid TrainingID { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
