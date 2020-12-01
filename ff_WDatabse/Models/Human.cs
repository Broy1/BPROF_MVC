using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Human
    {
        [Key]
        public string HumandID { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Nationality { get; set; }

        [NotMapped]
        public virtual ICollection<Witcher> Friends { get; set; }

        [StringLength(100)]
        public string Job { get; set; }

        [Range(0, 10000)]
        public int Wage { get; set; }
    }
}
