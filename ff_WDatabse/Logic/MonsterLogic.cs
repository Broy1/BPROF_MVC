using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Models;
using System.Linq;
using Repository;

namespace Logic
{
    public class MonsterLogic
    {
        IRepository<Monster> MonsterRepo;
        IRepository<Witcher> WitcherRepo;
        public MonsterLogic(IRepository<Monster> MonsterRepo)
        {
            this.MonsterRepo = MonsterRepo;
        }

        public void Add(Monster item)
        {
            this.MonsterRepo.Add(item);
        }

        public IQueryable<Monster> GetAll()
        {
            return this.MonsterRepo.GetAll();
        }

        public void Delete(Monster item)
        {
            this.MonsterRepo.Delete(item);
        }

        public void Delete(string uid)
        {
            this.MonsterRepo.Delete(uid);
        }

        public Monster Read(string uid)
        {
            return this.MonsterRepo.Read(uid);
        }

        public void Save()
        {
            this.MonsterRepo.Save();
        }

        public void Update(string oldid, Monster newitem)
        {
            this.MonsterRepo.Update(oldid, newitem);
        }

        public void Init()
        {
            MonsterRepo.Add(new Monster() { Name = "Eredin", Killedby = null, Race = "Elf", Threat = 10, Bounty = 10000 });
            MonsterRepo.Add(new Monster() { Name = "Royal wyvern", Killedby = null, Race = "Dragon", Threat = 7, Bounty = 500 });
            MonsterRepo.Add(new Monster() { Name = "Botchling", Killedby = null, Race = "Cursed One", Threat = 2, Bounty = 230 });
            MonsterRepo.Add(new Monster() { Name = "Gargoyle", Killedby = null, Race = "Elementa", Threat = 5, Bounty = 420 });
            MonsterRepo.Add(new Monster() { Name = "Leshen", Killedby = null, Race = "Relict", Threat = 6, Bounty = 450 });
            MonsterRepo.Add(new Monster() { Name = "Nekker", Killedby = null, Race = "Ogroid", Threat = 1, Bounty = 120 });
            MonsterRepo.Add(new Monster() { Name = "Godling", Killedby = null, Race = "Relict", Threat = 0, Bounty = 0 });
            MonsterRepo.Add(new Monster() { Name = "Higher Vampire", Killedby = null, Race = "Vampire", Threat = 8, Bounty = 600 });
            MonsterRepo.Add(new Monster() { Name = "Water Hag", Killedby = null, Race = "Necrophage", Threat = 4, Bounty = 350 });

            MonsterRepo.Save();
        }
    }
}
