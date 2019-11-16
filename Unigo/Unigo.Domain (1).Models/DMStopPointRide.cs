using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unigo.Domail.Models
{
    public class StopPointRide
    {
        public int Id { get; set; }

        public DMRide Ride { get; set; }
        public int RideId { get; set; }
        
        public string Location { get; set; }

        public DateTime LeavingTime { get; set; }
    }
}