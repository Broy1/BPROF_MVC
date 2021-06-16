using Logic;
using Microsoft.AspNetCore.Authorization;
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
    public class WitcherController : ControllerBase
    {
        // localhoston /Witcher a tartalma ennek a kontrollernek
        WitcherLogic logic;
        public WitcherController(WitcherLogic logic)
        {
            this.logic = logic;
        }

        [HttpDelete("{uid}")] //localhost:6666/witcher/sadfasdf
        public void DeleteWitcher(string uid)
        {
            logic.Delete(uid);
        }

        [HttpGet("{uid}")]
        public Witcher GetWitcher(string uid)
        {
            return logic.Read(uid);
        }

        [HttpGet]
        public IEnumerable<Witcher> GetAllWitcher()
        {
            return logic.GetAll();
        }

        [HttpPost] 
        public void AddWitcher([FromBody]Witcher item)
        {
            logic.Add(item);
        }

        [HttpPut("{oldid}")]
        public void UpdateWitcher(string oldid,[FromBody] Witcher item)
        {
            logic.Update(oldid,item);
        }
    }
}
