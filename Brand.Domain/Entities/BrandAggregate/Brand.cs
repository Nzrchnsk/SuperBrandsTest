using System.Collections;
using System.Collections.Generic;
using Brand.Domain.Interfaces;

namespace Brand.Domain.Entities.BrandAggregate
{
    public class Brand : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        
        public IEnumerable<Size> Sizes { get; private set; }

        private Brand()
        {
            
        }

        public Brand(int id, string name, IEnumerable<Size> sizes)
        {
            base.Id = id;
            Name = name;
            Sizes = sizes;
        }
    }
}