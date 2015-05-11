using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spa.Data.Entities
{
    public class Order
    {
        //public Order()
        //{
        //    //ShippingMethod = new ShippingMethod();
        //    //PaymentMethod = new PaymentMethod();
        //    OrderItems = new List<OrderItem>();
        //    Customer = new Customer();
        //}
        public int OrderId { get; set; }
        public int OrderDiscount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string CustomerComment { get; set; }
        public string AdminOrderComment { get; set; }
        public int ShippingCost { get; set; }
        //public ShippingMethod ShippingMethod { get; set; }
        //public PaymentMethod PaymentMethod { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Customer Customer { get; set; }
    }
}