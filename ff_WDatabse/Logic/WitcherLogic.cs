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
        public void AddMonsterSlain(Monster item, string wid)
        {
            // hmm repobol kéne ide
        }

        public void DeleteMonsterSlain(string mid, string wid)
        {
            // hmm
        }

        public void Init()
        {
            this.WitcherRepo.Add(new Witcher() { Name = "Geralt", Age = 55, AvaragePay = 765, School = "School of the Wolf" });
            this.WitcherRepo.Add(new Witcher() { Name = "Vesemir", Age = 120, AvaragePay = 450, School = "School of the Wolf" });
            this.WitcherRepo.Add(new Witcher() { Name = "Lambert", Age = 40, AvaragePay = 423, School = "School of the Wolf" });
            this.WitcherRepo.Add(new Witcher() { Name = "Eskel", Age = 43, AvaragePay = 550, School = "School of the Wolf" });
            this.WitcherRepo.Add(new Witcher() { Name = "Raven", Age = 38, AvaragePay = 376, School = "School of the Griffin" });
            this.WitcherRepo.Add(new Witcher() { Name = "Aiden", Age = 32, AvaragePay = 190, School = "School of the Cat" });
            this.WitcherRepo.Add(new Witcher() { Name = "Gerd", Age = 45, AvaragePay = 334, School = "School of the Viper" });
            this.WitcherRepo.Add(new Witcher() { Name = "Brehen", Age = 74, AvaragePay = 200, School = "School of the Cat" });
            this.WitcherRepo.Add(new Witcher() { Name = "Kolgrim", Age = 63, AvaragePay = 110, School = "School of the Viper" });
            this.WitcherRepo.Add(new Witcher() { Name = "Cedric", Age = 26, AvaragePay = 240, School = "School of the Cat" });
            this.WitcherRepo.Add(new Witcher() { Name = "Henry", Age = 37, AvaragePay = 660, School = "School of the Wolf" });

            WitcherRepo.Save();
        }
    }
}
