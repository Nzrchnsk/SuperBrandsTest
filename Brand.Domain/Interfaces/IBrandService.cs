using System.Collections.Generic;
using Brand.Domain.Entities.BrandAggregate;

namespace Brand.Domain.Interfaces
{
    public interface IBrandService
    {
        //TODO:Async?
        public Entities.BrandAggregate.Brand Get(int id);
        public Entities.BrandAggregate.Brand GetWithSizes(int id);
        public List<Entities.BrandAggregate.Brand> GetRange();
        public List<Entities.BrandAggregate.Brand> GetRange(int limit, int offset);
        public Entities.BrandAggregate.Brand Create(int id);
        public Entities.BrandAggregate.Brand AddSize(Size size);
        public Entities.BrandAggregate.Brand AddSize(IEnumerable<Size> size);
    }
}