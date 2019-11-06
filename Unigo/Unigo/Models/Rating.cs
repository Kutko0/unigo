using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Unigo.Models
{
    public class Rating
    {
        public int Id { get; set; }

        [ForeignKey("RiderId")]
        public Person Rider { get; set; }
        public int RiderId { get; set; }

        [ForeignKey("RaterId")]
        public Person Rater { get; set; }
        public int RaterId { get; set; }

        [Range(0, 5)]
        public int Stars { get; set; }
    }
}