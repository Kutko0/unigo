﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Unigo.Data
{
    public class Person
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
     }
}