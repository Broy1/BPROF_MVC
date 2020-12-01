using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class EmberRepo : IRepository<Ember>
    {
        public void Add(Ember item)
        {
            throw new NotImplementedException();
        }

        public System.Linq.IQueryable<Ember> AllItem()
        {
            throw new NotImplementedException();
        }

        public void Delete(Ember item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string uid)
        {
            throw new NotImplementedException();
        }

        public Ember Read(string uid)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(string oldid, Ember newitem)
        {
            throw new NotImplementedException();
        }
    }
}
