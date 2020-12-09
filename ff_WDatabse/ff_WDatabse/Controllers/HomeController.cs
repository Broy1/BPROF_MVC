using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Repository;
using Models;

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
            ;

            Human h2 = new Human() { Name = "Zoltan Chivay", Friends = null, Nationality = "Mahakam", Job = "Officer", Wage = 200 };
            h2.HumandID = Guid.NewGuid().ToString();
            HumanLogic.Add(h2);




            //MonsterLogic.Add(new Monster() { Name = "Eredin", Killedby = null, Race = "Elf", Threat = 10, Bounty = 10000 });
            //MonsterLogic.Add(new Monster() { Name = "Royal wyvern", Killedby = null, Race = "Dragon", Threat = 7, Bounty = 500 });
            //MonsterLogic.Add(new Monster() { Name = "Botchling", Killedby = null, Race = "Cursed One", Threat = 2, Bounty = 230 });
            //MonsterLogic.Add(new Monster() { Name = "Gargoyle", Killedby = null, Race = "Elementa", Threat = 5, Bounty = 420 });
            //MonsterLogic.Add(new Monster() { Name = "Leshen", Killedby = null, Race = "Relict", Threat = 6, Bounty = 450 });
            //MonsterLogic.Add(new Monster() { Name = "Nekker", Killedby = null, Race = "Ogroid", Threat = 1, Bounty = 120 });
            //MonsterLogic.Add(new Monster() { Name = "Godling", Killedby = null, Race = "Relict", Threat = 0, Bounty = 0 });
            //MonsterLogic.Add(new Monster() { Name = "Higher Vampire", Killedby = null, Race = "Vampire", Threat = 8, Bounty = 600 });
            //MonsterLogic.Add(new Monster() { Name = "Water Hag", Killedby = null, Race = "Necrophage", Threat = 4, Bounty = 350 });

            //WitcherLogic.Add(new Witcher() { Name = "Geralt", Age = 55, AvaragePay = 765, School = "School of the Wolf", FriendID = });
            //WitcherLogic.Add(new Witcher() { Name = "Vesemir", Age = 120, AvaragePay = 450, School = "School of the Wolf" });
            //WitcherLogic.Add(new Witcher() { Name = "Lambert", Age = 40, AvaragePay = 423, School = "School of the Wolf" });
            //WitcherLogic.Add(new Witcher() { Name = "Eskel", Age = 43, AvaragePay = 550, School = "School of the Wolf" });
            //WitcherLogic.Add(new Witcher() { Name = "Raven", Age = 38, AvaragePay = 376, School = "School of the Griffin" });
            //WitcherLogic.Add(new Witcher() { Name = "Aiden", Age = 32, AvaragePay = 190, School = "School of the Cat" });
            //WitcherLogic.Add(new Witcher() { Name = "Gerd", Age = 45, AvaragePay = 334, School = "School of the Viper" });
            //WitcherLogic.Add(new Witcher() { Name = "Brehen", Age = 74, AvaragePay = 200, School = "School of the Cat" });
            //WitcherLogic.Add(new Witcher() { Name = "Kolgrim", Age = 63, AvaragePay = 110, School = "School of the Viper" });
            //WitcherLogic.Add(new Witcher() { Name = "Cedric", Age = 26, AvaragePay = 240, School = "School of the Cat" });
            //WitcherLogic.Add(new Witcher() { Name = "Henry", Age = 37, AvaragePay = 660, School = "School of the Wolf" });


            //HumanLogic.Add(new Human() { Name = "Zoltan Chivay", Friends = null, Nationality = "Mahakam", Job = "Officer", Wage = 200 });
            //HumanLogic.Add(new Human() { Name = "Emhyr var Emreis", Friends = null, Nationality = "Nilfgaard", Job = "Emperor", Wage = 8500 });
            //HumanLogic.Add(new Human() { Name = "Sigismund Dijkstra", Friends = null, Nationality = "Redenia", Job = "Spy", Wage = 500 });
            //HumanLogic.Add(new Human() { Name = "Radovid V", Friends = null, Nationality = "Redenia", Job = "Emperor", Wage = 10000 });
            //HumanLogic.Add(new Human() { Name = "Svorlag Barber", Friends = null, Nationality = "Skellige", Job = "Armorer", Wage = 10 });
            //HumanLogic.Add(new Human() { Name = "Anselm", Friends = null, Nationality = "Redenia", Job = "Merchant", Wage = 25 });
            //HumanLogic.Add(new Human() { Name = "Midcopse Armorer", Friends = null, Nationality = "Temeria", Job = "Armorer", Wage = 30 });

            return RedirectToAction(nameof(Index));
        }

       
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
    }
}
