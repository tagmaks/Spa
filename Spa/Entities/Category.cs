using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spa.Entities
{
    public class Category
    {
        //public Category()
        //{
        //    Products = new List<Product>();
        //}
        public int CategoryId { get; set; }
        public string Name { get; set; }
        //public string ParentCategory { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string MiniPicture { get; set; }
        //public int ProductsCount { get; set; }
        public bool Enabled { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}