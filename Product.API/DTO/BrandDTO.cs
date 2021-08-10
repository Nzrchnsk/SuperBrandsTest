using System.Collections.Generic;

namespace Product.API.DTO
{
    public class BrandDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SizeDTO> Sizes { get; set; }
    }
}