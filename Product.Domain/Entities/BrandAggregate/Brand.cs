using System.Collections.Generic;
using Product.Domain.Interfaces;

namespace Product.Domain.Entities.BrandAggregate
{
    public class Brand : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        
        public IEnumerable<Size> Sizes { get; private set; }

        public Brand()
        {
            
        }
        public Brand(int id, string name, IEnumerable<Size> sizes)
        {
            base.Id = id;
            Name = name;
            Sizes = sizes;
        } 
        public Brand(int id, string name)
        {
            base.Id = id;
            Name = name;
        }
    }
}