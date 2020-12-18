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
            
        }
    }
}
