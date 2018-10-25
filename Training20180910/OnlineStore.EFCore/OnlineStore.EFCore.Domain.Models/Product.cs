using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineStore.EFCore.Domain.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid ProductID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        public Guid SupplierID { get; set; }
        [ForeignKey("SupplierID")]

        public Supplier Supplier { get; set; }

        public Guid CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category  Category { get; set; }


        public decimal UnitPrice { get; set; }

        public decimal UnitsInStock { get; set; }

        public decimal UnitsOnOrder { get; set; }

        public decimal ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
    }
}
