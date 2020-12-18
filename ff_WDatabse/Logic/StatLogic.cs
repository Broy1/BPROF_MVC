using System;
using System.Collections.Generic;
using System.Text;
using Repository;
using Models;
using System.Linq;

namespace Logic
{
    public class StatLogic
    {
        IRepository<Human> humanrepo;
        IRepository<Monster> monsterrepo;
        IRepository<Witcher> witcherrepo;
        public StatLogic(IRepository<Human> humanrepo, IRepository<Monster> monsterrepo, IRepository<Witcher> witcherrepo)
        {
            this.humanrepo = humanrepo;
            this.monsterrepo = monsterrepo;
            this.witcherrepo = witcherrepo;
        }

        public string AvgHuntedBounty()
        {
            var avgbounty = (from x in witcherrepo.GetAll().ToList()
                             join y in monsterrepo.GetAll().ToList() on x.WitcherID equals y.WitcherID
                             group x by x.Name into g
                             select new
                             {
                                 Name = g.Key,
                                 Avg = g.SelectMany(x => x.Monsters_slain).Distinct().Average(y => y.Bounty)
                             }).OrderBy(z => z.Avg).LastOrDefault();
            return avgbounty.Name;
        }

        public string SchoolStats()
        {
            var bestschool = (from x in witcherrepo.GetAll().ToList()
                         join y in monsterrepo.GetAll().ToList() on x.WitcherID equals y.WitcherID
                         group x by x.School into g
                         select new
                         {
                             Name = g.Key,
                             Threat = g.SelectMany(y => y.Monsters_slain).Distinct().Average(y => y.Threat)
                         }).OrderBy(l => l.Threat).FirstOrDefault();
            return bestschool.Name;
        }

        public int HasRedenianFriend()
        {
            var howmany = (from x in witcherrepo.GetAll().ToList()
                           join y in humanrepo.GetAll().ToList() on x.FriendID equals y.HumandID
                           where y.Nationality == "Redenia"
                           select x).Count();
            return howmany;
        }
    }
}
