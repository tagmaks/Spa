using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GenericServices.Core;
using Spa.Data.Entities;
using Spa.Data.Infrastructure;

namespace Spa.Data.Dtos
{
    public class CustomerGroupDto : EfGenericDto<CustomerGroup, CustomerGroupDto>
    {
        public int CustomerGroupId { get; set; }
        public string GroupName { get; set; }
        public int Discount { get; set; }
        public OfferList OfferList { get; set; }
        public ICollection<User> Customers { get; set; }

        protected override CrudFunctions SupportedFunctions
        {
            get { return CrudFunctions.List; }
        }
    }
}