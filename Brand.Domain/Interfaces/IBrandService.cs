using System.Collections.Generic;
using Brand.Domain.Entities;

namespace Brand.Domain.Interfaces
{
    public interface IBrandService
    {
        //TODO:Async?
        public Entities.Brand Get(int id);
        public Entities.Brand Create(int id);
        public Entities.Brand AddSize(Size size);
        public Entities.Brand AddSize(IEnumerable<Size> size);
    }
}