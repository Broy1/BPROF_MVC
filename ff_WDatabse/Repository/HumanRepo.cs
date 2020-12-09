using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Repository
{
    public class HumanRepo : IRepository<Human>
    {
        WDatabaseContext context = new WDatabaseContext();
        
        public void Add(Human item)
        {
            this.context.Humen.Add(item);
            this.context.SaveChanges();
        }

        public IQueryable<Human> GetAll()
        {
            return this.context.Humen;
        }

        public void Delete(Human item)
        {
            this.context.Humen.Remove(item);
            this.context.SaveChanges();
        }

        public void Delete(string uid)
        {
            var del = this.context.Humen
                .FirstOrDefault(h => h.HumandID == uid);
            this.context.Humen.Remove(del);
            this.context.SaveChanges();
        }

        public Human Read(string uid)
        {
            var q = this.context.Humen
                .FirstOrDefault(h => h.HumandID == uid);
            return q;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void Update(string oldid, Human newitem)
        {
            var old = this.context.Humen
                .FirstOrDefault(h => h.HumandID == oldid);

            old.Friends = newitem.Friends;
            old.HumandID = newitem.HumandID;
            old.Job = newitem.Job;
            old.Name = newitem.Name;
            old.Nationality = newitem.Nationality;
            old.Wage = newitem.Wage;
            this.context.SaveChanges();
        }
    }
}
