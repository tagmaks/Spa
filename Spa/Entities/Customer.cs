using Spa.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Spa.Data.Entities
{
    public class Customer: AppUser
    {
        //public Customer()
        //{
        //    CustomerGroup = new CustomerGroup();
        //    ApplicationUser = new ApplicationUser();
        //}
        //public int CustomerId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool SubscribedNews { get; set; }
        [Required]
        public CustomerGroup CustomerGroup { get; set; }
        //public AppUser ApplicationUser { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Ratio> Ratios { get; set; }
    }
}