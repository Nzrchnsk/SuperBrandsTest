using System.Collections.Generic;
using System.Threading.Tasks;
using Product.Domain.Entities;

namespace Product.Domain.Interfaces
{
    public interface IAsyncRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<TEntity> Get(int id);
        public Task<List<TEntity>> GetRangeAsync();
        public Task<List<TEntity>> GetRangeAsync(int limit, int offset);
        public Task<TEntity> AddAsync(TEntity entity);
        public Task<TEntity> UpdateAsync(TEntity entity);
        public Task<TEntity> DeleteAsync(TEntity entity);
        public Task<TEntity> DeleteAsync(int id);
    }
}