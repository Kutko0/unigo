using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unigo.Data
{
    public class RideOnMap
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("RideDescriptionId")]
        public virtual RideDescription RideDesc { get; set; }
        public int RideDescriptionId { get; set; }

        public double Start_Long { get; set; }

        public double Start_Lat { get; set; }

        public double Dest_Long { get; set; }

        public double Dest_Lat { get; set; }
    }
}
