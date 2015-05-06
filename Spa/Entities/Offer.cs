using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spa.Entities
{
    public class Offer
    {
        //public Offer()
        //{
        //    Product = new Product();
        //    OfferList = new OfferList();
        //}
        public int OfferId { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int ShipPrice { get; set; }
        public Product Product { get; set; }
        public OfferList OfferList { get; set; }
    }
}