using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unigo.Data;
using Unigo.Repo;

namespace Unigo.Controllers
{
    public class TestController : Controller
    {
        

        // GET: Test
        public ActionResult Index()
        {
           
            return View();
        }
    }
}