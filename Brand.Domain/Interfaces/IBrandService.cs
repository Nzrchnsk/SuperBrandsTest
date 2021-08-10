using System.Collections.Generic;
using System.Threading.Tasks;
using Brand.Domain.Entities.BrandAggregate;

namespace Brand.Domain.Interfaces
{
    public interface IBrandService
    {
        Task<Entities.BrandAggregate.Brand> GetAsync(int id);
        Task<Entities.BrandAggregate.Brand> GetWithSizesAsync(int id);
        Task<Entities.BrandAggregate.Brand> FindAsync(string name);
        Task<Entities.BrandAggregate.Brand> FindWithSizesAsync(string name);
        // TODO: IAsyncEnumerable?
        Task<List<Entities.BrandAggregate.Brand>> GetRangeAsync();
        Task<List<Entities.BrandAggregate.Brand>> GetRangeAsync(int limit, int offset);
        Task<Entities.BrandAggregate.Brand> CreateAsync(Entities.BrandAggregate.Brand brand);
        Task<Entities.BrandAggregate.Brand> AddSizeAsync(Size size, int brandId);
        Task<Entities.BrandAggregate.Brand> AddSizeRangeAsync(IEnumerable<Size> sizes, int brandId);
    }
}