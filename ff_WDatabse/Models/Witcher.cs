using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Witcher
    {
        [Key]
        public string WitcherID { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        [Range(0, 200)]
        public int Age { get; set; }
        [StringLength(100)]
        public string School { get; set; }
        [Range(0, 2000)]
        public int AvaragePay { get; set; }

        [NotMapped]
        public virtual Human Friend { get; set; }
        public string FriendID { get; set; }
        public virtual ICollection<Monster> Monsters_slain { get; set; }
    }
}
