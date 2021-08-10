using System.Collections.Generic;
using System.Threading.Tasks;
using Brand.Domain.Entities;

namespace Brand.Domain.Interfaces
{
    public interface IRepositoryAsync<TEntity> where TEntity : BaseEntity
    {
        public Task<TEntity> GetAsync(int id);
        
        //TODO: IAsyncEnumerable<TEntity>?
        public Task<List<TEntity>> GetRangeAsync();
        public Task<List<TEntity>> GetRangeAsync(int limit, int offset);
        public Task<TEntity> AddAsync(TEntity entity);
        public Task<TEntity> UpdateAsync(TEntity entity);
        public Task<TEntity> DeleteAsync(TEntity entity);
        public Task<TEntity> DeleteAsync(int id);
    }
}