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
    public class LogController : ApiController
    {
        private ILogAdapter _adapter;

        public LogController()
        {
            _adapter = new LogDataAdapter();
        }


        [Authorize]
        public IHttpActionResult Patch(int id)
        {
            string userId = User.Identity.GetUserId();
            List<LogViewModel> model = _adapter.GetLogViewModel(userId, id);
            return Ok(model);
        }


        [Authorize]
        public IHttpActionResult Delete(int Id)
        {
            _adapter.RemoveLog(Id);
            return Ok();
        }

        public IHttpActionResult Post(LogViewModel model)
        {
            _adapter.AddLog(model);
            return Ok();
        }
    }
}
