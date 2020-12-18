using Logic;
using Models;
using Moq;
using NUnit.Framework;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    [TestFixture]
    class Test
    {
        Mock<IRepository<Witcher>> wrepo;
        Mock<IRepository<Monster>> mrepo;
        Mock<IRepository<Human>> hrepo;

        //-------------crud tesztelés
        [Test]
        public void GetAllWitchers()
        {
            Mock<IRepository<Witcher>> mock = new Mock<IRepository<Witcher>>(MockBehavior.Loose);
            List<Witcher> TList = new List<Witcher>()
              { new Witcher() { Name = "Geralt of Testia", Age = 40, AvaragePay = 440, School = "School of the Wolf" },
                new Witcher() { Name = "Fred", Age = 50, AvaragePay = 350, School = "School of the Cat"},
                new Witcher() { Name = "Bob", Age = 35, AvaragePay = 4000, School = "School of the Griffin" }};

            mock.Setup(x => x.GetAll()).Returns(TList.AsQueryable);

            //---
            WitcherLogic wl = new WitcherLogic(mock.Object);
            var output = wl.GetAll();

            //---
            List<Witcher> WList = new List<Witcher>() { TList[0], TList[1], TList[2] };
            Assert.That(output, Is.EquivalentTo(WList));
            Assert.That(output.Count, Is.EqualTo(WList.Count));

        }

        [Test]
        public void AddWitcher()
        {
            Mock<IRepository<Witcher>> mock1 = new Mock<IRepository<Witcher>>(MockBehavior.Loose);
            mock1.Setup(x => x.Add(It.IsAny<Witcher>()));
            WitcherLogic wl = new WitcherLogic(mock1.Object);

            Witcher w1 = new Witcher { Name = "Gezu", Age = 5, AvaragePay = 555, School = "School of the Viper" };
            wl.Add(w1);

            mock1.Verify(x => x.Add(w1), Times.Once);
        }

        [Test]
        public void EditMonster()
        {
            Mock<IRepository<Monster>> mock2 = new Mock<IRepository<Monster>>(MockBehavior.Loose);
            Monster m1 = new Monster { Name = "Alpot", Bounty = 4000, Threat = 10, Race = "Cursed One" };

            mock2.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<Monster>()));
            MonsterLogic ml = new MonsterLogic(mock2.Object);

            ml.Update(m1.Race, m1);
            mock2.Verify(x => x.Update(m1.Race, m1), Times.Once);

        }

        [Test]
        public void DeleteHuman()
        {
            Mock<IRepository<Human>> mock3 = new Mock<IRepository<Human>>(MockBehavior.Loose);
            mock3.Setup(x => x.Delete(It.IsAny<string>()));

            HumanLogic hl = new HumanLogic(mock3.Object);
            Human h1 = new Human() { Name = "Chad", Job = "Emperor", Nationality = "Temerian", Wage = 2000 };
            hl.Delete(h1);

            mock3.Verify(x => x.Delete(h1), Times.Once);
        }

        [Test]
        public void GetWitcher()
        {
            Mock<IRepository<Witcher>> mock4 = new Mock<IRepository<Witcher>>(MockBehavior.Loose);
            Witcher w2 = new Witcher { Name = "John", Age = 99, AvaragePay = 120, School = "School of the Bear" };
            
            string randomid = "random1234";

            mock4.Setup(x => x.Read(randomid)).Returns(w2);
            WitcherLogic wl = new WitcherLogic(mock4.Object);

            //---
            Witcher w3 = wl.Read(randomid);
            Assert.That(w3, Is.EqualTo(w2));

        }


        //----------------------------------- non-crud tesztelés
        public StatLogic GetWitcherLogic()
        {
            // monster - witcher - human sorrend fontos 
            wrepo = new Mock<IRepository<Witcher>>(MockBehavior.Loose);
            hrepo = new Mock<IRepository<Human>>(MockBehavior.Loose);
            mrepo = new Mock<IRepository<Monster>>(MockBehavior.Loose);

            List<Monster> monsters = new List<Monster>()
            {
                new Monster { Bounty = 300, MonsterID = "mid001", Name = "mbot1", Race = "Ogroid", Threat = 2, WitcherID = "wid002"},
                new Monster { Bounty = 120, MonsterID = "mid002", Name = "mbot2", Race = "Relict", Threat = 5, WitcherID = "wid003"},
                new Monster { Bounty = 250, MonsterID = "mid003", Name = "mbot3", Race = "Beast", Threat = 3, WitcherID = "wid001"},
                new Monster { Bounty = 3200, MonsterID = "mid004", Name = "mbot4", Race = "Humanoid", Threat = 7, WitcherID = "wid003"},
                new Monster { Bounty = 25, MonsterID = "mid005", Name = "mbot5", Race = "Vampire", Threat = 9, WitcherID = "wid005"},
            };

            List<Witcher> witchers = new List<Witcher>()
            {
                new Witcher { Age = 50, AvaragePay = 300, FriendID = "hid003", Monsters_slain = new Monster[]{ monsters[4]}, Name = "wbot1", School = "School of the Wolf", WitcherID = "wid001"},
                new Witcher { Age = 42, AvaragePay = 42, FriendID = "hid002", Monsters_slain = new Monster[]{ monsters[2]}, Name = "wbot2", School = "School of the Cat", WitcherID = "wid002"},
                new Witcher { Age = 26, AvaragePay = 1, FriendID = "hid005", Monsters_slain = new Monster[]{ monsters[0]}, Name = "wbot3", School = "School of the Viper", WitcherID = "wid003"},
                new Witcher { Age = 87, AvaragePay = 999, FriendID = "hid001", Monsters_slain = new Monster[]{ monsters[3]}, Name = "wbot4", School = "School of the Bear", WitcherID = "wid004"},
                new Witcher { Age = 111, AvaragePay = 460, FriendID = "hid004", Monsters_slain = new Monster[]{ monsters[1]}, Name = "wbot5", School = "School of the Cat", WitcherID = "wid005"},
            };

            List<Human> humans = new List<Human>()
            {
                new Human { Friends = new Witcher[] {witchers[0],witchers[3]}, HumandID = "hid001", Job = "Armorer", Name = "hbot1", Nationality = "Redenia", Wage = 600, WitcherID = "wid005"},
                new Human { Friends = new Witcher[] {witchers[1],witchers[4]}, HumandID = "hid002", Job = "Blacksmith", Name = "hbot2", Nationality = "Temeria", Wage = 201, WitcherID = "wid003"},
                new Human { Friends = new Witcher[] {witchers[2]}, HumandID = "hid003", Job = "Trader", Name = "hbot3", Nationality = "Skellige", Wage = 305, WitcherID = "wid004"},
                new Human { Friends = new Witcher[] {witchers[0],witchers[3]}, HumandID = "hid004", Job = "Hunter", Name = "hbot4", Nationality = "Redenia", Wage = 404, WitcherID = "wid001"},
                new Human { Friends = new Witcher[] {witchers[3]}, HumandID = "hid005", Job = "Officer", Name = "hbot4", Nationality = "Skellige", Wage = 500, WitcherID = "wid002"},
            };

            wrepo.Setup(x => x.GetAll()).Returns(witchers.AsQueryable());
            hrepo.Setup(x => x.GetAll()).Returns(humans.AsQueryable());
            mrepo.Setup(x => x.GetAll()).Returns(monsters.AsQueryable());

            return new StatLogic(hrepo.Object, mrepo.Object, wrepo.Object);
        }

        [Test]
        public void GetSchoolStats()
        {
            StatLogic sl = GetWitcherLogic(); 
            string bestschool = "School of the Wolf";
            string testschool = sl.SchoolStats();

            Assert.That(bestschool, Is.EqualTo(testschool));
        }

        [Test]
        public void GetAvgHuntedBounty()
        {
            StatLogic sl = GetWitcherLogic();

            string avgbountyleader = "wbot3";
            string testbounty = sl.AvgHuntedBounty();

            Assert.That(avgbountyleader, Is.EqualTo(testbounty));
        }

        [Test]
        public void GetHasRedenianFriend()
        {
            StatLogic sl = GetWitcherLogic();

            int redenians = 2;
            int testredenians = sl.HasRedenianFriend();

            Assert.That(redenians, Is.EqualTo(testredenians));   
        }
    }
}
