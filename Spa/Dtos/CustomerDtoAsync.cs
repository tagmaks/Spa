using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GenericServices.Core;
using Spa.Data.Entities;

namespace Spa.Data.Dtos
{
    public class CustomerDtoAsync : EfGenericDtoAsync<Customer, CustomerDtoAsync>
    {
        public DateTime? DateOfBirth { get; set; }
        public bool SubscribedNews { get; set; }
        [Required]
        public CustomerGroup CustomerGroup { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Ratio> Ratios { get; set; }

        protected override CrudFunctions SupportedFunctions
        {
            get { return CrudFunctions.List; }
        }
    }
}