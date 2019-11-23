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
    public class DestinationsController : ApiController
    {
        public IRepository<Destination> destinationsRepository;

        public DestinationsController(IRepository<Destination> destinationsRepo)
        {
            this.destinationsRepository = destinationsRepo;
        }

        [HttpGet]
        public IEnumerable<Destination> GetAllDestinations()
        {
            return destinationsRepository.GetAll();
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            Destination destination = destinationsRepository.GetById(id);

            if (destination == null)
                return NotFound();

            return Ok(destination);
        }

        [HttpPost] 
        public IHttpActionResult CreateDestination(Destination destination)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            destinationsRepository.Add(destination);
            destinationsRepository.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + destination.Id), destination);
        }

        [HttpPut]
        public IHttpActionResult UpdateDestination(int id, Destination destination)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");


            var existingDestination = destinationsRepository.GetById(id);

            if (existingDestination != null)
            {
                existingDestination.Name = destination.Name;

                destinationsRepository.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        public void RemoveDestination(int id)
        {
            if (destinationsRepository.GetById(id) == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            destinationsRepository.RemoveById(id);
            destinationsRepository.SaveChanges();
        }

    }
}
