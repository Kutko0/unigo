using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unigo.Data
{
    public class RideDescription
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("DriverId")]
        public Person Driver { get; set; }
        public int DriverId { get; set; }

        public string Description { get; set; }

    }
}
