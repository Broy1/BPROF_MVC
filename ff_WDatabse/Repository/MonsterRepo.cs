using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Repository
{
    public class MonsterRepo : IRepository<Monster>
    {
        WDatabaseContext context = new WDatabaseContext();
        
        public void Add(Monster item)
        {
            this.context.Monsters.Add(item);
            this.context.SaveChanges();
        }

        public IQueryable<Monster> GetAll()
        {
            return this.context.Monsters;
        }

        public void Delete(Monster item)
        {
            this.context.Monsters.Remove(item);
            this.context.SaveChanges();
        }

        public void Delete(string uid)
        {
            var del = this.context.Monsters
                .FirstOrDefault(w => w.MonsterID == uid);
            this.context.Monsters.Remove(del);
            this.context.SaveChanges();
        }

        public Monster Read(string uid)
        {
            var q = this.context.Monsters
                .FirstOrDefault(w => w.MonsterID == uid);
            return q;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void Update(string oldid, Monster newitem)
        {
            var old = this.context.Monsters
                .FirstOrDefault(w => w.MonsterID == oldid);

            old.Bounty = newitem.Bounty;
            old.Killedby = newitem.Killedby;
            old.MonsterID = newitem.MonsterID;
            old.Name = newitem.Name;
            old.Race = newitem.Race;
            old.Threat = newitem.Threat;
            old.WitcherID = newitem.WitcherID;
            this.context.SaveChanges();
        }
    }
}
