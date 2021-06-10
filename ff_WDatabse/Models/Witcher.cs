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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public override bool Equals(object obj)
        {
            if (obj is Witcher)
            {
                Witcher w = obj as Witcher;
                bool b1 = (this.Age == w.Age && this.AvaragePay == w.AvaragePay && this.School == w.School
                    && this.Name == w.Name && this.Monsters_slain == w.Monsters_slain && this.Friend == w.Friend && this.FriendID == w.FriendID);
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
