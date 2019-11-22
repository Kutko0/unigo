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
    [RoutePrefix("api/personRides")]
    public class PersonRidesController : ApiController
    {
        public IRepository<PersonRide> personRidesRepository;

        public PersonRidesController(IRepository<PersonRide> personRidesRepo)
        {
            this.personRidesRepository = personRidesRepo;
        }

        [HttpGet]
        
        public IList<PersonRide> GetAllPersonRide()
        {
            return personRidesRepository.GetAll().ToList();
        }

        [HttpGet]
        [Route("ByRideId/{id}")]
        public IHttpActionResult GetByRideId(int id)
        {
            IList<PersonRide> personRides = personRidesRepository.GetAll().ToList();
            var chosenPersonRides = from personRide in personRides
                                    where personRide.RideId == id
                                    select personRide;

            return Ok(chosenPersonRides);
        }

        [HttpGet]
        [Route("ByPersonId/{id}")]
        public IHttpActionResult GetByPersonId(int id)
        {
            IList<PersonRide> personRides = personRidesRepository.GetAll().ToList();
            var chosenPersonRides = from personRide in personRides
                                    where personRide.PersonId == id
                                    select personRide;

            return Ok(chosenPersonRides);
        }

        [HttpPost]
       public IHttpActionResult CreatePersonRide(PersonRide personRide)
        {
            //Checks data annotations in model class PersonRide
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            personRidesRepository.Add(personRide);
            personRidesRepository.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + personRide.Id), personRide);
        }

        [HttpDelete]
        public void RemovePersonRide(int id)
        {
            if (personRidesRepository.GetById(id) == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            personRidesRepository.RemoveById(id);
            personRidesRepository.SaveChanges();
        }
    }
}
