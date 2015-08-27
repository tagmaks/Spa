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
    public interface ISpaRepository<TEntity, TDto, TDtoAsync>
        where TEntity: class, new()
        where TDto : class, new()
        where TDtoAsync : class, new()
    {

        #region Old methods
        bool EntityExists(int key);
        IQueryable<TEntity> GetAll();
        SingleResult<TEntity> Get(Func<TEntity, bool> predicate);
        Task<TEntity> GetAsync(int key);
        Task<int> PostAsync(TEntity entity);
        Task<int> PatchAsync();
        Task<int> PutAsync(TEntity update);
        Task<int> DeleteAsync(TEntity entity);
        #endregion

        IListService<TEntity> ListService { get; set; }
        IDetailServiceAsync<TEntity> DetailServiceAsync { get; set; }
        IDetailService<TEntity> DetailService { get; set; }
        ICreateServiceAsync<TEntity> CreateServiceAsync { get; set; }
        IUpdateServiceAsync<TEntity> UpdateServiceAsync { get; set; }

        IQueryable<TEntity> GetAll2();
        Task<ISuccessOrErrors<TEntity>> GetAsync2(int key);
        ISuccessOrErrors<TEntity> Get2(int key);
        Task<ISuccessOrErrors> PostAsync2(TEntity entity);
        Task<ISuccessOrErrors> PatchAsync2(TEntity entity);

        IQueryable<TDto> GetAllDto();
        Task<ISuccessOrErrors<TDtoAsync>> GetDtoAsync(int key);
        ISuccessOrErrors<TDto> GetDto(int key);
        Task<ISuccessOrErrors> PostDtoAsync(TDtoAsync dto);
        Task<ISuccessOrErrors> PatchDtoAsync(TDtoAsync dto);
    }
}   