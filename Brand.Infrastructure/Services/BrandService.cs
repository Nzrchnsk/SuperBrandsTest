using System.Collections.Generic;
using Brand.Domain.Entities.BrandAggregate;
using Brand.Domain.Interfaces;

namespace Brand.Infrastructure.Services
{
    public class BrandService: IBrandService
    {

        private IBrandRepository _brandRepository;
        
        public BrandService()
        {
            
        }
        
        public Domain.Entities.BrandAggregate.Brand Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Domain.Entities.BrandAggregate.Brand GetWithSizes(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Domain.Entities.BrandAggregate.Brand> GetRange()
        {
            throw new System.NotImplementedException();
        }

        public List<Domain.Entities.BrandAggregate.Brand> GetRange(int limit, int offset)
        {
            throw new System.NotImplementedException();
        }

        public Domain.Entities.BrandAggregate.Brand Create(int id)
        {
            throw new System.NotImplementedException();
        }

        public Domain.Entities.BrandAggregate.Brand AddSize(Size size)
        {
            throw new System.NotImplementedException();
        }

        public Domain.Entities.BrandAggregate.Brand AddSize(IEnumerable<Size> size)
        {
            throw new System.NotImplementedException();
        }
    }
}