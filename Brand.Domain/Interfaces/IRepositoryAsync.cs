using System.Collections.Generic;
using System.Threading.Tasks;
using Brand.Domain.Entities;

namespace Brand.Domain.Interfaces
{
    public interface IRepositoryAsync<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetAsync(int id);
        
        //TODO: IAsyncEnumerable<TEntity>?
        Task<List<TEntity>> GetRangeAsync();
        Task<List<TEntity>> GetRangeAsync(int limit, int offset);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<TEntity> DeleteAsync(int id);
    }
}