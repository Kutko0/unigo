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
    [RoutePrefix("api/people")]
    public class PeopleController : ApiController
    {

        public IRepository<Person> peopleRepository;

        public PeopleController(IRepository<Person> peopleRepo)
        {
            this.peopleRepository = peopleRepo;
        }


        [HttpGet]
        public IEnumerable<Person> GetAllPeople()
        {
            return peopleRepository.GetAll();
        }

        [HttpGet]
        [Route("ById/{id}")]
        public IHttpActionResult GetById(int id)
        {
            Person person = peopleRepository.GetById(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpGet]
        [Route("ByName/{name}")]
        public IEnumerable<Person> GetByName(string name)
        {
            var people = peopleRepository.GetAll();
            var chosenPeople = from person in people
                               where person.FirstName.Contains(name) || person.LastName.Contains(name)
                               select person;


            return chosenPeople;
        }


        [HttpPost]
        public IHttpActionResult CreatePerson(Person person)
        {
            //Checks data annotations in model class Person
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            peopleRepository.Add(person);
            peopleRepository.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + person.Id), person );
        }

        
        [HttpPut]
        public IHttpActionResult UpdatePerson(int id, Person person)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");


            var existingPerson = peopleRepository.GetById(id);

            if (existingPerson != null)
            {

                
                existingPerson.FirstName = person.FirstName;
                existingPerson.LastName = person.LastName;
                existingPerson.DateOfBirth = person.DateOfBirth;
                existingPerson.PhoneNumber = person.PhoneNumber;
                existingPerson.Email = person.Email;
                
                peopleRepository.SaveChanges();
             }
             else
             {
                    return NotFound();
             }
            
            return Ok();
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
