using Mobat.Adapters;
using Mobat.Adapters.Data;
using Mobat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace Mobat.Controllers
{
    public class GameController : ApiController
    {
        private IGameAdapter _adapter;


        public GameController()
        {
            _adapter = new GameDataAdapter();
        }


        public IHttpActionResult Get()
        {
            string userId = User.Identity.GetUserId();
            List<GameViewModel> model = _adapter.GetGameViewModel(userId);
            return Ok(model);
        }


        public IHttpActionResult Post(GameViewModel model)
        {
            string userId = User.Identity.GetUserId();
            _adapter.AddGameToDatabase(model, userId);

            return Ok();
        }

        public IHttpActionResult Put(GameViewModel model)
        {   
            string userId = User.Identity.GetUserId();
            _adapter.EditGame(model, userId);

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            string userId = User.Identity.GetUserId();
            _adapter.DeleteGame(id);

            return Ok();
        }

            
    }
}
