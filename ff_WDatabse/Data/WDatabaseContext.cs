using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Data
{
    public class WDatabaseContext : IdentityDbContext<IdentityUser>
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

            modelbuilder.Entity<IdentityRole>().HasData(
                new { Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "341743f0-dee2–42de-bbbb-59kmkkmk72cf6", Name = "Customer", NormalizedName = "CUSTOMER" }
            );

            var appUser = new IdentityUser
            {
                Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                Email = "somebody@nik.uni-obuda.hu",
                NormalizedEmail = "somebody@nik.uni-obuda.hu",
                EmailConfirmed = true,
                UserName = "somebody@nik.uni-obuda.hu",
                NormalizedUserName = "somebody@nik.uni-obuda.hu",
                SecurityStamp = string.Empty
            };

            var appUser2 = new IdentityUser
            {
                Id = "p2174cf0–9412–4cfe-afbf-59f706d72cf6",
                Email = "somebody2@nik.uni-obuda.hu",
                NormalizedEmail = "somebody2@nik.uni-obuda.hu",
                EmailConfirmed = true,
                UserName = "somebody2@nik.uni-obuda.hu",
                NormalizedUserName = "somebody2@nik.uni-obuda.hu",
                SecurityStamp = string.Empty
            };

            appUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Almafa123!");
            appUser2.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Almafa123!");


            modelbuilder.Entity<IdentityUser>().HasData(appUser);
            modelbuilder.Entity<IdentityUser>().HasData(appUser2);

            modelbuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                UserId = "02174cf0–9412–4cfe-afbf-59f706d72cf6"
            });

            modelbuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "341743f0-dee2–42de-bbbb-59kmkkmk72cf6",
                UserId = "p2174cf0–9412–4cfe-afbf-59f706d72cf6"
            });

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
                    //UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\WDb.mdf;integrated security=True;MultipleActiveResultSets=True");
                    UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MonsterDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            }
        }

        public DbSet<Human> Humen { get; set; }
        public DbSet<Witcher> Witchers { get; set; }
        public DbSet<Monster> Monsters { get; set; }
    }
}
