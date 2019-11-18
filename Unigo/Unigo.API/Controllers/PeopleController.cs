using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unigo.Data;
using Unigo.Repo;

namespace Unigo.API.Controllers
{
    public class PeopleController : ApiController
    {
        
        private IRepository<Person> peopleRepository = new GenericRepo<Person>(new ApplicationDbContext());

        [HttpGet]
        public IEnumerable<Person> GetAllPeople()
        {
            return peopleRepository.GetAll();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Person person = peopleRepository.GetById(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        
        [HttpPost]
        public IHttpActionResult CreatePerson(Person person)
        {
            //Checks data annotations in model class Person
            if (!ModelState.IsValid)
                return BadRequest();

            peopleRepository.Add(person);
            peopleRepository.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + person.Id), person );
        }

        [HttpPut]
        public void UpdatePerson(int id, Person person)
        {
           
        }

        [HttpDelete]
        public void RemovePerson(int id)
        {
            if(peopleRepository.GetById(id) == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            peopleRepository.RemoveById(id);
            peopleRepository.SaveChanges();
        }
    }
}
