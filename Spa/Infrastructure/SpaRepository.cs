using Spa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Spa.Data.Infrastructure
{
    public class SpaRepository 
    {
        private ApplicationDbContext _db;
        public SpaRepository()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            _db = db;
        }

        public IQueryable<Customer> GetCustomers()
        {
            return _db.Customers;
        }
        public IQueryable<Customer> GetCustomer(int key)
        {
            return _db.Customers.AsQueryable().Where(c => c.Id == key);
        }
        public IQueryable<CustomerGroup> GetAllCustomerGroups()
        {
            return _db.CustomerGroups.AsQueryable();
        }

        public CustomerGroup GetCustomerGroup(int key)
        {
            return _db.CustomerGroups.Find(key);
        }

        //public bool Insert(Product product)
        //{
        //    try
        //    {
        //        _db.Products.Add(product);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public IQueryable<Product> GetAllProducts()
        //{
        //    return _db.Products.AsQueryable();
        //}

        //public IQueryable<Product> GetProductsByOrder(int orderId)
        //{
        //    var products = from p in _db.Products
        //                   join oi in _db.OrderItems on p.ProductId equals oi.Product.ProductId
        //                   join o in _db.Orders on oi.Order.OrderId equals o.OrderId
        //                   where o.OrderId == orderId
        //                   select p;
        //    return products;
        //}

        //public IQueryable<dynamic> GetDetailedOrder(int orderId)
        //{
        //    var detailedOrder = from c in _db.Customers
        //                        join o in _db.Orders on c.Id equals o.Customer.Id
        //                        join oi in _db.OrderItems on o.OrderId equals oi.Order.OrderId
        //                        join p in _db.Products on oi.Product.ProductId equals p.ProductId
        //                        where o.OrderId == orderId
        //                        select new
        //                        {
        //                            CustomerId = c.Id
        //                        };
        //    return detailedOrder;
        //}
    }
}