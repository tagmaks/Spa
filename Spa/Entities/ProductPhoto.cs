using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spa.Entities
{
    public class ProductPhoto
    {
        public ProductPhoto()
        {
            Product = new Product();
        }
        public int ProductPhotoId { get; set; }
        public string PhotoName { get; set; }
        public string Description { get; set; }
        public bool Main { get; set; }
        public string OriginName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Product Product { get; set; }
    }
}