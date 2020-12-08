using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;

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

        public IActionResult AddWitcher() 
        {
            return View();
        }
    }
}
