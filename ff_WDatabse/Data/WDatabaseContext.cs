using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Models;


namespace Data
{
    public class WDatabaseContext : DbContext
    {

        public WDatabaseContext(DbContextOptions<WDatabaseContext> opt) : base(opt)
        {
        }

        public WDatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Monster>(entity =>
            {
                entity
                .HasOne(Monster => Monster.Killedby)
                .WithMany(Witcher => Witcher.Monsters_slain)
                .HasForeignKey(Monster => Monster.WitcherID)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelbuilder.Entity<Witcher>(entity =>
            {
                entity
                .HasOne(Witcher => Witcher.Friend)
                .WithMany(Human => Human.Friends)
                .HasForeignKey(Witcher => Witcher.FriendID)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelbuilder.Entity<Human>(entity =>
            {
                entity
                .HasMany(Human => Human.Friends)
                .WithOne(Witcher => Witcher.Friend)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\WDb.mdf;integrated security=True;MultipleActiveResultSets=True");
            }
        }

        public DbSet<Human> Humen { get; set; }
        public DbSet<Witcher> Witchers { get; set; }
        public DbSet<Monster> Monsters { get; set; }
    }
}
