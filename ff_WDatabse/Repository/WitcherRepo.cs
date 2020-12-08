using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Repository
{
    public class WitcherRepo : IRepository<Witcher>
    {
        WDatabaseContext context;
        public WitcherRepo(WDatabaseContext context)
        {
            this.context = context;
        }
        public void Add(Witcher item)
        {
            this.context.Witchers.Add(item);
            this.context.SaveChanges();
        }

        public IQueryable<Witcher> GetAll()
        {
            return this.context.Witchers;
        }

        public void Delete(Witcher item)
        {
            this.context.Witchers.Remove(item);
            this.context.SaveChanges();
        }

        public void Delete(string uid)
        {
            var del = this.context.Witchers
                .FirstOrDefault(w => w.WitcherID == uid);
            this.context.Witchers.Remove(del);
            this.context.SaveChanges();
        }

        public Witcher Read(string uid)
        {
            var q = this.context.Witchers
                .FirstOrDefault(w => w.WitcherID == uid);
            return q;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void Update(string oldid, Witcher newitem)
        {
            var old = this.context.Witchers
                .FirstOrDefault(w => w.WitcherID == oldid);

            old.Age = newitem.Age;
            old.AvaragePay = newitem.AvaragePay;
            old.Friend = newitem.Friend;
            old.FriendID = newitem.FriendID;
            old.Monsters_slain = newitem.Monsters_slain;
            old.Name = newitem.Name;
            old.School = newitem.School;
            old.WitcherID = newitem.WitcherID;
            this.context.SaveChanges();
        }
    }
}
