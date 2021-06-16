using System;
using Data;
using Models;
using Repository;
using System.Linq;

namespace Logic
{
    public class WitcherLogic
    {
        IRepository<Witcher> WitcherRepo;
        public WitcherLogic(IRepository<Witcher> WitcherRepo)
        {
            this.WitcherRepo = WitcherRepo;
            
        }

        public void Add(Witcher item)
        {
            this.WitcherRepo.Add(item);
        }

        public IQueryable<Witcher> GetAll()
        {
            return this.WitcherRepo.GetAll();
        }

        public void Delete(Witcher item)
        {
            this.WitcherRepo.Delete(item);
        }

        public void Delete(string uid)
        {
            this.WitcherRepo.Delete(uid);
        }

        public Witcher Read(string uid)
        {
            return this.WitcherRepo.Read(uid);
        }

        public void Save()
        {
            this.WitcherRepo.Save();
        }

        public void Update(string oldid, Witcher newitem)
        {
            this.WitcherRepo.Update(oldid, newitem);
        }
        public void AddMonsterSlain(Monster monster, string wid)
        {
            Read(wid).Monsters_slain.Add(monster);
            WitcherRepo.Save();
        }

        public void DeleteMonsterSlain(Monster monster, string wid)
        {
            Read(wid).Monsters_slain.Remove(monster);
            WitcherRepo.Save();
        }
    }
}
