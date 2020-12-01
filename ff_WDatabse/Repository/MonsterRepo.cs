using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class MonsterRepo : IRepository<Monster>
    {
        public void Add(Monster item)
        {
            throw new NotImplementedException();
        }

        public System.Linq.IQueryable<Monster> AllItem()
        {
            throw new NotImplementedException();
        }

        public void Delete(Monster item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string uid)
        {
            throw new NotImplementedException();
        }

        public Monster Read(string uid)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(string oldid, Monster newitem)
        {
            throw new NotImplementedException();
        }
    }
}
