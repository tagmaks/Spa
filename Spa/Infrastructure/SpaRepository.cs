using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using Spa.Data.Entities;
using System;

namespace Spa.Data.Infrastructure
{
    public class SpaRepository<TEntity> : ISpaRepository<TEntity> where TEntity: class 
    {
        private readonly ApplicationDbContext _db;

        public SpaRepository()
        {
            var db = new ApplicationDbContext();
            _db = db;
        }

        #region Customer CRUDs

        public bool EntityExists(int key)
        {
            return _db.Set<TEntity>().Find(key) != null;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>();
        }

        public SingleResult<TEntity> Get(Func<TEntity, bool> predicate)
        {
            var entity = _db.Set<TEntity>().Where(predicate).AsQueryable();
            
            return SingleResult.Create<TEntity>(entity);
        }

        public async Task<TEntity> GetAsync(int key)
        {
            return await _db.Set<TEntity>().FindAsync(key);
        }
            
        public async Task<int> PostAsync(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> PatchAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<int> PutAsync(TEntity update)
        {
            _db.Entry(update).State = EntityState.Modified;
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
            return await _db.SaveChangesAsync();
        }

        #endregion

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