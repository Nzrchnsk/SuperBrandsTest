using System.Collections.Generic;
using System.Threading.Tasks;
using Brand.Domain.Entities.BrandAggregate;

namespace Brand.Domain.Interfaces
{
    public interface IBrandService
    {
        public Task<Entities.BrandAggregate.Brand> GetAsync(int id);
        public Task<Entities.BrandAggregate.Brand> GetWithSizesAsync(int id);
        // TODO: IAsyncEnumerable?
        public Task<List<Entities.BrandAggregate.Brand>> GetRangeAsync();
        public Task<List<Entities.BrandAggregate.Brand>> GetRangeAsync(int limit, int offset);
        public Task<Entities.BrandAggregate.Brand> CreateAsync(Entities.BrandAggregate.Brand brand);
        public Task<Entities.BrandAggregate.Brand> AddSizeAsync(Size size, int brandId);
        public Task<Entities.BrandAggregate.Brand> AddSizeRangeAsync(IEnumerable<Size> sizes, int brandId);
    }
}