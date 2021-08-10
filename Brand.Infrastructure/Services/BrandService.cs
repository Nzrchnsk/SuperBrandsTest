using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brand.Domain.Entities.BrandAggregate;
using Brand.Domain.Exception;
using Brand.Domain.Interfaces;
using Brand.Infrastructure.Data;

namespace Brand.Infrastructure.Services
{

    // TODO: Необходимость данного сервиса?
    // Возможно стоит выделить размер как отдельный корень агрегации,
    // тогда для корня агрегации "размер" необходимо создать отдельный репо
    // и в данном сервисе производить объединение коллекции размеров с брэндом.
    public class BrandService : IBrandService
    {

        private readonly IBrandRepositoryAsync _brandRepository;

        public BrandService(IBrandRepositoryAsync brandRepositoryAsync)
        {
            _brandRepository = brandRepositoryAsync;
        }

        public async Task<Domain.Entities.BrandAggregate.Brand> GetAsync(int id)
        {
            var brand = await _brandRepository.GetAsync(id);
            if (brand is null)
            {
                throw new BrandException("Brand not found");
            }
            return brand;
        }

        public async Task<Domain.Entities.BrandAggregate.Brand> GetWithSizesAsync(int id)
        {
            var brand = await _brandRepository.GetWithSizesAsync(id);
            if (brand is null)
            {
                throw new BrandException("Brand not found");
            }
            return brand;
        }

        public async Task<Domain.Entities.BrandAggregate.Brand> FindAsync(string name)
        {
            var brand = await _brandRepository.FindAsync(name);
            if (brand is null)
            {
                throw new BrandException("Brand not found");
            }
            return brand;
        }

        public async Task<Domain.Entities.BrandAggregate.Brand> FindWithSizesAsync(string name)
        {
            var brand = await _brandRepository.FindWithSizeAsync(name);
            if (brand is null)
            {
                throw new BrandException("Brand not found");
            }
            return brand;
        }

        public async Task<List<Domain.Entities.BrandAggregate.Brand>> GetRangeAsync()
        {
            return await _brandRepository.GetRangeAsync();
        }

        public Task<List<Domain.Entities.BrandAggregate.Brand>> GetRangeAsync(int limit, int offset)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Domain.Entities.BrandAggregate.Brand> CreateAsync(Domain.Entities.BrandAggregate.Brand brand)
        {
            await _brandRepository.AddAsync(brand);
            return brand;
        }

        public async Task<Domain.Entities.BrandAggregate.Brand> AddSizeAsync(Size size, int brandId)
        {
            var brand = await _brandRepository.GetWithSizesAsync(brandId);
            if (brand.Sizes.FirstOrDefault(s => s.RusSize == size.RusSize && s.BrandSize == size.BrandSize) != null)
            {
                throw new BrandException("Size pair already exist for this brand");
            }
            brand.Sizes.ToList().Add(size);
            await _brandRepository.AddSizeAsync(brand, size);
            return brand;
        }

        public async Task<Domain.Entities.BrandAggregate.Brand> AddSizeRangeAsync(IEnumerable<Size> sizes, int brandId)
        {
            var brand = await _brandRepository.GetWithSizesAsync(brandId);

            var sizeIntersection = brand.Sizes.Intersect(sizes);
            if (sizeIntersection.Any())
            {
                throw new BrandException("Some size pair already exist for this brand");
            }
            brand.Sizes.ToList().AddRange(sizes);
            await _brandRepository.AddSizeRangeAsync(brand, sizes);
            return brand;
        }
    }
}