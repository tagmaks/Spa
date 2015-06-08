using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Spa.Data.Infrastructure
{
    public interface ISpaRepository<TEntity> where TEntity: class
    {
        #region Customer CRUDs
        bool EntityExists(int key);
        IQueryable<TEntity> GetAll();
        SingleResult<TEntity> Get(Func<TEntity, bool> predicate);
        Task<TEntity> GetAsync(int key);
        Task<int> PostAsync(TEntity entity);
        Task<int> PatchAsync();
        Task<int> PutAsync(TEntity update);
        Task<int> DeleteAsync(TEntity entity);

        #endregion
    }
}   