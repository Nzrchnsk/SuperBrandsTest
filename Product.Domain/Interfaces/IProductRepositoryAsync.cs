using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Domain.Interfaces
{
    public interface IProductRepositoryAsync : IRepositoryAsync<Entities.Product>
    {
        Task<Entities.Product> FindAsync(string name);
    }
}