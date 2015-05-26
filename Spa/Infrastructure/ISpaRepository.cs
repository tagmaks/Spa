using Spa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.OData;


namespace Spa.Data.Infrastructure
{
    public interface ISpaRepository
    {
        #region Product CRUDs
        //bool Insert(Product product);

        //IQueryable<Product> GetAllProducts();
        ////IQueryable<Product> GetProductsByOrder(int orderId);
        //Product GetProduct(int productId);

        //bool Update(Product originalProduct, Product updatedProduct);

        //bool DeleteProduct(int productId);
        #endregion

        #region Order CRUDs
        //IQueryable<Order> GetAllOrders();
        //IQueryable<dynamic> GetDetailedOrder(int orderId);
        //IQueryable<Order> GetOrdersByCustomer(int customerId);
        //Order GetOrder(int orderId);
        #endregion

        #region Customer CRUDs
        IQueryable<Customer> GetCustomers();
        SingleResult<Customer> GetCustomer(int key);
        Task<Customer> GetCustomerAsync(int key);

        Task<int> PostCustomerAsync(Customer customer);
        Task<int> PatchCustomer(int key, Delta<Customer> customer);
        //Customer GetCustomerByOrder(int orderId);

        #endregion
    }
}   