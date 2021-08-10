using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Interfaces;

namespace Product.Infrastructure.Data
{
    public class ProductRepositoryAsync : RepositoryAsync<Domain.Entities.Product>, IProductRepositoryAsync
    {
        public ProductRepositoryAsync(ProductDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<Domain.Entities.Product> FindAsync(string name)
        {
            return await _dbContext.Set<Domain.Entities.Product>().FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}