using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineStore.EFCore.Domain.Models
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailID { get; set; }

        public int OrderLineID { get; set; }

        public Guid OrderID { get; set; }

        [ForeignKey("OrderID")]
        [Required]
        public Order Order { get; set; }

        public Guid ProductID { get; set; }
        [ForeignKey("ProductID")]
        [Required]
        public Product Product { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Quantity { get; set; }

        public decimal Discount { get; set; }
        
    }
}
