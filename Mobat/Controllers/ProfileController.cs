using Mobat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Mobat.Adapters;
using Mobat.Adapters.Data;

namespace Mobat.Controllers
{
    public class ProfileController : ApiController
    {
        private IProfileAdapter _adapter;

        public ProfileController()
        {
            _adapter = new ProfileDataAdapter();
        }


        // GET for ProvileViewModel
        //[Authorize]
        public IHttpActionResult Get()
        {
            string userId = User.Identity.GetUserId();
            ProfileViewModel model = _adapter.GetProfileViewModel(userId);
            return Ok(model);
        }


        public IHttpActionResult Put(ProfileViewModel data)
        {
            string userId = User.Identity.GetUserId();
            _adapter.UpdateProfileViewModel(data, userId);
            return Ok();
        }
    }
}