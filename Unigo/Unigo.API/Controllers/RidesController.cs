﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unigo.Data;
using Unigo.Repo;

namespace Unigo.API.Controllers
{
    [RoutePrefix("api/rides")]
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
        [Route("ById/{id}")]
        public IHttpActionResult GetById(int id)
        {
            Ride ride = ridesRepository.GetById(id);

            if (ride == null)
                return NotFound();

            return Ok(ride);
        }

        [HttpGet]
        [Route("ByDestination/{name}")]
        public IList<Ride> GetByDestination(string name)
        {
            var rides = ridesRepository.GetAll();
            var chosenRides = from ride in rides
                              where ride.Destination.Name.Contains(name)
                              select ride;


            return chosenRides.ToList();
        }

        [HttpGet]
        [Route("ByActiveStatus/{status}")]
        public IList<Ride> GetByActiveStatus(int status)
        {
            var rides = ridesRepository.GetAll();
            var chosenRides = from ride in rides
                              where ride.Status == status
                              select ride;


            return chosenRides.ToList();
        }

        [HttpGet]
        [Route("GetActiveRides")]
        public IList<Ride> GetActiveRides()
        {
            var rides = ridesRepository.GetAll();
            var chosenRides = from ride in rides
                              where ride.Status == 1
                              select ride;


            return chosenRides.ToList();
        }

        [HttpGet]
        [Route("GetActiveRides/{name}")]
        public IList<Ride> GetActiveRidesByDestination(string name)
        {
            var rides = ridesRepository.GetAll();
            var chosenRides = from ride in rides
                              where ride.Destination.Name.Contains(name) && ride.Status == 1
                              select ride;


            return chosenRides.ToList();
        }


        [HttpGet]
        [Route("GetInactiveRides")]
        public IList<Ride> GetInactiveRides()
        {
            var rides = ridesRepository.GetAll();
            var chosenRides = from ride in rides
                              where ride.Status == 0
                              select ride;


            return chosenRides.ToList();
        }

        [HttpGet]
        [Route("GetInactiveRides/{name}")]
        public IList<Ride> GetInactiveRidesByDestination(string name)
        {
            var rides = ridesRepository.GetAll();
            var chosenRides = from ride in rides
                              where ride.Destination.Name.Contains(name) && ride.Status == 0
                              select ride;


            return chosenRides.ToList();
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
                existingRide.Status = ride.Status;

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
