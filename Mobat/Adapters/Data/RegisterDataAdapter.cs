using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mobat.Data;
using Mobat.Data.Model;
using Mobat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mobat.Adapters.Data
{
    public class RegisterDataAdapter : IRegisterAdapter
    {
        public void CreateUser(RegisterViewModel data)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(db);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(store);

            if (!db.Users.Any(u => u.UserName == data.UserName && u.Email == data.Email))
            {
                ApplicationUser User = new ApplicationUser { UserName = data.UserName, Email = data.Email };
                userManager.Create(User, data.Password);
                userManager.AddToRole(User.Id, "User");

                db.Profiles.Add(
                    new Profile
                    {
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                        AvatarUrl = data.AvatarUrl,
                        UserId = db.Users.Where(u => u.Email == data.Email).FirstOrDefault().Id,
                    });
                db.SaveChanges();
            }
        }
    }
}