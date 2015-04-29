using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spa.Entities
{
    public class CustomerGroup
    {
        public CustomerGroup()
        {
            CustomerGroupOfferList = new OfferList();
            Customers = new List<Customer>();
        }
        public int CustomerGroupId { get; set; }
        public string GroupName { get; set; }
        public int Discount { get; set; }
        public OfferList CustomerGroupOfferList { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
