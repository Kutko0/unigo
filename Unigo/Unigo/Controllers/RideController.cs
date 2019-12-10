using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Unigo.Data;
using Unigo.Models;
using Unigo.Repo;

namespace Unigo.Controllers
{
    public class RideController : Controller
    {

        private IRepository<Destination> destRepo;
        private IRepository<Person> peopleRepo;
        private IRepository<Ride> rideRepo;
        private IRepository<Car> carRepo;
        private IRepository<PersonRide> personRideRepo;


        public RideController(IRepository<Destination> destRepo, IRepository<Person> people,
            IRepository<PersonRide> peopleRide, IRepository<Ride> ride, IRepository<Car> car)
        {
            this.destRepo = destRepo;
            this.peopleRepo = people;
            this.personRideRepo = peopleRide;
            this.rideRepo = ride;
            this.carRepo = car;
        }



        //TODO:
        // GET and POST : Find rides by campus and time and location of user ---DONE
        // POST: Join ride, stay on website, not able to join ride within 30 min, concurrency here
        // AccountController: GET ; rideshistory
        //                  : GET : My rides
        //                  : POST : Leave ride
        // Burndown chart spravit



        // GET: Find
        public ActionResult Find()
        {

            FindRideViewModel frvm = new FindRideViewModel
            {
                Destinations = GetListOfDestination(),
                Rides = new List<Ride>()
            };


            return View(frvm);
        }


        private List<ListHelper> GetListOfDestination()
        {
            IEnumerable<Destination> dests = destRepo.GetAll().ToList();
            var selectList = new List<ListHelper>();

            foreach (var dest in dests)
            {
                var newItem = new ListHelper
                {
                    Id = dest.Id,
                    Name = dest.Name

                };
                selectList.Add(newItem);

            }

            return selectList;
        }


        // POST: /Ride/Find
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(FindRideViewModel model)
        {
            FindRideViewModel frvm = new FindRideViewModel();
            frvm.Destinations = GetListOfDestination();
            frvm.UrlPhoto = "https://i.kym-cdn.com/entries/icons/medium/000/029/043/Shaq_Tries_to_Not_Make_a_Face_While_Eating_Spicy_Wings___Hot_Ones_11-21_screenshot.png";
            frvm.PartialViewByRideId = new Dictionary<int, PartialViewForOneRide>();

            if (!ModelState.IsValid)
            {
                FindRideViewModel frvmn = new FindRideViewModel
                {
                    Destinations = GetListOfDestination(),
                    Rides = new List<Ride>()
                };
                
                return View(frvmn);
            }

            double startLat = double.Parse(model.StartLat, System.Globalization.CultureInfo.InvariantCulture);
            double startLng = double.Parse(model.StartLng, System.Globalization.CultureInfo.InvariantCulture);

            foreach (var dest in frvm.Destinations)
            {
                if (dest.Id == model.DestinationId)
                {
                    frvm.DestinationName = dest.Name;
                    break;
                }
            }

            if (!Regex.Match(Request["datetimefield"], @"^([0]\d|[1][0-2])\/([0-2]\d|[3][0-1])\/([2][01]|[1][6-9])\d{2}(\s([0-1]\d|[2][0-3])(\:[0-5]\d){1,2})?$").Success)
            {
                ModelState.AddModelError("Leaqving Time", "Enter correct date format.");
                return View(model);
            }

            DateTime myDate = DateTime.ParseExact(Request["datetimefield"], "MM/dd/yyyy HH:mm",
                                       System.Globalization.CultureInfo.InvariantCulture);
            long myDateTicks = myDate.Ticks;

            List<Ride> rides = new List<Ride>();
            List<Ride> data = rideRepo.GetAll().Where(m => m.Status == 1).Where(m => m.DateTicks < myDateTicks)
                .Where(m => m.DestinationId == model.DestinationId).OrderByDescending(m => m.LeavingTime).ToList();
            Dictionary<Ride, double> calcByDistanceFromStart = new Dictionary<Ride, double>();
            int compareNumber;
            List<PersonRide> pr = personRideRepo.GetAll().ToList();
            List<Car> cars = carRepo.GetAll().ToList();
            



            foreach (Ride ride in data)
            {
                compareNumber = pr.Where(m => m.Ride.Id == ride.Id).ToList().Count();
                if (ride.NumberOfSeats > compareNumber)
                {
                    calcByDistanceFromStart.Add(ride, DistanceAlgorithm.DistanceBetweenPlaces(startLng, startLat, ride.StartLat, ride.StartLong));

                    // Getting car for ride
                    string Plate = cars.Where(m => m.RiderId == ride.RiderId).FirstOrDefault().LicensePlate;
                    string BrandType = cars.Where(m => m.RiderId == ride.RiderId).Where(m => m.Status == 1).FirstOrDefault().Brand;

                    Person p = peopleRepo.GetById(ride.RiderId);
                    string first = p.FirstName;
                    string Last = p.LastName;

                    frvm.PartialViewByRideId.Add(ride.Id, new PartialViewForOneRide
                    {
                        FirstName = first,
                        LastName = Last,
                        ride = ride,
                        CarType = BrandType,
                        LicensePLate = Plate,
                        DestinationName = frvm.DestinationName,
                        PhotoUrl = frvm.UrlPhoto
                    });
                    
                }
            }

            foreach (var item in calcByDistanceFromStart.OrderByDescending(key => key.Value))
            {
                rides.Add(item.Key);
            }


            frvm.calcNumbers = GetCalculatedFreeSeatsByNumberId(rides);
            frvm.Rides = rides;
            
            
            

            

                return View(frvm);
        }

        private Dictionary<int,int> GetCalculatedFreeSeatsByNumberId(IEnumerable<Ride> rides)
        {
            Dictionary<int, int> returnDic = new Dictionary<int, int>();

            foreach(var ride in rides)
            {
                int peopleOnRide = personRideRepo.GetAll().Where(m => m.RideId == ride.Id).Count();
                int calculated = ride.NumberOfSeats - peopleOnRide;

                returnDic.Add(ride.Id, calculated);
            }

            return returnDic;
        }

    }


    // Help classes
    // ------------

    // Source from : https://stackoverflow.com/questions/1502590/calculate-distance-between-two-points-in-google-maps-v3
    public class DistanceAlgorithm
    {
        const double PIx = 3.141592653589793;
        const double RADIO = 6378.16;

       
        private DistanceAlgorithm() { }
      
        public static double Radians(double x)
        {
            return x * PIx / 180;
        }

        public static double DistanceBetweenPlaces(
            double lon1,
            double lat1,
            double lon2,
            double lat2)
        {
            double dlon = Radians(lon2 - lon1);
            double dlat = Radians(lat2 - lat1);

            double a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + Math.Cos(Radians(lat1)) * Math.Cos(Radians(lat2)) * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
            double angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return (angle * RADIO) * 0.62137; //distance in miles
        }

    }

    public class GFG : IComparer<double>
    {
        public int Compare(double x, double y)
        {
            if (x == 0 || y == 0)
            {
                return 0;
            }

            // CompareTo() method 
            return x.CompareTo(y);

        }
    }
}