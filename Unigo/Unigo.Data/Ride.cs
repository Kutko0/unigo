﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Unigo.Data
{
    public class Ride
    {
        public int Id { get; set; }

        [ForeignKey("RiderId")]
        public virtual Person Rider { get; set; }
        public int RiderId { get; set; }

        [ForeignKey("DestinationId")]
        public virtual Destination Destination { get; set; }
        public int DestinationId { get; set; }

        public string StartPoint { get; set; }

        public DateTime LeavingTime { get; set; }

        public double Price { get; set; }

        public bool Active { get; set; }

        public int NumberOfSeats { get; set; }
    }
}