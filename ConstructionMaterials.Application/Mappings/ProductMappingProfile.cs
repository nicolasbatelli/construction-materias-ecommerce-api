using AutoMapper;
using ConstructionMaterials.Application.Models;

namespace ConstructionMaterials.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Configure your mappings here
            CreateMap<Product, ProductDto>();
            CreateMap<PagedResult<Product>, PagedResult<ProductDto>>();

        }
    }
}