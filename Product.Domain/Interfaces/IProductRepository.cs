using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Domain.Interfaces
{
    public interface IProductRepositoryAsync : IAsyncRepository<Entities.Product>
    {
        // public Task<Entities.Product> Get(int id);
        // public Task<List<Entities.Product>> GetRangeAsync();
        // public Task<List<Entities.Product>> GetRangeAsync(int limit, int offset);
        // public Task<Entities.Product> AddAsync(Entities.Product product);
        // public Task<Entities.Product> UpdateAsync(Entities.Product product);
        // public Task<Entities.Product> DeleteAsync(Entities.Product product);
        // public Task<Entities.Product> DeleteAsync(int id);
    }
}