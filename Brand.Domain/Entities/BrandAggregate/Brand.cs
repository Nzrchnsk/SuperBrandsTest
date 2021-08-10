#nullable enable
using System.Collections;
using System.Collections.Generic;
using Brand.Domain.Entities;
using Brand.Domain.Entities.BrandAggregate;
using Brand.Domain.Interfaces;

namespace Brand.Domain.Entities.BrandAggregate
{
    public class Brand : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        
        public IEnumerable<Size>? Sizes { get; private set; }

        //TODO:Remove this!
        public void SetSizes(IEnumerable<Size> sizes)
        {
            Sizes = sizes;
        }
        
        public Brand()
        {
            
        }

        public Brand(int id, string name, IEnumerable<Size>? sizes)
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