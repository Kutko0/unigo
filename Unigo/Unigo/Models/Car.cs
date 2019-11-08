using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Unigo.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        public string LicensePlate { get; set; }

        public string Color { get; set; }

        public string Type { get; set; }

        public int NumberOfSeats { get; set; }

        [ForeignKey("RiderId")]
        public virtual Person Rider { get; set; }
        public int RiderId { get; set; }
    }
}