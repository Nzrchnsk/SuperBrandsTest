using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Brand.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Size = Brand.Domain.Entities.BrandAggregate.Size;

namespace Brand.Infrastructure.Data
{
    public class BrandRepositoryAsync : RepositoryAsync<Domain.Entities.BrandAggregate.Brand>, IBrandRepositoryAsync
    {
        public BrandRepositoryAsync(BrandDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<Domain.Entities.BrandAggregate.Brand> GetWithSizesAsync(int id)
        {
            // var query = _dbContext.Set<Domain.Entities.BrandAggregate.Brand>()
            //     .Where(brand => brand.Id == id)
            //     .Select(brand => new Domain.Entities.BrandAggregate.Brand(brand.Id,
            //         brand.Name,
            //         from size in _dbContext.Set<Domain.Entities.BrandAggregate.Size>()
            //         where size.BrandId == brand.Id
            //         select new Domain.Entities.BrandAggregate.Size(size.RusSize, size.BrandSize)));
            // var entity = await query.FirstOrDefaultAsync();
            // return entity;
            //TODO: Refactor this method
            var brand = await _dbContext.Set<Domain.Entities.BrandAggregate.Brand>().FindAsync(id);
            var sizes = await _dbContext.Set<Size>().Where(x => x.BrandId == brand.Id).ToListAsync();
            brand.SetSizes(sizes);
            return brand;
        }

        public async Task<Domain.Entities.BrandAggregate.Brand> FindAsync(string name)
        {
            var brand = await _dbContext.Set<Domain.Entities.BrandAggregate.Brand>().FirstOrDefaultAsync(x => x.Name == name);
            return brand;
        }
        public async Task<Domain.Entities.BrandAggregate.Brand> FindWithSizeAsync(string name)
        {
            //TODO: Refactor this method
            var brand = await _dbContext.Set<Domain.Entities.BrandAggregate.Brand>().FirstOrDefaultAsync(x => x.Name == name);
            var sizes = await _dbContext.Set<Size>().Where(x => x.BrandId == brand.Id).ToListAsync();
            brand.SetSizes(sizes);
            return brand;
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