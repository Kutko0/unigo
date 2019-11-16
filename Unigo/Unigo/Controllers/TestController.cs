﻿using System;
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
        private readonly IRepository<Person> personRepo;


        public TestController(IRepository<Person> personRepository)
        {
            this.personRepo = personRepository;
        }

        public ActionResult Index()
        {
            Person p = personRepo.GetById(1);
            ViewBag.CustomerName = p.FirstName + " " + p.LastName;
            return View();
        }
    }
}