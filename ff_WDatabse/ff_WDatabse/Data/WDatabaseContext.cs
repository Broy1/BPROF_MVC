using ff_WDatabse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ff_WDatabse.Data
{
    public class WDatabaseContext : DbContext
    {

        public WDatabaseContext(DbContextOptions<WDatabaseContext> opt) : base(opt)
        {
            
        }
      
        public DbSet<Human> Humen { get; set; }
        public DbSet<Witcher> Witchers { get; set; }
        public DbSet<Monster> Monsters { get; set; }
    }
}
