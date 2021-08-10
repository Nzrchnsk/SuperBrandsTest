using System.Collections.Generic;

namespace Brand.API.DTO
{
    public class CreateBrandDTO
    {
        public string Name { get; set; }
        public List<SizeDTO> Sizes { get; set; }

    }
}