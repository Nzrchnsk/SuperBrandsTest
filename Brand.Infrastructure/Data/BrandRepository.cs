using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Brand.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Size = Brand.Domain.Entities.BrandAggregate.Size;

namespace Brand.Infrastructure.Data
{
    public class BrandRepository : AsyncRepository<Domain.Entities.BrandAggregate.Brand>, IBrandRepository
    {
        public BrandRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Domain.Entities.BrandAggregate.Brand> GetWithSizesAsync(int id)
        {
            var query = from brand in _dbContext.Set<Domain.Entities.BrandAggregate.Brand>()
                where brand.Id == id
                select new Domain.Entities.BrandAggregate.Brand(id: brand.Id,
                    name: brand.Name,
                    sizes:
                    from size in _dbContext.Set<Domain.Entities.BrandAggregate.Size>()
                    where size.BrandId == brand.Id
                    select new Domain.Entities.BrandAggregate.Size(rusSize: size.RusSize, brandSize: size.BrandSize)
                );
            var entity = await query.FirstOrDefaultAsync();
            return entity;
        }

        public async Task<Domain.Entities.BrandAggregate.Brand> AddSizeAsync(Domain.Entities.BrandAggregate.Brand brand, Size size)
        {
            await _dbContext.Set<Size>().AddAsync(size);
            await _dbContext.SaveChangesAsync();
            return brand;
        }

        public async Task<Domain.Entities.BrandAggregate.Brand> AddSizeRangeAsync(Domain.Entities.BrandAggregate.Brand brand, IEnumerable<Size> sizes)
        {
            await _dbContext.Set<Size>().AddRangeAsync(sizes);
            await _dbContext.SaveChangesAsync();
            return brand;
        }
    }
}