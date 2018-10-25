using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineStore.EFCore.Domain.Models
{
    [Table("Shipper")]
    public class Shipper
    {
        [Key]
        public Guid ShipperID { get; set; }

        [MaxLength(100)]
        [Required]
        public string CompanyName { get; set; }

        [MaxLength(15)]
        [Required]
        public string Phone { get; set; }

    }
}
