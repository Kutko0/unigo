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

    }
}