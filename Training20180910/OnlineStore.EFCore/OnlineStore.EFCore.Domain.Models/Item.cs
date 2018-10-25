using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineStore.EFCore.Domain.Models
{
    [Table("Item")]
    public class Item
    {
        [Key]
        public Guid ItemID { get; set; }

        [MaxLength(60)]
        public string Name { get; set; }

        [MaxLength(60)]
        public string Type { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public decimal Cost { get; set; }

        public decimal Cooldown { get; set; }

        public bool IsChanneling { get; set; }

        public bool IsDisassemble { get; set; }

        public bool IsTargetable { get; set; }

        public int? UpgradeLevel { get; set; }

    }
}
