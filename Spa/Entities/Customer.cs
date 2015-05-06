using Spa.Infrastructure;
using System;
using System.Collections.Generic;

namespace Spa.Entities
{
    public class Customer: ApplicationUser
    {
        //public Customer()
        //{
        //    CustomerGroup = new CustomerGroup();
        //    ApplicationUser = new ApplicationUser();
        //}
        //public int CustomerId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool SubscribedNews { get; set; }
        public CustomerGroup CustomerGroup { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Ratio> Ratios { get; set; }
    }
}