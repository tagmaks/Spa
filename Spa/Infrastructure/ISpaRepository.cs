using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using Spa.Data.Entities;

namespace Spa.Data.Infrastructure
{
    public interface ISpaRepository
    {
        #region Customer CRUDs
        bool CustomerExists(int key);
        IQueryable<Customer> GetCustomers();
        SingleResult<Customer> GetCustomer(int key);
        Task<Customer> GetCustomerAsync(int key);
        Task<int> PostCustomerAsync(Customer customer);
        Task<int> PatchCustomerAsync(Delta<Customer> patch, Customer origin);
        Task<int> PutCustomerAsync(Customer update);
        Task<int> DeleteCustomerAsync(Customer customer);

        #endregion
    }
}   