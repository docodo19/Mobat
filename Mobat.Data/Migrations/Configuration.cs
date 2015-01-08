namespace Mobat.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Mobat.Data.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Mobat.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Mobat.Data.ApplicationDbContext context)
        {
            //seeder settings
            bool seedUser = true;
            bool seedProfile = true;
            bool seedGame = true;
            bool seedLog = true;

            //seeder
            if (seedUser) UserSeeder(context);
            if (seedProfile) ProfileSeeder(context);
            if (seedGame) GameSeeder(context);
            if (seedLog) LogSeeder(context);
        }

        //seeder methods
        private void UserSeeder(ApplicationDbContext db)
        {
            UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(db);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(store);

            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(db);
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!roleManager.RoleExists("Admin")) roleManager.Create(new IdentityRole { Name = "Admin" });
            if (!roleManager.RoleExists("User")) roleManager.Create(new IdentityRole { Name = "User" });

            if (!db.Users.Any(u => u.UserName == "VAULT14"))
            {
                ApplicationUser User = new ApplicationUser { UserName = "VAULT14", Email = "docodo19@gmail.com" };
                userManager.Create(User, "123123");
                userManager.AddToRole(User.Id, "Admin");
            }

            if (!db.Users.Any(u => u.UserName == "Justintime2kill"))
            {
                ApplicationUser User = new ApplicationUser { UserName = "JustinTime2kill", Email = "mckenney85@gmail.com" };
                userManager.Create(User, "131313");
                userManager.AddToRole(User.Id, "Admin");
            }

            if (!db.Users.Any(u => u.UserName == "technicallyWilliams"))
            {
                ApplicationUser User = new ApplicationUser { UserName = "technicallyWilliams", Email = "dexterwilliams04@gmail.com" };
                userManager.Create(User, "415415");
                userManager.AddToRole(User.Id, "Admin");
            }

        }

        // Profile Seeder
        private void ProfileSeeder(ApplicationDbContext db)
        {
            db.Profiles.AddOrUpdate(p => p.UserId,
                 new Profile
                 {
                     FirstName = "Dan",
                     LastName = "Do",
                     AvatarUrl = "http://backup.datasolved.com/user/cimage/steel_bank_vault-200605-SM.jpg",
                     UserId = db.Users.Where(u => u.Email == "docodo19@gmail.com").FirstOrDefault().Id,
                 });

            db.Profiles.AddOrUpdate(p => p.UserId,
                new Profile
                {
                    FirstName = "Justin",
                    LastName = "Mckenney",
                    AvatarUrl = "http://backup.datasolved.com/user/cimage/steel_bank_vault-200605-SM.jpg",
                    UserId = db.Users.Where(u => u.Email == "mckenney85@gmail.com").FirstOrDefault().Id
                });

            db.Profiles.AddOrUpdate(p => p.UserId,
                new Profile
                {
                    FirstName = "Dexter",
                    LastName = "Williams",
                    AvatarUrl = "http://backup.datasolved.com/user/cimage/steel_bank_vault-200605-SM.jpg",
                    UserId = db.Users.Where(u => u.Email == "dexterwilliams04@gmail.com").FirstOrDefault().Id
                });
            db.SaveChanges();
        }

        // Game Seeder
        private void GameSeeder(ApplicationDbContext db)
        {
            db.Games.AddOrUpdate(g => g.ProfileId,
           new Game
           {
               GameName = "League of Legends",
               GameImageUrl = "http://8bitchimp.com/wp-content/uploads/2014/10/league.png",
               ProfileId = 1
           });

            db.Games.AddOrUpdate(g => g.ProfileId,
           new Game
           {
               GameName = "Smite",
               GameImageUrl = "http://gamerfitnation.com/wp-content/uploads/2014/07/smite1.jpg",
               ProfileId = 1
           });

            db.SaveChanges();
        }

        // Log Seeder
        private void LogSeeder(ApplicationDbContext db)
        {
            db.Logs.AddOrUpdate(l => l.GameId,
            new Log
            {
                Victory = true,
                TimePlayed = 30,
                Comment = "Initial Comment",
                GameId = 1
            });

            db.Logs.AddOrUpdate(l => l.GameId,
            new Log
            {
                Victory = false,
                TimePlayed = 60,
                Comment = "Second Comment",
                GameId = 1
            });
            db.SaveChanges();
        }
    }
}
