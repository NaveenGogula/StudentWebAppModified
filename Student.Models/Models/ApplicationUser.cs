﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApp.Models.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public String? Name { get; set; }
        public String? StreetAdress { get; set; }
        public String? City { get; set; }
        public String? State { get; set; }
        public String? Postalcode { get; set; }
    }
}
