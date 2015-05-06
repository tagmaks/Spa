using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spa.Entities
{
    public class Product
    {
        //public Product()
        //{
        //    Offers = new List<Offer>();
        //    ProductPhotos = new List<ProductPhoto>();
        //    ProductVideos = new List<ProductVideo>();
        //    Ratios = new List<Ratio>();
        //    Categories = new List<Category>();
        //}
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Enums.RatioGrade Ratio { get; set; }
        public int Discount { get; set; }
        public decimal Weight { get; set; }
        public decimal Size { get; set; }
        public bool IsFreeShipping { get; set; }
        public bool ItemSold { get; set; }
        public bool Enabled { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public bool Recomended { get; set; }
        public bool New { get; set; }
        public bool OnSale { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public ICollection<ProductPhoto> ProductPhotos { get; set; }
        public ICollection<ProductVideo> ProductVideos { get; set; }
        public ICollection<Ratio> Ratios { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}