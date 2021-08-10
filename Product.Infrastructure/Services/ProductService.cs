using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product.Domain.Exception;
using Product.Domain.Interfaces;

namespace Product.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IBrandClient _brandClient;
        private readonly IProductRepositoryAsync _productRepository;
        
        public ProductService(IBrandClient brandClient, IProductRepositoryAsync productRepository)
        {
            _brandClient = brandClient;
            _productRepository = productRepository;
        }

        public async Task<Domain.Entities.Product> GetAsync(int id)
        {
            var product = await _productRepository.GetAsync(id);
            if (product is null)
            {
                throw new ProductException("Product not found");
            }
            return product;
        }

        public async Task<Domain.Entities.Product> FindAsync(string name)
        {
            var product = await _productRepository.FindAsync(name);
            if (product is null)
            {
                throw new ProductException("Product not found");
            }
            return product;
        }

        public async Task<IEnumerable<Domain.Entities.Product>> GetRangeAsync()
        {
            return await _productRepository.GetRangeAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Product>> GetRangeAsync(int limit, int offset)
        {
            return await _productRepository.GetRangeAsync(limit: limit, offset: offset);

        }

        public async Task<Domain.Entities.Product> CreateAsync(Domain.Entities.Product product)
        {
            var brand = await _brandClient.GetBrand(product.BrandName);
            var size = brand.Sizes.FirstOrDefault(x => x.RusSize == product.RusSize);
            if (size is null)
            {
                throw new ProductException("The product can't be created because the brand doesn't have that size");
            }
            product.SetBrandId(brand.Id);
            return await _productRepository.AddAsync(product);
        }
    }
}