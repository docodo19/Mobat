using Mobat.Data;
using Mobat.Data.Model;
using Mobat.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mobat.Adapters.Data
{
    public class ProfileDataAdapter : IProfileAdapter
    {
        public ProfileViewModel GetProfileViewModel(string userId)
        {

            ProfileViewModel model = null;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Profiles.Where(p => p.UserId == userId).Select(p => new ProfileViewModel
                {

                    Id = p.Id,
                    UserName = p.User.UserName,
                    Email = p.User.Email,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    AvatarUrl = p.AvatarUrl,
                }).FirstOrDefault();

            }
            return model;
        }



        public void UpdateProfileViewModel(ProfileViewModel data, string userId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            ApplicationUser dbUser = db.Users.Find(userId);

            dbUser.Email = data.Email;

            Profile dbProfile = db.Profiles.Where(p => p.UserId == userId).FirstOrDefault();

            dbProfile.FirstName = data.FirstName;
            dbProfile.LastName = data.LastName;
            dbProfile.AvatarUrl = data.AvatarUrl;

            db.SaveChanges();
            

           

        }
    }
}