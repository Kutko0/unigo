using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Unigo.Data
{
    public class PersonRide
    {
        public int Id { get; set; }

        [ForeignKey("RideId")]
        public virtual Ride Ride { get; set; }
        public int RideId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }

    }
}