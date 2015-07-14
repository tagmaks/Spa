using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;
using GenericLibsBase;
using GenericServices;
using GenericServices.Core;
using GenericServices.Services;
using GenericServices.ServicesAsync;

namespace Spa.Data.Infrastructure
{
    public class SpaRepository<TEntity, TDto> : ISpaRepository<TEntity,TDto> 
        where TEntity : class, new()
        where TDto : EfGenericDto<TEntity, TDto>, new()
    {
        private readonly IGenericServicesDbContext _db;

        public SpaRepository(IGenericServicesDbContext context)
        {
            _db = context;
        }


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

            return SingleResult.Create(entity);
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
            //_db.Entry(update).State = EntityState.Modified;
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
            return await _db.SaveChangesAsync();
        }

        public IListService<TEntity> ListService { get; set; }
        public IDetailServiceAsync<TEntity> DetailServiceAsync { get; set; }
        public IDetailService<TEntity> DetailService { get; set; }
        public ICreateServiceAsync<TEntity> CreateServiceAsync { get; set; }
        public IUpdateServiceAsync<TEntity> UpdateServiceAsync { get; set; }
        public IUpdateService<TEntity> UpdateService { get; set; }


        //Using GenericService services

        public IQueryable<TEntity> GetAll2()
        {
            return ListService.GetAll();
        }
        public async Task<ISuccessOrErrors<TEntity>> GetAsync2(int key)
        {
            var keys = new ArrayList {key};
            return await DetailServiceAsync.GetDetailAsync(key);
        }
        public ISuccessOrErrors<TEntity> Get2(int key)
        {
            return DetailService.GetDetail(key);
        }

        public Task<ISuccessOrErrors<TDto>> Get2(Expression<Func<TEntity, bool>> whereExpression)
        {
            return DetailServiceAsync.GetDetailUsingWhereAsync(whereExpression);
        }

        public async Task<ISuccessOrErrors> PostAsync2(TEntity entity)
        {
            return await CreateServiceAsync.CreateAsync(entity);
        }

        public async Task<ISuccessOrErrors> PatchAsync2(TEntity entity)
        {
            return await UpdateServiceAsync.UpdateAsync(entity);
        }


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