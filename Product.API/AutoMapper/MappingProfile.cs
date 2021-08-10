using AutoMapper;
using Product.API.DTO;
using Product.Domain.Entities.BrandAggregate;

namespace Product.API.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.BrandAggregate.Brand, BrandDTO>();
            CreateMap<BrandDTO, Domain.Entities.BrandAggregate.Brand>();
            CreateMap<Size, SizeDTO>();
            CreateMap<SizeDTO, Size>();
            CreateMap<Domain.Entities.Product, ProductDTO>();
            CreateMap<ProductDTO, Domain.Entities.Product>();
        }
    }
}