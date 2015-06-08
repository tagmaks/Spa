using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Spa.Data.Entities
{
    public class CustomerGroup
    {
        //public CustomerGroup()
        //{
        //    //CustomerGroupOfferList = new OfferList();
        //    Customers = new List<Customer>();
        //}
        public int CustomerGroupId { get; set; }
        public string GroupName { get; set; }
        [ConcurrencyCheck]
        public int Discount { get; set; }
        public OfferList OfferList { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
