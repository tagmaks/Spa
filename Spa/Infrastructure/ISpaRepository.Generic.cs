using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using GenericLibsBase;
using GenericServices;
using GenericServices.Core;
using GenericServices.Services;
using GenericServices.ServicesAsync;

namespace Spa.Data.Infrastructure
{
    public interface ISpaRepository<TEntity, TDto, TDtoAsync>
        where TEntity : class, new()
        where TDto : EfGenericDto<TEntity, TDto>, new()
        where TDtoAsync : EfGenericDtoAsync<TEntity, TDtoAsync>, new()
    {

        #region Old methods
        bool EntityExists(int key);
        IQueryable<TEntity> GetAllOld();
        SingleResult<TEntity> GetOld(Func<TEntity, bool> predicate);
        Task<TEntity> GetAsyncOld(int key);
        Task<int> PostAsyncOld(TEntity entity);
        Task<int> PatchAsyncOld();
        Task<int> PutAsyncOld(TEntity update);
        Task<int> DeleteAsyncOld(TEntity entity);
        #endregion

        #region Service fields for property injections with <TEntity> generic
        IListService<TEntity> ListService { get; set; }
        IDetailServiceAsync<TEntity> DetailServiceAsync { get; set; }
        IDetailService<TEntity> DetailService { get; set; }
        ICreateServiceAsync<TEntity> CreateServiceAsync { get; set; }
        IUpdateServiceAsync<TEntity> UpdateServiceAsync { get; set; }
        #endregion

        IDeleteServiceAsync DeleteServiceAsync { get; set; }

        #region Service fields for property injections with <TEntity, TDto> generics
        IListService<TEntity, TDto> ListServiceDto { get; set; }
        IDetailServiceAsync<TEntity, TDtoAsync> DetailServiceDtoAsync { get; set; }
        IDetailService<TEntity, TDto> DetailServiceDto { get; set; }
        ICreateServiceAsync<TEntity, TDtoAsync> CreateServiceDtoAsync { get; set; }
        IUpdateServiceAsync<TEntity, TDtoAsync> UpdateServiceDtosync { get; set; }
        #endregion

        #region CRUD methods with <TEntity> generic
        IQueryable<TEntity> GetAll();
        Task<ISuccessOrErrors<TEntity>> GetAsync(int key);
        ISuccessOrErrors<TEntity> Get(int key);
        Task<ISuccessOrErrors> PostAsync(TEntity entity);
        Task<ISuccessOrErrors> PatchAsync(TEntity entity);
        #endregion

        Task<ISuccessOrErrors> DeleteAsync(int key);

        #region CRUD methods with <TDto, TDtoAsync> generic
        IQueryable<TDto> GetAllDto();
        Task<ISuccessOrErrors<TDtoAsync>> GetDtoAsync(int key);
        ISuccessOrErrors<TDto> GetDto(int key);
        Task<ISuccessOrErrors> PostDtoAsync(TDtoAsync dto);
        Task<ISuccessOrErrors> PatchDtoAsync(TDtoAsync dto);
        #endregion
    }
}