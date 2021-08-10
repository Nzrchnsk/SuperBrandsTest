using System.Collections.Generic;
using Brand.Domain.Interfaces;

namespace Brand.Domain.Entities.BrandAggregate
{
    // public class Size : BaseEntity, IAggregateRoot
    public class Size : ValueObject
    {
        public string RusSize { get; private set; }
        public string BrandSize { get; private set; }

        //For EF
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        private Size()
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