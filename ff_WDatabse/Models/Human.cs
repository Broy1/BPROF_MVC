using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Human
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string HumandID { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Nationality { get; set; }

        [NotMapped]
        public virtual ICollection<Witcher> Friends { get; set; }
        public string WitcherID { get; set; }

        [StringLength(100)]
        public string Job { get; set; }

        [Range(0, 10000)]
        public int Wage { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Human)
            {
                Human h = obj as Human;
                bool b1 = (this.Friends == h.Friends && this.HumandID == h.HumandID && this.Job == h.Job && this.Name == h.Name && this.Nationality
                    == h.Nationality && this.Wage == h.Wage && this.WitcherID == h.WitcherID);
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
