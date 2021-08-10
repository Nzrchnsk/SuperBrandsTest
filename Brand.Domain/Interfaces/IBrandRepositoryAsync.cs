using System.Collections.Generic;
using System.Threading.Tasks;
using Brand.Domain.Entities.BrandAggregate;

namespace Brand.Domain.Interfaces
{
    public interface IBrandRepositoryAsync : IRepositoryAsync<Entities.BrandAggregate.Brand>
    {
        public Task<Entities.BrandAggregate.Brand> GetWithSizesAsync(int id);
        public Task<Entities.BrandAggregate.Brand> AddSizeAsync(Entities.BrandAggregate.Brand brand, Size size);
        public Task<Entities.BrandAggregate.Brand> AddSizeRangeAsync(Entities.BrandAggregate.Brand brand, IEnumerable<Size> sizes);

    }
}