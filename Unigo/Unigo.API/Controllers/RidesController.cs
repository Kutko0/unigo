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
    public class RidesController : ApiController
    {
        public IRepository<Ride> ridesRepository;

        public RidesController(IRepository<Ride> ridesRepo)
        {
            this.ridesRepository = ridesRepo;
        }

        [HttpGet]
        public IList<Ride> GetAll()
        {
            return ridesRepository.GetAll().ToList();
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            Ride ride = ridesRepository.GetById(id);

            if (ride == null)
                return NotFound();

            return Ok(ride);
        }

        [HttpPost]
        public IHttpActionResult CreateRide(Ride ride)
        {
            //Checks data annotations in model class Ride
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            ridesRepository.Add(ride);
            ridesRepository.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + ride.Id), ride);
        }

        [HttpPut]
        public IHttpActionResult UpdateRide(int id, Ride ride)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");


            var existingRide = ridesRepository.GetById(id);

            if (existingRide != null)
            {

                existingRide.NumberOfSeats = ride.NumberOfSeats;
                existingRide.Price = ride.Price;
                existingRide.LeavingTime = ride.LeavingTime;
                existingRide.Active = ride.Active;

                ridesRepository.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        public void RemoveRide(int id)
        {
            if (ridesRepository.GetById(id) == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            ridesRepository.RemoveById(id);
            ridesRepository.SaveChanges();
        }
    }
}
