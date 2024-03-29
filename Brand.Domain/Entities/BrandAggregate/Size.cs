using System.Collections.Generic;
using Brand.Domain.Entities;

namespace Brand.Domain.Entities.BrandAggregate
{
    public class Size : ValueObject
    {
        public string RusSize { get; private set; }
        public string BrandSize { get; private set; }

        //For EF
        public int BrandId { get; set; }
        public Entities.BrandAggregate.Brand Brand { get; set; }

        public Size()
        {

        }

        public Size(string rusSize, string brandSize)
        {
            RusSize = rusSize;
            BrandSize = brandSize;
        }

        public Size(string rusSize, string brandSize, int brandId)
        {
            RusSize = rusSize;
            BrandSize = brandSize;
            BrandId = brandId;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return RusSize;
            yield return BrandSize;
        }
    }
}