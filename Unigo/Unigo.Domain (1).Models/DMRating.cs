using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unigo.Domail.Models
{
    public class DMRating
    {
        public int Id { get; set; }

        public DMPerson Rider { get; set; }
        public int RiderId { get; set; }

        public DMPerson Rater { get; set; }
        public int RaterId { get; set; }

        public int Stars { get; set; }
    }
}