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

                // Ako to urobiť existingPerson= person a nie jednotlivé parametre

                existingPerson.FirstName = person.FirstName;
                existingPerson.LastName = person.LastName;
                existingPerson.Age = person.Age;
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
