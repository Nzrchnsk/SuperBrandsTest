using System.Collections.Generic;
using Brand.Domain.Entities;

namespace Product.Domain.Entities.BrandAggregate
{
    public class Size : ValueObject
    {
        public string RusSize { get; private set; }
        public string BrandSize { get; private set; }

        public Size()
        {

        }

        public Size(string rusSize, string brandSize)
        {
            RusSize = rusSize;
            BrandSize = brandSize;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return RusSize;
            yield return BrandSize;
        }
    }
}