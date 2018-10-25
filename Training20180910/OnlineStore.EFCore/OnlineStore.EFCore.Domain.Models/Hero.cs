using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineStore.EFCore.Domain.Models
{
        [Table("Hero")]
        public class Hero
        {
            [Key]
            public Guid HeroID { get; set; }
            [MaxLength(60)]
            public string Name { get; set; }

            [MaxLength(60)]
            public string Attribute { get; set; }


            public decimal Hit { get; set; }

            public decimal Mana { get; set; }

            public decimal Damage { get; set; }

            public decimal Armor { get; set; }

            [MaxLength(1000)]
            public string Description { get; set; }

            public bool IsMelee { get; set; }

            public string AghanimsEffect { get; set; }

        }
    }
