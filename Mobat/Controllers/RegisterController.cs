using Mobat.Adapters;
using Mobat.Adapters.Data;
using Mobat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Mobat.Controllers
{
    public class RegisterController : ApiController
    {

        private IRegisterAdapter _adapter;

        public RegisterController()
        {
            _adapter = new RegisterDataAdapter();
        }



        public IHttpActionResult Post(RegisterViewModel data)
        {
            //string userId = User.Identity.GetUserId();
            _adapter.CreateUser(data);
            return Ok();
        }




    }
}