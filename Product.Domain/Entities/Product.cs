using Product.Domain.Interfaces;

namespace Product.Domain.Entities
{
    public class Product : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }

        public int BrandId { get; private set; }
        
        public string BrandName { get; private set; }

        public string RusSize { get; private set; }

        private Product()
        {
            
        }
        
        public Product(int id, string name, int brandId, string brandName, string rusSize)
        {
            base.Id = id;
            Name = name;
            BrandId = brandId;
            BrandName = brandName;
            RusSize = rusSize;
        }
    }
}