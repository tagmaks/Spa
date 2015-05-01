using Spa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spa.Infrastructure
{
    public class ISpaRepository
    {
        IQueryable<Product> GetAllProducts();
        IQueryable<Product> GetProductsByOrder(int orderId);
        Product GetProduct(int productId);

        IQueryable<Order> GetAllOrders();
        IQueryable<Order> GetOrdersByCustomer(int customerId);
        Order GetOrder(int orderId);

        IQueryable<Customer> GetAllCustomers();
        IQueryable<Customer> GetAllCustomersWithOrders();
        Customer GetCustomerByOrder(int orderId);
        Customer GetCustomer(int customerId);
        




    }
}