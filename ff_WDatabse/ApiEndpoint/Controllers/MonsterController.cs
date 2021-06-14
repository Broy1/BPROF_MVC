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
    public class MonsterController : ControllerBase
    {

        MonsterLogic logic;
        public MonsterController(MonsterLogic logic)
        {
            this.logic = logic;
        }

        [HttpDelete("{uid}")]
        public void DeleteMonster(string uid)
        {
            logic.Delete(uid);
        }

        [HttpGet("{uid}")]
        public Monster GetMonster(string uid)
        {
            return logic.Read(uid);
        }

        [HttpGet]
        public IEnumerable<Monster> GetAllMonster()
        {
            return logic.GetAll();
        }

        [HttpPost]
        public void AddMonster([FromBody] Monster item)
        {
            logic.Add(item);
        }

        [HttpPut("{oldid}")]
        public void UpdateMonster(string oldid, [FromBody] Monster item)
        {
            logic.Update(oldid, item);
        }
    }
}
