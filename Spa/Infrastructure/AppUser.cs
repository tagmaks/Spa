using Microsoft.AspNet.Identity.EntityFramework;
using Spa.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spa.Data.Infrastructure
{
    public class AppUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }
        public Enums.Gender? Gender { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        //public ICollection<CustomUserClaim> Claims { get; set; }
    }
}