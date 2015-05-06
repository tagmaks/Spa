using Spa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spa.Infrastructure
{
    public class SpaRepository 
    {
        private ApplicationDbContext _ctx;
        public SpaRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public bool Insert(Product product)
        {
            try
            {
                _ctx.Products.Add(product);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<Product> GetAllProducts()
        {
            return _ctx.Products.AsQueryable();
        }

        //public IQueryable<Product> GetProductsByOrder(int orderId)
        //{
        //    var products = from p in _ctx.Products
        //                   join oi in _ctx.OrderItems on p.ProductId equals oi.Product.ProductId
        //                   join o in _ctx.Orders on oi.Order.OrderId equals o.OrderId
        //                   where o.OrderId == orderId
        //                   select p;
        //    return products;
        //}

        //public IQueryable<dynamic> GetDetailedOrder(int orderId)
        //{
        //    var detailedOrder = from c in _ctx.Customers
        //                        join o in _ctx.Orders on c.Id equals o.Customer.Id
        //                        join oi in _ctx.OrderItems on o.OrderId equals oi.Order.OrderId
        //                        join p in _ctx.Products on oi.Product.ProductId equals p.ProductId
        //                        where o.OrderId == orderId
        //                        select new
        //                        {
        //                            CustomerId = c.Id
        //                        };
        //    return detailedOrder;
        //}
    }
}