using Mobat.Data;
using Mobat.Data.Model;
using Mobat.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mail;

namespace Mobat.Adapters.Data
{
    public class GameDataAdapter: IGameAdapter
    {

        public List<GameViewModel> GetGameViewModel(string UserId) //This will execute when the page loads (onload)
        {
            List<GameViewModel> model = null;

            using (ApplicationDbContext db = new ApplicationDbContext()) 
            {
                model = db.Games.Where(g => g.Profile.UserId == UserId).Select(p => new GameViewModel
                {
                    Id = p.Id,
                    GameName = p.GameName,
                    GameImageUrl = p.GameImageUrl,

                }).ToList();

            }
            return model;
        }


        public void AddGameToDatabase(GameViewModel model, string userId) 
        {
         

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                    Profile dbProfile = db.Profiles.Where(p => p.UserId == userId).FirstOrDefault();

                    Game dbGame = db.Games.Create();
                    dbGame.GameName = model.GameName;
                    dbGame.GameImageUrl = model.GameImageUrl;
                    dbGame.ProfileId = dbProfile.Id;

                    db.Games.Add(dbGame);

                    db.SaveChanges();
                }

            }



        public void EditGame(GameViewModel model, string userId) 
        {
           

            using (ApplicationDbContext db = new ApplicationDbContext())
            {

              
                Game dbGames = db.Games.Where(g => g.Id == model.Id).FirstOrDefault(); 
       

                dbGames.GameName = model.GameName;
                dbGames.GameImageUrl = model.GameImageUrl;
                dbGames.Id = model.Id;
                
                db.SaveChanges(); 
  

            }
        }


        public void DeleteGame(int id) 
        {
            Game dbGame = null;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                dbGame = db.Games.Single(g => g.Id == id);
                db.Games.Remove(dbGame);

                db.SaveChanges();
            }
        }

        
    }
}