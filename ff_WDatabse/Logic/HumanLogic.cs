using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Repository;
using Models; //???
using System.Linq;

namespace Logic
{
    public class HumanLogic
    {
   
        IRepository<Human> HumanRepo;
        public HumanLogic(IRepository<Human> HumanRepo)
        {
            this.HumanRepo = HumanRepo;
        }

        public void Add(Human item)
        {
            this.HumanRepo.Add(item);
        }

        public IQueryable<Human> GetAll()
        {
            return this.HumanRepo.GetAll();
        }

        public void Delete(Human item)
        {
            this.HumanRepo.Delete(item);
        }

        public void Delete(string uid)
        {
            this.HumanRepo.Delete(uid);
        }

        public Human Read(string uid)
        {
            return this.HumanRepo.Read(uid);
        }

        public void Save()
        {
            this.HumanRepo.Save();
        }

        public void Update(string oldid, Human newitem)
        {
            this.HumanRepo.Update(oldid,newitem);
        }
        
        //non crud methods


        //public void Init()
        //{
        //    HumanRepo.Add(new Human() { Name = "Dandelion", Friends = null, Nationality = "Redenia", Job = "Bard", Wage = 100 });
        //    HumanRepo.Add(new Human() { Name = "Zoltan Chivay", Friends = null, Nationality = "Mahakam", Job = "Officer", Wage = 200 });
        //    HumanRepo.Add(new Human() { Name = "Emhyr var Emreis", Friends = null, Nationality = "Nilfgaard", Job = "Emperor", Wage = 8500 });
        //    HumanRepo.Add(new Human() { Name = "Sigismund Dijkstra", Friends = null, Nationality = "Redenia", Job = "Spy", Wage = 500 });
        //    HumanRepo.Add(new Human() { Name = "Radovid V", Friends = null, Nationality = "Redenia", Job = "Emperor", Wage = 10000 });
        //    HumanRepo.Add(new Human() { Name = "Svorlag Barber", Friends = null, Nationality = "Skellige", Job = "Armorer", Wage = 10 });
        //    HumanRepo.Add(new Human() { Name = "Anselm", Friends = null, Nationality = "Redenia", Job = "Merchant", Wage = 25 });
        //    HumanRepo.Add(new Human() { Name = "Midcopse Armorer", Friends = null, Nationality = "Temeria", Job = "Armorer", Wage = 30 });

        //    HumanRepo.Save();
        //}
        
    }
}
