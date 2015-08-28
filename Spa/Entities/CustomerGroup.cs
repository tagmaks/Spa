using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Spa.Data.Infrastructure;

namespace Spa.Data.Entities
{
    public class CustomerGroup
    {
        public int CustomerGroupId { get; set; }
        public string GroupName { get; set; }
        public int Discount { get; set; }
        public OfferList OfferList { get; set; }
        public ICollection<User> Customers { get; set; }
    }
}
