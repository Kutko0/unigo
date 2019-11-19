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
    public class CarsController : ApiController
    {
        public IRepository<Car> carsRepository;

        public CarsController(IRepository<Car> carsRepo)
        {
            this.carsRepository = carsRepo;
        }


        [HttpGet]
        public IList<Car> GetAllPeople()
        {
            
            return carsRepository.GetAll().ToList();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Car car = carsRepository.GetById(id);

            if (car == null)
                return NotFound();

            return Ok(car);
        }

        [HttpPost]
        public IHttpActionResult CreateCar(Car car)
        {
            //Checks data annotations in model class Car
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            carsRepository.Add(car);
            carsRepository.SaveChanges();
                           
            return Created(new Uri(Request.RequestUri + "/" + car.Id), car);
        }

        [HttpPut]
        public IHttpActionResult UpdateCar(int id, Car car)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");


            var existingCar = carsRepository.GetById(id);

            if (existingCar != null)
            {


                existingCar.NumberOfSeats = car.NumberOfSeats;
                existingCar.Type = car.Type;
                existingCar.Color = car.Color;

                carsRepository.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        public void RemoveCar(int id)
        {
            if (carsRepository.GetById(id) == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            carsRepository.RemoveById(id);
            carsRepository.SaveChanges();
        }
    }
}
