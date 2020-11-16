using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ff_WDatabse.Models
{
    public class Human
    {
        [Key]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Nationality { get; set; }

        public virtual Witcher Friend { get; set; }

        [StringLength(100)]
        public string Job { get; set; }

        [Range(0, 10000)]
        public int Wage { get; set; }
    }
}
