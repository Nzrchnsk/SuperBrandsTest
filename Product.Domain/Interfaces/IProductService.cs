using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Domain.Interfaces
{
    public interface IProductService
    {
        Task<Product.Domain.Entities.Product> GetAsync(int id);

        Task<Product.Domain.Entities.Product> FindAsync(string name);

        //TODO:IAsyncEnumerable?
        Task<IEnumerable<Product.Domain.Entities.Product>> GetRangeAsync();
        Task<IEnumerable<Product.Domain.Entities.Product>> GetRangeAsync(int limit, int offset);
        Task<Product.Domain.Entities.Product> CreateAsync(Product.Domain.Entities.Product product);
    }
}