using Mobat.Data;
using Mobat.Data.Model;
using Mobat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mobat.Adapters.Data
{
    public class LogDataAdapter : ILogAdapter
    {
        public List<LogViewModel> GetLogViewModel(string userId, int id)
        {
            List<LogViewModel> models = null;

            using(ApplicationDbContext db = new ApplicationDbContext())
            {
               
                //models = db.Logs.Where(l => l.Game.Profile.UserId == userId).Select(m => new LogViewModel
                //{
                //    Id = m.Id,
                //    TimePlayed = m.TimePlayed,
                //    Victory =m.Victory,
                //    Comment = m.Comment,
                //}).ToList();
                models = db.Logs.Where(l => l.GameId == id).Select(m => new LogViewModel
                {
                    Id = m.Id,
                    TimePlayed = m.TimePlayed,
                    Victory = m.Victory,
                    Comment = m.Comment,
                }).ToList();
            }
            return models;
        }

        public void AddLog(LogViewModel model)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                Log dbLog = db.Logs.Create();
                dbLog.Comment = model.Comment;
                dbLog.Victory = model.Victory;
                dbLog.TimePlayed = model.TimePlayed;
                dbLog.GameId = model.GameId;
                db.Logs.Add(dbLog);
                db.SaveChanges();
            }
        }

        public void RemoveLog(int Id)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                Log Log = db.Logs.Find(Id);
                db.Logs.Remove(Log);
                db.SaveChanges();
            }
        }
    }
}