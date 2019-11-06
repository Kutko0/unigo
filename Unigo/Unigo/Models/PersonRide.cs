using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Unigo.Models
{
    public class PersonRide
    {
        public int Id { get; set; }

        [ForeignKey("RideId")]
        public Ride Ride { get; set; }
        public int RideId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
        public int PersonId { get; set; }

    }
}