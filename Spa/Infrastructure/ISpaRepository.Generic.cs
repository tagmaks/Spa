using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using GenericLibsBase;
using GenericServices;
using GenericServices.Services;
using GenericServices.ServicesAsync;

namespace Spa.Data.Infrastructure
{
    public interface ISpaRepository<TEntity, TDto> where TEntity: class, new()
    {


        bool EntityExists(int key);
        IQueryable<TEntity> GetAll();
        SingleResult<TEntity> Get(Func<TEntity, bool> predicate);
        Task<TEntity> GetAsync(int key);
        Task<int> PostAsync(TEntity entity);
        Task<int> PatchAsync();
        Task<int> PutAsync(TEntity update);
        Task<int> DeleteAsync(TEntity entity);


        IListService<TEntity> ListService { get; set; }
        IDetailServiceAsync<TEntity> DetailServiceAsync { get; set; }
        IDetailService<TEntity> DetailService { get; set; }
        ICreateServiceAsync<TEntity> CreateServiceAsync { get; set; }
        IUpdateServiceAsync<TEntity> UpdateServiceAsync { get; set; }
        IUpdateService<TEntity> UpdateService { get; set; }

        IQueryable<TEntity> GetAll2();
        Task<ISuccessOrErrors<TEntity>> GetAsync2(int key);
        ISuccessOrErrors<TEntity> Get2(int key);
        Task<ISuccessOrErrors> PostAsync2(TEntity entity);
        Task<ISuccessOrErrors> PatchAsync2(TEntity entity);

    }
}   