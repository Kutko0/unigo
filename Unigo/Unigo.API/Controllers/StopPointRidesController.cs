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
    public class StopPointRidesController : ApiController
    {
        public IRepository<StopPointRide> stopPointRidesRepository;

        public StopPointRidesController(IRepository<StopPointRide> stopPointRidesRepo)
        {
            this.stopPointRidesRepository = stopPointRidesRepo;
        }

        [HttpGet]
        public IList<StopPointRide> GetAll()
        {
            return stopPointRidesRepository.GetAll().ToList();
        }

        [HttpGet]
        public IHttpActionResult GetByRideId(int id)
        {
            IList<StopPointRide> stopPointRides = stopPointRidesRepository.GetAll().ToList();
            var chosenStopPointRides = from stopPointRide in stopPointRides
                                       where stopPointRide.RideId == id
                                       select stopPointRide;

            return Ok(chosenStopPointRides);
        }

        [HttpPost]
        public IHttpActionResult CreateStopPointRide(StopPointRide stopPointRide)
        {
            //Checks data annotations in model class StopPointRide
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            stopPointRidesRepository.Add(stopPointRide);
            stopPointRidesRepository.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + stopPointRide.Id), stopPointRide);
        } 

        [HttpPut]
        public IHttpActionResult UpdateStopPointRide(int id, StopPointRide stopPointRide)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");


            var existingStopPointRide = stopPointRidesRepository.GetById(id);

            if (existingStopPointRide != null)
            {
                existingStopPointRide.Location = stopPointRide.Location;
                existingStopPointRide.LeavingTime = stopPointRide.LeavingTime;

                stopPointRidesRepository.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        public void RemoveStopPointRide(int id)
        {
            if (stopPointRidesRepository.GetById(id) == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            stopPointRidesRepository.RemoveById(id);
            stopPointRidesRepository.SaveChanges();
        }


    }
}
