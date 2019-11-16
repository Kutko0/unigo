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
        
        private readonly IRepository<Person> personRepo;

        // Dependency
        public TestController(IRepository<Person> personRepository)
        {
            this.personRepo = personRepository;
        }

        // GET: Test
        public ActionResult Index()
        {
            Person p = personRepo.GetById(1);
            ViewBag.CustomerName = p.FirstName + " " + p.LastName;
            return View();
        }
    }
}