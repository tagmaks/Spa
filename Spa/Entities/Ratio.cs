using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spa.Data.Infrastructure;

namespace Spa.Data.Entities
{
    public class Ratio
    {
        //public Ratio()
        //{
        //    Product = new Product();
        //    Customer = new Customer();
        //}
        public int RatioId { get; set; }
        public Enums.RatioGrade ProductRatio { get; set; }
        public DateTime AddDate { get; set; }
        public Product Product { get; set; }
        public User Customer { get; set; }
    }
}