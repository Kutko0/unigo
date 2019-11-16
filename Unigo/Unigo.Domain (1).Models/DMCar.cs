using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unigo.Domail.Models
{
    public class DMCar
    {
        public int Id { get; set; }

        public string LicensePlate { get; set; }

        public string Color { get; set; }

        public string Type { get; set; }

        public int NumberOfSeats { get; set; }

        public DMPerson Rider { get; set; }
        public int RiderId { get; set; }
    }
}