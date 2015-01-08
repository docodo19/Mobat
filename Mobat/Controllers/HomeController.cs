using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;
using Mobat.Adapters;
using Mobat.Adapters.Data;
using Mobat.Models;
using Microsoft.AspNet.Identity;

namespace Mobat.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}
