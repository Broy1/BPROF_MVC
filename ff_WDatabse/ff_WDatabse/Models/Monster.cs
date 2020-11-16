using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ff_WDatabse.Models
{
    public class Monster
    {
        [Key]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual Witcher Killedby { get; set; }

        [Range(0, 10)]
        public int Threat { get; set; }

        [StringLength(100)]
        public string Race { get; set; }

        [Range(0, 10000)]
        public int Bounty { get; set; }
    }
}
