using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Unigo.Data
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        public string LicensePlate { get; set; }

        public string Color { get; set; }

        public string Brand { get; set; }
        
        public string Description { get; set; }

        public string Type { get; set; }

        public int NumberOfSeats { get; set; }

        public ActiveInactive Status { get; set; }

        [ForeignKey("RiderId")]
        public virtual Person Rider { get; set; }
        public int RiderId { get; set; }
    }
}