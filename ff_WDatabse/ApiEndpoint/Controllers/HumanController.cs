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
    public class HumanController : ControllerBase
    {
        HumanLogic logic;
        public HumanController(HumanLogic logic)
        {
            this.logic = logic;
        }

        [HttpDelete("{uid}")]
        public void DeleteHuman(string uid)
        {
            logic.Delete(uid);
        }

        [HttpGet("{uid}")]
        public Human GetHuman(string uid)
        {
            return logic.Read(uid);
        }

        [HttpGet]
        public IEnumerable<Human> GetAllHuman()
        {
            return logic.GetAll();
        }

        [HttpPost]
        public void AddHuman([FromBody] Human item)
        {
            logic.Add(item);
        }

        [HttpPut("{oldid}")]
        public void UpdateHuman(string oldid, [FromBody] Human item)
        {
            logic.Update(oldid, item);
        }
    }
}
