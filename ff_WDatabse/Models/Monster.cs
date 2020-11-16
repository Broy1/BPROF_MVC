using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Models
{
    public class Monster
    {
        [Key]
        public string MonsterID { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        [NotMapped]
        public virtual Witcher Killedby { get; set; }
        public string WitcherID { get; set; }

        [Range(0, 10)]
        public int Threat { get; set; }

        [StringLength(100)]
        public string Race { get; set; }

        [Range(0, 10000)]
        public int Bounty { get; set; }
    }
}
