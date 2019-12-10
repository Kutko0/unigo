using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Unigo.Controllers
{
    public class RideController : Controller
    {
        //TODO:
            // GET and POST : Find rides by campus and time and location of user
            // POST: Join ride, stay on website, not able to join ride within 30 min, concurrency here
            // AccountController: GET ; rideshistory
            //                  : GET : My rides
            //                  : POST : Leave ride
            // Burndown chart spravit



        // GET: Ride
        public ActionResult Index()
        {
            return View();
        }
    }
}