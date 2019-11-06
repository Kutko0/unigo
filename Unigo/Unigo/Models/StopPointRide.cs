using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Unigo.Models
{
    public class StopPointRide
    {
        [ForeignKey("RideId")]
        public Ride Ride { get; set; }
        public int RideId { get; set; }
        
        public string Location { get; set; }

        public DateTime LeavingTime { get; set; }
    }
}