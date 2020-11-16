using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ff_WDatabse.Models
{
    public class Witcher
    {
        [Key]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(0, 200)]
        public int Age { get; set; }

        [StringLength(100)]
        public string School { get; set; }
        [Range(0, 2000)]
        public int AvaragePay { get; set; }
    }
}
