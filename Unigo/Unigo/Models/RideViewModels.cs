using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Unigo.Data;

namespace Unigo.Models
{
    public class FindRideViewModel
    {
        public List<ListHelper> Destinations { get; set; }

        [Required]
        public int DestinationId { get; set; }

        [Required]
        public DateTime LeavingTime { get; set; }

        public IEnumerable<Ride> Rides { get; set; }

        public string DestinationName { get; set; }

        public Dictionary<int, int> calcNumbers { get; set; }

        [Required(ErrorMessage = "Choose place on map.")]
        public string StartLat { get; set; }

        [Required(ErrorMessage = "Choose place on map.")]
        public string StartLng { get; set; }

        public string UrlPhoto { get; set; }

        public Dictionary<int, PartialViewForOneRide> PartialViewByRideId { get; set; }

    }

    public class PartialViewForOneRide
    {
        public Ride ride { get; set; }

        [Required]
        public int rideId { get; set; }

        public string PhotoUrl { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CarType { get; set; }

        public string LicensePLate { get; set; }

        public string DestinationName { get; set; }

        public int FreeSeats { get; set; }
    }
}