using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unigo.Domail.Models
{
    public class DMRide
    {
        public int Id { get; set; }

        public DMPerson Rider { get; set; }
        public int RiderId { get; set; }

        public DMDestination Destination { get; set; }
        public int DestinationId { get; set; }

        public string StartPoint { get; set; }

        public DateTime LeavingTime { get; set; }

        public double Price { get; set; }

        public bool Active { get; set; }

        public int NumberOfSeats { get; set; }
    }
}