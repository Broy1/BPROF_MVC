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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public override bool Equals(object obj)
        {
            if (obj is Monster)
            {
                Monster m = obj as Monster;
                bool b1 = (this.Bounty == m.Bounty && this.Killedby == m.Killedby && this.MonsterID == m.MonsterID && this.Name == m.Name &&
                    this.Race == m.Race && this.Threat == m.Threat && this.WitcherID == m.WitcherID);
                return b1;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return 0;
        }
    }
}
