using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEndpoint.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class EditController : ControllerBase
    {
        WitcherLogic wlogic;
        HumanLogic hlogic;
        MonsterLogic mlogic;

        public EditController(WitcherLogic wlogic, HumanLogic hlogic, MonsterLogic mlogic)
        {
            this.wlogic = wlogic;
            this.hlogic = hlogic;
            this.mlogic = mlogic;
        }

        [HttpPost]
        public void AddMonsterToWitcher([FromBody] MonsterToWitcher item)
        {
            wlogic.AddMonsterSlain(mlogic.Read(item.MonsterUid), item.WitcherUid);
        }

        [HttpDelete]
        public void RemoveMonsterFromWitcher([FromBody] MonsterToWitcher item)
        {
            wlogic.DeleteMonsterSlain(mlogic.Read(item.MonsterUid), item.WitcherUid);
        }

        [HttpGet] //localhost:231/Edit
        public void FillDb()
        {
            Human h1 = new Human() { Name = "Dandelion", Nationality = "Redenia", Job = "Bard", Wage = 100 };

            hlogic.Add(h1);
            Witcher w1 = new Witcher() { Name = "Geralt", Age = 55, AvaragePay = 765, School = "School of the Wolf", FriendID = h1.HumandID };

            wlogic.Add(w1);
            Monster m1 = new Monster() { Name = "Eredin", WitcherID = w1.WitcherID, Race = "Elf", Threat = 10, Bounty = 10000 };

            mlogic.Add(m1);
            Monster m2 = new Monster() { Name = "Royal wyvern", WitcherID = w1.WitcherID, Race = "Dragon", Threat = 7, Bounty = 500 };

            mlogic.Add(m2);

            Human h2 = new Human() { Name = "Zoltan Chivay", Nationality = "Mahakam", Job = "Officer", Wage = 200 };

            hlogic.Add(h2);
            Human h3 = new Human() { Name = "Emhyr var Emreis", Nationality = "Nilfgaard", Job = "Emperor", Wage = 8500 };

            hlogic.Add(h3);
            Human h4 = new Human() { Name = "Sigismund Dijkstra", Nationality = "Redenia", Job = "Spy", Wage = 500 };

            hlogic.Add(h4);
            Human h5 = new Human() { Name = "Radovid V", Nationality = "Redenia", Job = "Emperor", Wage = 10000 };

            hlogic.Add(h5);
            Human h6 = new Human() { Name = "Svorlag Barber", Nationality = "Skellige", Job = "Barber", Wage = 10 };

            hlogic.Add(h6);
            Human h7 = new Human() { Name = "Anselm", Nationality = "Redenia", Job = "Merchant", Wage = 25 };

            hlogic.Add(h7);
            Human h8 = new Human() { Name = "Midcopse Armorer", Nationality = "Temeria", Job = "Armorer", Wage = 30 };

            hlogic.Add(h8);

            Witcher w2 = new Witcher() { Name = "Vesemir", Age = 120, AvaragePay = 450, School = "School of the Wolf", FriendID = h2.HumandID };

            wlogic.Add(w2);
            Witcher w3 = new Witcher() { Name = "Lambert", Age = 40, AvaragePay = 423, School = "School of the Wolf", FriendID = h2.HumandID };

            wlogic.Add(w3);
            Witcher w4 = new Witcher() { Name = "Eskel", Age = 43, AvaragePay = 550, School = "School of the Wolf", FriendID = h1.HumandID };

            wlogic.Add(w4);
            Witcher w5 = new Witcher() { Name = "Raven", Age = 38, AvaragePay = 376, School = "School of the Griffin", FriendID = h7.HumandID };

            wlogic.Add(w5);
            Witcher w6 = new Witcher() { Name = "Aiden", Age = 32, AvaragePay = 190, School = "School of the Cat", FriendID = h3.HumandID };

            wlogic.Add(w6);
            Witcher w7 = new Witcher() { Name = "Gerd", Age = 45, AvaragePay = 334, School = "School of the Viper", FriendID = h4.HumandID };

            wlogic.Add(w7);
            Witcher w8 = new Witcher() { Name = "Brehen", Age = 74, AvaragePay = 200, School = "School of the Cat", FriendID = h8.HumandID };

            wlogic.Add(w8);
            Witcher w9 = new Witcher() { Name = "Kolgrim", Age = 63, AvaragePay = 110, School = "School of the Viper", FriendID = h4.HumandID };

            wlogic.Add(w9);
            Witcher w10 = new Witcher() { Name = "Cedric", Age = 26, AvaragePay = 240, School = "School of the Cat", FriendID = h3.HumandID };

            wlogic.Add(w10);
            Witcher w11 = new Witcher() { Name = "Henry", Age = 37, AvaragePay = 660, School = "School of the Wolf", FriendID = h6.HumandID, Monsters_slain = new List<Monster>() };

            wlogic.Add(w11);


            Monster m3 = new Monster() { Name = "Botchling", WitcherID = w5.WitcherID, Race = "Cursed One", Threat = 2, Bounty = 230 };

            mlogic.Add(m3);
            Monster m4 = new Monster() { Name = "Gargoyle", WitcherID = null, Race = "Elementa", Threat = 5, Bounty = 420 };

            mlogic.Add(m4);
            Monster m5 = new Monster() { Name = "Leshen", WitcherID = w6.WitcherID, Race = "Relict", Threat = 6, Bounty = 450 };

            mlogic.Add(m5);
            Monster m6 = new Monster() { Name = "Nekker", WitcherID = null, Race = "Ogroid", Threat = 1, Bounty = 120 };

            mlogic.Add(m6);
            Monster m7 = new Monster() { Name = "Godling", WitcherID = w3.WitcherID, Race = "Relict", Threat = 0, Bounty = 0 };

            mlogic.Add(m7);
            Monster m8 = new Monster() { Name = "Higher Vampire", WitcherID = w2.WitcherID, Race = "Vampire", Threat = 8, Bounty = 600 };

            mlogic.Add(m8);
            Monster m9 = new Monster() { Name = "Water Hag", WitcherID = w9.WitcherID, Race = "Necrophage", Threat = 4, Bounty = 350 };

            mlogic.Add(m9);

            AddMonsterToWitcher(new MonsterToWitcher { MonsterUid =m5.MonsterID, WitcherUid =w11.WitcherID});

            //w1.Monsters_slain.Add(m1);
            //w2.Monsters_slain.Add(m8);
            //w2.Monsters_slain.Add(m3);
            //w2.Monsters_slain.Add(m5);
            //w3.Monsters_slain.Add(m5);
            //w4.Monsters_slain.Add(m3);
            //w4.Monsters_slain.Add(m4);
            //w5.Monsters_slain.Add(m4);
            //w5.Monsters_slain.Add(m6);
            //w5.Monsters_slain.Add(m9);
            //w6.Monsters_slain.Add(m6);
            //w7.Monsters_slain.Add(m5);
            //w7.Monsters_slain.Add(m5);
            //w8.Monsters_slain.Add(m6);
            //w8.Monsters_slain.Add(m5);
            //w8.Monsters_slain.Add(m3);
            //w9.Monsters_slain.Add(m7);
            //w10.Monsters_slain.Add(m2);
            //w10.Monsters_slain.Add(m8);
            //w11.Monsters_slain.Add(m9);
        }
    }
}
