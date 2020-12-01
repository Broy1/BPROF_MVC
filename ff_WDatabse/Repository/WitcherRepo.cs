using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class WitcherRepo : IRepository<Witcher>
    {
        public void Add(Witcher item)
        {
            throw new NotImplementedException();
        }

        public System.Linq.IQueryable<Witcher> AllItem()
        {
            throw new NotImplementedException();
        }

        public void Delete(Witcher item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string uid)
        {
            throw new NotImplementedException();
        }

        public Witcher Read(string uid)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(string oldid, Witcher newitem)
        {
            throw new NotImplementedException();
        }
    }
}
