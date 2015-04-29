using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spa.Entities
{
    public class OrderItem
    {
        public OrderItem()
        {
            Order = new Order();
            //OrderDelivery = new OrderDelivery();
            Product = new Product();
        }
        public int OrderItemId { get; set; }
        public int Amount { get; set; }
        public Order Order { get; set; }
        //public OrderDelivery OrderDelivery { get; set; }
        public Product Product { get; set; }

    }
}