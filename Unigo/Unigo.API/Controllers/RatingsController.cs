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
    public class RatingsController : ApiController
    {
        public IRepository<Rating> ratingsRepository;
        public RatingsController(IRepository<Rating> ratingsRepo)
        {
            this.ratingsRepository = ratingsRepo;
        }

        [HttpGet]
        public IList<Rating> GetAll()
        {
            return ratingsRepository.GetAll().ToList();
        }

        [HttpGet]
        public IList<Rating> GetByRider(int id)
        {
            IList<Rating> ratings = ratingsRepository.GetAll().ToList();
            var chosenRatings = from rating in ratings
                                where rating.RiderId == id
                                select rating;

            return chosenRatings.ToList();  
        }

        [HttpPut]
        public IHttpActionResult UpdateRating(int id, Rating rating)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var existingRating = ratingsRepository.GetById(id);

            if(existingRating != null)
            {
                existingRating.Stars = rating.Stars;
                ratingsRepository.SaveChanges();
            } 
            else
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult CreateRating(Rating rating)
        {
            //Checks data annotations in model class Person
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            ratingsRepository.Add(rating);
            ratingsRepository.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + rating.Id), rating);
        }

        [HttpDelete]
        public void RemoveRating(int id)
        {
            if(ratingsRepository.GetById(id) == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            ratingsRepository.RemoveById(id);
            ratingsRepository.SaveChanges();
        }

    }
}
