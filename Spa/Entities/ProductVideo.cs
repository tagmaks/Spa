using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spa.Entities
{
    public class ProductVideo
    {
        //public ProductVideo()
        //{
        //    Product = new Product();
        //}
        public int ProductVideoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
    }
}