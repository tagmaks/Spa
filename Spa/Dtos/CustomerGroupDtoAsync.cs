using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GenericServices.Core;
using Spa.Data.Entities;

namespace Spa.Data.Dtos
{
    public class CustomerGroupDtoAsync : EfGenericDtoAsync<CustomerGroup, CustomerGroupDtoAsync>
    {
        public int CustomerGroupId { get; set; }
        public string GroupName { get; set; }
        public int Discount { get; set; }
        public OfferList OfferList { get; set; }
        public ICollection<Customer> Customers { get; set; }

        protected override CrudFunctions SupportedFunctions
        {
            get { return CrudFunctions.List; }
        }
    }
}