using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unigo.Domail.Models
{
    public class DMPersonRide
    {
        public int Id { get; set; }

        public DMRide Ride { get; set; }
        public int RideId { get; set; }

        public DMPerson Person { get; set; }
        public int PersonId { get; set; }

    }
}