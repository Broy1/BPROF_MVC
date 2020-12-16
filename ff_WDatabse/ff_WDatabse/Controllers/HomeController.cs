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

        public HomeController(WitcherLogic WitcherLogic, HumanLogic HumanLogic,MonsterLogic MonsterLogic)
        {
            this.WitcherLogic = WitcherLogic;
            this.HumanLogic = HumanLogic;
            this.MonsterLogic = MonsterLogic;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Init()
        {
            
            Human h1 = new Human() { Name = "Dandelion", Nationality = "Redenia", Job = "Bard", Wage = 100 };
            h1.HumandID = Guid.NewGuid().ToString();
            HumanLogic.Add(h1);
            Witcher w1 = new Witcher() { Name = "Geralt", Age = 55, AvaragePay = 765, School = "School of the Wolf", FriendID =h1.HumandID };
            w1.WitcherID = Guid.NewGuid().ToString();
            WitcherLogic.Add(w1);
            Monster m1 = new Monster() { Name = "Eredin", WitcherID = w1.WitcherID,  Race = "Elf", Threat = 10, Bounty = 10000 };
            m1.MonsterID = Guid.NewGuid().ToString();
            MonsterLogic.Add(m1);
            Monster m2 = new Monster() { Name = "Royal wyvern", WitcherID = w1.WitcherID, Race = "Dragon", Threat = 7, Bounty = 500 };
            m2.MonsterID = Guid.NewGuid().ToString();
            MonsterLogic.Add(m2);

            Witcher w2 = new Witcher() { Name = "Vesemir", Age = 120, AvaragePay = 450, School = "School of the Wolf" };
            w2.WitcherID = Guid.NewGuid().ToString();
            WitcherLogic.Add(w2);
            Witcher w3 = new Witcher() { Name = "Lambert", Age = 40, AvaragePay = 423, School = "School of the Wolf" };
            w3.WitcherID = Guid.NewGuid().ToString();
            WitcherLogic.Add(w3);
            Witcher w4 = new Witcher() { Name = "Eskel", Age = 43, AvaragePay = 550, School = "School of the Wolf" };
            w4.WitcherID = Guid.NewGuid().ToString();
            WitcherLogic.Add(w4);
            Witcher w5 = new Witcher() { Name = "Raven", Age = 38, AvaragePay = 376, School = "School of the Griffin" };
            w5.WitcherID = Guid.NewGuid().ToString();
            WitcherLogic.Add(w5);
            Witcher w6 = new Witcher() { Name = "Aiden", Age = 32, AvaragePay = 190, School = "School of the Cat" };
            w6.WitcherID = Guid.NewGuid().ToString();
            WitcherLogic.Add(w6);
            Witcher w7 = new Witcher() { Name = "Gerd", Age = 45, AvaragePay = 334, School = "School of the Viper" };
            w7.WitcherID = Guid.NewGuid().ToString();
            WitcherLogic.Add(w7);
            Witcher w8 = new Witcher() { Name = "Brehen", Age = 74, AvaragePay = 200, School = "School of the Cat" };
            w8.WitcherID = Guid.NewGuid().ToString();
            WitcherLogic.Add(w8);
            Witcher w9 = new Witcher() { Name = "Kolgrim", Age = 63, AvaragePay = 110, School = "School of the Viper" };
            w9.WitcherID = Guid.NewGuid().ToString();
            WitcherLogic.Add(w9);
            Witcher w10 = new Witcher() { Name = "Cedric", Age = 26, AvaragePay = 240, School = "School of the Cat" };
            w10.WitcherID = Guid.NewGuid().ToString();
            WitcherLogic.Add(w10);
            Witcher w11 = new Witcher() { Name = "Henry", Age = 37, AvaragePay = 660, School = "School of the Wolf" };
            w11.WitcherID = Guid.NewGuid().ToString();
            WitcherLogic.Add(w11);

            Human h2 = new Human() { Name = "Zoltan Chivay", Nationality = "Mahakam", Job = "Officer", Wage = 200 };
            h2.HumandID = Guid.NewGuid().ToString();
            HumanLogic.Add(h2);
            Human h3 = new Human() { Name = "Emhyr var Emreis", Nationality = "Nilfgaard", Job = "Emperor", Wage = 8500 };
            h3.HumandID = Guid.NewGuid().ToString();
            HumanLogic.Add(h3);
            Human h4 = new Human() { Name = "Sigismund Dijkstra", Nationality = "Redenia", Job = "Spy", Wage = 500 };
            h4.HumandID = Guid.NewGuid().ToString();
            HumanLogic.Add(h4);
            Human h5 = new Human() { Name = "Radovid V", Nationality = "Redenia", Job = "Emperor", Wage = 10000 };
            h5.HumandID = Guid.NewGuid().ToString();
            HumanLogic.Add(h5);
            Human h6 = new Human() { Name = "Svorlag Barber",  Nationality = "Skellige", Job = "Barber", Wage = 10 };
            h6.HumandID = Guid.NewGuid().ToString();
            HumanLogic.Add(h6);
            Human h7 = new Human() { Name = "Anselm", Nationality = "Redenia", Job = "Merchant", Wage = 25 };
            h7.HumandID = Guid.NewGuid().ToString();
            HumanLogic.Add(h7);
            Human h8 = new Human() { Name = "Midcopse Armorer", Nationality = "Temeria", Job = "Armorer", Wage = 30 };
            h8.HumandID = Guid.NewGuid().ToString();
            HumanLogic.Add(h8);

            

            Monster m3 = new Monster() { Name = "Botchling", Killedby = null, Race = "Cursed One", Threat = 2, Bounty = 230 };
            m3.MonsterID = Guid.NewGuid().ToString();
            MonsterLogic.Add(m3);
            Monster m4 = new Monster() { Name = "Gargoyle", Killedby = null, Race = "Elementa", Threat = 5, Bounty = 420 };
            m4.MonsterID = Guid.NewGuid().ToString();
            MonsterLogic.Add(m4);
            Monster m5 = new Monster() { Name = "Leshen", Killedby = null, Race = "Relict", Threat = 6, Bounty = 450 };
            m5.MonsterID = Guid.NewGuid().ToString();
            MonsterLogic.Add(m5);
            Monster m6 = new Monster() { Name = "Nekker", Killedby = null, Race = "Ogroid", Threat = 1, Bounty = 120 };
            m6.MonsterID = Guid.NewGuid().ToString();
            MonsterLogic.Add(m6);
            Monster m7 = new Monster() { Name = "Godling", Killedby = null, Race = "Relict", Threat = 0, Bounty = 0 };
            m7.MonsterID = Guid.NewGuid().ToString();
            MonsterLogic.Add(m7);
            Monster m8 = new Monster() { Name = "Higher Vampire", Killedby = null, Race = "Vampire", Threat = 8, Bounty = 600 };
            m8.MonsterID = Guid.NewGuid().ToString();
            MonsterLogic.Add(m8);
            Monster m9 = new Monster() { Name = "Water Hag", Killedby = null, Race = "Necrophage", Threat = 4, Bounty = 350 };
            m9.MonsterID = Guid.NewGuid().ToString();
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

        public IActionResult MonsterSlain(string id)
        {
            return View(nameof(MonsterSlain),id);
        }
        [HttpPost]
        public IActionResult MonsterSlain(Monster monster)
        {

            monster.MonsterID = Guid.NewGuid().ToString();
            MonsterLogic.Add(monster);
            return RedirectToAction(nameof(ListAllWitchers));
        }

        public IActionResult AddNewFriend(string id)
        {
            return View(nameof(AddNewFriend),id);
        }
        [HttpPost]
        public IActionResult AddNewFriend(Human human)
        {

            human.HumandID = Guid.NewGuid().ToString();
            HumanLogic.Add(human);
            return RedirectToAction(nameof(ListAllWitchers));
        }
        public IActionResult Contracts(WDatabaseContext context)
        {
            return View(context.Monsters);
        }
    }
}
