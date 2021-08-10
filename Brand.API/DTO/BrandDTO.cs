using System.Collections;
using System.Collections.Generic;

namespace Brand.API.DTO
{
    public class BrandDTO
    {
        public BrandDTO()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<SizeDTO> Sizes { get; set; }
    }
}