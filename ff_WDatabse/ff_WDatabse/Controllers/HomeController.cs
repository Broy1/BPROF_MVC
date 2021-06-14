using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Repository;
using Models;
using System.Dynamic;
using Data;

namespace ff_WDatabse.Controllers
{
    public class HomeController : Controller
    {
        WitcherLogic WitcherLogic;
        HumanLogic HumanLogic;
        MonsterLogic MonsterLogic;
        StatLogic StatLogic;
        public HomeController(WitcherLogic WitcherLogic, HumanLogic HumanLogic,MonsterLogic MonsterLogic, StatLogic StatLogic)
        {
            this.WitcherLogic = WitcherLogic;
            this.HumanLogic = HumanLogic;
            this.MonsterLogic = MonsterLogic;
            this.StatLogic = StatLogic;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Init()
        {
            
            Human h1 = new Human() { Name = "Dandelion", Nationality = "Redenia", Job = "Bard", Wage = 100 };
            
            HumanLogic.Add(h1);
            Witcher w1 = new Witcher() { Name = "Geralt", Age = 55, AvaragePay = 765, School = "School of the Wolf", FriendID =h1.HumandID };
            
            WitcherLogic.Add(w1);
            Monster m1 = new Monster() { Name = "Eredin", WitcherID = w1.WitcherID,  Race = "Elf", Threat = 10, Bounty = 10000 };
            
            MonsterLogic.Add(m1);
            Monster m2 = new Monster() { Name = "Royal wyvern", WitcherID = w1.WitcherID, Race = "Dragon", Threat = 7, Bounty = 500 };
            
            MonsterLogic.Add(m2);

            Human h2 = new Human() { Name = "Zoltan Chivay", Nationality = "Mahakam", Job = "Officer", Wage = 200 };
            
            HumanLogic.Add(h2);
            Human h3 = new Human() { Name = "Emhyr var Emreis", Nationality = "Nilfgaard", Job = "Emperor", Wage = 8500 };
            
            HumanLogic.Add(h3);
            Human h4 = new Human() { Name = "Sigismund Dijkstra", Nationality = "Redenia", Job = "Spy", Wage = 500 };
            
            HumanLogic.Add(h4);
            Human h5 = new Human() { Name = "Radovid V", Nationality = "Redenia", Job = "Emperor", Wage = 10000 };
            
            HumanLogic.Add(h5);
            Human h6 = new Human() { Name = "Svorlag Barber", Nationality = "Skellige", Job = "Barber", Wage = 10 };
            
            HumanLogic.Add(h6);
            Human h7 = new Human() { Name = "Anselm", Nationality = "Redenia", Job = "Merchant", Wage = 25 };
            
            HumanLogic.Add(h7);
            Human h8 = new Human() { Name = "Midcopse Armorer", Nationality = "Temeria", Job = "Armorer", Wage = 30 };
            
            HumanLogic.Add(h8);

            Witcher w2 = new Witcher() { Name = "Vesemir", Age = 120, AvaragePay = 450, School = "School of the Wolf", FriendID = h2.HumandID };
            
            WitcherLogic.Add(w2);
            Witcher w3 = new Witcher() { Name = "Lambert", Age = 40, AvaragePay = 423, School = "School of the Wolf", FriendID = h2.HumandID};
            
            WitcherLogic.Add(w3);
            Witcher w4 = new Witcher() { Name = "Eskel", Age = 43, AvaragePay = 550, School = "School of the Wolf", FriendID = h1.HumandID};
            
            WitcherLogic.Add(w4);
            Witcher w5 = new Witcher() { Name = "Raven", Age = 38, AvaragePay = 376, School = "School of the Griffin", FriendID = h7.HumandID};
            
            WitcherLogic.Add(w5);
            Witcher w6 = new Witcher() { Name = "Aiden", Age = 32, AvaragePay = 190, School = "School of the Cat", FriendID = h3.HumandID};
            
            WitcherLogic.Add(w6);
            Witcher w7 = new Witcher() { Name = "Gerd", Age = 45, AvaragePay = 334, School = "School of the Viper", FriendID = h4.HumandID};
            
            WitcherLogic.Add(w7);
            Witcher w8 = new Witcher() { Name = "Brehen", Age = 74, AvaragePay = 200, School = "School of the Cat", FriendID = h8.HumandID};
            
            WitcherLogic.Add(w8);
            Witcher w9 = new Witcher() { Name = "Kolgrim", Age = 63, AvaragePay = 110, School = "School of the Viper", FriendID = h4.HumandID};
          
            WitcherLogic.Add(w9);
            Witcher w10 = new Witcher() { Name = "Cedric", Age = 26, AvaragePay = 240, School = "School of the Cat", FriendID = h3.HumandID};
           
            WitcherLogic.Add(w10);
            Witcher w11 = new Witcher() { Name = "Henry", Age = 37, AvaragePay = 660, School = "School of the Wolf", FriendID = h6.HumandID};
           
            WitcherLogic.Add(w11);


            Monster m3 = new Monster() { Name = "Botchling", WitcherID = w5.WitcherID, Race = "Cursed One", Threat = 2, Bounty = 230 };
           
            MonsterLogic.Add(m3);
            Monster m4 = new Monster() { Name = "Gargoyle", WitcherID = null, Race = "Elementa", Threat = 5, Bounty = 420 };
          
            MonsterLogic.Add(m4);
            Monster m5 = new Monster() { Name = "Leshen", WitcherID = w6.WitcherID, Race = "Relict", Threat = 6, Bounty = 450 };
           
            MonsterLogic.Add(m5);
            Monster m6 = new Monster() { Name = "Nekker", WitcherID = null, Race = "Ogroid", Threat = 1, Bounty = 120 };
            
            MonsterLogic.Add(m6);
            Monster m7 = new Monster() { Name = "Godling", WitcherID = w3.WitcherID, Race = "Relict", Threat = 0, Bounty = 0 };
           
            MonsterLogic.Add(m7);
            Monster m8 = new Monster() { Name = "Higher Vampire", WitcherID = w2.WitcherID, Race = "Vampire", Threat = 8, Bounty = 600 };
           
            MonsterLogic.Add(m8);
            Monster m9 = new Monster() { Name = "Water Hag", WitcherID = w9.WitcherID, Race = "Necrophage", Threat = 4, Bounty = 350 };
           
            MonsterLogic.Add(m9);

            return RedirectToAction(nameof(Index));
        }

        //-----------------------------------------Humans
        public IActionResult HumanPage()
        {
            return View();
        }

        public IActionResult ListAllHumans()
        {
            return View(HumanLogic.GetAll());
        }

        public IActionResult AddHuman()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddHuman(Human h)
        {
            h.HumandID = Guid.NewGuid().ToString();
            HumanLogic.Add(h);
            return RedirectToAction(nameof(HumanPage));
        }

        public IActionResult UpdateHuman(string id)
        {
            return View(HumanLogic.Read(id));
        }
        [HttpPost]
        public IActionResult UpdateHuman(Human human)
        {
            HumanLogic.Update(human.HumandID,human);
            return RedirectToAction(nameof(ListAllHumans));
        }

        public IActionResult DeleteHuman(string id)
        {
            HumanLogic.Delete(HumanLogic.Read(id));
            return RedirectToAction(nameof(ListAllHumans));
        }

        //--------------------------------------------------- Monsters

        public IActionResult MonsterPage()
        {
            return View();
        }

 
        public IActionResult AddMonster()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMonster(Monster m)
        {
            m.MonsterID = Guid.NewGuid().ToString();
            MonsterLogic.Add(m);
            return RedirectToAction(nameof(MonsterPage));
        }

        public IActionResult ListAllMonsters()
        {
            return View(MonsterLogic.GetAll());
        }

        public IActionResult DeleteMonster(string id)
        {
            MonsterLogic.Delete(MonsterLogic.Read(id));
            return RedirectToAction(nameof(ListAllMonsters));
        }

        public IActionResult UpdateMonster(string id)
        {
            return View(MonsterLogic.Read(id));
        }
        [HttpPost]
        public IActionResult UpdateMonster(Monster monster)
        {
            MonsterLogic.Update(monster.MonsterID, monster);
            return RedirectToAction(nameof(ListAllMonsters));
        }

        //------------------------------------------------------- Witchers

        public IActionResult WitcherPage()
        {
            return View();
        }

        public IActionResult ListAllWitchers()
        {
            return View(WitcherLogic.GetAll());
        }

        public IActionResult AddWitcher()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWitcher(Witcher w)
        {
            w.WitcherID = Guid.NewGuid().ToString();
            WitcherLogic.Add(w);
            return RedirectToAction(nameof(ListAllWitchers));
        }

        public IActionResult UpdateWitcher(string id)
        {
            return View(WitcherLogic.Read(id));
        }
        [HttpPost]
        public IActionResult UpdateWitcher(Witcher witcher)
        {
            WitcherLogic.Update(witcher.WitcherID, witcher);
            return RedirectToAction(nameof(ListAllWitchers));
        }
        public IActionResult DeleteWitcher(string id)
        {
            WitcherLogic.Delete(WitcherLogic.Read(id));
            return RedirectToAction(nameof(ListAllWitchers));
        }

        //----//
        public IActionResult Contracts(WDatabaseContext context)
        {
            return View(context.Monsters);
        }

        // -------------------------- stats


        public IActionResult Stats()
        {
            StatModel statModel = new Models.StatModel();

            statModel.AvgHuntedBounty = StatLogic.AvgHuntedBounty();
            statModel.SchoolStats = StatLogic.SchoolStats();
            statModel.HasRedenianFriend = StatLogic.HasRedenianFriend();
            return View(statModel);
        }
    }
}
