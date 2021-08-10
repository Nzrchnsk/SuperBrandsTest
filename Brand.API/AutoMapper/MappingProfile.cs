using AutoMapper;
using Brand.API.DTO;
using Brand.Domain.Entities.BrandAggregate;

namespace Brand.API.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.BrandAggregate.Brand, BrandDTO>();
            CreateMap<Size, SizeDTO>();
            CreateMap<SizeDTO, Size>();
        }
    }
}